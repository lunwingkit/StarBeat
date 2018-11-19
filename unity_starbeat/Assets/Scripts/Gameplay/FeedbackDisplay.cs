using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackDisplay : MonoBehaviour {

    private int count = 0;

    public TextMesh comboDisplay;

    public void Awake()
    {
        comboDisplay.text = "";
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addFeedback(int keyValue)
    {
        switch (keyValue)
        {
            case 0:
            case 1:
            case 2:
                count++;
                comboDisplay.text = "Combo " + count;
                comboDisplay.gameObject.SetActive(true);
                break;
            case 3:
            default:
                count = 0;
                comboDisplay.text = "Combo " + count;
                comboDisplay.gameObject.SetActive(true);
                break;
        }
    }
}
