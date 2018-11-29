using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumInvoker : MonoBehaviour {
    public GameObject drum;
    public int selector;
    public Material beforeHitMaterial;
    public Material afterHitMaterial;
    Renderer rend;
	
	// Use this for initialization
	void Start () {
        drum = this.gameObject;
        selector = int.Parse(drum.name.Replace("Drum", ""));
        rend = GentComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = beforeHitMaterial;
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(selector.ToString()))
        {
            rend.sharedMaterial = afterHitMaterial;
            AudioSoundEffect.instance.onPress(int.Parse(selector));
            invokeJudgment();
        }
	else if (Input.GetKeyDown(selector.ToString()))
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
            AudioSoundEffect.instance.onPress(selector);
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
        AudioSoundEffect.instance.onPress(selector);
        GameObject.Find("NodeLine" + selector + "/TapPosition").GetComponent<CheckTiming>().invokeJudgment();
    }
	
    void OnMouseDown()
    {
        rend.sharedMaterial = beforeHitMaterial;
    }
}
