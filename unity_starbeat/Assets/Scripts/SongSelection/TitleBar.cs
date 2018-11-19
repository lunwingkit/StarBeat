using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBar : MonoBehaviour {

    public List<string> modes = new List<string>() { "Practice Mode", "Freestyle Mode" };
    public Dropdown dropdown;

	// Use this for initialization
	void Start () {
        PopulateList();
    }

    void PopulateList()
    {
        dropdown.AddOptions(modes);
    }
}
