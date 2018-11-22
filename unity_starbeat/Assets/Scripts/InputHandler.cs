using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class InputHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        keyBoardInput();
        touchScreenInput();
        leapMotionInput();
        voiceInput();
	}

    void keyBoardInput()
    {

    }

    void touchScreenInput()
    {
        if(Input.touchCount >= 1)
        {
            //Define 5 Area
            print("Touching");
        }
    }

    void leapMotionInput()
    {
        Controller controller = new Controller();
        ControllerListener listener = new ControllerListener();
        controller.Connect += listener.OnServiceConnect;
        controller.Device += listener.OnConnect;
        controller.FrameReady += listener.OnFrame;

        
        //controller.RemoveListener(listener);
        //controller.Dispose();

    }

    class ControllerListener
    {
        public void OnServiceConnect(object sender, ConnectionEventArgs args)
        {
            print("Service Connected");
        }

        public void OnConnect(object sender, DeviceEventArgs args)
        {
            print("Connected");
        }

        public void OnFrame(object sender, FrameEventArgs args)
        {
            print("Frame Available");

            Frame frame = args.frame;


            foreach(Hand hand in frame.Hands)
            {
                print("ID:" + hand.Id.ToString() + "PalmPos:" + hand.PalmPosition + "Finger:" +  hand.Fingers.Count);
            }
            
        }
    }

    void voiceInput()
    {

    }

}
