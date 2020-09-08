using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WebController : MonoBehaviour {
	
	//float growingSpeed = 6f;
	//float decreaseSpeed = 0.7f;
	//float maxSize = 0.6f;
	//float minSize = 0.1f;
	//Vector3 startScale;

	//SpriteRenderer thisSpriteRender;

 //   public GameObject fakeWeb;

 //   List<GameObject> eatenBugs = new List<GameObject>();

	
	////EVENTS
	//public delegate void WebEvent(string webEvent);
	//public static event WebEvent webEvent;
	//public const string WEBSHRINK_EVENT = "Eating";
	//public const string BUGCATCHED_EVENT = "BugCatched";
	//public const string FINISHEATING_EVENT = "FinishedEating";


 //   public GoTween tweenGrow;
 //   public GoTween tweenShrink;



 //   // Use this for initialization
 //   void Start () {
	//	startScale = transform.localScale;
	//	transform.GetComponent<Collider2D>().enabled = false;

	//	thisSpriteRender = transform.GetComponent<SpriteRenderer> ();

	//	Go.defaultEaseType = GoEaseType.QuadOut;

	//}
	
	//// Update is called once per frame
	//void FixedUpdate () {
	

	//	if(transform.localScale.x > maxSize - (maxSize*0.05))
	//	{
	//		transform.GetComponent<Animation>().Play("WebExplosion");
	//	}
	//	else
	//	{
	//		thisSpriteRender.color = new Color(255,255,255);
	//		transform.GetComponent<Animation>().Stop();
	//	}

	


	//}


    

 //   void ResetWeb(){
        
 //       StopAllCoroutines();
 //       transform.localScale = startScale ;



 //       transform.GetComponent<Animation>().enabled = true;
	//	transform.GetComponent<Collider2D>().enabled = false;

	//}
	
	
	//void OnTriggerEnter2D(Collider2D col){

 //       if (col.tag.Contains ("Bug")) {
	//		col.transform.SendMessage ("MoveToSpider", transform.position);

	//		eatenBugs.Add (col.gameObject);
			
	//	} 
	//	else if (col.tag.Contains ("Ground")) {
	//		Invoke("CheckIfEaten",0.1f);
	//	}
		
		
	//}
	
	//void FinalEvent()
 //   {
 //       if (webEvent != null)
 //       {
 //           webEvent(FINISHEATING_EVENT);
 //       }
 //       ResetWeb();
 //   }
	//public void CheckIfEaten(){

	//	if(eatenBugs.Count > 0){
	//		if(webEvent != null){	
				
	//			webEvent(WEBSHRINK_EVENT);
	//		}

	//		transform.GetComponent<Collider2D>().enabled = false;
 //           StartCoroutine(ScaleOverTime(decreaseSpeed,startScale));
 //           Invoke("FinalEvent", decreaseSpeed);
 //           /*transform.scaleTo(decreaseSpeed,minSize).setOnCompleteHandler((x) =>
	//		                                                  {					
					
					
					

	//		});	*/

 //           if (webEvent != null){					
	//			webEvent(WEBSHRINK_EVENT);
	//		}
	//	}
	//	else{

	//		GameObject webClone = Instantiate (fakeWeb, transform.position, Quaternion.identity) as GameObject;
	//		webClone.transform.localScale = transform.localScale;	

	//		ResetWeb();
	//	}
		
	//}
	
	//public void ActivateColision(){


 //      // tweenGrow.destroy();

	//	transform.GetComponent<Collider2D>().enabled = true;
	//}
	//public void DeactivateColision(){
	//	transform.GetComponent<Collider2D>().enabled = false;

	//}
	
	//public void ActivateGrow(){
 //     /*  if (tween != null)
 //       {
 //           ResetWeb();
 //           print("AKI");
 //       }*/
			

	//	eatenBugs.Clear ();

 //       StartCoroutine(ScaleOverTime(growingSpeed, new Vector3(maxSize, maxSize, maxSize)));

 //       /*
	//	var scaleProperty = new ScaleTweenProperty( new Vector3(maxSize,maxSize, maxSize ) );
	//	//var rotateProperty = new EulerAnglesTweenProperty(new Vector3(0f,0f,360f));
	//	var config = new GoTweenConfig();
	//	//config.addTweenProperty(rotateProperty);
	//	config.addTweenProperty( scaleProperty );

 //       tweenGrow = new GoTween( transform, growingSpeed, config );
        

	//	Go.addTween(tweenGrow);*/

	//	Go.to( transform, 5f, new GoTweenConfig()
	//	      .eulerAngles(new Vector3(0,0,360))
	//	      .setEaseType(GoEaseType.Linear)
	//	      .setIterations( -1 ,GoLoopType.RestartFromBeginning)
	//	      );
	//	//	transform.collider2D.enabled = true;
	//}

 //   IEnumerator ScaleOverTime(float time, Vector3 finalScale)
 //   {
 //       Vector3 originalScale = transform.localScale;
 //       Vector3 destinationScale = finalScale;

 //       float currentTime = 0.0f;

 //       do
 //       {
 //           transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
 //           currentTime += Time.deltaTime;
 //           yield return null;
 //       } while (currentTime <= time);
        
 //   }


 //   void GameEventHandler (string action)
	//{
	//	switch (action) {
	//	case Main.RETURN_MENU_EVENT:
	//	case Main.CONTINUE_GAME_EVENT:
	//	case Main.RESTART_GAME_EVENT:
	//		ResetWeb();
	//		break;
	//	case Main.END_GAME_EVENT:
	//		print ("DESTRUE ANIM");
	//		transform.GetComponent<Animation>().enabled = false;
 //               //tweenGrow.destroy();
	//		//ResetWeb();
	//		break;
	//	}
	//}
	
	//void OnEnable(){
	//	Main.gameEvent += GameEventHandler;
	//}
	
	//void OnDisable(){
		
	//	Main.gameEvent -= GameEventHandler;
	//}
}
