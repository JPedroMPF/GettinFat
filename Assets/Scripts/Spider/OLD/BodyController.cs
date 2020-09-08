using UnityEngine;
using System.Collections;

public class BodyController : MonoBehaviour {

	/*public Sprite [] bodySprites = new Sprite[3];


	Vector3 startPosition;

	float increment;
	float finishScale;

	float localX;
	float localY;
	bool canGrow = true;
 	float decreaseAmount = 0.2f;
	float startScale = 1f;

	private GoTween growTween;
	private GoTweenConfig tweenConfig = new GoTweenConfig();


	// Use this for initialization
	void OnEnable(){
		Main.gameEvent += GameEventHandler;
		BugController.bugEvent += bugEventHandler;
		SpiderController.spiderEvent += SpiderEventHandler;
	}
	void OnDisable(){
		Main.gameEvent -= GameEventHandler;
		BugController.bugEvent -= bugEventHandler;
		SpiderController.spiderEvent -= SpiderEventHandler;
	}

	void Start () {

		startPosition = transform.localPosition;
		finishScale = 1;


		localX = transform.localScale.x;
		localY = transform.localScale.y;


	}



	void OnTriggerEnter2D(Collider2D col){	
		
		if (col.tag.Contains("Bug")) {
			
			transform.parent.SendMessage("BodyHitHandler",col);

		}
		
	}

	public void GrowInSize(){
		Vector3 newScale = new Vector3(1.5f,1.5f,transform.localScale.z);
		transform.scaleTo(0.5f,newScale);		
	}

	public void ResetSize(){
		finishScale = 1;
		localX = startScale;
		localY = startScale;
		
		canGrow = false;
		
		Vector3 newScale = new Vector3(localX,localY,transform.localScale.z);
		transform.scaleTo(0.5f,newScale).setOnCompleteHandler((x) =>
		                                                    {
			canGrow = true;
			
		});		
	}

	void ReduceSize(){

		print ("TENHO K REDUZIR");

		float decreaseLocalAmountX = transform.localScale.x * decreaseAmount;
		float decreaseLocalAmountY = transform.localScale.y * decreaseAmount;

		localX = transform.localScale.x - decreaseLocalAmountX;
		localY = transform.localScale.y - decreaseLocalAmountY;

		if (localX < startScale) {
			localX = startScale;
			localY = startScale;
		}

		canGrow = false;
		
		Vector3 newScale = new Vector3(localX,localX,transform.localScale.z);
		transform.scaleTo(4f,newScale).setOnCompleteHandler((x) =>
		                                                    {
			canGrow = true;
			finishScale = transform.localScale.x;
		});		
	}


	
	
	protected void BubbleAnimFinsihed(AbstractGoTween tween)
	{
		var positions = new PositionTweenProperty( new Vector3(transform.parent.transform.position.x,transform.parent.transform.position.y -0.30f, transform.position.z ) );
		//var rotateProperty = new EulerAnglesTweenProperty(new Vector3(0f,0f,360f));
		var config = new GoTweenConfig();
		config.addTweenProperty( positions );
		config.setEaseType(GoEaseType.BounceOut);
		
		
		GoTween tween2 = new GoTween( transform, 0.55f, config );
		
		
		Go.addTween( tween2 );
	}*/

	/*void SpiderEventHandler (string action)
	{
		
		switch (action) {
		
		case SpiderController.WAKEUP_EVENT:
			break;
		case SpiderController.EATING_EVENT:

			transform.GetComponent<Animation>().Play();

    */
			
			//EditorApplication.isPaused = true;

			/*
			var positions = new PositionTweenProperty( new Vector3(transform.position.x,transform.position.y, transform.position.z ) );
			//var rotateProperty = new EulerAnglesTweenProperty(new Vector3(0f,0f,360f));
			var config = new GoTweenConfig();
			//config.addTweenProperty(rotateProperty);
			config.addTweenProperty( positions );
			config.setEaseType(GoEaseType.BounceOut);
			config.onComplete(BubbleAnimFinsihed);

			
			GoTween tween = new GoTween( transform, 0.55f, config );
			
			
			Go.addTween( tween );*/
			


		
/*
			break;
		case SpiderController.DEAD_EVENT:
			Vector3 newPosition = startPosition;

			newPosition.y = -0.3f;
			transform.localPositionTo(0.15f,newPosition,false).setOnCompleteHandler((x) =>{

				transform.localPositionTo(0.15f,startPosition,false);

	
			});	
			break;
		
		}
	}*/


/*
	void GameEventHandler (string action)
	{
		switch (action) {	
		case Main.RETURN_MENU_EVENT:
		case Main.RESTART_GAME_EVENT:
			print ("REDUXE SIZE");
			ResetSize();
			
			break;
			
			
		}	
	}

	void bugEventHandler (string bugEvent,  string type)
	{	
	//	print ("BIXO COMIDO");
		switch(bugEvent){

			case BugController.BUGEATEN_EVENT:

				if(type == "Beetle")
				{
				
					growTween.destroy();
					ReduceSize();

				}
				else{
					if(canGrow ){

					if(growTween !=null)
						growTween.pause ();

						finishScale += 0.01f;

						
						

					Vector3 newScale = new Vector3(finishScale,finishScale,transform.localScale.z);
						var scaleProperty = new ScaleTweenProperty( newScale );
						
						tweenConfig = new GoTweenConfig();
						
						//config.setDelay( 1f );
						tweenConfig.addTweenProperty( scaleProperty );
						
						growTween = new GoTween( transform, 1f, tweenConfig );						
						
						Go.addTween( growTween );

					}
				}
			break;
		}
	}

    */

}
