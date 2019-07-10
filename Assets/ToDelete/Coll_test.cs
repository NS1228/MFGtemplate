using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_test : MonoBehaviour
{

    private bool triggercheck;
    // Start is called before the first frame update
    void Start()
    {
        triggercheck = true;
    }

    // Update is called once per frame
    void Update()
    {
       if(triggercheck)
        {
            //this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
        if (!triggercheck)
        {
         this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }


    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            triggercheck = false;
            
            print("YES");
        }
       
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           triggercheck = true;
            print("No");

}


    }

    }
