using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.


public class text_entered : MonoBehaviour {
    public Text Maininput;
    public GameObject activate_what;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Maininput.text == "")
        {
            activate_what.SetActive(false);
        }
        else {
            activate_what.SetActive(true);
        }


	}
}
