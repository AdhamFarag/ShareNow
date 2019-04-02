using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class go_to_URL : MonoBehaviour {
    public string the_url;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void go_to()
    {
        Application.OpenURL(the_url);

    }
}
