using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {
    AudioSource audioData;
    public float time;
    public static bool isPaused = false;

    // Use this for initialization
    void Start () {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isPaused && !audioData.isPlaying && Time.time >= time)
        {
            audioData.Play(0);
        }
    }
}
