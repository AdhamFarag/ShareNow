using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_deactivate : MonoBehaviour {
    public GameObject[] DE_allObjects;
    public GameObject[] AC_allObjects;

   // public GameObject Deactivating;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DE_activate()
    {
        //GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in DE_allObjects)
        {
            go.SetActive(false);
        }
    }
    public void AC_activate()
    {
        //GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in AC_allObjects)
        {
            go.SetActive(true);
        }
    }
}
