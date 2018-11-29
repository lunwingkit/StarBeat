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
        clips[0] = (AudioClip)Resources.Load("drum1");
        clips[1] = (AudioClip)Resources.Load("drum2");
        clips[2] = (AudioClip)Resources.Load("drum3");
        clips[3] = (AudioClip)Resources.Load("drum4");
        clips[4] = (AudioClip)Resources.Load("drum1");
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
