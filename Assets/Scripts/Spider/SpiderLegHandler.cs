using UnityEngine;
using System.Collections;

public class SpiderLegHandler : MonoBehaviour {
    Animator legAnimator;
    SpiderCheckMovement legMovementDetector;
    //SPEED
    Vector3 lastPosition = Vector3.zero;
    float objectSpeed;
    float legSpeed = 10f;


    // Use this for initialization
    void Start () {
        legAnimator = transform.GetComponent<Animator>();
        legMovementDetector = transform.GetComponent<SpiderCheckMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (legMovementDetector.IsMoving == true)
        {
            objectSpeed = (transform.parent.position - lastPosition).magnitude;
            lastPosition = transform.parent.position;
            legAnimator.SetFloat("MovementSpeed", objectSpeed * legSpeed);
            legAnimator.SetBool("Walking", true);
        }
        else
        {
            legAnimator.SetBool("Walking", false);
        }
        
    }
    public void Move() {
        legAnimator.SetBool("Walking", true);
    }

    public void Eat() {
        legAnimator.SetBool("Eating", true);
    }

    public void StopEat() {
        legAnimator.SetBool("Eating", false);

    }

    public void Die() {
        legAnimator.SetBool("Dead", true);
    }

    public void Stop() {
        legAnimator.SetBool("Walking", false);

    }
}
