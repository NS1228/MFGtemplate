using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sleeping_Enemies : MonoBehaviour
{
    public Transform Player;
    public GameObject player;
    public float range = 20;
    public bool inRange;

    Animator anim;

    public bool takeSleepDMG;
    public float dmgTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //stunDMG = false;
        anim = this.GetComponent<Animator>();
       
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

      if(Enemy_Sleeper.PlayAnim)
        {
            if (this.gameObject.tag == "Axer")
            {
                anim.SetBool("Sleep", true);
                this.GetComponent<Enemy_Movement>().enabled = false;
                // this.GetComponent<Ranged_enemyFire>().enabled = false;
                takeSleepDMG = true;
                dmgTimer = Time.time + 5f;
                anim.SetBool("Swing", false);
            }
            if (this.gameObject.tag == "Shotguner")
            {
                anim.SetBool("Sleep", true);
                this.GetComponent<New_ShotgunMovement>().enabled = false;
                // this.GetComponent<Ranged_enemyFire>().enabled = false;
                takeSleepDMG = true;
                dmgTimer = Time.time + 5f;
                anim.SetBool("Shotgun", false);
            }
            if (this.gameObject.tag == "Blowguner")
            {
                anim.SetBool("Sleep", true);
                this.GetComponent<Blowguner_Movement>().enabled = false;
                // this.GetComponent<Ranged_enemyFire>().enabled = false;
                takeSleepDMG = true;
                dmgTimer = Time.time + 5f;
                anim.SetBool("Blowgun", false);
            }



        }
      else
        {
            anim.SetBool("Sleep", false);
        }

        

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
            
        



        }

        if (player.GetComponent<Enemy_Sleeper>().HackThem == false)
        {
            if (anim.GetBool("Dead") == false)
            {
                if (this.gameObject.tag == "Axer")
                {
                    gameObject.GetComponent<Enemy_Movement>().enabled = true;
                    //gameObject.GetComponent<Ranged_enemyFire>().enabled = true;
                }
                if(this.gameObject.tag == "Shotguner")
                {
                    gameObject.GetComponent<New_ShotgunMovement>().enabled = true;
                }
                if (this.gameObject.tag == "Blowguner")
                {
                    gameObject.GetComponent<Blowguner_Movement>().enabled = true;
                }
            }
          


        }

        if(takeSleepDMG && Time.time >= dmgTimer)
        {
            takeSleepDMG = false;
            this.GetComponent<AI_health>().health -= 20;
        }

        if (anim.GetBool("Dead") == true)
        {
            anim.SetBool("Sleep", false);
        }
       
     
      


        

    


    }

 
}
