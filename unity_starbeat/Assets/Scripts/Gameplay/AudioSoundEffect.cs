using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSoundEffect : MonoBehaviour {
    public static AudioSoundEffect instance;
    public AudioSource audioSource;
    
    public AudioClip[] clips;
	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);

        audioSource = GetComponent<AudioSource>();
        clips = new AudioClip[5];
        clips[0] = (AudioClip)Resources.Load("drum01"); //Add ar
        clips[1] = (AudioClip)Resources.Load("drum02"); //Add ar
        clips[2] = (AudioClip)Resources.Load("drum02"); //Add ar
        clips[3] = (AudioClip)Resources.Load("drum02"); //Add ar
        clips[4] = (AudioClip)Resources.Load("drum05"); //Add ar
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPress(int position)
    {
        audioSource.clip = clips[position - 1];
        audioSource.Play();
    }
}
