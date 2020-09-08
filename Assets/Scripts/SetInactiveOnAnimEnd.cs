using UnityEngine;
using System.Collections;

public class SetInactiveOnAnimEnd : MonoBehaviour {

	public void SetInactive(){
		transform.gameObject.SetActive (false);
	}

	
	public void SetActive(){
		transform.gameObject.SetActive (true);
	}

}
