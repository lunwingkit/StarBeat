using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSoundEffect : MonoBehaviour {
    public static Audio instance;
    public AudioSource audioSource;
    
    public AudioClip[] clips;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        clips = new AudioClip[5];
        clips[0] = (AudioClip)Resources.Load("pos0");
        clips[1] = (AudioClip)Resources.Load("pos1");
        clips[2] = (AudioClip)Resources.Load("pos2");
        clips[3] = (AudioClip)Resources.Load("pos3");
        clips[4] = (AudioClip)Resources.Load("pos4");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void onPress(int position)
    {
        audioSource.clip = clips[position];
        audioSource.Play();
    }
}
