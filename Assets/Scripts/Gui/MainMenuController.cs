using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour {
/*
	public GameObject sideMenu;
	public GameObject btMenu;
	public GameObject spider;

	public GameObject sideMenuSelectedSprite;

	SpiderController spiderController;

	//SETTINGS SCREENS;
	public GameObject homeScreen;
	public GameObject settingsMenu;
	public GameObject statsMenu;
	public GameObject infoMenu;

	public GameObject btInfo;
	public GameObject btSettings;
	public GameObject btStats;
	public GameObject btHome;

	GameObject currentMenu;

	//ANIMATION VIA SCROLL
	/*float sliderPos = 0;
	float currentSliderPos = 0;
	float lerpAmount = 2f;
	float speed = 2f;
	float wantedPosition = 0.33f;
	string animationName = "sideMenuSelectedAnim";
	bool activateAnim = false;*/

	/*
	// Use this for initialization
	void Start () {
		homeScreen.SetActive (true);
		sideMenu.SetActive(false);
		settingsMenu.SetActive(false);
		statsMenu.SetActive(false);
		infoMenu.SetActive(false);


		/*sideMenuSelectedSprite.animation[animationName].enabled = true;
		sideMenuSelectedSprite.animation[animationName].weight = 1;
		currentSliderPos = 0;
		sideMenuSelectedSprite.animation[animationName].speed = 0f;*/

		//spiderController = spider.GetComponent<SpiderController>();
	//}
	
	// Update is called once per frame
	void Update () {

		//ANIMAÇAO POR SCROLL
		/*if(activateAnim == true){

			lerpAmount += Time.deltaTime * speed;

			//sideMenuSelectedSprite.animation[animationName].normalizedTime = Mathf.Lerp(currentSliderPos,wantedPosition,lerpAmount);
			sideMenuSelectedSprite.animation[animationName].normalizedTime = Mathf.SmoothStep(currentSliderPos, wantedPosition, lerpAmount);
			sideMenuSelectedSprite.animation[animationName].speed = 0f;

			if(sideMenuSelectedSprite.animation[animationName].normalizedTime == wantedPosition){
				if(wantedPosition == 0)
					sideMenuSelectedSprite.SetActive(false);

				currentSliderPos = wantedPosition;
				activateAnim = false;
			}
		}*/
	}
    /*

	public void HandleClick(string clickedButton){
		switch(clickedButton)
		{
		case "btMenu":
			
			//btMenu.animation.Play("btMenu");
			sideMenu.SetActive(true);
			sideMenu.GetComponent<Animation>().Play("SideMenuIn");
			currentMenu = homeScreen;

			break;
		case "btHome":
			//if(currentMenu != homeScreen)
			//	StartCoroutine(ShowNewScreen(currentMenu,homeScreen,0.5f));

			//btMenu.animation.Play("btMenuOn");
			sideMenu.GetComponent<Animation>().Play("SideMenuOut");
			//spiderController.MoveToStartPosition();

			//Vector3 newPosition = btHome.transform.position;
			//newPosition.x -=50000;

			//sideMenuSelectedSprite.transform.positionTo(0.3f,newPosition);

			break;
			
		case "btSettings":
			if(currentMenu != settingsMenu)
				StartCoroutine(ShowNewScreen(currentMenu,settingsMenu,0.5f));
			spiderController.MoveOutOfScreen(1.33f);

			sideMenuSelectedSprite.transform.positionTo(0.3f,btSettings.transform.position);

			break;
			
		case "btStats":
			if(currentMenu != statsMenu)
				StartCoroutine(ShowNewScreen(currentMenu,statsMenu,0.5f));

			spiderController.MoveOutOfScreen(0.66f);

			sideMenuSelectedSprite.transform.positionTo(0.3f,btStats.transform.position);

			break;
			
		case "btInfo":
			if(currentMenu != infoMenu)
				StartCoroutine(ShowNewScreen(currentMenu,infoMenu,0.5f));

			spiderController.MoveOutOfScreen(0.33f);

			sideMenuSelectedSprite.transform.positionTo(0.3f,btInfo.transform.position);

			break;
		}


		//ANIMAÇAO POR SCROOLL
	/*	activateAnim = true;
		switch(clickedButton)
		{
		case "btMenu":
			activateAnim = false;
			sideMenuSelectedSprite.SetActive(true);
			//btMenu.animation.Play("btMenu");
			//sideMenu.SetActive(true);
			//sideMenu.animation.Play("SideMenuIn");
			break;
		case "btHome":
			//btMenu.animation.Play("btMenuOn");
			//sideMenu.animation.Play("SideMenuOut");
			//
			wantedPosition = 0f;


			break;
			
		case "btSettings":
			wantedPosition = 0.33f;
		
			break;
			
		case "btStats":
			wantedPosition = 0.66f;

			//spiderController.MoveOutOfScreen(0.66f);
			break;
			
		case "btInfo":

			wantedPosition = 1f;

			break;
		}

		lerpAmount=0;*/


	//}


	/*IEnumerator ShowNewScreen(GameObject screenToHide, GameObject screenToShow,float time){
		
		string animationOutName = screenToHide.name + "Out";
		string animationInName = screenToShow.name + "In";
		screenToHide.GetComponent<Animation>().Play (animationOutName);
		
		yield return new WaitForSeconds(time);
		screenToHide.SetActive (false);
		screenToShow.SetActive (true);
		screenToShow.GetComponent<Animation>().Play (animationInName);
		currentMenu = screenToShow;
	}*/

	//CLICK PARA ANIMAÇAO POR SCROLL
	/*public void HandleClick(string clickedButton){
		switch(clickedButton)
		{
		case "btMenu":

			//btMenu.animation.Play("btMenu");
			//sideMenu.SetActive(true);
			//sideMenu.animation.Play("SideMenuIn");
			break;
		case "btHome":
			//btMenu.animation.Play("btMenuOn");
			//sideMenu.animation.Play("SideMenuOut");
			//
			activateAnim = true;
			wantedPosition = 0f;
			lerpAmount=0;
			//spiderController.MoveToStartPosition();
			break;
			
		case "btSettings":
			activateAnim = true;
			wantedPosition = 0.33f;
			lerpAmount =0;
			//spiderController.MoveOutOfScreen(1.33f);
			break;
			
		case "btStats":
			activateAnim = true;
			wantedPosition = 0.66f;
			lerpAmount =0;
			//spiderController.MoveOutOfScreen(0.66f);
			break;
			
		case "btInfo":
			activateAnim = true;
			wantedPosition = 1f;
			lerpAmount=0;
			//spiderController.MoveOutOfScreen(0.33f);
			break;
		}
	}*/

}
