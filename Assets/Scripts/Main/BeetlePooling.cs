using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeetlePooling : MonoBehaviour {


	//public static BeetlePooling current;
	//public GameObject pooledObject;
	//public int listSize = 10;
	//public int  startingPooledAmount = 0;
	//public bool willGrow = false;
	//List<GameObject> pooledObjects;
	
	//void Awake(){
	//	current = this;
	//}
	//// Use this for initialization
	//void Start () {
	//	BugController beetleScript = pooledObject.GetComponent<BugController>() as BugController;
		
	//	pooledObjects = new List<GameObject>();
	//	for(int i = 0; i< listSize; i ++)
	//	{
	//		GameObject bug = (GameObject)Instantiate(pooledObject);
	//		beetleScript.thisBug = BugController.TypeOfBugs.Beetle;
	//		bug.SetActive(false);
	//		pooledObjects.Add(bug);
	//	}
	//}
	
	//public GameObject GetPooledObject(){
	//	for(int i = 0; i< pooledObjects.Count;i++){
	//		if(!pooledObjects[i].activeInHierarchy)
	//		{
	//			return pooledObjects[i];
	//		}
	//	}		
		
	//	return null;
	//}
	
	//public void SetNewPooledObject(){
	//	for(int i = 0; i< pooledObjects.Count;i++){
	//		if(!pooledObjects[i].activeInHierarchy)
	//		{
	//			pooledObjects[i].SetActive(true);
	//			return;
	//		}
	//	}
		
	//}
}
