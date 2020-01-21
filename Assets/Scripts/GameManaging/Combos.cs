using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour {

    public AudioControl control;
    public Animator animator;
    private int order_number;
    private int previous_number;
	// Use this for initialization
	void Start () {
        order_number = animator.GetInteger("Order");
        previous_number = animator.GetInteger("Order");
	}
	
	// Update is called once per frame
	void Update () {

        if (control.source.isPlaying == false && control.source.clip == control.clips[6]) 
        {
            Debug.Log("ready to call combos");
            control.source.clip = control.combos[0];
            control.source.PlayDelayed(2.0f);
        }

        order_number = animator.GetInteger("Order");
        if (previous_number != order_number)
        {
            Debug.Log("pad has been hit");

            //Jabs
            if (order_number < 3 && order_number >= 0)
            {
                Repeat();
            }

            //Jabs End
            if (order_number == 3)
            {
                NextAudio();
            }

            //Cross
            if (order_number == 4)
            {
                Repeat();
            }

            //Cross End
            if (order_number == 5)
            {
                NextAudio();
            }


            //Hook Once
            if(order_number == 6)
            {
                NextAudio();
            } 

            //Hook Once
            if(order_number == 7)
            {
                NextAudio();
            }

            //Repeat Jab + Cross call
            if (order_number == 9 || order_number == 11)
            {
                Repeat();
            }

            // End of 3 Jab + Cross call
            if (order_number == 13)
            {
                NextAudio();
            }

            if(order_number == 16)
            {
                Repeat();
            }

            if(order_number == 19)
            {
                NextAudio();
            }
            
            if (order_number == 22)
            {
                NextAudio();
            }

            if(order_number == 24)
            {
                control.source.clip = control.clips[7];
                control.source.Play();
                gameObject.SetActive(false);
            }
        }


    }


    void Repeat()
    {

        control.source.PlayDelayed(1.0f);
        previous_number = order_number;
    }

    void NextAudio()
    {
        int number;
        number = System.Array.IndexOf(control.combos, control.source.clip);
        control.source.clip = control.combos[number + 1];
        control.source.PlayDelayed(1.0f);
        previous_number = order_number;
    }

}
