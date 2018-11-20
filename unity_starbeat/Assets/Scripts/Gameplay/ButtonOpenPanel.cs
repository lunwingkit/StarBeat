using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenPanel : MonoBehaviour {
    public GameObject panel;
    public AudioSource audioSource;
    public void start()
    {
    }

    public void onClick()
    {
        Audio.isPaused = true;
        audioSource.Pause();
        Time.timeScale = 0;
        panel.SetActive(true);
    }
}
