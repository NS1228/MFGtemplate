using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact_script : MonoBehaviour
{

    public float grednadeTimer;
    public float destroyTimer;
    public GameObject grenadeSpawner;

    public bool canDrop;
    public bool canDie;

    // Start is called before the first frame update
    void Start()
    {
        grednadeTimer = Time.time + 9.59f;
        destroyTimer = Time.time + 6f;

        grenadeSpawner = GameObject.FindGameObjectWithTag("gSpawner");
        canDrop = true;
        canDie = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= grednadeTimer && canDrop)
        {

            grenadeSpawner.GetComponent<Grenade_drop>().grenadeLimit -= 1;
            canDrop = false;
        }

        if(Time.time >= destroyTimer && canDie)
        {
             Destroy(this.gameObject);
            grenadeSpawner.GetComponent<Grenade_drop>().grenadeLimit -= 1;
            canDie = false;
            // this.GetComponent<Greande_Kill>().timetoBlow = true;

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
