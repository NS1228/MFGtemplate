using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{

    public Transform Player;
    public float MoveSpeed = 4;
    public float MaxDist = 10;
    public float MinDist = 5;

    

    public bool Canlookaround;

    //public GameObject thePlayer;

    Rigidbody rb;

    public static bool meeleeGrounded;

    public float freezeTimer;
    public bool canFreeze;
    public bool speedLower;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Canlookaround = false;

    }

    void Update()
    {

        if (!Canlookaround)
        {
            Vector3 lookAtPosition = Player.position;
            lookAtPosition.y = transform.position.y;
            transform.LookAt(lookAtPosition);
        }
        if (Canlookaround)
        {
            transform.LookAt(Player);
        }


        Player = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;




            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                Canlookaround = true;

            }
            else
            {
                Canlookaround = false;
                
            }

        }

        if (speedLower)
        {

            MoveSpeed -= 0.25f * Time.deltaTime;
            // print(MoveSpeed);


        }

        if (MoveSpeed <= 0 && speedLower)
        {
            MoveSpeed = 0;
            speedLower = false;
        }

        if (Time.time >= freezeTimer && canFreeze == true)
        {
            MoveSpeed = 4;
            canFreeze = false;
        }
    }




    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            meeleeGrounded = true;
        }

        if (other.gameObject.tag == "Icetrail")
        {
            this.gameObject.GetComponent<AI_health>().health -= 5f;
            speedLower = true;
            freezeTimer = Time.time + 10;
            canFreeze = true;
            print("FREEZE");


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
