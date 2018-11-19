using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSetting : MonoBehaviour {
	public void onClick()
    {
        SceneManager.LoadScene("Setting");
    }
}
