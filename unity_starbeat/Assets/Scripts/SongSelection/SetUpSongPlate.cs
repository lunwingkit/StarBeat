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
    public static int x = 0;

	// Use this for initialization
	void Start () {

        parent = GameObject.Find("SongPlateContainer");
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
                    string difficultyInfo = reader.ReadLine();
                    Song newSong = JsonUtility.FromJson<Song>(songInfo);
                    Difficulty songDifficulty = JsonUtility.FromJson<Difficulty>(difficultyInfo);
                    newSong.difficulty = songDifficulty;
                    songList.Add(newSong);
                }
                foreach (Song song in songList)
                {
                    createSongPlate(song);
                }
            }
        }
        else
            print("Cannot Find Json File");
    }

    public void createSongPlate(Song song)
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
    }
}


public class Song
{
    public string songName;
    public string songWriter;
    public string chartMaker;
    public string bpm;
    public Difficulty difficulty;
}

public class Difficulty
{
    public string easy;
    public string normal;
    public string hard;
}

public class PlayRecord
{
    public Song song;
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
