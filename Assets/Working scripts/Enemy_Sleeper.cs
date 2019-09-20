using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sleeper : MonoBehaviour
{
    public  bool HackThem;

    public bool stopHack;
    public float timer;

    public bool inUse;
    public float Cooldown;

    public bool resetthis;
    public float resettimer;

    public bool stunDMG;

    Animator anim;
    

    public bool playAnim;
    public float animTimer;

    public bool soundSwitch;
    public float soundTimer;

    AudioSource audios;

    public  bool PlayAnim;

    public bool enemyAnim;

    public GameObject banButton;

    // Start is called before the first frame update
    void Start()
    {
        HackThem = false;
        stopHack = false;
        inUse = false;
        resetthis = false;

        stunDMG = false;

        anim = this.GetComponent<Animator>();

        audios = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if(playAnim && Time.time >= animTimer)
        {
            playAnim = false;
            anim.SetBool("Sleeper", false);
            this.GetComponent<Thirsperson_character>().verSpeed = 2;
            Thirsperson_character.speed = 4;
            audios.volume = 1;
            soundSwitch = false;
            Mine_Sound.sleeperSFX = false;
            // playAnim = true;
            enemyAnim = true;
            
            
        }

        if (this.GetComponent<Thirsperson_character>().hasBall == false && AbilityManager.hasBooster == false && this.GetComponent<Rollerskates>().skating == false && this.GetComponent<Bouncy>().canBounce == false && this.GetComponent<Fly_test>().canFly == false && HBspawner.Riding == false)
        {
            if (Input.GetKey(KeyCode.E) && !inUse)
            {
                banButton.SetActive(true);
                HackThem = true;
                timer = Time.time + 12.7f;
                stopHack = true;
                inUse = true;
                stunDMG = true;
                anim.SetBool("Sleeper", true);
                playAnim = true;
                animTimer = Time.time + 2.18f;
                this.GetComponent<Thirsperson_character>().verSpeed = 0;
                Thirsperson_character.speed = 0;
                audios.volume = 0;
                soundSwitch = true;
                soundTimer = Time.time + 0.69f;
                Mine_Sound.sleeperSFX = true;

                this.GetComponent<Shop_Menu>().enabled = false;



            }
        }

        if(stopHack && Time.time >= timer)
        {
            stopHack = false;
            HackThem = false;

            resetthis = true;
            resettimer = Time.time + 6;
            enemyAnim = false;
            this.GetComponent<Shop_Menu>().enabled = true;


        }




        
        CooldownReset();



        }

  

   


    void CooldownReset ()
    {
        if(resetthis && Time.time >= resettimer)
        {
            inUse = false;
            resetthis = false;
            banButton.SetActive(false);
        }
    }








    }


