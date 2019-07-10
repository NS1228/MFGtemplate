using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact_script : MonoBehaviour
{

    public float grednadeTimer;
    public float destroyTimer;
    public GameObject grenadeSpawner;
    // Start is called before the first frame update
    void Start()
    {
        grednadeTimer = Time.time + 4f;
        destroyTimer = Time.time + 4f;

        grenadeSpawner = GameObject.FindGameObjectWithTag("gSpawner");


    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= grednadeTimer)
        {

            grenadeSpawner.GetComponent<Grenade_drop>().grenadeLimit -= 1;
        }

        if(Time.time >= destroyTimer)
        {
            Destroy(this.gameObject);
        } 
        
    }


   // void OnCollisionEnter(Collision other)
   // {
       // if(other.gameObject.name == "Floor")
     //   {
           //grenadeSpawner.GetComponent<Grenade_drop>().grenadeLimit -= 1;
          
         //   Destroy(this.gameObject, 3f);
      //  }
   // }
}
