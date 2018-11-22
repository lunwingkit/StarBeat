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

    // Use this for initialization
    void Start () {
        instance = this;
        audioData = GetComponent<AudioSource>();

        clip = (AudioClip)Resources.Load(SongPlateManager.instance.selectedSong.audioDataPath);
        //AudioClip clip = (AudioClip)Resources.Load("002");
        this.setAudioClip(clip);

        
    }

    // Update is called once per frame
    void Update()
    {
        
        // && Time.time >= time
        if (!isPaused && !audioData.isPlaying && Time.timeSinceLevelLoad >= 3) 
        {
            audioData.Play(0);
        }

        //print("TIME:" + audioData.time);
        //print(clip.length);

        //endTime = clip.length;

        print("Time:" + Time.time + "AudioTime:" + audioData.time);

        int count = 0;
        if(audioData.time == 0)
        {
            count++;
            //print("reach start/end");
        }

        if(count >= 2)
        {
            print("end");
        }


    }

    public void setAudioClip(AudioClip clip)
    {
        this.audioData.clip = clip;
    }
}
