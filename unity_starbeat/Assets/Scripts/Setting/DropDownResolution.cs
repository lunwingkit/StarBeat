using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownResolution : MonoBehaviour {
    Resolution[] resolutions;

    List<string> resolutionList = new List<string>();

    public Dropdown dropdown;

	// Use this for initialization
	void Start () {
        resolutions = Screen.resolutions;
        


        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionList.Add(ResToString(resolutions[i]));
        }
        PopulateList();

        dropdown.onValueChanged.AddListener(delegate
        {
            Screen.SetResolution(resolutions[dropdown.value].width, resolutions[dropdown.value].height, false);
        });
    }
    
    void PopulateList()
    {
        dropdown.AddOptions(resolutionList);
    }

    string ResToString(Resolution res)
    {
        return res.width + " * " + res.height;
    }
}
