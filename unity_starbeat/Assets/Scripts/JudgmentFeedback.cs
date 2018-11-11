using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentFeedback : MonoBehaviour {
    public TextMesh judgmentFeedback;
    public float speed;


    public void Awake()
    {
        judgmentFeedback.text = "";
    }
    // Use this for initialization
    void Start()
    {
        if (speed != 1)
        {
            speed = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (judgmentFeedback.color.a <= 0)
        {
            this.enabled = false;
        }
        else
        {
            var alfa = judgmentFeedback.color.a - speed * Time.deltaTime;
            judgmentFeedback.color = new Color(judgmentFeedback.color.r, judgmentFeedback.color.g, judgmentFeedback.color.b, alfa);
        }
    }

    public void addFeedback(string judgment)
    {
        judgmentFeedback.text = judgment;
        judgmentFeedback.color = new Color(1, 1, 1, 0.4f);
        this.enabled = true;
    }
}
