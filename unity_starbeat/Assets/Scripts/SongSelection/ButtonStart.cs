using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour {

    public void onClick()
    {
        if (SongPlateManager.selectedSong == null)
            print("No song selected!");
        else
            SceneManager.LoadScene("Gameplay");
    }

    public void update()
    {
        print(gameObject.name + gameObject.transform.position);
    }
}
