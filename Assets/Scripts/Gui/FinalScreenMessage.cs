using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScreenMessage : MonoBehaviour {

	public string [] goodSentences;
	public string [] badSentences;

	public Text textHolder;

	//public Main mainScript;

	// Use this for initialization
	void Start () {
		/*int randomSentence = Random.Range (0, goodSentences.Length);
		if (mainScript.highScore > Main.BUGS_EATEN) {
			textHolder.text = badSentences [randomSentence];

		} else {
			textHolder.text = goodSentences [randomSentence];
		}*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
