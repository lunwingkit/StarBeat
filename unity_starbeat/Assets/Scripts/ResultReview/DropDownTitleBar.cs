using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownTitleBar : MonoBehaviour {
    public List<string> modes = new List<string>() { "Practice Mode - Result Review" };
    public Dropdown dropdown;
    void Start()
    {
        dropdown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
        PopulateList();
    }

    void PopulateList()
    {
        dropdown.AddOptions(modes);
    }
}
