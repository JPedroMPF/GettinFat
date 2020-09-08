using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyPooling : MonoBehaviour {
	
public static FlyPooling current;
	public GameObject pooledObject;
	public int listSize = 100;
	public int  startingPooledAmount = 10;
	public bool willGrow = false;
	List<GameObject> pooledObjects;

	int bugNumber = 0;
	void Awake(){
		current = this;
	}
	// Use this for initialization
	void Start () {
		BugController beeScript = pooledObject.GetComponent<BugController>() as BugController;

		pooledObjects = new List<GameObject>();
		for(int i = 0; i< listSize; i ++)
		{
			GameObject bug = (GameObject)Instantiate(pooledObject);
			//beeScript.thisBug = BugController.TypeOfBugs.Fly;
			bug.SetActive(false);
			bug.name = "Bug" + i.ToString();


			pooledObjects.Add(bug);
		}
		bugNumber = startingPooledAmount;
	}

	

	void MainEventHandler (string action)
	{
		/*switch (action) {
			case Main.RETURN_MENU_EVENT:
			case Main.RESTART_GAME_EVENT:	
				bugNumber = startingPooledAmount;

				break;
		case Main.CONTINUE_GAME_EVENT:
			bugNumber = (bugNumber*2)/3;
			break;
		}*/
	}



	public GameObject GetPooledObject(){
		for(int i = 0; i< bugNumber;i++){
			if(!pooledObjects[i].activeInHierarchy)
			{
			
				return pooledObjects[i];
			}
		}		


		return null;
	}


	
	public void SetNewPooledObject(){
		if (pooledObjects [bugNumber] != null) {
			pooledObjects[bugNumber].SetActive(true);
			bugNumber ++;

		}

	}

    
}
