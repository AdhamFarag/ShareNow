using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class saveenetry : MonoBehaviour {
    public string entryname;
  //  public string info;
    public InputField IF;
	// Use this for initialization
	void Awake () {
        IF.text = PlayerPrefs.GetString(entryname);
    }

    // Update is called once per frame
    void Update () {
      //  IF.text = PlayerPrefs.GetString(entryname);
        PlayerPrefs.SetString(entryname, IF.text);


    }
}
