using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		/*Go.to(transform, 3f, new GoTweenConfig()
		      .eulerAngles(new Vector3(0,0,10))
		    
		    
		      );*/
		
		/*Go.to( transform, 3f, new GoTweenConfig()
		      .eulerAngles(new Vector3(0,0,360))
		      .setIterations( -1 ,GoLoopType.RestartFromBeginning)
		      );*/

		/*var rotateProperty = new EulerAnglesTweenProperty(new Vector3(0f,0f,360f));
		var config = new GoTweenConfig();
		config.addTweenProperty(rotateProperty);
		
		var tween = new GoTween( transform, 5f, config );
		
		
		Go.addTween( tween );*/


		StartCoroutine( RepeatingFunction() );
			

	}

	IEnumerator RepeatingFunction () { 
		while(true) { 
			print ("BU");
			yield return new WaitForSeconds(2f); 
		} 
	}
	// Update is called once per frame
	void Update () {

	}
}
