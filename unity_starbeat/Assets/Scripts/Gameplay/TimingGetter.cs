using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingGetter : MonoBehaviour {
    private GameObject nodeParent;
    const string nodeName = "Node(Clone)";
    public CheckTiming checkTiming;

    // Use this for initialization
    void Start () {
        nodeParent = gameObject.transform.parent.gameObject;
        checkTiming = GameObject.Find(nodeParent.name + "/TapPosition").GetComponent<CheckTiming>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == nodeName)
        {
            checkTiming.addNode(this.gameObject.name, other.gameObject);
            print(this.gameObject.name + "enter");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == nodeName)
        {
            checkTiming.removeNode(this.gameObject.name, other.gameObject);
            print(this.gameObject.name + "exit");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
