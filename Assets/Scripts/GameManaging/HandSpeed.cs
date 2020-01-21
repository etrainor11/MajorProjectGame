using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSpeed : MonoBehaviour {

    public float hand_speed;
    public Vector3 currant_trans;
    public Vector3 old_trans;
	// Use this for initialization
	void Start () {
        update_trans();
        old_trans = currant_trans;
	}
	
	// Update is called once per frame
	void Update () {
        update_trans();
        float the_speed = (currant_trans.magnitude - old_trans.magnitude) / Time.deltaTime;
        hand_speed = Mathf.Abs(the_speed);

        if(old_trans != currant_trans)
        {
            //Debug.Log(hand_speed);
            
            old_trans = currant_trans;

        }
	}

    void update_trans()
    {
        currant_trans = gameObject.transform.position;
    }
   
}



