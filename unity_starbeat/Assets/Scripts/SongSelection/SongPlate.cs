using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlate : MonoBehaviour {
    public GameObject songPlate;
    public AudioSource audioData;

    public void start()
    {
        audioData = songPlate.GetComponent<AudioSource>();
    }
    public void onClick()
    {
        audioData.Play(0);
        
        //his.transform.localPosition = new Vector3(0f, 0f, 0f);
    }
}
