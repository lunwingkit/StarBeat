using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReturn : MonoBehaviour {
    public static string scene;
    public void LoacScene()
    {
        SceneManager.LoadScene(scene);
        GameplayController.instance.gameObject.SetActive(true);
    }
}
