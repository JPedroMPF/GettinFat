using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BugPooling : MonoBehaviour {

    public static BugPooling current;
    public GameObject bugType1;
    public GameObject bugType2;
    public GameObject bugType3;
    public GameObject bugType4;

    List<GameObject> bugType1Pool;
    int initialSizeType1;
    List<GameObject> bugType2Pool;
 //   int initialSizeType1;
    List<GameObject> bugType3Pool;
    List<GameObject> bugType4Pool;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
