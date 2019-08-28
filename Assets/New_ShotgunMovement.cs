using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class New_ShotgunMovement : MonoBehaviour
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

    public static bool meeleeGrounded;

    public float freezeTimer;
    public bool canFreeze;
    public bool speedLower;


    public bool reload;
   // AnimationClip shootAnim;

   

    public bool isFrozen;
    public bool isStun;


    public bool animShooting;
    public bool reShoot;
    public float shootTimer;

    public bool realoading;
    public float timeforReload;


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
        if(reload && anim.GetBool("Sleep") == false)
        {
            anim.SetBool("Reload", true);
            anim.SetBool("Shotgun", false);
           
        }

        if(realoading && Time.time >=  timeforReload)
        {
            anim.SetBool("Reload", false);
            reload = false;
            this.GetComponent<Shooting_test>().ammo = 0;
            realoading = false;
        }

        if(reShoot && Time.time >= shootTimer && !reload)
        {
            reShoot = false;
            anim.Play("Shoot", 1, 0f);
            animShooting = true;
           
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
            anim.SetBool("Shotgun", false);
            anim.SetBool("reload", false);
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

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (isFrozen && !speedLower)
            {
                anim.SetBool("Run", false);
                //anim.SetBool("Swing", false);
            }
            else if (isStun)
            {
                anim.SetBool("Run", false);


            }

            else
            {
                anim.SetBool("Run", true);
            }






            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                Canlookaround = true;

                if (!reload)
                {
                    anim.SetBool("Shotgun", true);
                    canShoot = false;
                }

                    canShoot = true;
                
                MoveSpeed = 0;


                if (animShooting)
                {
                    reShoot = true;
                    shootTimer = Time.time + 0.71f;
                    animShooting = false;
                }
               


            }
            else
            {
                Canlookaround = false;
                //anim.SetBool("Swing", false);

                anim.SetBool("Shotgun", false);
                anim.SetBool("Reload",false);
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
            meeleeGrounded = true;
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
            meeleeGrounded = false;
        }
    }


}


