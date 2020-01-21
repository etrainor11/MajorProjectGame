using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddingHit : MonoBehaviour {

    private BoxCollider box;
    PadReaction padReactionScript;

	// Use this for initialization
	void Start () {
        box = GetComponent<BoxCollider>();
        //Debug.Log(box);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Glove")
        {
            Debug.Log(gameObject.name + " was hit by " + other.gameObject.name);
            //change animator state here 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Glove")
        {
            //change animator state here
        }
    }
}
