using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class addjournal : MonoBehaviour {
    public GameObject prefabButton;
    public RectTransform ParentPanel;

    // Use this for initialization
    void Start()
    {
        float newpos = 0;
        float newheight = 280;
        for (int i = 0; i < 5; i++)
        {
            GameObject goButton = (GameObject)Instantiate(prefabButton);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);
            newpos = newpos - 30;
            goButton.transform.position = new Vector3(-0.5f, newpos, 0);

            Button tempButton = goButton.GetComponent<Button>();
            int tempInt = i;
            ParentPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 280);
            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }


    }

    public void presshere()
    {

    }
    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
    }

}