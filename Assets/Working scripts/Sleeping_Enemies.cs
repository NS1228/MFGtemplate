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

    public bool playAnim;

    public bool sleepThis;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //stunDMG = false;
        anim = this.GetComponent<Animator>();

        sleepThis = true;
       
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

    /*  if(player.GetComponent<Enemy_Sleeper>().enemyAnim)
        {
            if (this.gameObject.tag == "Axer")
            {
                anim.SetBool("Sleep", true);
                anim.SetBool("Swing", false);
            }
            if (this.gameObject.tag == "Shotguner")
            {
                anim.SetBool("Sleep", true);
               
                anim.SetBool("Shotgun", false);
            }
            if (this.gameObject.tag == "Blowguner")
            {
                anim.SetBool("Sleep", true);
                anim.SetBool("Blowgun", false);

            }



        }
      else
        {
            anim.SetBool("Sleep", false);
        } */

        

        if (Vector3.Distance(gameObject.transform.position, Player.position) <= range)
        {
            inRange = true;
           // print("YES IN RANGE");
            

        }
        if (Vector3.Distance(transform.position, Player.position) > range)
        {
            inRange = false;
          // print ("not in range");
           
        }



        if (player.GetComponent<Enemy_Sleeper>().HackThem == true && player.GetComponent<Enemy_Sleeper>().enemyAnim && sleepThis)
        {
            sleepThis = false;
            if (inRange)
            {

                if (this.gameObject.tag == "Blowguner")
                {
                    this.GetComponent<Blowguner_Movement>().enabled = false;
                    this.GetComponent<Blowgun_Shooting>().enabled = false;
                    // this.GetComponent<Ranged_enemyFire>().enabled = false;
                    takeSleepDMG = true;
                    dmgTimer = Time.time + 5f;
                    playAnim = true;

                    anim.SetBool("Sleep", true);
                    anim.SetBool("Blowgun", false);




                }
                if (this.gameObject.tag == "Shotguner")
                {

                    this.GetComponent<New_ShotgunMovement>().enabled = false;
                    this.GetComponent<Shooting_test>().enabled = false;
                    takeSleepDMG = true;
                    dmgTimer = Time.time + 5f;
                    playAnim = true;

                    anim.SetBool("Sleep", true);
                    anim.SetBool("Shotgun", false);


                }
                if (this.gameObject.tag == "Axer")
                {

                    this.GetComponent<Enemy_Movement>().enabled = false;
                    takeSleepDMG = true;
                    dmgTimer = Time.time + 5f;
                    playAnim = true;

                    anim.SetBool("Sleep", true);
                    anim.SetBool("Swing", false);

                }
            }




        }

        if (player.GetComponent<Enemy_Sleeper>().HackThem == false)
        {
            if (anim.GetBool("Dead") == false)
            {
                if (this.gameObject.tag == "Axer")
                {
                    gameObject.GetComponent<Enemy_Movement>().enabled = true;
                    //gameObject.GetComponent<Ranged_enemyFire>().enabled = true;
                    playAnim = false;
                    anim.SetBool("Sleep", false);
                    sleepThis = true;
                }
                if(this.gameObject.tag == "Shotguner")
                {
                    gameObject.GetComponent<New_ShotgunMovement>().enabled = true;
                    gameObject.GetComponent<Shooting_test>().enabled = true;
                    playAnim = false;
                    anim.SetBool("Sleep", false);
                    sleepThis = true;
                }
                if (this.gameObject.tag == "Blowguner")
                {
                    gameObject.GetComponent<Blowguner_Movement>().enabled = true;
                    
                    this.GetComponent<Blowgun_Shooting>().enabled = true;
                    playAnim = false;
                    anim.SetBool("Sleep", false);
                    sleepThis = true;
                }
            } 
          


        } 

        if(takeSleepDMG && Time.time >= dmgTimer)
        {
            takeSleepDMG = false;
            this.GetComponent<AI_health>().health -= 25;
            
        }

        if (anim.GetBool("Dead") == true)
        {
            anim.SetBool("Sleep", false);
        }
       
     
      


        

    


    }

 
}
