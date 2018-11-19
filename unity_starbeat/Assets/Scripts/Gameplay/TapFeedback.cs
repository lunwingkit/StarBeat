using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapFeedback : MonoBehaviour {
    public float speed;
    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Default()
    {
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 0.4f);
    }

    // Use this for initialization
    private void Start()
    {
        if (speed != 5)
        {
            speed = 5;
        }
    }

	// Update is called once per frame
	void Update () {
        if (this.enabled && renderer.material.color.a <= 0)
        {
            this.enabled = false;
        }
        else
        {
            var alfa = renderer.material.color.a - 5 * Time.deltaTime;
            renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alfa);
        }
    }
    
    public void Tap()
    {
        renderer.material.color = new Color(1, 1, 1, 0.4f);
        this.enabled = true;
    }

    public void Tap(Color color)
    {
        renderer.material.color = color;
        this.enabled = true;
    }
}
