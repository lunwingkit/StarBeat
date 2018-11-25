using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using UnityEngine.UI;

public class GameplayInputHandler : MonoBehaviour {
    public static GameplayInputHandler instance;
    public static ControllerListener listener;
    public static Controller controller;

    //public GameObject drumstick;

    public GameObject textTool;

    public GameObject pointer;

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);

        listener = new ControllerListener();
        controller = new Controller();
        controller.AddListener(listener);

        print("GameplayInputHandler Start");

	}
	
	// Update is called once per frame
	void Update () {
       // textTool.GetComponent<Text>().text = "Tool x:" + listener.toolpoX + " y:" + listener.toolpoY;
       // pointer.transform.position = new Vector2(listener.toolpoX * 2 + UnityEngine.Screen.width / 2, listener.toolpoY * 2 - UnityEngine.Screen.height / 4);
    }

    private void OnDestroy()
    {
        controller.RemoveListener(listener);
        controller.Dispose();
    }
}
