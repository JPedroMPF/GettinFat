using UnityEngine;
using System.Collections;
using System;

public class MainMenuScroll : MonoBehaviour {


	float currentSliderPos = 0;
	float lerpAmount = 2f;
	float speed = 2f;
	float wantedPosition = 0.33f;
	string animationName = "MenuScrollAnimation";
	bool activateAnim = false;

	public GameObject spider;

	public GameObject selectedBg;
	Vector3 startPosition;

	public GameObject btHome;
	public GameObject btSettings;
	public GameObject btStats;
	public GameObject btInfo;
    public GameObject btOpenMenu;
    public GameObject leftMenu;

    bool menuOpen = false;


	void Start () {

		SetMenuAnimationParam ();		

		startPosition = btHome.transform.position;

		selectedBg.transform.positionTo (0.3f, btHome.transform.position);

	}
	
	// Update is called once per frame
	void Update () {


		//ANIMAÇAO POR SCROLL
		if(activateAnim == true){

			lerpAmount += Time.deltaTime * speed;

			//sideMenuSelectedSprite.animation[animationName].normalizedTime = Mathf.Lerp(currentSliderPos,wantedPosition,lerpAmount);
			GetComponent<Animation>()[animationName].normalizedTime = Mathf.SmoothStep(currentSliderPos, wantedPosition, lerpAmount);
			GetComponent<Animation>()[animationName].speed = 0f;

			if(GetComponent<Animation>()[animationName].normalizedTime == wantedPosition){


				currentSliderPos = wantedPosition;
				activateAnim = false;
			}
		}
	}

  


	void SetMenuAnimationParam ()
	{
		GetComponent<Animation>()[animationName].enabled = true;
		GetComponent<Animation>()[animationName].weight = 1;
		currentSliderPos = 0;
		GetComponent<Animation>()[animationName].speed = 0f;
	}	
	
	public void HandleClick(string clickedButton){

		
		transform.GetComponent<AudioSource>().Play();
		//ANIMAÇAO POR SCROOLL

		activateAnim = true;
		switch(clickedButton)
		{
            case "btMenu":
                wantedPosition = 0f;

                btOpenMenu.GetComponent<Animation>().Play("btMenuOut");
                leftMenu.SetActive(true);
                leftMenu.GetComponent<Animation>().Play("Enter");
                menuOpen = true;

                break;

            case "btHome":
			    wantedPosition = 0f;

                CloseSideMenu();

               
			break;
			
		case "btSettings":
			wantedPosition = 0.33f;
			selectedBg.transform.positionTo(0.3f,btSettings.transform.position);
			spider.SendMessage("MoveOutOfScreen",0.5f);
			break;
			
		case "btStats":
			wantedPosition = 0.66f;
			selectedBg.transform.positionTo(0.3f,btStats.transform.position);
			spider.SendMessage("MoveOutOfScreen",0.5f);
			break;
			
		case "btInfo":

			wantedPosition = 1f;
			selectedBg.transform.positionTo(0.3f,btInfo.transform.position);
			spider.SendMessage("MoveOutOfScreen",0.5f);
			break;
		}

		lerpAmount=0;
		
		
	}

    public void CloseSideMenu()
    {
        if (menuOpen == true) {

            btOpenMenu.GetComponent<Animation>().Play("btMenuIn");

            if (Vector3.Distance(selectedBg.transform.position, btHome.transform.position) < 50)
            {
                leftMenu.GetComponent<Animation>().Play("Exit");
                menuOpen = false;
                //   spider.SendMessage("MoveToStartPosition");
            }
            else
            {
                selectedBg.transform.positionTo(0.3f, btHome.transform.position).setOnCompleteHandler((x) => {
                    leftMenu.GetComponent<Animation>().Play("Exit");
                    menuOpen = false;
                    //    spider.SendMessage("MoveToStartPosition");	
                });
            }
        }        
    }
}
