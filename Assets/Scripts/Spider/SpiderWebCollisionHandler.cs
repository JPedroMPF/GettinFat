using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderWebCollisionHandler : MonoBehaviour {

    List<GameObject> eatenBugs = new List<GameObject>();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CheckCollision() {
        transform.GetComponent<Collider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Contains("Bug"))
        {
            col.transform.GetComponent<BugBase>().isEated = true;
            eatenBugs.Add(col.gameObject);
        }
        else if (col.tag.Contains("Ground"))
        {
            Invoke("CheckIfEaten", 0.1f);
        }        
    }

    public void CheckIfEaten()
    {
        if (eatenBugs.Count > 0){
            transform.parent.GetComponent<SpiderHandler>().EatBugs(eatenBugs);
        }
        else{
            transform.parent.GetComponent<SpiderHandler>().NoBugsToEat();
        }
    }
}
