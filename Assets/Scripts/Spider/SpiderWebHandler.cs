using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

public class SpiderWebHandler : MonoBehaviour {

    public float growingSpeed = 8f;
    public float decreaseSpeed = 0.7f;
    float maxSize = 0.6f;
    float minSize = 0.1f;
    float timeToExplode = 2f;
    Vector3 startScale;

    GoTween tween;


    public GameObject fakeWeb;
    

    // Use this for initialization
    void Start () {
        startScale = transform.localScale;
    }
	

    public void Grow() {

        if (tween != null)
            tween.destroy();

        var scaleProperty = new ScaleTweenProperty(new Vector3(maxSize, maxSize, maxSize));
        var config = new GoTweenConfig();
        config.addTweenProperty(scaleProperty);

        tween = new GoTween(transform, growingSpeed, config);
        tween.setOnCompleteHandler(c => {
            StartExplosionEffect();
            Invoke("Explode", timeToExplode);
        });

        Go.addTween(tween);

        Go.to(transform, 5f, new GoTweenConfig()
              .eulerAngles(new Vector3(0, 0, 360))
              .setEaseType(GoEaseType.Linear)
              .setIterations(-1, GoLoopType.RestartFromBeginning)
              );

    }

    private void StartExplosionEffect()
    {
       // transform.GetComponent<Animator>().SetBool("Explode", true);
    }

    private void Explode()
    {
        ResetWeb();
    }

    public void Shrink() {
        tween.destroy();
        transform.scaleTo(decreaseSpeed, minSize).setOnCompleteHandler((x) =>
        {            
            ResetWeb();
            transform.parent.GetComponent<SpiderHandler>().FinishedEating();
        });
    }

    public void ReleaseWeb()
    {        
        GameObject webClone = Instantiate(fakeWeb, transform.position, Quaternion.identity) as GameObject;
        webClone.transform.parent = null;
        webClone.transform.localScale = transform.localScale;
        
        ResetWeb();

    }

    public void ResetWeb()
    {
        tween.destroy();
        transform.localScale = startScale;
        transform.GetComponent<Collider2D>().enabled = false;
      //  transform.GetComponent<Animator>().SetBool("Explode", false);

    }
}
