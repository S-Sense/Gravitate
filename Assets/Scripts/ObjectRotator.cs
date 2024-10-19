using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    // Rotation angle for 90 and 180 degrees
    private float rotationAngle = 90f;
    // Duration for rotation movement
    private float rotationDuration = 0.5f;

    void Update()
    {
        // Check input for the arrow keys
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Start rotating all objects clockwise around the player's position by 90 degrees
            StartCoroutine(RotateObjectsOverTime(-rotationAngle));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Start rotating all objects anticlockwise around the player's position by 90 degrees
            StartCoroutine(RotateObjectsOverTime(rotationAngle));
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Start rotating all objects either 180 degrees clockwise or anticlockwise
            StartCoroutine(RotateObjectsOverTime(180f));  // You can choose the sign of the angle if you prefer one direction
        }
    }

    // Coroutine to rotate objects over time
    IEnumerator RotateObjectsOverTime(float angle)
    {
        // Store the position of the player at the time of key press
        Vector3 rotationCenter = transform.position;

        // Find all objects tagged "rotatable"
        GameObject[] objectsToRotate = GameObject.FindGameObjectsWithTag("rotatable");

        // Store the original positions and calculate the target positions
        Vector3[] originalPositions = new Vector3[objectsToRotate.Length];
        Vector3[] targetPositions = new Vector3[objectsToRotate.Length];

        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            GameObject obj = objectsToRotate[i];
            originalPositions[i] = obj.transform.position;

            // Calculate the direction from the rotation center to the object
            Vector3 direction = obj.transform.position - rotationCenter;

            // Calculate the new direction after rotating by the specified angle
            Vector3 newDirection = Quaternion.Euler(0, 0, angle) * direction;

            // Calculate the target position
            targetPositions[i] = rotationCenter + newDirection;
        }

        // Animate the objects' positions over the duration
        float elapsedTime = 0f;
        while (elapsedTime < rotationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / rotationDuration);

            // Lerp each object to its target position
            for (int i = 0; i < objectsToRotate.Length; i++)
            {
                objectsToRotate[i].transform.position = Vector3.Lerp(originalPositions[i], targetPositions[i], t);
            }

            // Wait until the next frame
            yield return null;
        }

        // Ensure all objects are exactly at their target positions at the end
        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            objectsToRotate[i].transform.position = targetPositions[i];
        }
    }
}