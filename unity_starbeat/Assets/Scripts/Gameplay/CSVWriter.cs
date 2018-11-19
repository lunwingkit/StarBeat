using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CSVWriter : MonoBehaviour {

    public void writeCSV(List<List<string>>csv, string path)
    {
        var filePath = Application.dataPath + "/" + path + ".csv";
        var fi = new FileInfo(filePath);
        StreamWriter sw = null;
        try
        {
            sw = fi.AppendText();
            write(csv, sw);
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
        finally
        {
            if(sw != null)
            {
                sw.Close();
            }
        }
    }

    private StreamWriter write(List<List<string>>csv, StreamWriter sw)
    {
        for(var i = 0; i < csv.Count; i++)
        {
            string list = "";
            for (var j = 0; j < csv[i].Count; j++)
            {
                if (list == "")
                {
                    list += csv[i][j];
                }
                else
                {
                    list += "," + csv[i][j];
                }
            }
            sw.WriteLine(list);
        }
        return sw;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
