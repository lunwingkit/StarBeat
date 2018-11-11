﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCreator : MonoBehaviour {
    private CSVReader csvReader = new CSVReader();
    private float time;
    public GameObject Node;
    private GameObject nodeParent;
    private GameObject destination;
    private int line = 0;
    public int selector = 0;
    private List<List<string>> MAP = new List<List<string>>();

    private void Awake()
    {

        nodeParent = gameObject.transform.parent.gameObject;
        destination = GameObject.Find(nodeParent.name + "/DestroyPosition");
        selector = int.Parse(nodeParent.name.Replace("NodeLine", ""));
        MAP = csvReader.readCSV(@"text");
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        try
        {
            if (time >= float.Parse(MAP[line][0]))
            {
                if (int.Parse(MAP[line][selector]) == 1)
                {
                    NodeCreate();
                }
                line++;
            }
        }
        catch (System.ArgumentOutOfRangeException e) { }
	}

    private void NodeCreate()
    {
        var node = (GameObject)Instantiate(Node, nodeParent.transform);
        node.GetComponent<NodeMove>().destinationPosition = destination;
        node.transform.localPosition = this.transform.localPosition;
        node.transform.localRotation = this.transform.localRotation;
        node.transform.localScale = this.transform.localScale;
    }
}
