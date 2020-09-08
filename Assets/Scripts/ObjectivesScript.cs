using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectivesScript : MonoBehaviour {

//	public Main mainScript;

	public static string objective1 = "Eat 5 bees in one game";
	public static string objective2 = "Hold 30seconds without eating anyting";
	public static string objective3 = "Run away for 20 seconds from a butterfly";
	public static string objective4 = "Eat 50 bugs in one minute";
	public static string objective5 = "Explode your web 20 times";
	public static string objective6 = "Eat 20 beetles";
	public static string objective7 = "Eat 100.000 bugs total";

	public static bool objective1Passed = false;
	public static bool objective2Passed = false;
	public static bool objective3Passed = false;
	public static bool objective4Passed = false;
	public static bool objective5Passed = false;
	public static bool objective6Passed = false;
	public static bool objective7Passed = false;


	int startingBeesEaten;

	// Use this for initialization
	void Start () {
	//	startingBeesEaten = mainScript.bees_eaten;
		//print (startingBeesEaten);
	}
	
	// Update is called once per frame
	/*void Update () {
		if(!objective1Passed)
			CheckObjective1 ();

		if(!objective2Passed)
			CheckObjective2 ();

		if(!objective3Passed)
			CheckObjective3 ();

		if(!objective4Passed)
			CheckObjective4 ();

		if(!objective5Passed)
			CheckObjective5 ();

		if(!objective6Passed)
			CheckObjective6 ();

		if(!objective7Passed)
			CheckObjective7 ();

	}*/

	/*void CheckObjective1(){
		if (mainScript.bees_eaten >= startingBeesEaten + 5) {

			objective1Passed = true;
		}
	}

	void CheckObjective2(){
		if(mainScript.bees_eaten >= startingBeesEaten +5)
			print ("PASSED OBEJCTIVE 2");
	}

	void CheckObjective3(){
		if(mainScript.bees_eaten >= startingBeesEaten +5)
			print ("PASSED OBEJCTIVE 3");
	}

	void CheckObjective4(){
		if(mainScript.bees_eaten >= startingBeesEaten +5)
			print ("PASSED OBEJCTIVE 4");
	}

	void CheckObjective5(){
		if(mainScript.bees_eaten >= startingBeesEaten +5)
			print ("PASSED OBEJCTIVE 5");
	}

	void CheckObjective6(){
		if(mainScript.bees_eaten >= startingBeesEaten +5)
			print ("PASSED OBEJCTIVE 6");
	}

	void CheckObjective7(){
		if(mainScript.bees_eaten >= startingBeesEaten +5)
			print ("PASSED OBEJCTIVE 7");
	}*/
}
