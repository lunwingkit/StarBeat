using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour {
    public static Audio instance;
    public AudioSource audioData;
    public float time;
    public static bool isPaused = false;
    AudioClip clip;

    public const int preLatency = 3;
    public const int postLatency = 2;

    public float length;

    // Use this for initialization
    void Start () {
        instance = this;
        audioData = GetComponent<AudioSource>();

        if (SongPlateManager.selectedSong != null)
            clip = (AudioClip)Resources.Load(SongPlateManager.selectedSong.audioDataPath);
        else
            clip = (AudioClip)Resources.Load("summer_fest");
        this.setAudioClip(clip);

        length = clip.length;

        Invoke("LoadResultReview", preLatency + clip.length + postLatency);
    }

    internal void onPress(int selector)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
        // && Time.time >= time
        if (!isPaused && !audioData.isPlaying && Time.timeSinceLevelLoad >= preLatency) 
        {
            audioData.Play(0);
        }

        //print("TIME:" + audioData.time);
        //print(clip.length);

        //endTime = clip.length;

        //print("Time:" + Time.time + "AudioTime:" + audioData.time);
    }

    public void setAudioClip(AudioClip clip)
    {
        this.audioData.clip = clip;
    }

    void LoadResultReview()
    {
        SceneManager.LoadScene("ResultReview");
    }
}
