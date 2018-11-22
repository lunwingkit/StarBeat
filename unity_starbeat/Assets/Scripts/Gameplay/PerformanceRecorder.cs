using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceRecorder : MonoBehaviour {
    public static PerformanceRecorder instance;

    public PlayRecord newRecord;

	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        newRecord = new PlayRecord(SongPlateManager.instance.selectedSong, SongPlateManager.instance.selectedDifficulty);
	}
	
	// Update is called once per frame
	void Update () {

        //IF(completed)
        //THEN GO TO RESULT
        //ELSE DESTROY PLAYRECORD
	}
}


public class PlayRecord
{
    public Song song;
    public Difficulty difficulty;
    public int score;
    public float achievment;
    public int combo;
    public int flawlessCount;
    public int greatCount;
    public int goodCount;
    public int missCount;

    public PlayRecord(Song song, Difficulty difficulty)
    {
        this.song = song;
        this.difficulty = difficulty;
    }
}