using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumInvoker : MonoBehaviour {
    public GameObject drum;
    public int selector;
    public Material beforeHitMaterial; //add ar
    public Material afterHitMaterial; // add ar
    Renderer rend;
	
	// Use this for initialization
	void Start () {
        drum = this.gameObject;
        selector = int.Parse(drum.name.Replace("Drum", ""));
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = beforeHitMaterial;
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(selector.ToString()))
        {
            rend.sharedMaterial = afterHitMaterial;
            AudioSoundEffect.instance.OnPress(selector);
            GameObject.Find("NodeLine" + selector + "/TapPosition").GetComponent<CheckTiming>().invokeJudgment();
        }
	else if (Input.GetKeyUp(selector.ToString()))
	{
            rend.sharedMaterial = beforeHitMaterial;
	}
	}

    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.name == "Drumstick(Clone)" || collision.gameObject.name == "RigidRoundHand(Clone)")
        {
            print(selector.ToString() + " just hit");
            rend.sharedMaterial = afterHitMaterial;
            AudioSoundEffect.instance.OnPress(selector);
            GameObject.Find("NodeLine" + selector + "/TapPosition").GetComponent<CheckTiming>().invokeJudgment();
        }
    }
	
    void OnCollisionExit(Collision collision)
    {
        rend.sharedMaterial = beforeHitMaterial;
    }

    void OnMouseDown()
    {
        rend.sharedMaterial = afterHitMaterial;
        AudioSoundEffect.instance.OnPress(selector);
        GameObject.Find("NodeLine" + selector + "/TapPosition").GetComponent<CheckTiming>().invokeJudgment();
    }
	
    void OnMouseUp()
    {
        rend.sharedMaterial = beforeHitMaterial;
    }
}
