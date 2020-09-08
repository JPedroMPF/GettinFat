using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Main
{ 
    
      public enum GameState
      {
          Loading,
          Menu,
          Tutorial,
          Start,
          Pause,
          Resume,
          End
      }
      static GameState currentState;

      //EVENTS
      public delegate void GameEvents(GameState action);
      public static event GameEvents gameEvent;     
    
        public static void LoadGame()
        {

            if (gameEvent != null)
            {
                gameEvent(GameState.Loading);
            }

        }

        public static void ShowMenu()
        {
            if (gameEvent != null)
            {
                gameEvent(GameState.Menu);
            }
        }

        public static void StartTutorial()
        {

            if (gameEvent != null)
            {
                gameEvent(GameState.Tutorial);
            }

        }

        public static void StartGame()
        {

            if (gameEvent != null)
            {
                gameEvent(GameState.Start);
            }

        }

        public static void EndGame()
        {

            if (gameEvent != null)
            {
                gameEvent(GameState.End);
            }

        }
}



[Serializable]
class GameData
{
    public int flys_eaten = 0;
    public int bees_eaten = 0;
    public int beegle_eaten = 0;
    public int butterfly_eaten = 0;
    public int total_bugs_eaten = 0;
    public float best_Time = 0f;
    public int total_games = 0;
    public int highScore = 0;
    public bool tutorialSeen = false;
}

