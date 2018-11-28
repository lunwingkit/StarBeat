using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceRecorder : MonoBehaviour {
    public static PerformanceRecorder instance;

    public PlayRecord newRecord;

    public GameObject albumJacket;
    public GameObject songName;
    public GameObject difficulty;
    public GameObject buttonSN;
    public GameObject buttonD;
    //public Song song;
    //public Difficulty difficulty;
    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        if (SongPlateManager.instance != null)
            newRecord = new PlayRecord(SongPlateManager.selectedSong, SongPlateManager.selectedDifficulty);
        else
            newRecord = new PlayRecord(new Song(), Difficulty.HARD);


        albumJacket = GameObject.Find("ImageAlbumJacket");
        songName = GameObject.Find("SongName");
        difficulty = GameObject.Find("Difficulty");
        buttonSN = GameObject.Find("ButtonSN");
        buttonD = GameObject.Find("ButtonD");

        albumJacket.GetComponent<RawImage>().texture = Resources.Load<Texture2D>(SongPlateManager.selectedSong.audioDataPath);
        songName.GetComponent<Text>().text = SongPlateManager.selectedSong.songName;
        buttonSN.GetComponent<Button>().interactable = false;
        ColorBlock sn = buttonSN.GetComponent<Button>().colors;
        sn.disabledColor = new Color(1, 1, 1);
        buttonSN.GetComponent<Button>().colors = sn;
        difficulty.GetComponent<Text>().text = SongPlateManager.selectedDifficulty.ToString();
        buttonD.GetComponent<Button>().interactable = false;
        ColorBlock d = buttonD.GetComponent<Button>().colors;
        switch (SongPlateManager.selectedDifficulty)
        {
            case Difficulty.EASY:
                d.disabledColor = new Color(0.7411249f, 1, 0.4669811f);
                break;
            case Difficulty.NORMAL:
                d.disabledColor = new Color(1, 0.9869514f, 0.5518868f);
                break;
            case Difficulty.HARD:
                d.disabledColor = new Color(1, 0.4858491f, 0.4858491f);
                break;
        }
        buttonD.GetComponent<Button>().colors = d;
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