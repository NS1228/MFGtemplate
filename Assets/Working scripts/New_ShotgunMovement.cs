using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class New_ShotgunMovement : MonoBehaviour
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

    public bool freezeReShoot;
    public float freezeShootTimer;

   


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
        if(reload && anim.GetBool("Sleep") == false && !isFrozen)
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
            Shotgun_Sound.shotgunSFX = true;

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

        

        


        if (!Canlookaround && !isFrozen)
        {
            Vector3 lookAtPosition = Player.position;
            lookAtPosition.y = transform.position.y;
            transform.LookAt(lookAtPosition);
        }
        if (Canlookaround && !isFrozen)
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
                Dwarf_Jog.dwarfjogSFX = false;
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

                if (!reload)
                {
                    Shotgun_Sound.shotgunSFX = true;
                    Dwarf_Jog.dwarfjogSFX = false;
                    
                    canShoot = false;
                }

                    canShoot = true;
                
                MoveSpeed = 0;


                if (animShooting)
                {
                    
                    reShoot = true;
                    shootTimer = Time.time + 1f;
                    animShooting = false;
                    anim.SetBool("Shotgun", true);
                }
               


            }
            else
            {
                Canlookaround = false;
                //anim.SetBool("Swing", false);
                Shotgun_Sound.shotgunSFX = false;
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
            anim.SetBool("Freeze", false);
            Freeze_Soundy.freezeSFX = false;
            freezeReShoot = true;
            freezeShootTimer = Time.time + 0.5f;
            character.gameObject.GetComponent<Renderer>().materials = defaultMat;
            weapon.gameObject.GetComponent<Renderer>().materials = defaultWeapon;



        }

        if(freezeReShoot && Time.time >= freezeShootTimer)
        {
            MinDist = 0.1f;
            MaxDist = 9;
            freezeReShoot = false;
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


