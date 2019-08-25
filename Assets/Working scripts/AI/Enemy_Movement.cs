using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{

    public Transform Player;
    public GameObject player;
    public float MoveSpeed = 4;
    public float MaxDist = 10;
    public float MinDist = 5;

    Animator anim;

    public bool Canlookaround;

    public bool dmgTest;

    //public GameObject thePlayer;

    Rigidbody rb;

    public static bool meeleeGrounded;

    public float freezeTimer;
    public bool canFreeze;
    public bool speedLower;

    public bool dmgGiver;
    public float dmgTimer;

    public float axeDMG;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Canlookaround = false;

        anim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

        dmgTest = true;

    }

    void Update()
    {
        if(dmgGiver && Time.time >= dmgTimer)
        {
            dmgGiver = false;
            Player.GetComponent<Health_script>().health -= axeDMG;
            // print(Player.GetComponent<Health_script>().health);
            dmgTest = true;
        }


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
            anim.SetBool("Run", true);
            //anim.SetBool("Swing", false);
           

            



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                Canlookaround = true;
                anim.SetBool("Swing", true);
                
                MoveSpeed = 0;

                if (dmgTest)
                {
                    dmgGiver = true;
                    dmgTimer = Time.time + 1.08f;
                    dmgTest = false;
                    
                }
                 

            }
            else
            {
                Canlookaround = false;
                //anim.SetBool("Swing", false);
                MoveSpeed = 4;
                anim.SetBool("Swing", false);
                dmgTest = true;
                 dmgGiver = false;

               
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
