using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonResult : MonoBehaviour {

    public void onClickSetting()
    {
        ButtonReturn.scene = "ResultReview";
        SceneManager.LoadScene("Setting");
    }

    public void onClickReplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void onClickReturn()
    {
        SceneManager.LoadScene("SongSelection");
    }
}
