using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadReaction : MonoBehaviour {

    /*Script to activate  local 
      animation when glove hits pad*/


    public Animator animator;
        
	// Use this for initialization
	void Start () {
        animator = GameObject.Find("PaddingManagement").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
