using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using System.Net;

public class GUIHandler : MonoBehaviour {
    //SCREENS
    public GameObject mainMenuPanel;
    public GameObject inGamePanel;
    public GameObject inGameBG;

    public void StartGame()
    {
        Main.StartGame();

        transform.SendMessage("CloseSideMenu");
        StartCoroutine(ChangeScreens(inGamePanel, mainMenuPanel, "InGame"));
    }




    IEnumerator ChangeScreens(GameObject menuToShow, GameObject menuToHide, string bgPosition, float waitTime = 0)
    {
        if (menuToHide)
            menuToHide.GetComponent<Animation>().Play("Exit");

        //SHOW NEW SCREEN
        yield return new WaitForSeconds(waitTime);
        menuToShow.SetActive(true);
        menuToShow.GetComponent<Animation>().Play("Enter");

    }



    

        //MAIN OBJECT REFERENCES

        public Main MainScript;
        public GameObject mainCamera;
        Animator mainCameraAnimator;


        //GUI CANVAS
        public GameObject tutorialMenuCanvas;
        public GameObject mainMenuCanvas;

        public GameObject sideMenuCanvas;
        bool sideMenuOpen = false;

        public GameObject inGameMenuCanvas;
        public GameObject bgInGameAndFinalCanvas;
        Animator bgInGameAndFinalAnimator;
        public GameObject adsGameCanvas;
        public GameObject scoreGameCanvas;
        public GameObject pauseMenuCanvas;
        public GameObject tipTextCanvas;

        //BTS
        public GameObject btOpenMenu;

        public GameObject btPause;

        public Button btTryAgain;

        public GameObject flashPanel;




        public Text totalBugsText;
        public Text flysText;
        public Text beesText;
        public Text beaglesText;
        public Text butterFlyText;
        public Text bestTime;
        public Text totalGamesText;



        public Text currentScoreText;
        public Text highScoreText;

        public Text finalScoreText;
        public Text finalHighScoreText;

        int score = 0;
        bool fromPause = false;
        bool adsSeenOnce = false;

        public static GUIHandler Instance;

        void Awake(){
            Instance = this;
        }


    //    void OnEnable(){
    //    Main.gameEvent += Main_gameEvent; ;
    //       // GUITutorial.tutEvent += TutorialEventHandler;
    //        BugController.bugEvent += UpdateScore;

    //    }

    //private void Main_gameEvent(Main.GameState action)
    //{
    //    throw new System.NotImplementedException();
    //}

    //void OnDisable(){
    //        Main.gameEvent -= MainEventHandler;
    //       // GUITutorial.tutEvent -= TutorialEventHandler;
    //        BugController.bugEvent -= UpdateScore;
    //    }



    //    // Use this for initialization
    //    void Start () {
    //        AssignLoadedValues();

    //        #if UNITY_ANDROID

    //            LocalNotification.SendRepeatingNotification(1, 172800, 172800, "Message from Spidy:", "I could really eat one bug or two", new Color32(0xff, 0xe1, 0x1b, 255), false, false, true, "app_icon");
    //        #endif


    //        inGameMenuCanvas.SetActive(false);
    //        bgInGameAndFinalAnimator = bgInGameAndFinalCanvas.GetComponent<Animator> ();
    //        mainCameraAnimator = mainCamera.GetComponent<Animator> ();
    //        adsGameCanvas.SetActive(false);



    //    }


    //    public void AssignLoadedValues ()
    //    {
    //        totalBugsText.text = MainScript.total_bugs_eaten.ToString("000000");
    //        flysText.text = MainScript.flys_eaten.ToString("000000");
    //        beesText.text = MainScript.bees_eaten.ToString("000000");
    //        beaglesText.text = MainScript.beegle_eaten.ToString("000000");
    //        butterFlyText.text = MainScript.butterfly_eaten.ToString("000000");


    //        float savedTime = MainScript.best_Time;
    //        float minutes = savedTime / 60;
    //        float seconds = savedTime % 60;	


