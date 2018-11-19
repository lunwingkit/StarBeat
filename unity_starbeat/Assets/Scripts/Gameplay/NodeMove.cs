using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour {
    private float time = 0f;
    public new Transform transform;
    public GameObject destinationPosition;
    public float moveSpeed;
    private Vector3 v_startPosition;
    private Vector3 v_endPosition;

	// Use this for initialization
	void Start () {
        transform = this.GetComponent<Transform>();
        v_startPosition = this.transform.position;
        v_endPosition = destinationPosition.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        var v = time / moveSpeed;
        this.transform.position = Vector3.Lerp(v_startPosition, v_endPosition, v);
        time += Time.deltaTime;
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == destinationPosition)
        {
            Destroy(gameObject);
        }
    }
}
