using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour {
    public void onClick()
    {

        string filePath = Application.dataPath + "/002.mp3";

        AudioClip clip = Resources.Load<AudioClip>("002");
        Audio.instance.audioData.clip = clip;

        SceneManager.LoadScene("Gameplay");
    }
}
