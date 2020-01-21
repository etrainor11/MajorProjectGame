using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBag : MonoBehaviour {

    public GloveAudio gloveAudio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        gloveAudio = collision.gameObject.GetComponent<GloveAudio>();
        AudioSource audioSource = gloveAudio.audioSource;
        audioSource.clip = gloveAudio.clips[1];
        audioSource.Play();
    }
}
