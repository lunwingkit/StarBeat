using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SetUpSongPlate : MonoBehaviour {
    GameObject songPlate;
    Text songName;
    Text songWriter;
    Text achievementRate;
    Text bpm;
    public GameObject sample;
    public GameObject parent;

	// Use this for initialization
	void Start () {
        songPlate = GameObject.Find("SongPlate1");
        songName = songPlate.transform.Find("TextSongName").GetComponent<Text>();
        songWriter = songPlate.transform.Find("TextSongWriter").GetComponent<Text>();
        achievementRate = songPlate.transform.Find("TextAchievementRate").GetComponent<Text>();
        bpm = songPlate.transform.Find("TextBPM").GetComponent<Text>();

        songName.text = "text1";
        songWriter.text = "wr";
        achievementRate.text = "100%";
        bpm.text = "120";

        parent = GameObject.Find("SongPlateContainer");
        CreateSongPlate();
    }
	
	private void CreateSongPlate()
    {
        var plate = (GameObject)Instantiate(sample, parent.transform);
        plate.transform.Find("TextSongName").GetComponent<Text>().text = "HIHAH";
        plate.transform.Find("TextSongWriter").GetComponent<Text>().text = "HIHAH";
        plate.transform.Find("TextAchievementRate").GetComponent<Text>().text = "HIHAH";
        plate.transform.Find("TextBPM").GetComponent<Text>().text = "HIHAH";
        plate.transform.localPosition = songPlate.transform.localPosition;
        plate.transform.localRotation = songPlate.transform.localRotation;
        plate.transform.localScale = songPlate.transform.localScale;
    }


    public void readJson(GameObject songPlate)
    {
        string filePath = Application.dataPath + "/songPlateInfo.txt";
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            Song loadData = JsonUtility.FromJson<Song>(dataAsJson);
            songPlate.transform.Find("TextSongName").GetComponent<Text>().text = loadData.songName;

        }
    }

}


public class Song
{
    public string songName;
    public string songWriter;
    public string chartMaker;
    public string bpm;
    public List<Difficulty> level;
}

public enum Difficulty
{
    Easy,
    Normal,
    Hard
}

public class PlayRecord
{
    public Song song;
    public int score;
    public float achievment;
    public int combo;
}