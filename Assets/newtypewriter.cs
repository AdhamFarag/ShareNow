using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class newtypewriter : MonoBehaviour
{

    public float delay = 0.1f;
    public string fullText;
    public string currentText = "";
    public GameObject next;
    private string special;
    private Text special1;
    public bool isbold;
    public bool isspecial;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        //type.Play();
        for (int i = 0; i < fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i) + "<color=#00000000>" + fullText.Substring(i, fullText.Length - i);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
        
        // type.Stop();
        next.SetActive(true);

    }
}
