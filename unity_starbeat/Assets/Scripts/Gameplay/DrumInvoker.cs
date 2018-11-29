using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumInvoker : MonoBehaviour {
    public GameObject drum;
    public int selector;
	// Use this for initialization
	void Start () {
        drum = this.gameObject;
        selector = int.Parse(drum.name.Replace("Drum", ""));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.name == "Drumstick(Clone)" || collision.gameObject.name == "RigidRoundHand(Clone)")
        {
            print(selector.ToString() + " just hit");
            AudioSoundEffect.instance.onPress(selector);
            GameObject.Find("NodeLine" + selector + "/TapPosition").GetComponent<CheckTiming>().invokeJudgment();
        }
    }

    void OnMouseDown()
    {
        AudioSoundEffect.instance.onPress(selector);
        GameObject.Find("NodeLine" + selector + "/TapPosition").GetComponent<CheckTiming>().invokeJudgment();
    }
}
