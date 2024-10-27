using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        // Detect left mouse click (or any mouse button if you prefer)
        if (Input.GetMouseButtonDown(0))
        {
            LoadSceneZero();
        }
    }

    void LoadSceneZero()
    {
        // Load the scene with index 0
        SceneManager.LoadScene(0);
        Debug.Log("Loading scene with index 0");
    }
}
