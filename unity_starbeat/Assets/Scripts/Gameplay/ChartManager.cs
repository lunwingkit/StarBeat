using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartManager : MonoBehaviour {
    public List<NodeCreator> nodeCreators;
    public string fileName;

    // Use this for initialization
    void Awake () {
        for (int i = 1; i <= 5; i++)
        {
            nodeCreators.Add(GameObject.Find("NodeLine" + i + "/NodeCreator").GetComponent<NodeCreator>());
        }
        
        foreach(NodeCreator creator in nodeCreators)
        {
            creator.fileName = fileName;
        }
        print("Manager Done");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
