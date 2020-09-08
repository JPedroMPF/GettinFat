using UnityEngine;
using System.Collections;
using System;

public class SpiderMovementHandler : MonoBehaviour {

    //TOUCH
    private float dist;
    private bool dragging = false;
    private Vector3 offset;

    //MOUSE
    Vector3 mousePosition;

    public float movementSpeed = 0.05f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount != 1)
        {
            dragging = false;
            return;
        }
        

        MoveOnTouch();
    }   

    private void MoveOnTouch()
    {
        Vector3 v3;
        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out hit))
            {
                dist = hit.transform.position.z - Camera.main.transform.position.z;
                v3 = new Vector3(pos.x, pos.y, dist);
                v3 = Camera.main.ScreenToWorldPoint(v3);
                offset = transform.position - v3;
                dragging = true;
                transform.GetComponent<SpiderHandler>().MovementStarted();
            }

            

        }
        if (dragging && touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            transform.position = Vector3.Lerp(transform.position, v3 + offset, movementSpeed);

        }
        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
            transform.GetComponent<SpiderHandler>().MovementStoped();
        }
    }

    void OnMouseDown()
    {
        transform.GetComponent<SpiderHandler>().MovementStarted();
    }

    void OnMouseDrag()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, movementSpeed);

    }

    void OnMouseUp(){
        transform.GetComponent<SpiderHandler>().MovementStoped();
    }

   
}
