using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationHand : MonoBehaviour {

    public Text[] texts;
    public string[] punch;
	// Use this for initialization
	void Start () {
		
        if(Information.rightHanded == true)
        {
            texts[0].text = punch[0];
            texts[1].text = punch[1];
        }

        if(Information.rightHanded == false)
        {
            texts[0].text = punch[1];
            texts[1].text = punch[0];
        }

	}
	
	// Update is called once per frame
	
}
