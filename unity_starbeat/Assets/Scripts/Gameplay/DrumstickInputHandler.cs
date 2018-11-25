using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumstickInputHandler : MonoBehaviour {
    public GameObject drumMid;
    public GameObject drumLeftTop;
    public GameObject drumLeftBtm;
    public GameObject drumRightTop;
    public GameObject drumRightBtm;

	// Use this for initialization
	void Start () {
        drumMid = GameObject.Find("DrumMid");
        drumLeftBtm = GameObject.Find("DrumLeftBtm");
        drumLeftTop = GameObject.Find("DrumLeftTop");
        drumRightBtm = GameObject.Find("DrumRightBtm");
        drumRightTop = GameObject.Find("DrumRightTop");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "DrumMid":

                break;
            case "DrumLeftBtm":
                break;
            case "DrumLeftTop":
                break;
            case "DrumRightBtm":
                break;
            case "DrumRightTop":
                break;
        }
    }
}
