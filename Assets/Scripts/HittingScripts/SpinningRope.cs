using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinningRope : MonoBehaviour {
    public float limit;
    public float x_spin;
    public float TimeBreak;
    public Text text;
	// Use this for initialization
	void Start () {
        text.text = Score.ropeScore.ToString();
        x_spin = 5;
        
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, 0, x_spin, Space.Self);

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Glove")
        {
            Debug.Log("Hit the rope!");
            if(Score.ropeScore > 0 )
            {
                Score.ropeScore--;
            }
            
            text.text = Score.ropeScore.ToString();
        }

    }


    
}
