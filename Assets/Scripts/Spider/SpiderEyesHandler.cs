using UnityEngine;
using System.Collections;

public class SpiderEyesHandler : MonoBehaviour {
    Animator eyesAnimator;

    public Sprite[] eyesArray = new Sprite[9];
    SpriteRenderer currentSpriteRenderer;
    
    public float animationTimer = 1f;
    float blinkTime = 0.2f;

    // Use this for initialization
    void Start () {
        eyesAnimator = transform.GetComponent<Animator>();
        currentSpriteRenderer = transform.GetComponent<SpriteRenderer>();

        InvokeRepeating("BlinkEye", 0, animationTimer);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void BlinkEye()
    {
        eyesAnimator.enabled = false;
        int randomFace = Random.Range(0, eyesArray.Length-1);

        currentSpriteRenderer.sprite = eyesArray[randomFace];
        Invoke("StopBlink", blinkTime);

    }

    void StopBlink()
    {
        eyesAnimator.enabled = true;
        currentSpriteRenderer.sprite = eyesArray[0];
    }

    void StartBlinking() {
        CancelInvoke("BlinkEye");
        InvokeRepeating("BlinkEye", 0, animationTimer);
    }

    
    public void Move()
    {       
        eyesAnimator.SetBool("Dead", false);
        eyesAnimator.SetBool("Eating", false);
        StartBlinking();
    }

    public void Eat()
    {
        CancelInvoke("BlinkEye");
        eyesAnimator.enabled = true;
        eyesAnimator.SetBool("Eating", true);
    }

    public void StopEat()
    {
        eyesAnimator.SetBool("Eating", false);
        StartBlinking();
    }

    public void Die()
    {
        CancelInvoke("BlinkEye");
        eyesAnimator.enabled = true;
        eyesAnimator.SetBool("Dead", true);
    }

}