    //        bestTime.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
    //        totalGamesText.text = MainScript.total_games.ToString("000000");
    //        highScoreText.text = MainScript.highScore.ToString("0000");
    //        finalHighScoreText.text = MainScript.highScore.ToString("0000");
    //    }

    //    public void OpenSideMenu(){
    //        transform.GetComponent<AudioSource>().Play();
    //        btOpenMenu.GetComponent<Animation>().Play ("btMenuOut");
    //        sideMenuCanvas.SetActive (true);

    //        sideMenuCanvas.GetComponent<Animation>().Play ("SideMenuIn");
    //        sideMenuOpen = true;
    //    }
    //    public void CloseSideMenu(){
    //        btOpenMenu.GetComponent<Animation>().Play ("btMenuIn");
    //        sideMenuCanvas.GetComponent<Animation>().Play ("SideMenuOut");
    //        sideMenuOpen = false;
    //    }



    //    public void UpdateScore (string bugEvent,string type)
    //    {

    //        switch(bugEvent)
    //        {
    //        case BugController.BUGEATEN_EVENT:
    //            score ++;			
    //            if(score> MainScript.highScore)
    //            {
    //                highScoreText.text = score.ToString("0000");

    //                //MainScript.highScore = score;

    //            }
    //            currentScoreText.text = score.ToString("0000");
    //            finalScoreText.text = score.ToString("0000");
    //            break;
    //        }
    //    }

    //    void ShareEventHandler (string action)
    //    {
    //        scoreGameCanvas.GetComponent<Animation>().Play ("scoreScreenOut");
    //        inGameMenuCanvas.SetActive (true);
    //        inGameMenuCanvas.GetComponent<Animation>().Play ("inGameIn");
    //        bgInGameAndFinalAnimator.SetBool ("Down", false);
    //        bgInGameAndFinalAnimator.SetBool ("Pause", false);
    //        mainCamera.GetComponent<Animator> ().SetBool ("blur",false);
    //        Invoke ("FinalMenuBack",3f);
    //    }

    //    void FinalMenuBack(){
    //        mainCamera.GetComponent<Animator> ().SetBool ("blur",true);
    //        scoreGameCanvas.SetActive(true);
    //        scoreGameCanvas.GetComponent<Animation>().Play("scoreScreenIn");
    //        inGameMenuCanvas.GetComponent<Animation>().Play ("inGameOut");
    //        bgInGameAndFinalAnimator.SetBool ("Down", true);
    //        bgInGameAndFinalAnimator.SetBool ("Pause", true);


    //    }



        void TutorialEventHandler (string action)
        {
           /* switch (action) {
                case GUITutorial.FINISH_EVENT:

                StartCoroutine(HideAndShowMenu(inGameMenuCanvas,tutorialMenuCanvas,"null"));

                break;
            }*/
        }



        //void MainEventHandler (string action)
        //{
        //    GameObject screenToHide;
        //    switch (action) {
        //        case Main.START_TUTORIAL_EVENT:	
        //        print("START TUT");


        //            if(Main.GAME_STARTED == false)
        //                StartCoroutine(HideAndShowMenu(tutorialMenuCanvas,mainMenuCanvas,"null"));

        //            break;

        //        case Main.START_GAME_EVENT:
        //       // print("START GAME");

        //            if(sideMenuOpen)
        //                CloseSideMenu();

        //            score = Main.BUGS_EATEN;
        //            currentScoreText.text = score.ToString("0000");	

        //            if(tipTextCanvas.activeSelf)
        //                HideTipText();

        //            CancelInvoke ("ShowTipText");	

        //            StartCoroutine(HideAndShowMenu(inGameMenuCanvas,mainMenuCanvas,"InGame"));

        //            break;
        //        case Main.END_GAME_EVENT:	

        //            fromPause = false;
        //            if(GameCenterScript.INTERNET_CONNECTION == true && adsSeenOnce == false){
        //                StartCoroutine(HideAndShowMenu(adsGameCanvas,inGameMenuCanvas,"FinalGame"));
        //                btTryAgain.interactable = true;
        //            }
        //            else{
        //                btTryAgain.interactable = false;
        //                StartCoroutine(HideAndShowMenu(scoreGameCanvas,inGameMenuCanvas,"FinalGame",0.5f));
        //            }				


