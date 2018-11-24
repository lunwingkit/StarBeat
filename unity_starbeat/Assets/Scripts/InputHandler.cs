using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;
    ControllerListener listener;
    Controller controller;
    public GameObject image;


    public static float pox;
    public static float poy;

    public Text textPointer;
    public Text textTarget;
    public GameObject canvas;

    // Use this for initialization
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        //V3

        Controller controller = new Controller();

        ControllerListener listener = new ControllerListener();

        controller.Connect += listener.OnServiceConnect;
        controller.Device += listener.OnConnect;
        controller.FrameReady += listener.OnFrame;
        image = GameObject.Find("Pointer");


        pox = 0;
        poy = 0;
        //V2

        print("InputHandler Start");
        textPointer = GameObject.Find("TextPointer").GetComponent<Text>();
        textTarget = GameObject.Find("TextTarget").GetComponent<Text>();
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.touchCount >= 1)
        {
            //Define 5 Area
            print("Touching");


            image.transform.position = Input.touches[0].position;
        }
    }

    void leapMotionInput()
    {

        //controller.RemoveListener(listener);
        //controller.Dispose();
    }

    public bool isOnPress()
    {
        return true;
        //return instance.listener.getIsPressed();
    }

    class ControllerListener
    {
        bool isPressed = false;

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

            Frame frame = args.frame;


            foreach (Hand hand in frame.Hands)
            {
                //print("ID:" + hand.Id.ToString() + "PalmPos:" + hand.PalmPosition + "Finger:" + hand.Fingers.Count);

                foreach (Finger finger in hand.Fingers)
                {
                    //print(finger.TipPosition + finger.Type.ToString());


                    if (finger.Type == Finger.FingerType.TYPE_INDEX)
                    {
                        
                        InputHandler.instance.image.transform.position = new Vector2(finger.TipPosition.x * 2 + Screen.width / 2 , finger.TipPosition.y * 2 - Screen.height / 5);
                        InputHandler.instance.textPointer.text = "x:" + finger.TipPosition.x + " y:" + finger.TipPosition.y
                            + " screen w:" + Screen.width + " screen h:" + Screen.height
                            + " pointer x:" + InputHandler.instance.image.transform.position.x + " pointer y:" + InputHandler.instance.image.transform.position.y;

                        //print("pointer: " + InputHandler.instance.image.transform.position);
                        if (finger.TipPosition.z < -50)
                        {
                            print("press");
                            isPressed = true;
                        }
                        else
                            isPressed = false;
                    }

                }



            }
            //foreach (Tool )
        }

        public bool getIsPressed()
        {
            return isPressed;
        }
    }


    void voiceInput()
    {

    }
}
