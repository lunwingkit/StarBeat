using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSongSelectionListener : MonoBehaviour {
    public static ButtonSongSelectionListener instance;
    List<GameObject> buttons;
    public GameObject textTarget;
    public GameObject canvas;
    public GameObject songPlateContainer;


    public float test = 0;

	// Use this for initialization
	void Start () {
        instance = this;
        buttons = new List<GameObject>();
        buttons.Add(GameObject.Find("ButtonStart"));
        buttons.Add(GameObject.Find("ButtonHard"));
        buttons.Add(GameObject.Find("ButtonNormal"));
        buttons.Add(GameObject.Find("ButtonEasy"));
        buttons.Add(GameObject.Find("ButtonSetting"));
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("SongPlate"))
        {
            buttons.Add(go);
        }

        textTarget = GameObject.Find("TextTarget");
        canvas = GameObject.Find("Canvas");
        songPlateContainer = GameObject.Find("SongPlateContainer");
	}
	
	// Update is called once per frame
	void Update () {
        //print(button.name + button.transform.position.x + " " +  button.transform.position.y + " " + button.transform.localPosition);
        //print(button.GetComponent<RectTransform>().rect.width + " " + button.GetComponent<RectTransform>().rect.height);


        /*
        textTarget.GetComponent<Text>().text = "Transform xy:" + button.transform.position.x.ToString() + " " + button.transform.position.y.ToString() +
            " Rect xy:" + button.GetComponent<RectTransform>().rect.x + " " + button.GetComponent<RectTransform>().rect.y +
            " test3:" + RectTransformToScreenSpace(button.GetComponent<RectTransform>());
            */


        /*
        if (InputHandler.instance.image.transform.position.x >= RectTransformToScreenSpace(button.GetComponent<RectTransform>()).x &&
            InputHandler.instance.image.transform.position.x <= RectTransformToScreenSpace(button.GetComponent<RectTransform>()).x + RectTransformToScreenSpace(button.GetComponent<RectTransform>()).width &&
            InputHandler.instance.image.transform.position.y >= RectTransformToScreenSpace(button.GetComponent<RectTransform>()).y &&
            InputHandler.instance.image.transform.position.y <= RectTransformToScreenSpace(button.GetComponent<RectTransform>()).y + RectTransformToScreenSpace(button.GetComponent<RectTransform>()).height)
        {
            print("inside");
            button.GetComponent<Button>().Select();

            if (InputHandler.instance.isScreenTapping)
            {
                button.GetComponent<Button>().onClick.Invoke();
                InputHandler.instance.isScreenTapping = false;
            }
            
        }
        else
        {
            GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        }
        */

        foreach(GameObject go in buttons)
        {
            pointerClick(InputHandler.instance.image.transform.position, go);
        }
        //pointerClick(InputHandler.instance.image.transform.position, button);


        pointerSwipe(InputHandler.instance.image.transform.position, songPlateContainer.GetComponent<RectTransform>());

        songPlateContainer.GetComponent<ScrollRect>().horizontalNormalizedPosition = test;
    }

    public void pointerClick(Vector3 pointer, GameObject go)
    {
        if (pointer.x >= RectTransformToScreenSpace(go.GetComponent<RectTransform>()).x &&
            pointer.x <= RectTransformToScreenSpace(go.GetComponent<RectTransform>()).x + RectTransformToScreenSpace(go.GetComponent<RectTransform>()).width &&
            pointer.y >= RectTransformToScreenSpace(go.GetComponent<RectTransform>()).y &&
            pointer.y <= RectTransformToScreenSpace(go.GetComponent<RectTransform>()).y + RectTransformToScreenSpace(go.GetComponent<RectTransform>()).height)
        {
            print(go.name);
            go.GetComponent<Button>().Select();
            if (InputHandler.instance.isScreenTapping)
            {
                go.GetComponent<Button>().onClick.Invoke();
                InputHandler.instance.isScreenTapping = false;
            }
        }
        else
        {
            GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        }
    }

    public void pointerSwipe(Vector3 pointer, RectTransform rectTransform)
    {
        if(pointer.x >= RectTransformToScreenSpace(rectTransform).x &&
            pointer.x <= RectTransformToScreenSpace(rectTransform).x + RectTransformToScreenSpace(rectTransform).width &&
            pointer.y >= RectTransformToScreenSpace(rectTransform).y &&
            pointer.y <= RectTransformToScreenSpace(rectTransform).y + RectTransformToScreenSpace(rectTransform).height)
        {
            if(InputHandler.instance.isSwiping)
            {
                if (InputHandler.instance.swipeLeftward)
                {
                    SongPlateManager.instance.selectBySwiping(1);
                    print("left");
                }
                else if (InputHandler.instance.swipeRightward)
                {
                    SongPlateManager.instance.selectBySwiping(-1);
                    print("right");
                }

                InputHandler.instance.isSwiping = false;
            }
        }

    }

    public static Rect RectTransformToScreenSpace(RectTransform transform)
    {
        Vector2 size = Vector2.Scale(transform.rect.size, transform.lossyScale);
        float x = transform.position.x - (transform.pivot.x * size.x);
        float y = transform.position.y - ((1.0f - transform.pivot.y) * size.y);
        return new Rect(x, y, size.x, size.y);
    }
}
