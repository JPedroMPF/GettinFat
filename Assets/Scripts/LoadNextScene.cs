using UnityEngine;
using System.Collections;

public class LoadNextScene : MonoBehaviour {
	public GameObject mainGUI;
	public GameObject spider;

	// Use this for initialization
	void Start () {
		//Invoke ("LoadMainScene", 2.0f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadMainScene(){
		mainGUI.SetActive (true);
		spider.SetActive (true);

		transform.gameObject.SetActive (false);
	}



}