/*public enum GameState
  {
      Loading,
      Menu,
      Tutorial,
      Start,
      Pause,
      Resume,
      End
  }
  static GameState currentState;

  //EVENTS
  public delegate void GameEvents(string action);
  public static event GameEvents gameEvent;

  //CONSTS
  public static bool GAME_STARTED = false;
  public static int NUMBER_GAMES = 0;


  //SPAWN BUGS FLYS
  public float SHOW_FINAL_SCREEN_TIMMING = 1.5f;
  public float SPAWN_FLY_TIME = 1;
  public float SPAWN_FLY_REPEATRATE = 2f;
  public float SPAWN_BEE_TIME = 5;
  public float SPAWN_BEE_REPEATRATE = 15f;
  public float SPAWN_BEETLE_TIME = 20;
  public float SPAWN_BEETLE_REPEATRATE = 25f;
  public float SPAWN_BUTTERFLY_TIME = 15;
  public float SPAWN_BUTTERFLY_REPEATRATE = 20f;


  //TIMERS
  public float RESTART_GAME_TIMER = 0.5f;
  float startTime = 0;
  public static float GAME_TIME = 0;

  //MAIN OBJECTS
  public GameObject spider;
  public GameObject btStartTutorial;

  //STARTING VALUES
  public static int BUGS_EATEN;

  //STATS TO SAVE
  public int flys_eaten = 0;
  public int bees_eaten = 0;
  public int beegle_eaten = 0;
  public int butterfly_eaten = 0;
  public int total_bugs_eaten = 0;
  public float best_Time = 0f;
  public int total_games = 0;
  public int highScore = 0;

  public const string START_TUTORIAL_EVENT = "StartTutorial";
  public const string START_GAME_EVENT = "Start";
  public const string END_GAME_EVENT = "End";
  public const string RESTART_GAME_EVENT = "Restart";
  public const string CONTINUE_GAME_EVENT = "Continue";
  public const string RETURN_MENU_EVENT = "Return to menu";
  public const string POWERUP = "PowerUpEvent";
  public const string RESUME_GAME_EVENT = "Resume";
  public const string PAUSE_GAME_EVENT = "Pause";


  //CONDITIONS
  public bool tutorialSeen = false;
  public static bool gamePause = false;




  void OnEnable(){
      BugController.bugEvent += BugEventHandler;
      SpiderController.spiderEvent += SpiderEventHandler;
      //GUITutorial.tutEvent += TutorialEventHandler;
  }
  void OnDisable(){
      BugController.bugEvent -= BugEventHandler;
      //GUITutorial.tutEvent -= TutorialEventHandler;
      SpiderController.spiderEvent -= SpiderEventHandler;
  }

  void Awake() {
      //if (Advertisement.isSupported) {
      //	Advertisement.allowPrecache = false;

      //	#if UNITY_IPHONE
      //	Advertisement.Initialize("80991", false);
      //	#elif UNITY_ANDROID
      //	Advertisement.Initialize("69201", false);
      //	#endif

      //	Debug.Log("PLATFORM SUPPORTED");
      //} else {
      //	Debug.Log("PLATFORM NOT SUPPORTED");
      //}
  }




      void Start () {		
          Load ();

          currentState = GameState.Loading;

          if(tutorialSeen){
              spider.GetComponent<CircleCollider2D>().enabled = true;
              btStartTutorial.SetActive(false);
          }
          else{
              spider.GetComponent<CircleCollider2D>().enabled = false;
              btStartTutorial.SetActive(true);
          }


          //SOCIAL FOR PLAY SERVICES
          //Social.localUser.Authenticate (ProcessAuthentication);

      }	


  public void StartTutorial(){
      btStartTutorial.SetActive (false);
      if (gameEvent != null) {
          gameEvent(START_TUTORIAL_EVENT);
      }		
  }

      public void StartGame (){	
          startTime = Time.time;
          GAME_TIME = 0;
          Init ();
          if (gameEvent != null) {
              gameEvent(START_GAME_EVENT);
          }		
          GAME_STARTED = true;
          NUMBER_GAMES ++;
          total_games ++;
          btStartTutorial.SetActive(false);
  }

      void GameLost ()
      {		
          if (GAME_TIME > best_Time) {
              best_Time = GAME_TIME;
          }

          GUIHandler.Instance.btPause.GetComponent<Animator>().SetBool("Paused",true);
          if (gameEvent != null) {
              gameEvent(END_GAME_EVENT);
          }
  }

  void RestartGame ()
      {
          CancelInvoke("RestartGame");

          BUGS_EATEN =0;
          //REVIVE SPIDER
          if (gameEvent != null) {
              gameEvent(RESTART_GAME_EVENT);
          }


 }	


      void ContinueGame(){
  print ("CONTINUE");
  Init();
  if (gameEvent != null) {
      gameEvent(CONTINUE_GAME_EVENT);
  }
      }


      public void PauseGame(string donext=null){
  if(!gamePause){
      Time.timeScale = 0;
      gamePause = true;


      if (gameEvent != null) {
          gameEvent(PAUSE_GAME_EVENT);
      }

  }
  else{
      StartCoroutine("SetTimeScale",1f);

      gamePause = false;

      if(donext == "continue"){
          if (gameEvent != null) {
              gameEvent(RESUME_GAME_EVENT);
          }
      }
  }
  }

  public IEnumerator SetTimeScale( float delay )
  {
      float start = Time.realtimeSinceStartup;


      while( Time.realtimeSinceStartup < start + delay )
      {

          yield return null;
      }
      Time.timeScale = 1;
      StopCoroutine ("SetTimeScale");

  }



  void Init ()
  {	
      if (SettingsHandler.BABY_MODE == false) {
          InvokeRepeating ("AddMoreBugs", SPAWN_FLY_TIME, SPAWN_FLY_REPEATRATE);	
          InvokeRepeating ("CreateBees", SPAWN_BEE_TIME, SPAWN_BEE_REPEATRATE);
          InvokeRepeating ("CreateButterflys", SPAWN_BUTTERFLY_TIME, SPAWN_BUTTERFLY_REPEATRATE);
          InvokeRepeating ("CreateBeetles", SPAWN_BEETLE_TIME, SPAWN_BEETLE_REPEATRATE);
      } else {
          InvokeRepeating ("AddMoreBugs", SPAWN_FLY_TIME*10, SPAWN_FLY_REPEATRATE*10);	
          InvokeRepeating ("CreateBees", SPAWN_BEE_TIME*10, SPAWN_BEE_REPEATRATE*10);
          InvokeRepeating ("CreateButterflys", SPAWN_BUTTERFLY_TIME*10, SPAWN_BUTTERFLY_REPEATRATE*10);
          InvokeRepeating ("CreateBeetles", SPAWN_BEETLE_TIME*10, SPAWN_BEETLE_REPEATRATE*10);
      }


  }


      void AddMoreBugs(){
         // print (Time.fixedTime);
          FlyPooling.current.SetNewPooledObject();
      }

      void CreateBees ()	{
          GameObject bee = BeePooling.current.GetPooledObject();
          if(bee == null) return;
          bee.SetActive(true);
      }

      void CreateBeetles (){
          GameObject beetle = BeetlePooling.current.GetPooledObject();		
          if(beetle == null) return;		
          beetle.SetActive(true);		
      }

      void CreateButterflys (){
          GameObject butterfly = ButterflyPooling.current.GetPooledObject();		
          if(butterfly == null) return;
          butterfly.SetActive(true);		
      }	

      void CreateFlys (){
          GameObject bug = FlyPooling.current.GetPooledObject();		
          if(bug == null) return;
          bug.SetActive(true);			
      }

      void BugEventHandler(string bugEvent, string type){

          switch(bugEvent)
          {
              case BugController.BUGEATEN_EVENT:
                  BUGS_EATEN ++;
                  total_bugs_eaten ++;

              switch(type){
                  case "Beetle":
                      beegle_eaten ++;
                      if (gameEvent != null) {
                          gameEvent(POWERUP);
                      }
                      break;
                  case "Bee":
                      bees_eaten ++;
                      break;
                  case "Fly":
                      flys_eaten ++;
                      break;
                  case "ButterFly":
                      butterfly_eaten ++;
                      break;
                  }


              break;
          }
      }


      void TutorialEventHandler (string action)
      {
          tutorialSeen = true;
          StartGame ();

          spider.GetComponent<SpiderController> ().MoveToStartPosition();

          if (gameEvent != null) {
              gameEvent(START_GAME_EVENT);
          }

  }



  void SpiderEventHandler (string action)
  {

      switch (action) {
          case SpiderController.DEAD_EVENT:
              Save();
              CancelInvoke("AddMoreBugs");
              CancelInvoke ("CreateBees");
              CancelInvoke ("CreateButterflys");
              CancelInvoke ("CreateBeetles");
          GUIHandler.Instance.btPause.GetComponent<Button>().interactable = false;
              Invoke("GameLost",SHOW_FINAL_SCREEN_TIMMING);

              break;

          case SpiderController.TOUCH_DRAG_EVENT:
              if(tutorialSeen && GAME_STARTED == false)
                  StartGame();
              break;	
      }
  }

  public void OnFinalScreenBtClick(string clickedButton){

  switch (clickedButton) {
      case "btShowAd":

      if(Advertisement.isReady()){
          Debug.Log("ADVERTISEMENT READY");
          Advertisement.Show(null, new ShowOptions {
              pause = false,
              resultCallback = result => {
                  AdResultHandler(result);
              }
          });			
      }
      break;
      case "btHome":
          GAME_STARTED = false;
          if (gameEvent != null) {
              gameEvent(RETURN_MENU_EVENT);
          }
          BUGS_EATEN =0;	

      Time.timeScale = 1;

          CancelInvoke("AddMoreBugs");
          CancelInvoke ("CreateBees");
          CancelInvoke ("CreateButterflys");
          CancelInvoke ("CreateBeetles");
          break;
      case "btRestart":
      Time.timeScale = 1;
          GAME_STARTED = false;
          CancelInvoke("AddMoreBugs");
          CancelInvoke ("CreateBees");
          CancelInvoke ("CreateButterflys");
          CancelInvoke ("CreateBeetles");
          Invoke("RestartGame",RESTART_GAME_TIMER);
          break;



  }


      }



  void AdResultHandler(ShowResult result){
      switch (result) {
      case ShowResult.Finished:
          Invoke("ContinueGame",0.5f);
          break;

      case ShowResult.Failed:
          Invoke("RestartGame",0.5f);
          break;
      }
  }



  void ProcessAuthentication (bool success) {
  if (success) {
      Debug.Log ("Authenticated, checking achievements");

      // Request loaded achievements, and register a callback for processing them
     // Social.LoadAchievements (ProcessLoadedAchievements);
  }
  else
      Debug.Log ("Failed to authenticate");
      }



      public void Save()
      {
          BinaryFormatter binFile = new BinaryFormatter();
          FileStream file = File.Create(Application.persistentDataPath + "/gamedata.dat");
          GameData data = new GameData();
          data.flys_eaten = flys_eaten;
          data.bees_eaten = bees_eaten;
          data.beegle_eaten = beegle_eaten;
          data.butterfly_eaten = butterfly_eaten;
          data.total_bugs_eaten = total_bugs_eaten;
          data.best_Time = best_Time;
          data.total_games = total_games;
          data.highScore = highScore;
          data.tutorialSeen = tutorialSeen;

          binFile.Serialize(file,data);
          file.Close();
      }

      public void Load()
      {

          if(File.Exists(Application.persistentDataPath + "/gamedata.dat"))
          {
              BinaryFormatter binFile = new BinaryFormatter();
              FileStream file = File.Open(Application.persistentDataPath + "/gamedata.dat",FileMode.Open);
              GameData data = (GameData)binFile.Deserialize(file);
              file.Close();

              total_bugs_eaten = data.total_bugs_eaten;
              flys_eaten = data.flys_eaten;
              bees_eaten = data.bees_eaten;
              beegle_eaten = data.beegle_eaten;
              butterfly_eaten = data.butterfly_eaten;
              best_Time = data.best_Time;
              total_games = data.total_games;
              highScore = data.highScore;
              tutorialSeen = data.tutorialSeen;

          //	print ("HIGHSCORE ON LOAD :" + highScore);

          }
      }

  */
