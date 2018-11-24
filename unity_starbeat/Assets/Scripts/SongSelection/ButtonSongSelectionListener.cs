using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSongSelectionListener : MonoBehaviour {
    public static ButtonSongSelectionListener instance;
    GameObject button;

    public GameObject textTarget;
    public GameObject canvas;
    
	// Use this for initialization
	void Start () {
        instance = this;
        button = GameObject.Find("ButtonStart");

        textTarget = GameObject.Find("TextTarget");
        canvas = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
        //print(button.name + button.transform.position.x + " " +  button.transform.position.y + " " + button.transform.localPosition);
        //print(button.GetComponent<RectTransform>().rect.width + " " + button.GetComponent<RectTransform>().rect.height);


        textTarget.GetComponent<Text>().text = "Transform xy:" + button.transform.position.x.ToString() + " " + button.transform.position.y.ToString() +
            " Rect xy:" + button.GetComponent<RectTransform>().rect.x + " " + button.GetComponent<RectTransform>().rect.y +
            // " Rect wh:" + button.GetComponent<RectTransform>().rect.width + " " + button.GetComponent<RectTransform>().rect.height +
            // " test:" + button.GetComponent<RectTransform>().transform.localPosition.x + " " + button.GetComponent<RectTransform>().transform.localPosition.y +
            // " test2:" + RectTransformUtility.PixelAdjustPoint(button.GetComponent<RectTransform>().sizeDelta, button.GetComponent<Transform>(), button.GetComponent<Canvas>()) +
            " test3:" + RectTransformToScreenSpace(button.GetComponent<RectTransform>());

        if (InputHandler.instance.image.transform.position.x >= RectTransformToScreenSpace(button.GetComponent<RectTransform>()).x &&
            InputHandler.instance.image.transform.position.x <= RectTransformToScreenSpace(button.GetComponent<RectTransform>()).x + RectTransformToScreenSpace(button.GetComponent<RectTransform>()).width &&
            InputHandler.instance.image.transform.position.y >= RectTransformToScreenSpace(button.GetComponent<RectTransform>()).y &&
            InputHandler.instance.image.transform.position.y <= RectTransformToScreenSpace(button.GetComponent<RectTransform>()).y + RectTransformToScreenSpace(button.GetComponent<RectTransform>()).height)
        {
            print("inside");
            button.GetComponent<Button>().Select();
            if (InputHandler.instance.isOnPress())
                button.GetComponent<Button>().onClick.Invoke();
        }
        else
        {
            GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

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
