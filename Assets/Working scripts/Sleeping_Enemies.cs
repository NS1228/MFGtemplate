using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeping_Enemies : MonoBehaviour
{
    public Transform Player;
    public GameObject player;
    public float range = 20;
    public bool inRange;

   
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //stunDMG = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        // Sleep();

        //  float distance = Vector3.Distance(gameObject.transform.position, Player.position);
        /* if(distance <= range)
           {
               inRange = true;
           }
         if(distance > range)
           {
              inRange = false;
           } */

      

        

        if (Vector3.Distance(gameObject.transform.position, Player.position) <= range)
        {
            inRange = true;
            
            

        }
        if (Vector3.Distance(transform.position, Player.position) > range)
        {
            inRange = false;
           
        }

        if (player.GetComponent<Enemy_Sleeper>().HackThem == true && inRange)
        {
            this.GetComponent<Ranged_enemyMovement>().enabled = false;
            this.GetComponent<Ranged_enemyFire>().enabled = false;
           
           
            

        }

        if (player.GetComponent<Enemy_Sleeper>().HackThem == false)
        {
            gameObject.GetComponent<Ranged_enemyMovement>().enabled = true;
            gameObject.GetComponent<Ranged_enemyFire>().enabled = true;

          

        }

     
       
     
       


        

    


    }

 
}
