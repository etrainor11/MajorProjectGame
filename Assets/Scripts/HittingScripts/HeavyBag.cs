using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeavyBag : MonoBehaviour {
    
    public GloveAudio gloveAudioScript;
    int times_hit;
    
	// Use this for initialization
	void Start () {
        times_hit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Glove")
        {
            times_hit++;
            //Debug.Log(times_hit);
            gloveAudioScript = collision.gameObject.GetComponent<GloveAudio>();
            AudioSource audioSource = gloveAudioScript.audioSource;
            audioSource.clip = gloveAudioScript.clips[0];
            audioSource.Play();
        }
    }

  
}
