using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour
{
    private bool gamePaused = false;

    // When the player enters the trigger at the finish line
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider belongs to the player
        {
            // Pause the game
            Time.timeScale = 0;
            gamePaused = true;
            Debug.Log("Finish Line Reached! Press any key to proceed.");
        }
    }

    private void Update()
    {
        // If the game is paused and the player presses any input, unpause and load the next scene
        if (gamePaused && Input.anyKeyDown)
        {
            // Unpause the game
            Time.timeScale = 1;
            gamePaused = false;

            // Load the next scene by getting the next scene index
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("No more scenes to load.");
            }
        }
    }
}
