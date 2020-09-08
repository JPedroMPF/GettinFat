using UnityEngine;
using System.Collections;
using System;

public abstract class BugBase : MonoBehaviour {

    protected Vector3 startPosition;
    protected Vector3 finalPosition;
    protected GameObject spider;

    protected Vector2 xBounds = new Vector2(-10f, 10f);
    protected Vector2 yBounds = new Vector2(-5.5f, 5.5f);


    //TWEENS
    protected GoTween moveRandomTween;
    protected GoTween moveToSpiderTween;


    //SPEEDS
    [SerializeField]
    protected float bugSpeed = 0.02f;
    [SerializeField]
    protected float bugStartSpeed;

    [SerializeField]
    protected float bugCaughtSpeed = 0.05f;
    public float caughtSpeed
    {
        get
        {
            //Some other code
            return bugCaughtSpeed;
        }
    }

    [SerializeField]
    protected float raiseSpeedAmount;

    //CONDITIONS
    bool exitScreen = false;

    [SerializeField]
    protected bool canMove;



    [SerializeField]
    protected bool beenEated;

    public bool isEated
    {
        get
        {
            //Some other code
            return beenEated;
        }
        set
        {
            //Some other code
            beenEated = value;
        }
    }

    CustomSpiderJPTree tree;

    void OnEnable()
    {
        Main.gameEvent += Main_gameEvent;
    }

    void OnDisable()
    {
        Main.gameEvent -= Main_gameEvent;
    }

    private void Main_gameEvent(Main.GameState action)
    {
        switch (action)
        {
            case Main.GameState.Loading:
                break;
            case Main.GameState.Menu:
                //BlockMovement();
                break;
            case Main.GameState.Tutorial:
                break;
            case Main.GameState.Start:
                canMove = true;
                break;
            case Main.GameState.Pause:
                canMove = false;
                break;
            case Main.GameState.Resume:
                break;
            case Main.GameState.End:
                canMove = false;
                break;
            default:
                break;
        }
    }

    

    void Start()
    {
        finalPosition = transform.position;
        bugStartSpeed = bugSpeed;
        spider = GameObject.FindGameObjectWithTag("Spider");

        tree = new CustomSpiderJPTree(spider,gameObject);
    }

    void Update()
    {
        tree.StartTree();

        
/*
         if (canMove)
         {
             if (!beenEated)
             {
                 MoveBug();
             }
         }
         else if (canMove == false && exitScreen == true)
         {
            AssignRigidBody();

            
         }*/
    }

    private void AssignRigidBody()
    {
        transform.GetComponent<BoxCollider2D>().isTrigger = false;

        if (gameObject.GetComponent<Rigidbody2D>() == null)
            gameObject.AddComponent<Rigidbody2D>();

        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

        //  currentDistance = Vector3.Distance(Vector3.zero, transform.position);

        if (transform.GetComponent<Renderer>().isVisible == false)
        {
            //print ("SET FALSE ACTIVE");
            gameObject.SetActive(false);
            canMove = true;
            exitScreen = false;
            bugSpeed = bugStartSpeed;
        }
    }

    public abstract void MoveBug();

    public abstract void RunAway();

    public abstract void MoveToSpiderMouth();

    public abstract void AttackSpider();

    protected void RotateBug(Vector3 targetPosition)
    {
        float angle = Mathf.Atan2((targetPosition.y - transform.position.y), (targetPosition.x - transform.position.x)) * Mathf.Rad2Deg;
        angle -= 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

   
    void MoveOutOfScreen()
    {
        transform.GetComponent<BoxCollider2D>().isTrigger = false;
        if (gameObject.GetComponent<Rigidbody2D>() == null)
            gameObject.AddComponent<Rigidbody2D>();

        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

    }

    void IncreaseSpeed()
    {
        bugSpeed -= raiseSpeedAmount;
    }

    //TWEEN EVENTS HANDLERS
    protected void OnPathFinish(AbstractGoTween obj)
    {
        MoveBug();
    }


}
