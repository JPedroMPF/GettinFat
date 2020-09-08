using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreIncrement : MonoBehaviour {

//	public Main mainScript;
//	public Text scoreText;

//	public Animator finalBigImageAnimator;
//	public Animation highScoreAnimation;
//	public Text highScoreSmallText;

//	public Button btTryAgain;
//	public Button btSocialScore;

//	public AudioClip[] audiosList;



//	float duration = 1f;


//	int target = 0000;
//	int score = 5000;


//	//this is how much we increment the score every tick - set in the inspector
//	public int ScorePerTick = 1;
	
//	//this is how long we wait between ticks - set in the inspector
//	float TickInterval = 0.0003f;
	
//	void Start(){
//	//	highScoreSmallText.text =mainScript.highScore.ToString("0000");

//		if (GameCenterScript.INTERNET_CONNECTION == false) {
//			btTryAgain.interactable = false;
//			btSocialScore.interactable = false;
//		}
//	}

//	void StartAddingScore()
//	{
//		finalBigImageAnimator.SetBool("highScore",false);
//		scoreText.text = "0000";
//		score = 0;
//	//	target = Main.BUGS_EATEN;


//		float textBaseScoreIncreaseAnimationSpeed = 5.0f;
//		TickInterval = Time.deltaTime / textBaseScoreIncreaseAnimationSpeed;

//		StartCoroutine("CountTo",target);
//	/*	transform.audio.Stop ();
//		transform.GetComponent<AudioSource>().audio.clip = audiosList[0];
//		transform.audio.loop = true;
//		transform.audio.Play();*/

//	}

//	IEnumerator CountTo (int target) {
//		bool highScoreBeaten = false;
//		int start = score;
//		for (float timer = 0; timer <= duration; timer += Time.deltaTime) {
//			float progress = timer / duration;
//			score = (int)Mathf.Lerp (start, target, progress);


//			if (score > mainScript.highScore && highScoreBeaten == false) {					
//				finalBigImageAnimator.SetBool("highScore",true);
//				highScoreBeaten = true;

//				transform.GetComponent<AudioSource>().Stop ();
//				transform.GetComponent<AudioSource>().GetComponent<AudioSource>().clip = audiosList[0];
//				transform.GetComponent<AudioSource>().loop = false;
//				transform.GetComponent<AudioSource>().Play();
//			}
			
			
			
//			scoreText.text = score.ToString("0000");
//			yield return null;
//		}
//		score = target;
//		scoreText.text = score.ToString("0000");

//		if (score > mainScript.highScore && highScoreBeaten == false) {					
//			finalBigImageAnimator.SetBool("highScore",true);
//			highScoreBeaten = true;

//			transform.GetComponent<AudioSource>().Stop ();
//			transform.GetComponent<AudioSource>().GetComponent<AudioSource>().clip = audiosList[0];
//			transform.GetComponent<AudioSource>().loop = false;
//			transform.GetComponent<AudioSource>().Play();
//		}

//		if (score == target && highScoreBeaten) {
//			mainScript.highScore = score;
//			mainScript.Save();
//			highScoreAnimation.Play();
//			highScoreSmallText.text = mainScript.highScore.ToString("0000");
//			transform.parent.SendMessage("AssignLoadedValues");
//			transform.parent.SendMessage("PostHighScoreGoogleBoard");
//			StopCoroutine("CountTo");

//			print ("SAVING");



//		}

//	}
    


//	public IEnumerator Ticker()
//	{
//		bool highScoreBeaten = false;
//		//this loop will run forever so you can just call AddScore and the ticker will continue automatically
//		while (true)
//		{
//			//we don't want to increment CurrentScore to infinity, so we only do it if it's lower than TargetScore
//			if (score < target)
//			{
//				score += ScorePerTick;

//				//this is a 'safety net' to ensure we never exceed our TargetScore
//				if (score > target){
//					score = target;					
//				}

//				scoreText.text = score.ToString("0000");

///*
//				if (score > mainScript.highScore) {					
//					finalBigImageAnimator.SetBool("highScore",true);
//					highScoreBeaten = true;
//				}

				
//				if (score == target && highScoreBeaten) {
//					mainScript.highScore = score;
//					mainScript.Save();
//					highScoreAnimation.Play();
//					highScoreSmallText.text = mainScript.highScore.ToString("0000");
//					transform.parent.SendMessage("AssignLoadedValues");
//					transform.parent.SendMessage("PostHighScoreGoogleBoard");
//					StopCoroutine("Ticker");
//				}
//                */
				

//			}
//			else if(target == score)
//			{
//				StopCoroutine("Ticker");
//				Time.timeScale = 1;
//				print("FINAL");
//			}

//			yield return new WaitForSeconds(TickInterval);
//		}


//	}

}
