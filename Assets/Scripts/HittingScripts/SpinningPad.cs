using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPad : MonoBehaviour {

    private SpinningRope ropeScript;
    Animator animator;
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Glove")
        {
            //glove has hit pad and it has reacted   
            Score.ringScore++;
            animator.SetBool("SpinningPadHit", true);
            //increase speed of rope swinging here!!!
            ropeScript.x_spin = ropeScript.x_spin + 0.10f;
            Debug.Log("Hit spinning pad");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Glove")
        {
            animator.SetBool("SpinningPadHit", false);
        }
    }
}
