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

    public bool dmgTestwo;
    public float dmgTwoTimer;
    public bool dmgLoop;

    public bool isFrozen;
    public bool isStun;


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
        if(!isFrozen)
        {
            anim.SetBool("Freeze", false);
        }

        if(MoveSpeed < 0)
        {
            MoveSpeed = 0;
        }
         
        if (anim.GetBool("Dead") == true)
        {
            anim.SetBool("Swing", false);
        }

        if (dmgGiver && Time.time >= dmgTimer)
        {
            dmgGiver = false;
            Player.GetComponent<Health_script>().health -= axeDMG;
            // print(Player.GetComponent<Health_script>().health);
            dmgTestwo = true;
        }

        if(dmgLoop && Time.time >= dmgTwoTimer)
        {
            Player.GetComponent<Health_script>().health -= axeDMG;
            dmgTestwo = true;
            dmgLoop = false;
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
                anim.SetBool("Swing", true);
                
                MoveSpeed = 0;

                if (dmgTest && this.anim.GetCurrentAnimatorStateInfo(3).IsName("Sleep") == false)
                {
                    dmgGiver = true;
                    dmgTimer = Time.time + 0.25f;
                    dmgTest = false;
                    
                }

                if (dmgTestwo && this.anim.GetCurrentAnimatorStateInfo(3).IsName("Sleep") == false)
                {
                    dmgTestwo = false;
                    dmgTwoTimer = Time.time + 1.08f;
                    dmgLoop = true;
                }
                 

            }
            else
            {
                Canlookaround = false;
                //anim.SetBool("Swing", false);
                
                anim.SetBool("Swing", false);
                dmgTest = true;
                dmgTestwo = false;
                dmgLoop = false;
                dmgGiver = false;

                if(!isFrozen && !isStun)
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
            anim.SetBool("Freeze",false);
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
            print("FREEZE");
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
