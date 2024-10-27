using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TMP_Text timerText;  // Reference to the Text component
    private float timeElapsed = 0f;
    private bool isTimerRunning = false;
    private bool hasStarted = false;  // To check if the timer has already started

    void Update()
    {
        // Check if the timer should be running
        if (isTimerRunning)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerDisplay();
        }

        // Start the timer on any key press, but only once
        if (!hasStarted && Input.anyKeyDown)
        {
            StartTimer();
        }
    }

    void StartTimer()
    {
        isTimerRunning = true;
        hasStarted = true;  // Ensure the timer only starts once
        timeElapsed = 0f;   // Reset timer to 0 when started
    }

    void UpdateTimerDisplay()
    {
        // Format time as minutes:seconds:milliseconds and update text
        int minutes = Mathf.FloorToInt(timeElapsed / 60F);
        int seconds = Mathf.FloorToInt(timeElapsed % 60F);
        int milliseconds = Mathf.FloorToInt((timeElapsed * 1000F) % 1000F);  // Calculate milliseconds

        // Update the text with minutes, seconds, and milliseconds
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
