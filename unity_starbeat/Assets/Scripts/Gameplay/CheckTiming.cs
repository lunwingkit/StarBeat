using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTiming : MonoBehaviour {
    public int fCount = 0;
    public int grCount = 0;
    public int gCount = 0;
    public int mCount = 0;
    public TapFeedback tapFeedback;
    public JudgmentFeedback judgmentFeedback;
    private GameObject nodeParent;
    private string selector;

    public FeedbackDisplay feedbackDisplay;

    public Dictionary<string, List<GameObject>> timing = new Dictionary<string, List<GameObject>>
    {
        {"Flawless", new List<GameObject>() },
        {"Great", new List<GameObject>() },
        {"Good", new List<GameObject>() },
        {"Miss", new List<GameObject>() }
    };


    private void Awake()
    {
        nodeParent = gameObject.transform.parent.gameObject;
        tapFeedback = GameObject.Find(nodeParent.name + "/TapFeedback").GetComponent<TapFeedback>();
        judgmentFeedback = GameObject.Find(nodeParent.name + "/JudgmentFeedback").GetComponent<JudgmentFeedback>();
        selector = nodeParent.name.Replace("NodeLine", "");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(selector))
        {
            
            if (timing["Flawless"].Count > 0)
            {
                fCount++;
                destroyNode("Flawless");
                tapFeedback.Tap(new Color(1, 0.92f, 0.016f, 0.4f));
                judgmentFeedback.addFeedback("FLAWLESS");

                updatePerformanceRecord("Flawless");
                
            }
            else if (timing["Great"].Count > 0)
            {
                grCount++;
                destroyNode("Great");
                tapFeedback.Tap(new Color(1, 0, 0, 0.4f));
                judgmentFeedback.addFeedback("GREAT");

                updatePerformanceRecord("Great");
            }
            else if (timing["Good"].Count > 0)
            {
                gCount++;
                destroyNode("Good");
                tapFeedback.Tap(new Color(0, 1, 0, 0.4f));
                judgmentFeedback.addFeedback("GOOD");

                updatePerformanceRecord("Good");
            }
            else
                tapFeedback.Tap();
        }
        if (timing["Miss"].Count > 0)
        {
            mCount++;
            destroyNode("Miss");
            judgmentFeedback.addFeedback("MISS");

            updatePerformanceRecord("Miss");
        }


    }

    public void addNode(string judgment, GameObject gameObject)
    {
        timing[judgment].Add(gameObject);
    }

    public void removeNode(string judgment, GameObject gameObject)
    {
        timing[judgment].Remove(gameObject);
    }

    int getKeyValue(string key)
    {
        var dict = new System.Collections.Generic.Dictionary<string, int>()
        {
            {"Flawless",0 },
            {"Great",1 },
            {"Good",2 },
            {"Miss",3 }
        };
            return dict[key];
    }
    void destroyNode(string key)
    {
        feedbackDisplay.addFeedback(getKeyValue(key));
        try
        {
            GameObject obj = timing[key][0];
            Destroy(obj);
            timing["Flawless"].Remove(obj);
            timing["Great"].Remove(obj);
            timing["Good"].Remove(obj);
            timing["Miss"].Remove(obj);
        }
        catch(System.NullReferenceException e) { }
    }

    public void updatePerformanceRecord(string accuracy)
    {
        switch (accuracy)
        {
            case "Flawless":
                PerformanceRecorder.instance.newRecord.flawlessCount++;
                break;
            case "Great":
                PerformanceRecorder.instance.newRecord.greatCount++;
                break;
            case "Good":
                PerformanceRecorder.instance.newRecord.goodCount++;
                break;
            case "Miss":
                PerformanceRecorder.instance.newRecord.missCount++;
                break;
        }

    }
}
