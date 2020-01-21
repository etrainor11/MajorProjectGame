using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadHit : MonoBehaviour {

    public float time_since_hit;
    

    // Use this for initialization
    void Start () {
        time_since_hit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(time_since_hit > 0.0f)
        {
            time_since_hit -= Time.deltaTime;
        } 

	}
}
