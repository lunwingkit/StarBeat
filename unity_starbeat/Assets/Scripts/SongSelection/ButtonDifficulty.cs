using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDifficulty : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickEasy()
    {
        SongPlateManager.instance.select(Difficulty.EASY);
    }

    public void onClickNormal()
    {
        SongPlateManager.instance.select(Difficulty.NORMAL);
    }

    public void onClickHard()
    {
        SongPlateManager.instance.select(Difficulty.HARD);
    }
}
