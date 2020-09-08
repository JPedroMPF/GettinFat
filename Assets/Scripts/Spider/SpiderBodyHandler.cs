using UnityEngine;
using System.Collections;

public class SpiderBodyHandler : MonoBehaviour {

    Animation bodyAnimation;

    public Sprite[] bodySprites = new Sprite[3];
    Vector3 startPosition;

    float increment;
    float finishScale;

    float localX;
    float localY;
    bool canGrow = true;
    float decreaseAmount = 0.2f;
    float startScale = 1f;

    private GoTween growTween;
    private GoTweenConfig tweenConfig = new GoTweenConfig();


    // Use this for initialization
    void Start () {
        bodyAnimation = transform.GetComponent<Animation>();

        startPosition = transform.localPosition;
        finishScale = 1;


        localX = transform.localScale.x;
        localY = transform.localScale.y;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Contains("Bug"))
        {
            if(col.GetComponent<BugBase>().isEated == false)
                transform.parent.GetComponent<SpiderHandler>().HandleHit(transform.gameObject);
        }
    }

    public void Grow() {

        //HERE I GROW;
        if (growTween != null)
            growTween.pause();

        finishScale += 0.01f;




        Vector3 newScale = new Vector3(finishScale, finishScale, transform.localScale.z);
        var scaleProperty = new ScaleTweenProperty(newScale);

        tweenConfig = new GoTweenConfig();

        //config.setDelay( 1f );
        tweenConfig.addTweenProperty(scaleProperty);

        growTween = new GoTween(transform, 1f, tweenConfig);

        Go.addTween(growTween);

    }

    public void Shrink(float amount = 0.2f)
    {

        float decreaseLocalAmountX = transform.localScale.x * decreaseAmount;
        float decreaseLocalAmountY = transform.localScale.y * decreaseAmount;

        localX = transform.localScale.x - decreaseLocalAmountX;
        localY = transform.localScale.y - decreaseLocalAmountY;

        if (localX < startScale)
        {
            localX = startScale;
            localY = startScale;
        }

        canGrow = false;

        Vector3 newScale = new Vector3(localX, localX, transform.localScale.z);
        transform.scaleTo(4f, newScale).setOnCompleteHandler((x) =>
        {
            canGrow = true;
            finishScale = transform.localScale.x;
        });
    }


    public void ResetSize()
    {
        finishScale = 1;
        localX = startScale;
        localY = startScale;

        canGrow = false;

        Vector3 newScale = new Vector3(localX, localY, transform.localScale.z);
        transform.scaleTo(0.5f, newScale).setOnCompleteHandler((x) =>
        {
            canGrow = true;

        });
    }

    public void DisableCollider() {
        transform.GetComponent<CircleCollider2D>().enabled = false;
    }

    public void EnableCollider()
    {
        transform.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void Eat()
    {
        bodyAnimation.Play("BodyEating");
    }

    public void Die()
    {
       
    }

}
