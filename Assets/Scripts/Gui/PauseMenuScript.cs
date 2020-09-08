using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour {

	public Text objectiveHolder1;
	public Text objectiveHolder2;
	public Text objectiveHolder3;

	// Use this for initialization
	void Start () {
		objectiveHolder1.text = ObjectivesScript.objective1;
		objectiveHolder2.text = ObjectivesScript.objective2;
		objectiveHolder3.text = ObjectivesScript.objective3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
