using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orbvest_manager : MonoBehaviour
{
    public GameObject charatcer;

     public GameObject vestBarrel1;
     public GameObject vestBarrel2;
     public GameObject vestBarrel3;
     public GameObject vestBarrel4;

   public Material[] deafultMat;
   

    public Material[] orbMat;
    

    public float cooldown;

    public bool isUsing;
    public bool canCooldown;

    public float resetcooldown;
    public bool CooldownReset;

    public Animator anim;

    public bool animPlay;
    public float playTimer;

    public GameObject banButton;
    // Start is called before the first frame update
    void Start()
    {
        isUsing = false;
        CooldownReset = false;
        anim = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UsingVest();
        DurationCooldown();
        Reset();
    }

   public void UsingVest ()
    {
        if(isUsing && Input.GetKey(KeyCode.F))
        { 
            
            cooldown = 0f;
            this.GetComponent<Shop_Menu>().enabled = true;

            charatcer.gameObject.GetComponent<Renderer>().materials = deafultMat;




        }

        if (animPlay && Time.time >= playTimer)
        {
            animPlay = false;
            anim.SetBool("Orbs", false);
            vestBarrel1.GetComponent<Orb_shooter>().enabled = true;
            vestBarrel2.GetComponent<Orb_shooter>().enabled = true;
            vestBarrel3.GetComponent<Orb_shooter>().enabled = true;
            vestBarrel4.GetComponent<Orb_shooter>().enabled = true;
            isUsing = true;
           
            this.GetComponent<Thirsperson_character>().verSpeed = 2;
            Thirsperson_character.speed = 4;
            OrbClapSound.orbSFX = false;

            charatcer.gameObject.GetComponent<Renderer>().materials = orbMat;
            

        }

        if(Input.GetKey(KeyCode.E) && !isUsing && this.GetComponent<Thirsperson_character>().hasBall == false && AbilityManager.hasBooster == false && this.GetComponent<Rollerskates>().skating == false && this.GetComponent<Bouncy>().canBounce == false && this.GetComponent<Fly_test>().canFly == false && HBspawner.Riding == false)
        {
            banButton.SetActive(true);
            canCooldown = true;
            cooldown = Time.time + 15.5f;
            animPlay = true;
            playTimer = Time.time + 2.3f;
            anim.SetBool("Orbs", true);
            this.GetComponent<Thirsperson_character>().verSpeed = 0;
            Thirsperson_character.speed = 0;
            OrbClapSound.orbSFX = true;
            this.GetComponent<Shop_Menu>().enabled = false;
        }
    }

    public void DurationCooldown ()
    {
        if(canCooldown && Time.time >= cooldown)
        {
            vestBarrel1.GetComponent<Orb_shooter>().enabled = false;
            vestBarrel2.GetComponent<Orb_shooter>().enabled = false;
            vestBarrel3.GetComponent<Orb_shooter>().enabled = false;
            vestBarrel4.GetComponent<Orb_shooter>().enabled = false;

            CooldownReset = true;
            resetcooldown = Time.time + 6;
            canCooldown = false;
            this.GetComponent<Shop_Menu>().enabled = true;

            if (!HBspawner.Riding)
            {
                charatcer.gameObject.GetComponent<Renderer>().materials = deafultMat;
            }
            
            

        }
    }

    public void Reset ()
    {
        if(CooldownReset && Time.time >= resetcooldown)
        {
            banButton.SetActive(false);
            isUsing = false;
            CooldownReset = false;
        }
    }
}
