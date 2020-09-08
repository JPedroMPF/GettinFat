using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

	public static GameSettings Instance { get; private set; }




	private void Awake() {
		if (Instance != null) {
			DestroyImmediate(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	


	//SPIDER VARIABLES
	public float SPIDER_SPEED = 05f;
	public float SPIDER_LEG_SPEED = 0;


	//BUG VARIABLES
	public float BUG_SPEED = 0;
	public float BUG_CAUGHT_SPEED = 0;
	public float BUG_RAISE_SPEED_TIMER = 5;
	public float BUG_RAISE_SPEED_AMOUNT = 0.0003f;


	//WEB VARIABLES
	public float WEB_MIN_SIZE = 0.2f;
	public float WEB_MAX_SIZE = 1;
	public float WEB_GROW_SPEED = 15;
	public float WEB_DECREASE_SPEED = 0.5f;

	//BODY VARIABLES

	public static float SPIDER_BODY_GROWAMOUNT = 1;


	protected GameSettings(){
	}



}
