using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{
    public GameObject character;
    public GameObject weapon;
    public Material[] defaultMat;
    public Material[] frozenMat;
    public Material[] defaultWeapon;
    public Material[] frozenWeapon;

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

        if(isStun)
        {
            anim.SetBool("Stun", true);
        }
        if(!isStun)
        {
            anim.SetBool("Stun", false);
        }

        

        if(MoveSpeed < 0)
        {
            MoveSpeed = 0;
        }
         
        if (anim.GetBool("Dead") == true)
        {
            anim.SetBool("Swing", false);
            Axe_Sound.axeSFX = false;
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


        if (!Canlookaround && !isFrozen)
        {
            Vector3 lookAtPosition = Player.position;
            lookAtPosition.y = transform.position.y;
            transform.LookAt(lookAtPosition);
        }
        if (Canlookaround && !isFrozen)
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
                Dwarf_Jog.dwarfjogSFX = false;
                //anim.SetBool("Swing", false);
            }
            else if (isStun)
            {
                anim.SetBool("Run", false);
                Dwarf_Jog.dwarfjogSFX = false;


            }

            else
            {
                anim.SetBool("Run", true);
                Dwarf_Jog.dwarfjogSFX = true;
            }
           

            



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                Canlookaround = true;
                anim.SetBool("Swing", true);
                Dwarf_Jog.dwarfjogSFX = false;
                Axe_Sound.axeSFX = true;
                MoveSpeed = 0;

                if (dmgTest && this.anim.GetCurrentAnimatorStateInfo(2).IsName("Sleep") == false && this.anim.GetCurrentAnimatorStateInfo(4).IsName("Stun") == false && this.anim.GetCurrentAnimatorStateInfo(3).IsName("Freeze") == false)
                {
                    dmgGiver = true;
                    dmgTimer = Time.time + 0.25f;
                    dmgTest = false;
                    
                }

                if (dmgTestwo && this.anim.GetCurrentAnimatorStateInfo(2).IsName("Sleep") == false && this.anim.GetCurrentAnimatorStateInfo(4).IsName("Stun") == false && this.anim.GetCurrentAnimatorStateInfo(3).IsName("Freeze") == false)
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
                Axe_Sound.axeSFX = false;
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
            Freeze_Soundy.freezeSFX = true;
            MinDist = 500;
            MaxDist = 500;
            character.gameObject.GetComponent<Renderer>().materials = frozenMat;
            weapon.gameObject.GetComponent<Renderer>().materials = frozenWeapon;
        }

        if (Time.time >= freezeTimer && canFreeze == true)
        {
            MoveSpeed = 4;
            canFreeze = false;
            isFrozen = false;
            anim.SetBool("Freeze",false);
            Freeze_Soundy.freezeSFX = false;
            MinDist = 1.4f;
            MaxDist = 1.7f;
            character.gameObject.GetComponent<Renderer>().materials = defaultMat;
            weapon.gameObject.GetComponent<Renderer>().materials = defaultWeapon;

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
