using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningRope : MonoBehaviour {

    public float x_spin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(x_spin, 0, 0, Space.Self);

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Glove")
        {
            Debug.Log("Hit the rope!");
        }
    }
}
