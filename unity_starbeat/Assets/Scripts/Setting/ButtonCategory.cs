using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCategory : MonoBehaviour {
    public Button button;

    GameObject[] allObject;
    List<GameObject> canvas = new List<GameObject>();
    string category;

    public void Start()
    {
        category = button.name.Replace("Button", "");

        allObject = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject go in allObject)
        {
            if (go.name == "AudioCanvas" || go.name == "DisplayCanvas" || go.name == "GameplayCanvas" || go.name == "GeneralCanvas")
                canvas.Add(go);
        }
    }


    public void onClick()
    {
        foreach(GameObject go in canvas)
        {
            if (go.name.Equals(category+"Canvas"))
                go.SetActive(true);
            else
                go.SetActive(false);
        }
    }
}