        //            break;

        //        case Main.RESTART_GAME_EVENT:
        //            print("RESTART GAME");
        //            adsSeenOnce = false;				
        //            score = Main.BUGS_EATEN;
        //            currentScoreText.text = score.ToString("0000");		

        //            Invoke ("ShowTipText",6f);

        //            if(pauseMenuCanvas.activeSelf)
        //                screenToHide = pauseMenuCanvas;
        //            else
        //                screenToHide = scoreGameCanvas;

        //            if(fromPause)
        //                StartCoroutine(HideAndShowMenu(null,screenToHide,"ResumeGame"));
        //            else
        //                StartCoroutine(HideAndShowMenu(inGameMenuCanvas,screenToHide,"ResumeGame"));

        //        break;

        //        case Main.RETURN_MENU_EVENT:
        //        print("RETURN MENU GAME");
        //            if(tipTextCanvas.activeSelf)
        //                HideTipText();

        //            CancelInvoke ("ShowTipText");

        //            if (inGameMenuCanvas.activeSelf) {
        //                inGameMenuCanvas.GetComponent<Animation>().Play("InGameOut");		
        //            }				

        //            if(pauseMenuCanvas.activeSelf)
        //                screenToHide = pauseMenuCanvas;
        //            else
        //                screenToHide = scoreGameCanvas;

        //            StartCoroutine(HideAndShowMenu(mainMenuCanvas,screenToHide,"MainMenu",1f));				
        //            adsSeenOnce = false;			
        //            break;

        //        case Main.CONTINUE_GAME_EVENT:	
        //        print("CONTINUE GAME");
        //            adsSeenOnce = true;
        //            mainCameraAnimator.SetBool("blur",false);

        //            if(adsGameCanvas.activeSelf)
        //                screenToHide = adsGameCanvas;
        //            else
        //                screenToHide = scoreGameCanvas;

        //            StartCoroutine(HideAndShowMenu(inGameMenuCanvas,screenToHide,"BackToGame",0.7f));

        //        break;

        //        case Main.PAUSE_GAME_EVENT:
        //        print("PAUSE GAME");

        //        StartCoroutine(HideAndShowMenu(pauseMenuCanvas,null, "InPause"));	

        //        fromPause = true;

        //        break;
        //        case Main.RESUME_GAME_EVENT:
        //            print("RESUME GAME");

        //            StartCoroutine(HideAndShowMenu(null,pauseMenuCanvas, "ResumeGame",0.2f));

        //        break;

        //    }
        //}

