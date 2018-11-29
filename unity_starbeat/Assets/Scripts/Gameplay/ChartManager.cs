using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartManager : MonoBehaviour {
    public static ChartManager instance;
    public List<NodeCreator> nodeCreators;
    public string fileName;

    void Awake()
    {
        instance = this;

        if(SongPlateManager.selectedSong != null)
            fileName = SongPlateManager.selectedSong.getChartDataPath(SongPlateManager.selectedDifficulty);
        print(fileName);
        

        for (int i = 1; i <= 5; i++)
        {
            nodeCreators.Add(GameObject.Find("NodeLine" + i + "/NodeCreator").GetComponent<NodeCreator>());
        }

        foreach (NodeCreator creator in nodeCreators)
        {
            creator.fileName = fileName;
        }
        print("Manager Done");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
