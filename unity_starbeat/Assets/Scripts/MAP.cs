using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MAP : MonoBehaviour {
    private CSVWriter csvWriter = new CSVWriter();
    private List<List<string>> csv = new List<List<string>>();
    private Text text;
    int a = 0;
    int s = 0;
    int d = 0;
    int f = 0;
    int g = 0;
    float time = 0;
    
    void LateUpdate()
    {
        time += Time.deltaTime;
        if(a + s + d != 0)
        {
            List<string> line = new List<string>();
            line.Add(time.ToString());
            line.Add(a.ToString());
            line.Add(s.ToString());
            line.Add(d.ToString());
            line.Add(f.ToString());
            line.Add(g.ToString());
            csv.Add(line);
            a = s = d = f = g = 0;
        }
        if (Input.anyKey)
        {
            if (Input.GetKeyDown("a"))
            {
                a = 1;
            }
            if (Input.GetKeyDown("s"))
            {
                s = 1;
            }
            if (Input.GetKeyDown("d"))
            {
                d = 1;
            }
            if (Input.GetKeyDown("f"))
            {
                f = 1;
            }
            if (Input.GetKeyDown("g"))
            {
                g = 1;
            }
        }
    }

    private void OnApplicationQuit()
    {
        csvWriter.writeCSV(csv, "text");
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
