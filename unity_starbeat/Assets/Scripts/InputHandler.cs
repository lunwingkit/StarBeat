using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;
    public static ControllerListener listener;
    public static Controller controller;
    public GameObject image;

    public static float pox;
    public static float poy;

    public Text textPointer;
    public Text textTarget;


    public float indexFingerX;
    public float indexFingerY;

    public bool isSwiping;
    public bool isCircling;
    public bool isKeyTapping;
    public bool isScreenTapping;

    public float swipeVectorX;
    public bool swipeLeftward;
    public bool swipeRightward;

    public GameObject textTool;
    public GameObject pointer;
    public GameObject drumstick0 = null;
    public GameObject drumstick1 = null;

    // Use this for initialization
    void Start()
    {

        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        //V3
        image = GameObject.Find("Pointer");


        listener = new ControllerListener();
        controller = new Controller();
        controller.AddListener(listener);


        


        pox = 0;
        poy = 0;
        //V2

        if (SceneManager.GetActiveScene().name == "SongSelection")
        {
            print("InputHandler Start");
            textPointer = GameObject.Find("TextPointer").GetComponent<Text>();
            textTarget = GameObject.Find("TextTarget").GetComponent<Text>();

            indexFingerX = 0;
            indexFingerY = 0;

            isSwiping = false;
            isCircling = false;
            isKeyTapping = false;
            isScreenTapping = false;
            swipeVectorX = 0;
            swipeLeftward = false;
            swipeRightward = false;
        }
           else if (SceneManager.GetActiveScene().name == "Gameplay")
        {



            //Gameplay

            textTool = GameObject.Find("TextTool");
            pointer = GameObject.Find("Pointer");
            foreach(GameObject go in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (go.name == "Drumstick0")
                {
                    drumstick0 = go;
                    drumstick0.SetActive(false);
                }
                else if (go.name == "Drumstick1")
                {
                    drumstick1 = go;
                    drumstick1.SetActive(false);
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SongSelection")
        {
            keyBoardInput();
            touchScreenInput();
            leapMotionInput();
            voiceInput();
        }
        else if (SceneManager.GetActiveScene().name == "Gameplay")
        {
           gameplayInputHandler();
        }
        
    }

    
    void gameplayInputHandler()
    {
        if(listener.toolCount == 0)
        {
            drumstick0.SetActive(false);
            drumstick1.SetActive(false);
        }
        else if(listener.toolCount == 1)
        {
            drumstick0.SetActive(true);
            drumstick1.SetActive(false);
            drumstick0.transform.position = new Vector2(listener.toolPoX[0] * 2 + UnityEngine.Screen.width / 2, listener.toolPoY[0]);

        }
        else if(listener.toolCount == 2)
        {
            drumstick0.SetActive(true);
            drumstick1.SetActive(true);
            drumstick0.transform.position = new Vector2(listener.toolPoX[0] * 2 + UnityEngine.Screen.width / 2, listener.toolPoY[0]);
            drumstick1.transform.position = new Vector2(listener.toolPoX[1] * 2 + UnityEngine.Screen.width / 2, listener.toolPoY[1]);
            //drumstick0.transform.position = new Vector2(listener.toolVector[0].x, listener.toolVector[0].y);
            //drumstick1.transform.position = new Vector2(listener.toolVector[1].x, listener.toolVector[1].y);

        }
        textTool.GetComponent<Text>().text = "toolCount:" + listener.toolCount;
        if(listener.toolCount > 0)
        {
            //textTool.GetComponent<Text>().text += "vector:" + listener.toolVector;
        }


        //pointer.transform.position = new Vector2(listener.toolpoX * 2 + UnityEngine.Screen.width / 2, listener.toolpoY * 2 - UnityEngine.Screen.height / 4);
        

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


        if (listener.indexFingerX != this.indexFingerX || listener.indexFingerY != this.indexFingerY)
        {
            this.indexFingerX = listener.indexFingerX;
            this.indexFingerY = listener.indexFingerY;
            image.transform.position = new Vector2(this.indexFingerX * 2 +  UnityEngine.Screen.width / 2, this.indexFingerY * 2 - UnityEngine.Screen.height / 4);
        }


        textPointer.GetComponent<Text>().text = "finger x:" + indexFingerX + " y:" + indexFingerY +
            " pointer x:" + image.transform.position.x + " y:" + image.transform.position.y;
        

         if(listener.swipeVectorX != this.swipeVectorX)
        {

            if (this.swipeVectorX > listener.swipeVectorX)//Swipe Left
            {
                swipeLeftward = true;
                swipeRightward = false;
            }
            else
            {
                swipeRightward = true;
                swipeLeftward = false;
            }
            this.swipeVectorX = listener.swipeVectorX;
        }
        

    }

    private void OnDestroy()
    {
        controller.RemoveListener(listener);
        controller.Dispose();
    }

    void voiceInput()
    {

    }
}


public class ControllerListener : Listener
{
    private Object thisLock = new Object();
    public float indexFingerX;
    public float indexFingerY;

    public float swipeVectorX;

    public int toolCount;
    public float[] toolPoX;
    public float[] toolPoY;

    private void SafeWriteLine(string line)
    {
        lock (thisLock)
        {
            MonoBehaviour.print(line);
        }
    }

    public override void OnConnect(Controller controller)
    {
        SafeWriteLine("Connected");
        controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
        controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
        controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
        controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        controller.EnableGesture(Gesture.GestureType.TYPE_INVALID);
        indexFingerX = 0;
        indexFingerY = 0;
        swipeVectorX = 0;

        toolCount = 0;
        toolPoX = new float[2] { 0, 0 };
        toolPoY = new float[2] { 0, 0 };
    }

    public override void OnFrame(Controller controller)
    {
        Frame frame = controller.Frame();

        
        foreach(Hand hand in frame.Hands)
        {

            foreach(Finger finger in hand.Fingers)
            {
                if(finger.Type == Finger.FingerType.TYPE_INDEX)
                {
                    indexFingerX = finger.StabilizedTipPosition.x;
                    indexFingerY = finger.StabilizedTipPosition.y;
                }
                
            }
        }

        toolCount = frame.Tools.Count;
        for(int i = 0; i < frame.Tools.Count; i++)
        {
            toolPoX[i] = frame.Tools[i].TipPosition.x;
            toolPoY[i] = frame.Tools[i].TipPosition.y;

        }

        foreach (Tool tool in frame.Tools)
        {
            /*
            SafeWriteLine(
                " Sta_Tip_po:" + tool.StabilizedTipPosition +
                " Tip_po:" + tool.TipPosition +
                " Tip_velocity:" + tool.TipVelocity +
                " Width:" + tool.Width +
                " Length:" + tool.Length);
                */
        }

        foreach (Gesture gesture in frame.Gestures())
        {
            switch (gesture.Type)
            {
                case Gesture.GestureType.TYPE_CIRCLE:
                    InputHandler.instance.isCircling = true;
                    //SafeWriteLine("Circle");
                    break;
                case Gesture.GestureType.TYPE_KEY_TAP:
                    InputHandler.instance.isKeyTapping = true;
                    //SafeWriteLine("key tap");
                    break;
                case Gesture.GestureType.TYPE_SCREEN_TAP:
                    InputHandler.instance.isScreenTapping = true;
                    //SafeWriteLine("screen tap");
                    break;
                case Gesture.GestureType.TYPE_SWIPE:
                    InputHandler.instance.isSwiping = true;
                    SwipeGesture swipeGesture = new SwipeGesture(gesture);
                    swipeVectorX = swipeGesture.Position.x;
                    //SafeWriteLine("swipe");
                    break;
                default:
                    //SafeWriteLine("default");
                    break;
            }
        }

        
    }
}