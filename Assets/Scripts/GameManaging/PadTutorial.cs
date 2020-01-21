using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadTutorial : MonoBehaviour {

    public GameObject[] pads;
    public AudioControl control;
    public Animator animator;
    bool once = false;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if(control.source.clip == control.clips[3])
        {
            jab();
        }

        if(control.source.clip == control.clips[5])
        {
            cross();
        }

        if (control.source.clip == control.clips[7])
        {

            Debug.Log("once is " + once);
            if(once == false)
            {
                AlanHook();
                once = true;
            }

            if(pads[2].active == false && pads[3].active == false)
            {
                Debug.Log("Both pads down now changing audio");
                control.playnext();
            }
            
        }

    }


    void jab()
    {
        if(Information.rightHanded == true)
        {
            animator.SetBool("LeftHit", false);
            pads[0].SetActive(true);
            
        } 
        else
        {
            animator.SetBool("RightHit", false);
            pads[1].SetActive(true);
            
        }
    }

    void cross()
    {
        if (Information.rightHanded == true)
        {
            animator.SetBool("RightHit", false);
            pads[1].SetActive(true);
        }
        else
        {
            animator.SetBool("LeftHit", false);
            pads[0].SetActive(true);
        }
    }

    void AlanHook ()
    {
        pads[2].SetActive(true);
        pads[3].SetActive(true);
    }
}
