using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingAudio : MonoBehaviour {
    public Slider generalVolume;
    public Slider songVolume;
    public Slider soundEffectVolume;

    AudioListener audioListener;
    AudioSource song;
    AudioSource soundEffect;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeGeneralVolume(float value)
    {
        //audioListener.volu
    }

    void changeSongVolume(float value)
    {

    }

    void changeSoundEffectVolume(float value)
    {

    }

}
