using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour {

	public float delay = 0.1f;
	public string fullText;
	public string currentText = "";
    public GameObject next;
    private string special;
    private Text special1;
    public bool isbold;
    public bool isspecial;
	// Use this for initialization
	void Start () {
		StartCoroutine(ShowText());
	}
	
	IEnumerator ShowText(){
        //type.Play();
		for(int i = 0; i < fullText.Length; i++){
            if (fullText[i].ToString() == "^")
            {
                i = i + 1;
                isbold = !isbold;
            }
            if (isbold == true)
            {
                currentText = fullText.Substring(i,1);
                this.GetComponent<Text>().text += "<i><color=#ff0000ff >" + currentText + "</color></i>";
                yield return new WaitForSeconds(delay);
            }
            else if (fullText[i].ToString() == "%")
            {
                i = i + 1;
                currentText = fullText.Substring(i, 1);

                this.GetComponent<Text>().text += currentText + "\n";

            }
            else
            {
                currentText = fullText.Substring(i, 1);
                this.GetComponent<Text>().text += currentText;
                yield return new WaitForSeconds(delay);
            }
		}
       // type.Stop();
        next.SetActive(true);

	}
}
