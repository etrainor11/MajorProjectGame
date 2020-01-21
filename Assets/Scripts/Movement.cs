using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public float turn;
    public float zangle;
    private float shiftDown;
    public float distance_Moved;
    public Vector3[] positions;
    
	// Use this for initialization
	void Start () {
        positions[0] = transform.position;
        positions[1] = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        positions[0] = transform.position;
       // Debug.Log("current is " + positions[0]);
       // Debug.Log("previous position is " + positions[1]);

        if(positions[0] != positions[1])
        {
            distance_Moved = Vector3.Distance(positions[1], positions[0]);
            //Debug.Log("Moved " + distance_Moved + " places");
            positions[1] = positions[0];
        }
        else
        {
            distance_Moved = 0.0f;
        }
        

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 3, Space.Self);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -3, Space.Self );
        }

        
    }
}
