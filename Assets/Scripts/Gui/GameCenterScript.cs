using UnityEngine;
using UnityEngine.UI;
using System.Net;
public class GameCenterScript : MonoBehaviour {
	//MAIN REFERENCES
//	public Main mainScript;
	
	//STATIC VARS
	public static bool INTERNET_CONNECTION = false;
	
	
	//UI DEPENDENT
	public Button btSocialHS_MainMenu;
	public Button btSocialHS_ScoreScreen;

	public string googleLeaderBoardID = "CgkIgI-RwOYJEAIQAQ";
	public string iosLeaderBoardID = "com.lazybug.gettinfat";
	
	
	
	// Use this for initialization
	void Start () {
		//InvokeRepeating ("CheckForInternetConnection",0, 300);

		CheckForInternetConnection ();
		
		#if UNITY_IPHONE
		if(INTERNET_CONNECTION == true)
			InitIOSGameService();
		#elif UNITY_ANDROID
		if(INTERNET_CONNECTION == true){
			
			InitGoogleGameService();
		}
		
		#endif
		
		//print (INTERNET_CONNECTION + "INTERNET");
		
	}
	
	
	
	void InitIOSGameService(){


		Social.localUser.Authenticate((bool success) =>
		                              {
			if (success)
			{
				Debug.Log("You've successfully logged in");
				
			}
			else
			{
				Debug.Log("Login failed for some reason");
				
			}
		});
	}
	
	void InitGoogleGameService(){
		
		/*PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			// enables saving game progress.
			.EnableSavedGames()
				
				.Build();
		
		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		
		Social.localUser.Authenticate((bool success) =>
		                              {
			if (success)
			{
				//Debug.Log("You've successfully logged in");
				
			}
			else
			{
				//	Debug.Log("Login failed for some reason");
				
			}
		});*/
		
	}



	public void PostHighScoreGoogleBoard(){
		#if UNITY_IPHONE || UNITY_IPAD

		/*if(Social.localUser.authenticated){
			Social.ReportScore(Main.high,iosLeaderBoardID,(bool success) => {
				if(success)
				{
					Debug.Log("HIGHSCOREPOSTED");
				}
				else{
					Debug.Log("ËRROR ON HIGHSCORE POST");
				}
			});
		}*/

		#elif UNITY_ANDROID
	/*	Social.ReportScore(mainScript.highScore, googleLeaderBoardID, (bool success) => {
			// handle success or failure
		});*/
		

		
		#endif


	}
	
	public void ShowHighScoreGoogleBoard(){
		#if UNITY_IPHONE || UNITY_IPAD
		if(Social.localUser.authenticated){
			Social.ShowLeaderboardUI();
		}

		else{
			Social.localUser.Authenticate((bool success) =>
			                              {
				if (success)
				{
					Debug.Log("You've successfully logged in");
					
				}
				else
				{
					Debug.Log("Login failed for some reason");
					
				}
			});	
		}

		#elif UNITY_ANDROID
		/*if(PlayGamesPlatform.Instance.IsAuthenticated())
			PlayGamesPlatform.Instance.ShowLeaderboardUI(googleLeaderBoardID);
		else
			Social.localUser.Authenticate((bool success)=>{
				PlayGamesPlatform.Instance.ShowLeaderboardUI(googleLeaderBoardID);
			});*/
			
		#endif


		
		
	}
	
	bool CheckForInternetConnection()
	{
		try {
			using (var client = new WebClient())
			using (var stream = client.OpenRead("http://www.google.com")) {
				INTERNET_CONNECTION = true;
				return true;
				
				SetButtonsInternetDependent (true);
			}
		} catch {
			INTERNET_CONNECTION = false;
			SetButtonsInternetDependent (false);
			return false;
		}
	}
	
	void SetButtonsInternetDependent(bool newState){
		btSocialHS_MainMenu.interactable = newState;
		btSocialHS_ScoreScreen.interactable = newState;
	}

}
