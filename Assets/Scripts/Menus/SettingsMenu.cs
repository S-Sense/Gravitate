using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{




    public Text valueText;

    public AudioMixer audioMixer;




    public void OnSliderChanged(float value)
    {
        valueText.text = value.ToString();
    }



    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume - 80f);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }



}


