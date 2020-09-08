using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSpiderJPTree : SpiderJPTree {

    GameObject spider;
    GameObject web;
    GameObject thisBug;


    public CustomSpiderJPTree(GameObject spiderIN, GameObject bugIN)
    {
        thisBug = bugIN;
        spider = spiderIN;
    }

   
    protected override Func<bool> Eaten()
    {
        return new Func<bool>(() => {
           if (thisBug.GetComponent<BugController>().isEated == false)
                return false;
            else
                return true;
        });
    }

    protected override DTAction MoveToSpider()
    {
        return new DTAction(() =>
        {
            Debug.Log("Foste comido");
            thisBug.GetComponent<BugBase>().MoveToSpiderMouth();
            
        });
    }

    protected override Func<bool> SpiderEating()
    {

        return new Func<bool>(() => {
            if (spider.GetComponent<SpiderHandler>().isEating)
                return true;
            else
                return false;
        });
    }

    protected override Func<bool> RotatedToSpider()
    {
        return new Func<bool>(() => {

            Vector3 dirFromAtoB = (thisBug.transform.position - spider.transform.position).normalized;
            float dotProd = Vector3.Dot(dirFromAtoB, thisBug.transform.up);
         
            if (dotProd < -0.9)
            {   
                return true;
            }
            else
            {
                return false;
            }
        });
    }



    protected override DTAction Atack()
    {

        return new DTAction(() => MyAttack());
    }
    void MyAttack()
    {
        Debug.Log("Ataca ");
        thisBug.GetComponent<BugBase>().AttackSpider();

    }

    protected override DTAction Move()
    {

        return new DTAction(() => {
            Debug.Log("Anda livremente ");
            thisBug.GetComponent<BugBase>().MoveBug();
        });

    }
    

    protected override Func<bool> CloseToWeb()
    {
        return new Func<bool>(() => {
            Vector3 bugPos = thisBug.GetComponent<Transform>().position;
            Vector3 spiderPos = spider.GetComponent<Transform>().position;

            if (Vector3.Distance(bugPos, spiderPos) < 5)
            {
                return true;
            }
            else
                return false;
        });
    }


    protected override DTAction Run()
    {
        return new DTAction(() => {
            Debug.Log("Foge ");
            thisBug.GetComponent<BugBase>().RunAway();
        });
    }

   
}
