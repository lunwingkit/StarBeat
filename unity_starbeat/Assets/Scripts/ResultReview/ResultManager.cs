using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {
    Image albumJacket;
    Text songName;
    Text songWriter;
    Button difficulty;

    Text flawlessCount;
    Text greatCount;
    Text goodCount;
    Text missCount;
    Text combo;
    Text achievement;
    Text highScore;

    public PlayRecord record;

    // Use this for initialization
    void Start () {
        songName = GameObject.Find("TextSongName").GetComponent<Text>();
        songWriter = GameObject.Find("TextSongWriter").GetComponent<Text>();
        difficulty = GameObject.Find("ButtonDifficulty").GetComponent<Button>();

        flawlessCount = GameObject.Find("TextFlawlessCount").GetComponent<Text>();
        greatCount = GameObject.Find("TextGreatCount").GetComponent<Text>();
        goodCount = GameObject.Find("TextGoodCount").GetComponent<Text>();
        missCount = GameObject.Find("TextMissCount").GetComponent<Text>();
        combo = GameObject.Find("TextCombo").GetComponent<Text>();
        achievement = GameObject.Find("TextAchievement").GetComponent<Text>();
        highScore = GameObject.Find("TextHighScore").GetComponent<Text>();

        record = PerformanceRecorder.instance.newRecord;

        songName.text = record.song.songName;
        songWriter.text = record.song.songWriter;
        flawlessCount.text = record.flawlessCount.ToString();
        greatCount.text = record.greatCount.ToString();
        goodCount.text = record.goodCount.ToString();
        missCount.text = record.missCount.ToString();
        combo.text = (record.flawlessCount+record.greatCount+record.goodCount).ToString();
        achievement.text = "100%test";
        highScore.text = "10000text";


    }
}
