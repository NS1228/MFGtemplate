using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Objects : MonoBehaviour
{
    public GameObject turret;
    public bool canBuild;

    public bool canBuildNCD;
    public int buildLimit = 0;

    public bool startCD;

    public float timer;

    public bool buildLimitReached;

    public float Turrettimerz;
    public bool buildtimer;

    Animator anim;

    public bool animPlay;
    public float animTimer;

    public bool soundSwitch;
    public float soundTimer;

    AudioSource audios;

    public GameObject banButton;

    // Start is called before the first frame update
    void Start()
    {
        canBuildNCD = true;
        startCD = false;
        buildLimitReached = false;
        buildtimer = false;
        anim = this.GetComponent<Animator>();
        audios = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Thirsperson_character>().isGrounded)
        {
            canBuild = true;
        }
        else
        {
            canBuild = false;
        }


        if(Input.GetKey(KeyCode.F) && canBuildNCD)
        {
            Turrettimerz = 0;
            this.GetComponent<Shop_Menu>().enabled = true;
        }

        if(animPlay && Time.time >= animTimer)
        {
            animPlay = false;
            anim.SetBool("Build", false);
            Instantiate(turret, transform.position + (transform.forward * 2 + transform.up * 0.36f), transform.rotation);
            buildLimit += 1;
            buildLimitReached = true;
            buildtimer = true;
            Turrettimerz = Time.time + 10;
            this.GetComponent<Thirsperson_character>().verSpeed = 2;
            Thirsperson_character.speed = 4;
            audios.volume = 1;
            soundSwitch = false;
            Mine_Sound.turretSFX = false;
        }

        if (this.GetComponent<Thirsperson_character>().hasBall == false && AbilityManager.hasBooster == false && this.GetComponent<Rollerskates>().skating == false && this.GetComponent<Bouncy>().canBounce == false && this.GetComponent<Fly_test>().canFly == false && HBspawner.Riding == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && canBuild && canBuildNCD )
            {
                
                anim.SetBool("Build", true);
                animPlay = true;
                animTimer = Time.time + 0.4f;
                this.GetComponent<Thirsperson_character>().verSpeed = 0;
                Thirsperson_character.speed = 0;
                audios.volume = 0;
                soundSwitch = true;
                soundTimer = Time.time + 0.69f;
                Mine_Sound.turretSFX = true;
                this.GetComponent<Shop_Menu>().enabled = false;


            }

            
        }

        if(buildLimit >= 3 && buildLimitReached)
        {
            canBuildNCD = false;
            startCD = true;
            timer = Time.time + 6f;
            buildLimitReached = false;
            this.GetComponent<Shop_Menu>().enabled = true;
            banButton.SetActive(true);
        }

        if(buildtimer && Time.time >= Turrettimerz)
        {
            buildtimer = false;
            canBuildNCD = false;
            startCD = true;
            timer = Time.time + 6f;
            this.GetComponent<Shop_Menu>().enabled = true;
            banButton.SetActive(true);

        }

        Cooldown();

    }

   /* void OnCollisionEnter (Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            canBuild = true;
        }
        
        
    }

    void OnCollisionExit (Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            canBuild = false;
        }
        
        
    } */

       


    public void Cooldown ()
    {
        if(startCD && Time.time >= timer)
        {
            startCD = false;
            canBuildNCD = true;
            buildLimit = 0;
            banButton.SetActive(false);

        }
    }
}
