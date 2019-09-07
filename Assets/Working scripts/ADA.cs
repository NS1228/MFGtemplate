using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADA : MonoBehaviour
{
    public GameObject Player;
    
    public static bool hasGrednadeFall;
    // if the player has it equiped
    public static bool canGrenadeFall;
    // if the player can use the grenade
    public static bool isGrenadeFall;
    // triggers the grenades to deploy
    [Header("grenadeFall")]
    public float grenadeFallCooldown = 0;
    // duration of the grenade fall
    public float grenadeCooldownReset = 0f;
    // duration of the cooldown period

    public bool cooldownGrenadeFall;
    // bool to allow the duration cooldown to work
    public bool resetGrenadeFall;
    // bool to allow the cooldown to work

    public GameObject grednadespawner;

    [Header("Lightning")]
    public static bool hasLightning;
    //
    public static bool canLightning;
    //
    public static bool isLighting;
    //

    public float ightningCooldown = 0;
    //
    public float resetLightning = 0;


    Animator anim;

    public float animTimer;
    public bool deployGrenades;


    AudioSource audios;



    // Start is called before the first frame update
    void Start()
    {
        hasGrednadeFall = true;
        canGrenadeFall = true;
        isGrenadeFall = false;

        resetGrenadeFall = false;
        cooldownGrenadeFall = false;
        anim = this.GetComponent<Animator>();
        audios = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        ADAbilities();
        Cooldowns();
        Resetcooldowns();

        if(deployGrenades && Time.time >= animTimer)
        {
            deployGrenades = false;
            anim.SetBool("Grenade", false);
            this.GetComponent<Thirsperson_character>().verSpeed = 2;
            Thirsperson_character.speed = 4;
            audios.volume = 1;
            Mine_Sound.grenadeSFX = false;

            isGrenadeFall = true;
            grenadeFallCooldown = Time.time + 9.59f;
            canGrenadeFall = false;
            cooldownGrenadeFall = true;
        }
          
       

        
    }

    public void ADAbilities ()
    {
        if (canGrenadeFall && Input.GetKey(KeyCode.E) && this.GetComponent<Thirsperson_character>().hasBall == false && AbilityManager.hasBooster == false && this.GetComponent<Rollerskates>().skating == false && this.GetComponent<Bouncy>().canBounce == false && this.GetComponent<Fly_test>().canFly == false && HBspawner.Riding == false)
        {
            
            
            anim.SetBool("Grenade", true);
            deployGrenades = true;
            animTimer = Time.time + 1.59f;
            this.GetComponent<Thirsperson_character>().verSpeed = 0;
            Thirsperson_character.speed = 0;
            audios.volume = 0;
            Mine_Sound.grenadeSFX = true;
        }


        if(hasLightning)
        {
            Player.GetComponent<Lighting_Spawner>().enabled = true;
            
        }

       
            
    }

    public void Cooldowns()
    {
       if(Time.time >= grenadeFallCooldown && cooldownGrenadeFall)
        {
           
           isGrenadeFall = false;
           grenadeCooldownReset = Time.time + 10f;
           resetGrenadeFall = true;
            cooldownGrenadeFall = false;
            grednadespawner.GetComponent<Grenade_drop>().grenadeLimit = 0;

        }
       else if (grenadeFallCooldown >= Time.time && cooldownGrenadeFall)
        {
            //print("is using");
            resetGrenadeFall = false;
        }
    }

    public void Resetcooldowns ()
    {
        if(Time.time >= grenadeCooldownReset && resetGrenadeFall)
        {
            canGrenadeFall = true;
            resetGrenadeFall = false;
           // print("can use now");
        }
        else if (grenadeCooldownReset >= Time.time && resetGrenadeFall)
        {
           // print("on cooldown");
        }
    }
   
  

   
}
