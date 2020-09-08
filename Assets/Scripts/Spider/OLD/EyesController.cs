using UnityEngine;
using System.Collections;

public class EyesController : MonoBehaviour {


    /** EYES ARRAY
	 * [0] -> Idle
	 * [1] -> Dead
	 * [2] -> Eat	 
	 */

    public Sprite [] eyesArray = new Sprite[9];
	SpriteRenderer currentSpriteRenderer;


	Animator thisAnimator;
	
	public float animationTimer = 1f;
	float blinkTime = 0.2f;

	
	// Use this for initialization
	void Start () {
	
		thisAnimator = transform.GetComponent<Animator> ();		

		currentSpriteRenderer = transform.GetComponent<SpriteRenderer>();
		
		InvokeRepeating("BlinkEye",0,animationTimer);

	}
	
	void BlinkEye(){
		thisAnimator.enabled = false;
		int randomFace = Random.Range(1,6);
		
		currentSpriteRenderer.sprite  = eyesArray[randomFace];
		Invoke("StopBlink",blinkTime);
		
	}
	
	void StopBlink(){
		currentSpriteRenderer.sprite = eyesArray[0];
	}
	
	public void SetNewSprite(string newSprite){

		CancelInvoke("StopBlink");
		CancelInvoke("BlinkEye");


		thisAnimator.enabled = true;
		foreach (Sprite tmpSprite in eyesArray)
		{
			if (tmpSprite.name.Contains(newSprite))
			{
				
				if(newSprite.Contains("iddle"))
				{

					InvokeRepeating("BlinkEye",2,animationTimer);
					thisAnimator.SetBool("Eating",false);
					//currentSpriteRenderer.sprite = tmpSprite;
				}
				else if(newSprite.Contains("eat")){
					thisAnimator.SetBool("Eating",true);

				}
			}
		}
	}

	
}
