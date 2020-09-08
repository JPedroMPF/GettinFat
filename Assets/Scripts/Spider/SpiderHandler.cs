using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SpiderHandler : MonoBehaviour {
        
    public GameObject legs;
    SpiderLegHandler legHandlerScript;

    public GameObject body;
    SpiderBodyHandler bodyHandlerScript;

    public GameObject eyes;
    SpiderEyesHandler eyesHandlerScript;

    public GameObject web;
    SpiderWebHandler webHandlerScript;
    SpiderWebCollisionHandler webCollisionHandlerScript;

    //SPEEDS
    [SerializeField]
    protected bool eating;


    
    public bool isEating
    {
        get
        {
            //Some other code
            return eating;
        }
        set
        {
            //Some other code
            eating = value;
        }
    }



    void OnEnable() {
        Main.gameEvent += Main_gameEvent;
    }

    void OnDisable() {
        Main.gameEvent -= Main_gameEvent;
    }

    private void Main_gameEvent(Main.GameState action)
    {
        switch (action)
        {
            case Main.GameState.Loading:
                break;
            case Main.GameState.Menu:
                BlockMovement();
                break;
            case Main.GameState.Tutorial:
                break;
            case Main.GameState.Start:
                AllowMovement();
                break;
            case Main.GameState.Pause:
                BlockMovement();
                break;
            case Main.GameState.Resume:
                break;
            case Main.GameState.End:
                BlockMovement();
                break;
            default:
                break;
        }
    }

    // Use this for initialization
    void Start () {
        GetScriptReferences();
	}

    private void GetScriptReferences()
    {
        webHandlerScript = web.GetComponent<SpiderWebHandler>();
        webCollisionHandlerScript = web.GetComponent<SpiderWebCollisionHandler>();
        legHandlerScript = legs.GetComponent<SpiderLegHandler>();
        eyesHandlerScript = eyes.GetComponent<SpiderEyesHandler>();
        bodyHandlerScript = body.GetComponent<SpiderBodyHandler>();
    }

    // Update is called once per frame
    void Update () {       

       
    }

    public void AllowMovement() {
        transform.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void BlockMovement() {
        transform.GetComponent<CircleCollider2D>().enabled = false;
    }


    public void MovementStarted() {
        webHandlerScript.Grow();
        legHandlerScript.Move();
        eyesHandlerScript.Move();
    }

    public void MovementStoped() {
        webCollisionHandlerScript.CheckCollision();
        legHandlerScript.Stop();
    } 

    public void EatBugs(List<GameObject> eatenBugs)
    {
        isEating = true;
        BlockMovement();
        web.GetComponent<Collider2D>().enabled = false;
        webHandlerScript.Shrink();
        legHandlerScript.Eat();
        eyesHandlerScript.Eat();
        bodyHandlerScript.Eat();

        //foreach (var item in eatenBugs)
        //{
        //    if(item.GetComponent<BugController>()!=null)
        //    {
        //        item.GetComponent<BugController>().MoveToSpider(transform.position);
        //    }
        //}
    }

    public void FinishedEating() {
        isEating = false;
        AllowMovement();
        legHandlerScript.StopEat();
        eyesHandlerScript.StopEat();
    }

    public void NoBugsToEat() {
        webHandlerScript.ReleaseWeb();
    }


    public void HandleHit(GameObject obj) {

        legHandlerScript.Die();
        bodyHandlerScript.Die();
        eyesHandlerScript.Die();

    }


}
