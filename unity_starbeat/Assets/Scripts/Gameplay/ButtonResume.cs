using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResume : MonoBehaviour {
    public GameObject panel;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		
	}

    public void onClick()
    {
        Time.timeScale = 1f;
        Audio.isPaused = false;
        audioSource.UnPause();
        panel.SetActive(false);
    }
}
