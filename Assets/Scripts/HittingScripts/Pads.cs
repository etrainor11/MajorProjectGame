using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pads : MonoBehaviour
{

    public Animator animatorPad;
    private string name;
    public GloveAudio gloveAudioScript;
    public static int order_number;
    private HandSpeed hand_speed_script;
    public float speed_needed;
    private PadHit pad_hit_script;

    // Use this for initialization
    void Start()
    {
        name = gameObject.name;
        //Debug.Log(name);
        order_number = 0;
        speed_needed = 0f;

        pad_hit_script = GetComponent<PadHit>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Glove" && pad_hit_script.time_since_hit <= 0.0f)
        {

            hand_speed_script = other.gameObject.GetComponent<HandSpeed>();
            if (hand_speed_script.hand_speed >= speed_needed)
            {
                pad_hit_script.time_since_hit = 0.2f;
                Debug.Log(other.gameObject.name + " has entered " + gameObject.name);
                gloveAudioScript = other.gameObject.GetComponent<GloveAudio>();
                PerformAudio();

                switch (name)
                {
                    case "PaddingLeft":
                        //animatorPad.SetBool("LeftHit", true);
                        animatorPad.SetTrigger("Trigger1");
                        order_number++;
                        Debug.Log(order_number);
                        animatorPad.SetInteger("Order", order_number);
                        break;
                    case "PaddingRight":
                        animatorPad.SetTrigger("Trigger2");
                        order_number++;
                        Debug.Log(order_number);
                        animatorPad.SetInteger("Order", order_number);

                        break;
                    case "PaddingLeftWide":
                        animatorPad.SetTrigger("Trigger3");
                        order_number++;
                        Debug.Log(order_number);
                        animatorPad.SetInteger("Order", order_number);
                        break;
                    case "PaddingRightWide":
                        animatorPad.SetTrigger("Trigger4");
                        order_number++;
                        Debug.Log(order_number);
                        animatorPad.SetInteger("Order", order_number);
                        break;
                    case "SpinningPad":
                        animatorPad.SetTrigger("Trigger5");
                        Score.ropeScore = Score.ropeScore + 1;
                        SpinningRope spinningRopeScript = GameObject.Find("Rope (1)").GetComponent<SpinningRope>();
                        if(spinningRopeScript.x_spin <= spinningRopeScript.limit)
                        {
                            spinningRopeScript.x_spin = spinningRopeScript.x_spin + 0.5f;
                        }
                        Text text = GameObject.Find("SpinningPadScore").GetComponent<Text>();
                        text.text = Score.ropeScore.ToString();
                        //Debug.Log(Score.ropeScore);
                        break;
                }


                

            }

            else
            {
                Debug.Log("hand speed not quick enough");
            }

        }
    }


    private void OnTriggerStay(Collider other)
    {

        

        
    }
    /*private void OnTriggerExit(Collider other)
    {

        Debug.Log(other.gameObject.name + " has left " + gameObject.name);

        switch (name)
        {
            case "PaddingLeft":
                animatorPad.SetBool("LeftHit", false);
               

                break;
            case "PaddingRight":
                animatorPad.SetBool("RightHit", false);
              

                break;
            case "PaddingLeftWide":
                animatorPad.SetBool("LeftWideHit", false);
                
                break;
            case "PaddingRightWide":
                animatorPad.SetBool("RightWideHit", false);
                
                break;
            case "SpinningPad":
                animatorPad.SetBool("SpinningPadHit", false);
               
                break;
        }
    }*/

    void PerformAudio()
    {

        AudioSource audioSource = gloveAudioScript.audioSource;
        audioSource.clip = gloveAudioScript.clips[1];
        audioSource.Play();
    }



}
    

