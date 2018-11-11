using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour {
    public List<List<string>> readCSV(string fileName)
    {
        TextAsset ta = Resources.Load(fileName, typeof(TextAsset)) as TextAsset;
        StringReader reader = new StringReader(ta.text);
        return csv(reader);
    }

    private List<List<string>> csv(StringReader reader)
    {
        var csv = new List<List<string>>();
        var line = new List<string>();
        while(reader.Peek() > -1)
        {
            line = new List<string>();
            string str = reader.ReadLine();
            string[] value = str.Split(',');
            for(int i = 0; i < value.Length; i++)
            {
                line.Add(value[i]);
            }
            csv.Add(line);
        }
        reader.Close();
        return csv;
    }
}
