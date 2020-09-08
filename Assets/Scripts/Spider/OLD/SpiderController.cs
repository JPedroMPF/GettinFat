using UnityEngine;

public class SpiderController : MonoBehaviour {
	
//	public enum SpiderState{
//		Tutorial,
//		Stoped,
//		Walking,
//		Eating,
//		Dead,
//		Paused
//	};
	
//	public SpiderState currentState = SpiderState.Tutorial;

//	//VARIABLES
//	Vector3 startPosition;

//	//GAMEOBJECTS
//	public GameObject eyes;
//	EyesController eyesScript;

//	public GameObject body;

//	public GameObject legs;
//	WebController web;
//	Animator legAnimator;
//	Animator eyesAnimator;

//	public GameObject finalExplosion;

//	public AudioClip[] audiosList;
	
	
//	//CONDITIONS
//	public float movementSpeed = 0.005f;
//	float legSpeed = 10f;
//	public bool canMove = true;
//	public bool canBeHit = false;
	
	
//	//CONDTIIONS FOR MOVEMENT
//	Vector3 mousePosition;
//	SpiderCheckMovement thisMovementClass;
	
//	//SPEED
//	Vector3 lastPosition = Vector3.zero;
//	float objectSpeed;
	
//	//STARTING VALUES
	
//	//EVENTS
//	public delegate void SpiderDelegate(string action);
//	public static event SpiderDelegate spiderEvent;
//	public const string DEAD_EVENT = "Dead";
//	public const string WAKEUP_EVENT = "WakeUp";
//	public const string EATING_EVENT = "Eating";

//	//TUTORIAL EVENTS
//	public const string TOUCH_DRAG_EVENT = "Touch_drag";
//	public const string TOUCH_RELEASE_EVENT = "Touch_release";
//	public const string EAT_INPUT_EVENT = "Touch_eat";


//	void OnEnable(){
//		WebController.webEvent += webEventHandler;
//		//GUITutorial.tutEvent += TutEventHandler;
//		Main.gameEvent += GameEventHandler;
//	}
//	void OnDisable(){
//		WebController.webEvent -= webEventHandler;
//		//GUITutorial.tutEvent -= TutEventHandler;
//		Main.gameEvent -= GameEventHandler;
//	}

	
//	// Use this for initialization
//	void Start () {
//		web = transform.FindChild("web").GetComponent<WebController>();
//		legAnimator = legs.GetComponent<Animator>();
//		eyesAnimator = eyes.GetComponent<Animator> ();
//		eyesScript = eyes.GetComponent<EyesController>();
//		thisMovementClass = transform.GetComponent<SpiderCheckMovement>();
//		startPosition = transform.position;
//	}


//	// Update is called once per frame
//	void Update () {


//		//print ("SPIDER CAN MOVE? = " +canMove);
//		//transform.GetComponent<CircleCollider2D> ().enabled = true;
//		switch(currentState)
//		{		
//			case SpiderState.Tutorial:
//				canMove = true;
//				canBeHit = false;
//			break;

//			case SpiderState.Stoped:			
//				legAnimator.SetBool("Walking",false);
//				break;
//			case SpiderState.Walking:
//				canMove = true;
//				canBeHit = true;
//				break;
//			case SpiderState.Eating:
//				canMove = false;
//				canBeHit = false;
//				eyesScript.SetNewSprite("eat");
//				legAnimator.SetBool("Eating",true);
//				break;
//			case SpiderState.Dead:
//				canMove = false;
//				eyesScript.SetNewSprite("dead");
//				break;
//			case SpiderState.Paused:
//				canMove = false;
//				canBeHit = false;
//				break;
//		}


		

//	}
	
//	void FixedUpdate()
//	{		
//		objectSpeed = (transform.position - lastPosition).magnitude;
//		lastPosition = transform.position;
//		legAnimator.SetFloat("MovementSpeed",objectSpeed*legSpeed);
//	}
	
//	public void BodyHitHandler(Collider2D col){	
//		if (canBeHit) {	
//			if (col.tag.Contains("Bug")) {
//				BugController bugScript = col.gameObject.GetComponent<BugController>();

//				if (currentState != SpiderState.Eating || bugScript.beenEated == false ) {
//					currentState = SpiderState.Dead;

//					legAnimator.SetBool("Dead",true);
//					eyesAnimator.SetBool("Dead",true);

//				//	UnityEditor.EditorApplication.isPaused = true;

//					eyesScript.SetNewSprite("dead");
//					//eyes.SendMessage("TakeScreen");
//					transform.GetComponent<AudioSource>().Stop ();
//					transform.GetComponent<AudioSource>().GetComponent<AudioSource>().clip = audiosList[2];
//					transform.GetComponent<AudioSource>().Play();
//					transform.GetComponent<AudioSource>().loop = false;
					
//					if(spiderEvent != null){
//						spiderEvent(DEAD_EVENT);
//					}
//					canBeHit =false;
//				}
//			}
//		}
//	}
	
//	void OnMouseDown(){	
//	//	print (currentState);
//		web.DeactivateColision();

//		if(currentState == SpiderState.Tutorial)
//		{			
//			if(spiderEvent != null){
//				spiderEvent(TOUCH_DRAG_EVENT);
//			}
//		}



//		if(Main.GAME_STARTED == false && currentState !=SpiderState.Dead)
//		{
//			if(spiderEvent != null){
//				spiderEvent(TOUCH_DRAG_EVENT);
//			}
//		}
//		if(canMove){
//			if(currentState == SpiderState.Walking || currentState == SpiderState.Tutorial)
//				web.ActivateGrow();
//		}

//	}
	
//	void OnMouseDrag()	{

//		if(canMove){		
//			MoveSpider();
//			//if(web.tweenGrow.state == GoTweenState.Destroyed && currentState != SpiderState.Dead)
//				web.ActivateGrow();

//			if(currentState == SpiderState.Walking || currentState == SpiderState.Tutorial)
//				web.ActivateGrow();
//		}
//	}
	
//	void OnMouseUp(){
//		if (currentState != SpiderState.Dead) {
//			if (canMove) {
//				web.ActivateColision();
//				legAnimator.SetBool("Walking",false);
//			}
//		}


//		if(currentState == SpiderState.Tutorial)
//		{			
//			if(spiderEvent != null){
//				spiderEvent(TOUCH_RELEASE_EVENT);
//			}
//		}

//		if(transform.GetComponent<AudioSource>().isPlaying == true)
//			transform.GetComponent<AudioSource>().Stop();

//	}

//	void TutEventHandler(string eventType){
//		/*switch (eventType) {
//		case GUITutorial.FINISH_EVENT:
//			transform.GetComponent<CircleCollider2D>().enabled = true;
//			break;
//		}*/

//	}
	
//	void webEventHandler(string webEvent){
		
//		switch(webEvent)
//		{
//		case WebController.WEBSHRINK_EVENT:
//			currentState = SpiderState.Eating;	

//			transform.GetComponent<AudioSource>().GetComponent<AudioSource>().clip = audiosList[1];
//			transform.GetComponent<AudioSource>().Play();
//			transform.GetComponent<AudioSource>().loop = false;
//			if(spiderEvent != null){
//				spiderEvent(EATING_EVENT);
//			}

//			break;
//		case WebController.FINISHEATING_EVENT:
//			eyesScript.SetNewSprite("iddle");
//			legAnimator.SetBool("Eating",false);
//			currentState = SpiderState.Walking;	
//			break;
//		}
//		//currentState = SpiderState.Walking;
//	}
	
//	public void GameEventHandler (string action)
//	{
//		switch (action) {
//			case Main.START_TUTORIAL_EVENT:
//			//print ("SPIDER CATCH");
//				//transform.GetComponent<CircleCollider2D>().enabled = false;
//				currentState = SpiderState.Tutorial;
//				break;
//			case Main.START_GAME_EVENT:
//				currentState = SpiderState.Walking;
//				break;

//			case Main.RETURN_MENU_EVENT:
//			case Main.CONTINUE_GAME_EVENT:
//			case Main.RESTART_GAME_EVENT:
//			print ("RETURN");
//				Invoke("ExplodeWeb",1f);	

//				break;

//			case Main.PAUSE_GAME_EVENT:
//				currentState = SpiderState.Paused;
//			break;
//			case Main.RESUME_GAME_EVENT:

//				currentState = SpiderState.Walking;
				
//			break;
//			case Main.END_GAME_EVENT:
//				currentState = SpiderState.Dead;
//			break;

//		}	
//	}



//	void ExplodeWeb ()
//	{
//		canBeHit = false;
//		finalExplosion.SetActive(true);
//		finalExplosion.GetComponent<Animation>().Play("FinalExplosion");

//		Invoke("MoveToStartPosition",1f);
//	}

//	public void MoveToStartPosition(){

//		legAnimator.SetBool("Walking",true);
//		legAnimator.SetBool("Dead",false);
//		eyesAnimator.SetBool ("Dead", false);
	

//		transform.positionTo (2, startPosition).setOnCompleteHandler((x) =>
//		    {
//			eyesScript.SetNewSprite("iddle");
//			legAnimator.SetBool("Walking",false);
//			currentState = SpiderState.Walking;
//			canBeHit = true;
		
//				if(spiderEvent != null){
//					spiderEvent(WAKEUP_EVENT);
//				}
//			});	
//	}

//	public void MoveOutOfScreen(float speed){
		
//		legAnimator.SetBool("Walking",true);
//		legAnimator.SetBool("Dead",false);
//		transform.positionTo (speed, new Vector3 (0, 7.24f, 0)).setOnCompleteHandler((x) =>
//		                                                                     {
//			eyesScript.SetNewSprite("iddle");
//			legAnimator.SetBool("Walking",false);
//			currentState = SpiderState.Walking;
//			canBeHit = true;
			
//			if(spiderEvent != null){
//				spiderEvent(WAKEUP_EVENT);
//			}
//		});	
		
//	}


//	void MoveSpider(){


//		mousePosition = Input.mousePosition;
//		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
//		mousePosition.y = mousePosition.y + 1.5f;	
		
//		transform.position = Vector2.Lerp(transform.position,mousePosition,movementSpeed);

//		if (thisMovementClass.IsMoving) {
//			legAnimator.SetBool ("Walking", true);

//			if(currentState != SpiderState.Dead){
//				transform.GetComponent<AudioSource>().GetComponent<AudioSource>().clip = audiosList[0];
//				if(transform.GetComponent<AudioSource>().isPlaying == false)
//					transform.GetComponent<AudioSource>().Play();

//				transform.GetComponent<AudioSource>().loop = true;
//			}
			
//		} else {
//			legAnimator.SetBool("Walking",false);
//			transform.GetComponent<AudioSource>().Stop ();
//			transform.GetComponent<AudioSource>().loop = false;
//		}


	
//	}


}
