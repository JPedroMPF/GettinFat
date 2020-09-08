using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUITutorial : MonoBehaviour {
/*
	enum TutorialSteps{
		Starting,
		Hold,
		Release,
		HoldSecondTime,
		ReleaseSecondTime
	}

	TutorialSteps currentTutorialStep;

	public Text textToShow;
	public string [] textsArray = new string[5];
	public int index = 0;
	public GameObject spider;
	public GameObject spiderBody;
	public GameObject bug;
	public GameObject beetle;

	public delegate void TutorialDelegate(string action);
	public static event TutorialDelegate tutEvent;
	public const string FINISH_EVENT = "FinishTutorial";

	bool bugCatched =false;
	public bool isPressingSpider = false;

	int numberCatchAtemps = 0;

	// Use this for initialization
	void Start () {
		//WELCOM TEXT
		textToShow.text = textsArray[0];
		StartCoroutine(ShowText(1,2f));	
		currentTutorialStep = TutorialSteps.Starting;

	}



	IEnumerator ShowText(int index, float time){
		yield return new WaitForSeconds(time);
		textToShow.text = textsArray[index];
		spider.GetComponent<CircleCollider2D>().enabled = true;

	}



	void MoveSpiderOrder(){
		//HOLD THE SPIDER
		spider.GetComponent<CircleCollider2D> ().enabled = true;
		textToShow.text = textsArray[currentIndex];
		currentIndex++;
	
	}
	// Update is called once per frame
	void Update () {
		switch(currentTutorialStep)
		{
		case TutorialSteps.Hold:

			StartCoroutine(ShowText(2,1f));
          	

			break;
		case TutorialSteps.Release:
			StartCoroutine(ShowText(3,2f));
			numberCatchAtemps =0;
			break;
		case TutorialSteps.HoldSecondTime:

			if(bug){
				bug.SetActive(true);

				if(Vector3.Distance(spider.transform.position,bug.transform.position) > 1 && Vector3.Distance(spider.transform.position,bug.transform.position) < 2)
				{
				//	textToShow.text = "Now release";

					
				}


			}

			break;
		case TutorialSteps.ReleaseSecondTime:
			break;
		}


		
	}

	void SpiderEventHandler (string action)
	{

		switch (action) {
			case SpiderController.TOUCH_DRAG_EVENT:
				if(currentTutorialStep == TutorialSteps.Starting)
				{
					currentTutorialStep = TutorialSteps.Hold;
				}
				else if(currentTutorialStep == TutorialSteps.Release)
				{
					currentTutorialStep = TutorialSteps.HoldSecondTime;
				}
				
				
				//CATCH THE BUG
			//	textToShow.text = "Catch the bug with your web";
				//currentIndex++;
				//bug.SetActive (true);
				//Invoke("ShowBug",2f);

				break;
			case SpiderController.TOUCH_RELEASE_EVENT:
				if(currentTutorialStep == TutorialSteps.Hold)
				{
					currentTutorialStep = TutorialSteps.Release;
					
					
				}

				if(currentTutorialStep == TutorialSteps.HoldSecondTime){

					if(!bugCatched)
					{
						
						if(numberCatchAtemps == 0){
							textToShow.text = "Come on, it's not that hard. Try again.";
						}
						else {
							textToShow.text = "The bug must be INSIDE the web.";

						}
						numberCatchAtemps ++;
					}
				}

				break;
		}
		
	}




	void ShowBug(){
		bug.SetActive(true);
		textToShow.text = textsArray[index];
	//	currentIndex++;
	}

	void BugEventHandler (string bugEvent,string type)
	{

		if (type == "Fly") {
			if (numberCatchAtemps == 1) {
				textToShow.text = "Nice, you're a pro already!";
			} else if (numberCatchAtemps == 2) {
				textToShow.text = "YES! That's what I'm talking about.";
			} else {
				textToShow.text = "Finally!";
			}
			
			bugCatched = true;
			
			Destroy (bug);
			
			Invoke ("GrowSpider", 3f);


		} else {
			Invoke ("WishGoodLuck", 1f);
		}


	
	}

	void GrowSpider(){
		textToShow.text =  "Now, you'll get fat when you eat bugs… ";
		spiderBody.GetComponent<BodyController> ().GrowInSize ();
		spider.GetComponent<SpiderController> ().currentState = SpiderController.SpiderState.Tutorial;
		Invoke ("ShowBonusBug", 4f);
	}

	void ShowBonusBug(){

		textToShow.text =  "… but don't worry, Lucky Beetle will help you get in shape. \n Eat it to loose some weight";
		beetle.SetActive (true);

	}
	void WishGoodLuck(){
		beetle.SetActive (false);
		textToShow.text =  "If any of the bugs touches you \n before you eat it, you'll DIE!";

		Invoke ("FinishTutorial", 4f);
	}

	public void FinishTutorial(){
		spiderBody.GetComponent<BodyController> ().ResetSize ();
		spider.GetComponent<SpiderController> ().MoveToStartPosition ();



		if (tutEvent != null)
			tutEvent (FINISH_EVENT);

		CancelInvoke ();
		StopAllCoroutines ();

		gameObject.SetActive (false);
	}



	void OnEnable(){
		SpiderController.spiderEvent += SpiderEventHandler;
		BugController.bugEvent += BugEventHandler;

	}
	void OnDisable(){
		SpiderController.spiderEvent -= SpiderEventHandler;
		BugController.bugEvent -= BugEventHandler;
	}*/
}