        IEnumerator HideAndShowMenu(GameObject menuToShow, GameObject menuToHide, string bgPosition, float waitTime = 0){
            //SET ANIMATION NAMES MUST BE SAME AS GAMEOBJECT


            if (menuToHide != null && menuToHide.GetComponent<Animation> () != null) {
                string animationOutName = menuToHide.name + "Out";
                menuToHide.GetComponent<Animation>().Play (animationOutName);
            } else if(menuToHide !=null) {
                menuToHide.GetComponent<Animator>().SetBool("ShowMenu",false);

            }

            //SET BG POSITION
            switch (bgPosition) {
            case "InGame":
                bgInGameAndFinalCanvas.SetActive(true);
                break;
            case "BackToGame":
                bgInGameAndFinalAnimator.SetBool ("UpTillTop", false);
                bgInGameAndFinalAnimator.SetBool ("Pause", false);
                bgInGameAndFinalAnimator.SetBool("Down",false);
                btPause.GetComponent<Animator> ().SetBool ("Paused", false);
                btPause.GetComponent<Button>().interactable = true;
                break;
            case "InPause":
                bgInGameAndFinalAnimator.SetBool("Down",true);
                bgInGameAndFinalAnimator.SetBool("Pause",true);
                bgInGameAndFinalAnimator.SetBool("UpTillTop" , false);

                btPause.GetComponent<Animator> ().SetBool ("Paused", true);
                mainCameraAnimator.SetBool("blur",true);

                break;
            case "ResumeGame":
                bgInGameAndFinalAnimator.SetBool("Pause" , false);
                bgInGameAndFinalAnimator.SetBool("Down" , false);
                mainCameraAnimator.SetBool("blur",false);

                btPause.GetComponent<Animator> ().SetBool ("Paused", false);
                btPause.GetComponent<Button>().interactable = true;
                fromPause = false;
                break;
            case "FinalGame":
                bgInGameAndFinalAnimator.SetBool("Pause" , true);
                bgInGameAndFinalAnimator.SetBool ("Down", true);
                bgInGameAndFinalAnimator.SetBool ("UpTillTop", false);
                mainCameraAnimator.SetBool("blur",true);
                break;
            case "MainMenu":
                bgInGameAndFinalAnimator.SetBool ("UpTillTop", true);
                bgInGameAndFinalAnimator.SetBool ("UpTillEnd", false);			
                bgInGameAndFinalAnimator.SetBool ("Down", false);	
                mainCameraAnimator.SetBool("blur",false);
                break;
            case "BackToFinalScreen":
                bgInGameAndFinalCanvas.SetActive(true);
                bgInGameAndFinalAnimator.SetBool ("Down", true);	
                bgInGameAndFinalAnimator.SetBool ("Pause", true);
                break;
            }


            //SHOW NEW SCREEN
            yield return new WaitForSeconds (waitTime);

            if (menuToShow != null && menuToShow.GetComponent<Animation> () != null) {
                string animationInName = menuToShow.name + "In";
                if(menuToShow.activeSelf == false){
                    menuToShow.SetActive (true);
                    menuToShow.GetComponent<Animation>().Play (animationInName);	
                }
            } else if(menuToShow!=null) {
                if(menuToShow.activeSelf == false){
                    menuToShow.SetActive(true);
                    menuToShow.GetComponent<Animator>().SetBool("ShowMenu",true);
                }
            }

            //SPECIAL OPTIONS ON MENU IN ONLY FOR SOME SCREENS
            if (menuToShow == adsGameCanvas) {
                Invoke("HideAdsCanvas",5f);
            }

            if (menuToShow == inGameMenuCanvas) {
                btPause.GetComponent<Animator> ().SetBool ("Paused", false);
                btPause.GetComponent<Button>().interactable = true;
            }
        }

        void RemoveTutorialCanvas(){
            tutorialMenuCanvas.SetActive(false);
        }

        void ShowTipText(){
            tipTextCanvas.SetActive (true);
            tipTextCanvas.GetComponent<Animation>().Play ("TipTextIn");
        }

        void HideTipText(){
            tipTextCanvas.GetComponent<Animation>().Play ("TipTextOut");
        }

        public void HideAdsCanvas(){
            CancelInvoke("HideAdsCanvas");	
            StartCoroutine(HideAndShowMenu (scoreGameCanvas, adsGameCanvas, "same"));	
        }


        public void TakeScreenShot(){
            StartCoroutine(HideAndShowMenu (inGameMenuCanvas, scoreGameCanvas, "BackToGame"));	
            mainCamera.GetComponent<Animator> ().SetBool ("blur",false);
            flashPanel.SetActive (true);

            Invoke ("ScoreScreenBack", 2f);
        }

        void ScoreScreenBack(){
            mainCamera.GetComponent<Animator> ().SetBool ("blur",true);
            StartCoroutine(HideAndShowMenu (scoreGameCanvas,inGameMenuCanvas , "FinalGame"));	
        }


        public void OpenTwitterURL(string twitter_name){
            switch (twitter_name) {
                case "Joao":
                Application.OpenURL("https://www.linkedin.com/in/jpferreira87");
                    break;
                case "Ze":
                Application.OpenURL("https://www.linkedin.com/pub/jos%C3%A9-torre/21/9b8/397");
                    break;
                case "Marcio":
                Application.OpenURL("https://www.linkedin.com/pub/m%C3%A1rcio-pinto/46/611/4b2");
                    break;
            }

        }
    
}
