using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowguner_Movement : MonoBehaviour
{
    public Transform Player;
    public GameObject player;
    public float MoveSpeed = 4;
    public float MaxDist = 10;
    public float MinDist = 5;

    Animator anim;

    public bool Canlookaround;

    public bool canShoot;

    //public GameObject thePlayer;

    Rigidbody rb;

 

    public float freezeTimer;
    public bool canFreeze;
    public bool speedLower;


    
    // AnimationClip shootAnim;



    public bool isFrozen;
    public bool isStun;


    public bool animShooting;
    public bool reShoot;
    public float shootTimer;

   


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Canlookaround = false;

        anim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

        animShooting = true;


    }

    void Update()
    {
        

        if (reShoot && this.GetComponent<Blowgun_Shooting>().inSight)
        {
            reShoot = false;
            anim.Play("Blowgun", 0, 0f);
            animShooting = true;
            anim.SetBool("Blowgun", false);
            anim.SetBool("Idle", true);
            shootTimer = Time.time + 3f;


        }


        if (!isFrozen)
        {
            anim.SetBool("Freeze", false);
        }

        if (isStun)
        {
            anim.SetBool("Stun", true);
        }
        if (!isStun)
        {
            anim.SetBool("Stun", false);
        }



        if (MoveSpeed < 0)
        {
            MoveSpeed = 0;
        }

        if (anim.GetBool("Dead") == true)
        {
            anim.SetBool("Blowgun", false);
           
            canShoot = false;
        }






        if (!Canlookaround)
        {
            Vector3 lookAtPosition = Player.position;
            lookAtPosition.y = transform.position.y;
            transform.LookAt(lookAtPosition);
        }
        if (Canlookaround)
        {
            Vector3 lookAtPosition = Player.position;
            lookAtPosition.y = transform.position.y;
            transform.LookAt(lookAtPosition);
        }


        Player = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

          //  transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (isFrozen && !speedLower)
            {
                anim.SetBool("Idle", false);
                //anim.SetBool("Swing", false);
            }
            else if (isStun)
            {
                anim.SetBool("Idle", false);


            }

            else
            {
                anim.SetBool("Idle", true);
            }






            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                Canlookaround = true;

                if (this.GetComponent<Blowgun_Shooting>().inSight)
                {
                    Blowhole_Sound.blowgunSFX = true;
                    canShoot = true;
                }
                else
                {
                   
                    canShoot = false;
                }

                canShoot = true;

                MoveSpeed = 0;


                if (animShooting && this.GetComponent<Blowgun_Shooting>().inSight && Time.time >= shootTimer)
                {
                    reShoot = true;
                    
                    animShooting = false;
                    anim.SetBool("Blowgun",true);
                    anim.SetBool("Idle", false);
                    this.GetComponent<Blowgun_Shooting>().shootTimer = Time.time + 0.15f;
                }



            }
            else
            {
                Canlookaround = false;
                //anim.SetBool("Swing", false);
                Blowhole_Sound.blowgunSFX = false;
                anim.SetBool("Blowgun", false);
                anim.SetBool("Idle", true);
              
                canShoot = false;

                if (!isFrozen && !isStun)
                {
                    MoveSpeed = 4;

                }






            }

        }

        if (speedLower)
        {

            MoveSpeed -= 0.5f * Time.deltaTime;



        }

        if (MoveSpeed <= 0 && speedLower)
        {
            MoveSpeed = 0;
            speedLower = false;
            anim.SetBool("Freeze", true);
        }

        if (Time.time >= freezeTimer && canFreeze == true)
        {
            MoveSpeed = 4;
            canFreeze = false;
            isFrozen = false;
            anim.SetBool("Freeze", false);
        }
    }




    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
           
        }

        if (other.gameObject.tag == "Icetrail" && !canFreeze)
        {
            this.gameObject.GetComponent<AI_health>().health -= 15f;
            speedLower = true;
            freezeTimer = Time.time + 3f;
            canFreeze = true;
            //print("FREEZE");
            isFrozen = true;

        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            
        }
    }


}
