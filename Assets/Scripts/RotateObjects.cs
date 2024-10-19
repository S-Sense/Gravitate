using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    public Transform rotatePoint; // Assign the rotatepoint in the Unity editor
    public float rotationDuration = 0.25f; // Quarter of a second
    public float cooldownTime = 1.0f; // Cooldown time in seconds

    private List<Transform> rotatableObjects = new List<Transform>(); // List of rotatable objects
    private bool isRotating = false; // To prevent multiple rotations at the same time
    private float lastRotationTime; // Time of the last rotation

    void Update()
    {
        if (!isRotating && Time.time >= lastRotationTime + cooldownTime) // Check cooldown
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                StartCoroutine(RotateAroundPoint(-90)); // Rotate 90 degrees anti-clockwise
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                StartCoroutine(RotateAroundPoint(90)); // Rotate 90 degrees clockwise
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                StartCoroutine(RotateAroundPoint(180)); // Rotate 180 degrees
            }
        }
    }

    // Coroutine to smoothly rotate the rotatePoint and all attached objects
    IEnumerator RotateAroundPoint(float angle)
    {
        isRotating = true;
        lastRotationTime = Time.time; // Record the time of the last rotation

        // Find all objects with the "rotatable" tag and make them children of the rotatePoint
        rotatableObjects.Clear();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("rotatable");
        foreach (GameObject obj in objects)
        {
            rotatableObjects.Add(obj.transform);
            obj.transform.SetParent(rotatePoint);
        }

        // Perform smooth rotation
        Quaternion startRotation = rotatePoint.rotation;
        Quaternion endRotation = rotatePoint.rotation * Quaternion.Euler(0, 0, angle);
        float elapsedTime = 0;

        while (elapsedTime < rotationDuration)
        {
            rotatePoint.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rotatePoint.rotation = endRotation; // Ensure final rotation is exact

        // Unparent all rotatable objects from the rotatePoint
        foreach (Transform obj in rotatableObjects)
        {
            obj.SetParent(null);
        }

        isRotating = false; // Allow for a new rotation
    }
}