using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public enum Position { Heavy, Speed, Ring, Rope }
    Position position;
    public GameObject player;
    public GameObject centerHead;
    public Animator animator;
    private float timer;
    public float time_change;
    public Vector3 HeavyVec, SpeedVec, RingVec, RopeVec;
    public BoxCollider[] boxes;
    public AudioControl control;

	// Use this for initialization
	void Start () {

        position = Position.Heavy;
        player.transform.position = HeavyVec;
        animator = player.GetComponent<Animator>();
        Debug.Log(position);
        time_change = 48;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        

        if(timer > 0.5f)
        {
            animator.SetBool("HasMoved", false);
        }

        animator.SetFloat("Time", timer);
        if(animator.GetFloat("Time") > time_change)
        {
            animator.SetBool("DrillFinished", true);
        }

        

        if(animator.GetBool("DrillFinished") == true)
        {

            

           Ray ray = new Ray(centerHead.transform.position, centerHead.transform.forward * 100);
           RaycastHit hit;
           Debug.DrawRay(centerHead.transform.position, centerHead.transform.forward * 100, Color.blue);

            if(Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider == boxes[0] && position == Position.Heavy)
                {
                    RayMove();
                }

                
                if (hit.collider == boxes[1] && position == Position.Rope)
                {
                    RayMove();
                }

                if (hit.collider == boxes[2] && position == Position.Speed)
                {
                    RayMove();
                }
            }

        }

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("ViveFadeOut") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 2.0f)
        {
            
            switchPos();
            ResetAnim();
        }

	}

    void switchPos ()
    {
        switch(position)
        {
            case Position.Heavy:
                player.transform.position = RopeVec;
                position = Position.Rope;
                control.playnext();
                time_change = 43;
                break;
            case Position.Rope:
                player.transform.position = SpeedVec;
                position = Position.Speed;
                control.playnext();
                time_change = 60;
                break;
            case Position.Speed:
                player.transform.position = RingVec;
                position = Position.Ring;
                control.playnext();
                break;
        }

        Debug.Log(position);
    }
   
    void ResetAnim ()
    {
        animator.SetBool("HasMoved", true);
        animator.SetBool("MoveRequest", false);
        animator.SetBool("DrillFinished", false);
        timer = 0;
    }

    void RayMove ()
    {
        animator.SetBool("MoveRequest", true);
        animator.SetBool("HasMoved", false);
    }

}
