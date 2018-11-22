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
        //V3



        //V2
        ControllerListener listener = new ControllerListener();
        Controller controller = new Controller();
        controller.AddListener(listener);
        print("Start LM");
        controller.RemoveListener(listener);
        controller.Dispose();
    }

    public class ControllerListener : Listener
    {

        private Object thisLock = new Object();

        private void SafeWriteLine(string line)
        {
            lock (thisLock)
            {
                print(line);
            }
        }

        public override void OnConnect(Controller controller)
        {
            print("Connected");
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        public override void OnFrame(Controller controller)
        {
            print("Frame available");

            Frame frame = controller.Frame();

            SafeWriteLine(frame.Id.ToString() + frame.Timestamp + frame.Hands.Count + frame.Fingers.Count + frame.Tools.Count +
                frame.Gestures().Count);
        }
    }


    

    void voiceInput()
    {

    }
}


//For Leap Motion v3
/*
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
            
            foreach(Tool )
        }
    }
    */


/*
Controller controller = new Controller();

ControllerListener listener = new ControllerListener();
controller.Connect += listener.OnServiceConnect;
controller.Device += listener.OnConnect;
controller.FrameReady += listener.OnFrame;
*/


//controller.RemoveListener(listener);
//controller.Dispose();
//For Leap Motion v2