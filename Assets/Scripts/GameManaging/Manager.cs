using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public enum Position { Heavy, Speed, Ring, Rope }
    Position position;
    public GameObject player;
    public Transform[] Interactables;
    public Vector3 HeavyVec, SpeedVec, RingVec, RopeVec;
    public Text textScore;
    

	// Use this for initialization
	void Start () {
        //textScore = GameObject.Find("Text").GetComponent<Text>();
        

        position = Position.Heavy;
        textScore.text = position.ToString() + " Score = " + Score.heavybagScore;
        Debug.Log("Starting at " + position);
    }
	
	// Update is called once per frame
	void Update () {
        
		

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchPos();
            Debug.Log("We have moved to " + position);
        }
	}

    void SwitchPos()
    {
        switch (position) {
            case Position.Heavy:
                position = Position.Ring;
                textScore.text = position.ToString() + " Score = " + Score.ringScore;
                player.transform.position = RingVec;
                break;
            case Position.Ring:
                position = Position.Rope;
                textScore.text = position.ToString() + " Score = " + Score.ropeScore;
                player.transform.position = RopeVec;
                break;
            case Position.Rope:
                position = Position.Speed;
                textScore.text = position.ToString() + " Score = " + Score.speedBagScore;
                player.transform.position = SpeedVec;
                break;
            case Position.Speed:
                position = Position.Heavy;
                textScore.text = position.ToString() + " Score = " + Score.heavybagScore;
                player.transform.position = HeavyVec;
                player.transform.LookAt(Interactables[0]);
                break;
        }
            
    }
   
}
