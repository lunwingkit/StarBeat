using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlate : MonoBehaviour {
    public GameObject songPlate;
    //public AudioSource audioData;
    
    public Song song;


    public void start()
    {
        songPlate = this.gameObject;
        //audioData = songPlate.GetComponent<AudioSource>();
        
        //audioClip = (AudioClip)Resources.Load("002");
    }
    public void onClick()
    {

        //        audioData.Play(0);

        //his.transform.localPosition = new Vector3(0f, 0f, 0f);
        SongPlateManager.instance.select(this.gameObject);
    }
}
