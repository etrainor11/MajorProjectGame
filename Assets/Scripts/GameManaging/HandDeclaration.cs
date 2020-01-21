using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDeclaration : MonoBehaviour {

    public AudioControl control;
    public GameObject[] pads;
    public GameObject[] canvases;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (control.source.clip == control.clips[0])
        {
            if (gameObject.name == "PaddingRight")
            {
                Information.rightHanded = false;
                next();
                destroycan();
            }

            if (gameObject.name == "PaddingLeft")
            {
                Information.rightHanded = true;
                next();
                destroycan();
            }
        }

        if (control.source.clip == control.clips[7])
        {
            gameObject.SetActive(false);
            Debug.Log("turning " + gameObject + " off");
        }

        else
        {
            next();
        }

        
    }


    void next()
    {
        Debug.Log("right handed is " + Information.rightHanded);
        control.playnext();
        foreach (GameObject obj in pads)
        {
           obj.SetActive(false);
        }
    }

    
    void destroycan()
    {
        foreach (GameObject obj in canvases)
        {
            Destroy(obj);
        }
    }
}
