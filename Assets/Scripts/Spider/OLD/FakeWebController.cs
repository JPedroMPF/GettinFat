using UnityEngine;
using System.Collections;

public class FakeWebController : MonoBehaviour {
	public float fadeSpeed = 1f;
	GoTween tween;

	// Update is called once per frame
	void Shrink () {
		var scaleProperty = new ScaleTweenProperty( new Vector3(0.1f,0.1f, 0.1f ) );
		//var rotateProperty = new EulerAnglesTweenProperty(new Vector3(0f,0f,360f));
		var config = new GoTweenConfig();
		//config.addTweenProperty(rotateProperty);
		config.addTweenProperty( scaleProperty );
		
		tween = new GoTween( transform, fadeSpeed, config );
		
		
		Go.addTween( tween );
	}
	
	void Destroy(){
		Destroy (transform.gameObject);
	}
}
