using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenPanel : MonoBehaviour {
    public GameObject panel;

    public void start()
    {
    }

    public void onClick()
    {
        panel.SetActive(true);
    }
}
