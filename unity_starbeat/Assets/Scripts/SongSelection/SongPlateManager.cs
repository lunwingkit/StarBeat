﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SongPlateManager : MonoBehaviour {
    public static SongPlateManager instance;
    GameObject songPlate;
    Text songName;
    Text songWriter;
    Text achievementRate;
    Text bpm;
    public GameObject sample;
    public GameObject parent;
    public static int x = 0;
    List<GameObject> songPlateList;
    float differencePositionX;
    
    public Song selectedSong;


    void Awake()
    {

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start () {
        parent = GameObject.Find("SongPlateContainer");
        songPlateList = new List<GameObject>();

        //Find position From localPosition
        Vector2 v1 = transform.TransformPoint(new Vector2(sample.transform.localPosition.x + 0, sample.transform.localPosition.y));
        Vector2 v2 = transform.TransformPoint(new Vector2(sample.transform.localPosition.x + 200, sample.transform.localPosition.y));
        differencePositionX = v2.x - v1.x;

        string filePath = Application.dataPath + "/songPlateInfo.txt";
        readJson(filePath);
    }

    public void readJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            using (System.IO.StringReader reader = new System.IO.StringReader(dataAsJson))
            {
                List<Song> songList = new List<Song>();
                while (reader.Peek() != -1)
                {

                    string songInfo = reader.ReadLine();
                    string chartDataPath1 = reader.ReadLine();
                    string chartDataPath2 = reader.ReadLine();
                    string chartDataPath3 = reader.ReadLine();

                    print(songInfo);
                    print(chartDataPath1);
                    print(chartDataPath2);
                    print(chartDataPath3);
                    Song newSong = JsonUtility.FromJson<Song>(songInfo);
                    Chart newChart1 = JsonUtility.FromJson<Chart>(chartDataPath1);
                    Chart newChart2 = JsonUtility.FromJson<Chart>(chartDataPath2);
                    Chart newChart3 = JsonUtility.FromJson<Chart>(chartDataPath3);
                    newSong.chartDataList.Add(newChart1);
                    newSong.chartDataList.Add(newChart2);
                    newSong.chartDataList.Add(newChart3);
                    songList.Add(newSong);

                    print(newSong.ToString());
                    print(newChart1.ToString());
                    print(newChart2.ToString());
                    print(newChart3.ToString());
                }
                foreach (Song song in songList)
                {
                    songPlateList.Add(createSongPlate(song));
                }
            }
        }
        else
            print("Cannot Find Json File");
    }

    public GameObject createSongPlate(Song song)
    {
        
        var plate = (GameObject)Instantiate(sample, parent.transform);
        plate.transform.Find("TextSongName").GetComponent<Text>().text = song.songName;
        plate.transform.Find("TextSongWriter").GetComponent<Text>().text = song.songWriter;
        plate.transform.Find("TextAchievementRate").GetComponent<Text>().text = "100%";
        plate.transform.Find("TextBPM").GetComponent<Text>().text = song.bpm;
        plate.transform.localPosition = new Vector2(sample.transform.localPosition.x + x*200, sample.transform.localPosition.y);
        x++;
        plate.transform.localRotation = sample.transform.localRotation;
        plate.transform.localScale = sample.transform.localScale;
        plate.GetComponent<SongPlate>().song = song;
        return plate;
    }

    public void select(GameObject songPlate)
    {
        float x = 0f + Screen.width / 2;
        float y = songPlate.transform.position.y;


        //Before Selected SongPlate (Exclusive)
        int count = 1;
        for(int i = songPlateList.IndexOf(songPlate) - 1; i >= 0; i--)
        {
            songPlateList[i].transform.position = new Vector2(x - differencePositionX * count, y);
            count++;
        }

        //After Selected SongPlate (Inclusive)
        count = 0;
        for (int i = songPlateList.IndexOf(songPlate); i < songPlateList.Count; i++)
        {
            songPlateList[i].transform.position = new Vector2(x + differencePositionX * count, y);
            count++;
        }

        selectedSong = songPlate.GetComponent<SongPlate>().song;

        print(selectedSong.audioDataPath);
        //show level
        //show achievement
    }
}


public class Song
{
    public string songName;
    public string songWriter;
    public string bpm;
    public string audioDataPath;
    public List<Chart> chartDataList = new List<Chart>();

    public override string ToString()
    {
        return songName + " " + songWriter + " " + bpm + " " + audioDataPath;
    }
}

public class Chart
{
    public Difficulty difficulty;
    public string level;
    public string chartMaker;
    public string chartDataPath;

    public override string ToString()
    {
        return difficulty.ToString() + " " + level + " " + chartMaker + " " + chartDataPath;
    }

}
public enum Difficulty
{
    EASY,
    NORMAL,
    HARD
}

public class PlayRecord
{
    public Song song;
    public Difficulty difficulty;
    public int score;
    public float achievment;
    public int combo;
}


/*
            Song loadData = JsonUtility.FromJson<Song>(dataAsJson);
            songPlate.transform.Find("TextSongName").GetComponent<Text>().text = loadData.songName;

            Song test = new Song();
            test.songName = "name";
            test.songWriter = "";
            test.chartMaker = "";
            test.bpm = "";
        test.difficulty = new Difficulty();
        test.difficulty.easy = "5";
        test.difficulty.normal = "7";
        test.difficulty.hard = "10";
        string json = JsonUtility.ToJson(test);
        string j2 = JsonUtility.ToJson(test.difficulty);
        print(json);
        print(j2);
        Song newSong = JsonUtility.FromJson<Song>(json);
        print(newSong.songName);

            */



/*
songPlate = GameObject.Find("SongPlate1");
songName = songPlate.transform.Find("TextSongName").GetComponent<Text>();
songWriter = songPlate.transform.Find("TextSongWriter").GetComponent<Text>();
achievementRate = songPlate.transform.Find("TextAchievementRate").GetComponent<Text>();
bpm = songPlate.transform.Find("TextBPM").GetComponent<Text>();

songName.text = "text1";
songWriter.text = "wr";
achievementRate.text = "100%";
bpm.text = "120";
*/