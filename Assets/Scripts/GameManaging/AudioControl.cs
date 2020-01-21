using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControl : MonoBehaviour {

    public AudioSource source;
    public AudioClip[] clips;
    public AudioClip[] combos;
    public GameObject[] objects;
    private int number;
    public Animator animator;
    private Scene scene;

	// Use this for initialization
	void Start () {

        scene = SceneManager.GetActiveScene();

        source = GetComponent<AudioSource>();
        source.clip = clips[0];
        source.PlayDelayed(5.0f);
        


        number = System.Array.IndexOf(clips, source.clip);
	}
	
	// Update is called once per frame
	void Update () {

        int othernum = number;
        number = System.Array.IndexOf(clips, source.clip);
        if(othernum != number)
        {
            //Debug.Log("Animation index is now on " + number);
            othernum = number;
        }
        //Debug.Log(source.isPlaying);

        if(source.isPlaying == false )
        {
            if(scene.name == "Start")
            {
                if (source.clip == clips[1])
                {
                    playnext();
                }
                if (source.clip == clips[2])
                {
                    playnext();
                }

                if (source.clip == clips[4])
                {
                    playnext();
                }

                if (source.clip == clips[6])
                {
                    playnext();
                }

                if (source.clip == clips[8] && source.isPlaying == false)
                {
                    animator.SetBool("MoveRequest", true);

                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("ViveFadeOut") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 3.0f)
                    {
                        SceneManager.LoadSceneAsync("BoxingGym");
                    }

                    
                }

            }

            if (scene.name == "BoxingGym")
            {
                if(source.clip == clips[0] && animator.GetBool("DrillFinished") == true)
                {
                    playnext();
                }



                if(source.clip == clips[2] && animator.GetBool("DrillFinished") == true)
                {
                    playnext();
                }


                if (source.clip == clips[4] && animator.GetBool("DrillFinished") == true)
                {
                    playnext();
                }


                if(source.clip == clips[7] && source.isPlaying == false)
                {
                    animator.SetBool("MoveRequest", true);

                    if  (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 3.0f)
                    {
                        Debug.Log("Quit now");
                        Application.Quit();
                    }
                }

            }

        }

    }

    public void playnext()
    {
        source.clip = clips[number + 1];
        source.PlayDelayed(1.0f);
    }
}
