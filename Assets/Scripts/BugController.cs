
using UnityEngine;

public class BugController : BugBase {

    
    public override void MoveBug() {

        if ((transform.position - finalPosition).magnitude < 2)
        {
            finalPosition = FindNewPosition();
        }    
        transform.position = Vector3.MoveTowards(transform.position, finalPosition, Time.deltaTime * bugSpeed);
    }

    public override void MoveToSpiderMouth()
    {
        float step = caughtSpeed * Time.deltaTime;

        if ((transform.position - spider.transform.position).magnitude < 0.2f)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,
           spider.transform.position, step);
        }
       
    }

    public override void AttackSpider() {
        Vector3 dirFromAtoB = (transform.position - spider.transform.position).normalized;
        transform.Translate(dirFromAtoB * Time.deltaTime * bugSpeed);
        RotateBug(dirFromAtoB);
    }
    public override void RunAway()
    {
        Vector3 dirFromAtoB = (transform.position - spider.transform.position).normalized;
        transform.Translate(dirFromAtoB * Time.deltaTime * bugSpeed,Space.World);
        RotateBug(-dirFromAtoB);
    }

    Vector3 FindNewPosition()
    {
        Vector3 finalTempPosition = new Vector3();
        finalTempPosition.x = Random.Range(xBounds.x, xBounds.y);
        finalTempPosition.y = Random.Range(yBounds.x, yBounds.y);
        RotateBug(finalTempPosition);
        return finalTempPosition;
    }



    


    	//public enum TypeOfBugs{
     //       Bee,
     //       Fly,
     //       Butterfly,
     //       Beetle

     //   };

     //   public TypeOfBugs thisBug;

     //   Vector3 finalPosition;
     //   public float bugSpeed = 0.02f;
     //   float bugStartSpeed;
     //   float bugCaughtSpeed = 0.05f;
     //   GameObject spider;

     //   float raiseSpeedAmount = 0.02f;
     //   float raiseSpeedTimer = 30f;

     //   int maxBeetleMoves = 4;
     //   int numberBeetleMoves =0 ;

     //   Vector3 spawnPosition;

     //   //MOVEMENT TEST
     //   Vector3 endPoint; 
     //   float duration = 10.0f;		
     //   Vector3 startPoint;  
     //   float startTime ;



     //   //CONDITION
     //   public bool beenEated = false;
     //   public bool canMove = true;
     //   public bool exitScreen = false;
     //   int numberMovesSameSpot = 4;
     //   Vector3 lastSpiderPosition;



     //   //EVENTS
     //   public delegate void BugEvent(string bugEvent,string type);
     //   public static event BugEvent bugEvent;
     //   public const string BUGEATEN_EVENT = "EATED";


     //   public Main mainScript;

     //   public float currentDistance;

     //   // Use this for initialization
     //   void Start () {
     //       finalPosition = transform.position;
     //       bugStartSpeed = bugSpeed;

     //       spider = GameObject.FindGameObjectWithTag("Spider");

     //       startTime = Time.time; 
     //       InvokeRepeating("IncreaseSpeed",30,raiseSpeedTimer);

     //   }

     //   void IncreaseSpeed(){
     //       bugSpeed += raiseSpeedAmount;
     //   }

     //   // Update is called once per frame
     //   void FixedUpdate () {


     //       if (canMove) {

     //           if (!beenEated) {
     //               MoveBug();

     //           } else {
     //               transform.position = Vector2.Lerp (transform.position, spider.transform.position, bugCaughtSpeed);

     //           }



     //       } 
     //       else if (canMove == false && exitScreen == true) {
     //           transform.GetComponent<BoxCollider2D>().isTrigger = false;

     //           if(gameObject.GetComponent<Rigidbody2D>() == null)
     //               gameObject.AddComponent<Rigidbody2D>();

     //           gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

     //           currentDistance = Vector3.Distance(Vector3.zero,transform.position);

     //           if(transform.GetComponent<Renderer>().isVisible == false)
     //           {
     //               //print ("SET FALSE ACTIVE");
     //               gameObject.SetActive(false);
     //               canMove = true;
     //               exitScreen = false;
     //               bugSpeed = bugStartSpeed;


     //           }


     //       }

     //   }




     //   void RemoveRigidBody(){
     //       transform.GetComponent<BoxCollider2D>().isTrigger = true;
     //       Object.Destroy(gameObject.GetComponent<Rigidbody2D>());

     //       gameObject.SetActive(false);


     //   }

     //   void MoveBug ()
     //   {
     //       //SWITCH MOVEMNTS BY TYPE
     //       switch (thisBug) {

     //       case TypeOfBugs.Beetle:
     //           if(numberBeetleMoves < maxBeetleMoves){
     //               if ((transform.position - finalPosition).magnitude < 2) {
     //                   finalPosition.x = Random.Range (10, -10);
     //                   finalPosition.y = Random.Range (-5.5f, 5.5f);			
     //                   numberBeetleMoves ++;
     //                   startTime = Time.time; 
     //               }

     //           }
     //           else {
     //               finalPosition.x = spawnPosition.x;
     //               finalPosition.y = spawnPosition.y;


     //               if(Vector3.Distance(transform.position,finalPosition)< 1.5f)
     //               {

     //                   transform.gameObject.SetActive(false);
     //               }



     //           }

     //           break;

     //       case TypeOfBugs.Fly:
     //           if ((transform.position - finalPosition).magnitude < 2) {
     //               finalPosition.x = Random.Range (10, -10);
     //               finalPosition.y = Random.Range (-5.5f, 5.5f);	
     //               startTime = Time.time; 
     //           }


     //           break;

     //       case TypeOfBugs.Bee:
     //           finalPosition.x = spider.transform.position.x;
     //           finalPosition.y = spider.transform.position.y;		
     //           break;
     //       case TypeOfBugs.Butterfly: 

     //           if ((transform.position - finalPosition).magnitude < 0.5) {
     //               if(numberMovesSameSpot < 4){
     //                   Vector3 newFinalPosition;
     //                   do{
     //                       float newX = Random.Range(-10, 10);
     //                       float newy = Random.Range(-7, 7);

     //                       newFinalPosition = new Vector3(newX,newy,transform.position.z);

     //                   }while(Vector3.Distance(lastSpiderPosition,newFinalPosition) > 2 );
     //                   numberMovesSameSpot ++;


     //                   print (Vector3.Distance(lastSpiderPosition,newFinalPosition));

     //                   finalPosition = newFinalPosition;


     //                   print ("Tansform: " + transform.position + " FinalPosition " + finalPosition);

     //               }
     //               else{
     //                   finalPosition.x = spider.transform.position.x;
     //                   finalPosition.y = spider.transform.position.y;	
     //                   lastSpiderPosition = finalPosition;
     //                   numberMovesSameSpot =0;
     //               }


     //           }



     //           break;



     //       }



     //       //transform.position = Vector2.Lerp (transform.position, finalPosition, bugSpeed);

     //       transform.position = Vector3.MoveTowards (transform.position, finalPosition,Time.deltaTime * bugSpeed);


     //float angle = Mathf.Atan2 ((finalPosition.y - transform.position.y), (finalPosition.x - transform.position.x)) * Mathf.Rad2Deg;
     //       angle -= 90;
     //       transform.rotation = Quaternion.Euler (0, 0, angle);
     //       transform.localScale = new Vector3(1f,1f,1f);


     //       //transform.position = Vector3.Lerp(transform.position, finalPosition, (Time.time - startTime) / bugSpeed); 



           
     //   }

     //   void MoveOutOFScreen ()
     //   {
     //       print ("MOVE OUT OF SCREEN");
     //       int leftOrRight = Random.Range(0,12);
     //       int yPosition = Random.Range(-7,7);	

     //       Vector3 spawnPosition = new Vector3(0,yPosition,0);
     //       if(leftOrRight%2 == 0){
     //           spawnPosition.x = 10;
     //       }else{
     //           spawnPosition.x = -10;
     //       }	

     //       transform.position = spawnPosition;
     //       transform.rotation = Quaternion.identity;

     //       float angle = Mathf.Atan2 ((spawnPosition.y - transform.position.y), (spawnPosition.x - transform.position.x)) * Mathf.Rad2Deg;
     //       angle -= 90;
     //       transform.rotation = Quaternion.Euler (0, 0, angle);

     //       transform.positionTo (500, new Vector3 (spawnPosition.x, spawnPosition.y, 0)).setOnCompleteHandler((x) =>
     //                                                                                    {
     //           canMove = false;
     //           transform.gameObject.SetActive(false);
     //       });	
     //       //transform.eulerAnglesTo(0.2f,


     //   }	

     //   public void MoveToSpider(){

     //       string thisTypeOfBug = "";
     //       transform.tag = "Food";

     //       transform.scaleTo(1,0.6f);
     //       transform.positionTo(0.5f,spider.transform.position).setOnCompleteHandler((x) =>{
     //           gameObject.SetActive(false);



     //           switch (thisBug) {

     //           case TypeOfBugs.Beetle:
     //               thisTypeOfBug = "Beetle";

     //               break;
     //           case TypeOfBugs.Bee:
     //               thisTypeOfBug = "Bee";
     //               break;
     //           case TypeOfBugs.Fly:
     //               thisTypeOfBug = "Fly";
     //               break;
     //           case TypeOfBugs.Butterfly:
     //               thisTypeOfBug = "ButterFly";
     //               break;



     //           }
     //           if (bugEvent != null) {				
     //               bugEvent (BUGEATEN_EVENT, thisTypeOfBug);
     //           }



     //       });	


     //   }

     //   void HandlespiderEvent (string action)
     //   {
     //       if(action == SpiderController.DEAD_EVENT){
     //           canMove = false;
     //           transform.GetComponent<Animator>().SetBool("Fly",false);
     //       }
     //   }

     //   void GameEventHandler (string action)
     //   {
     //       switch (action) {
     //       case Main.CONTINUE_GAME_EVENT:

     //           exitScreen = true;
     //           break;
     //       case Main.RETURN_MENU_EVENT:
     //       case Main.RESTART_GAME_EVENT:
     //           bugSpeed = bugStartSpeed;
     //           canMove = false;
     //           exitScreen = true;
     //           break;

     //       }
     //   }

     //   void OnEnable(){
     //       SpiderController.spiderEvent += HandlespiderEvent;
     //       Main.gameEvent += GameEventHandler;

     //       transform.GetComponent<Animator>().SetBool("Fly",true);

     //       if(thisBug == TypeOfBugs.Butterfly && spider !=null)
     //       {

     //           finalPosition.x = spider.transform.position.x;
     //           finalPosition.y = spider.transform.position.y;	
     //       }



     //       int leftOrRight = Random.Range(0,12);
     //       int yPosition = Random.Range(-7,7);	

     //       spawnPosition = new Vector3(0,yPosition,0);
     //       if(leftOrRight%2 == 0){
     //           spawnPosition.x = 11;
     //       }else{
     //           spawnPosition.x = -11;
     //       }	

     //       transform.position = spawnPosition;
     //       transform.rotation = Quaternion.identity;

     //       numberBeetleMoves = 0;

     //   }

     //   void OnDisable(){
     //       SpiderController.spiderEvent -= HandlespiderEvent;
     //       Main.gameEvent -= GameEventHandler;

     //       transform.GetComponent<BoxCollider2D>().isTrigger = true;
     //       Object.Destroy(gameObject.GetComponent<Rigidbody2D>());

     //       transform.tag = "Bug";
     //       beenEated = false;
     //   }
        

}
