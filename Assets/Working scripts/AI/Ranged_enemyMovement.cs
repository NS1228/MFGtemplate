using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_enemyMovement : MonoBehaviour
{
    public Transform Player;
    public float MoveSpeed = 4;
    public float MaxDist = 15;
    public float MinDist = 10;

    public bool rangedGrounded;

    public static bool aiCANSHOOT;

    public bool Canlookaround;


    Rigidbody rb;

    public static bool grounded;

    public float freezeTimer;
    public bool canFreeze;
    public bool speedLower;

    Animator anim;

    public bool isFrozen;
    public bool isStun;


    void Start()
    {
        aiCANSHOOT = false;
        rb = GetComponent<Rigidbody>();
        Canlookaround = true;

        grounded = true;

        canFreeze = false;
        speedLower = false;

        anim = this.GetComponent<Animator>();
    }
        
    void Update()
    {

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
            anim.SetBool("Shoot", false);
        }


        if (!Canlookaround)
        {
            Vector3 lookAtPosition = Player.position;
            lookAtPosition.y = transform.position.y;
            transform.LookAt(lookAtPosition);
        }
        if(Canlookaround)
          {
            transform.LookAt(Player);
        }
        
       

        Player = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            anim.SetBool("Shotgun", false);
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
                anim.SetBool("Shotgun", true);

                //Here Call any function U want Like Shoot at here or something 
                rb.constraints =  RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                aiCANSHOOT = true;
                //Canlookaround = true;
                


            }
            else
            {
                aiCANSHOOT = false;
                // Canlookaround = false;
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
            rangedGrounded = true;
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
            rangedGrounded = false;
        }
    }







}

