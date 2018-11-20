using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSetting : MonoBehaviour {
	public void onClickFromGamePlay()
    {
        ButtonReturn.scene = "Gameplay";
        SceneManager.LoadScene("Setting");
        GameplayController.instance.gameObject.SetActive(false);
    }

    public void onClickFromSongSelection()
    {
        ButtonReturn.scene = "SongSelection";
        SceneManager.LoadScene("Setting");
    }
}
