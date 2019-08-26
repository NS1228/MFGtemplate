using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbvest_manager : MonoBehaviour
{
     public GameObject vestBarrel1;
     public GameObject vestBarrel2;
     public GameObject vestBarrel3;
     public GameObject vestBarrel4;

   

    public float cooldown;

    public bool isUsing;
    public bool canCooldown;

    public float resetcooldown;
    public bool CooldownReset;

    public Animator anim;

    public bool animPlay;
    public float playTimer;
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

        }

        if(Input.GetKey(KeyCode.E) && !isUsing)
        {
            canCooldown = true;
            cooldown = Time.time + 14.3f;
            animPlay = true;
            playTimer = Time.time + 2.3f;
            anim.SetBool("Orbs", true);
            this.GetComponent<Thirsperson_character>().verSpeed = 0;
            Thirsperson_character.speed = 0;
            OrbClapSound.orbSFX = true;
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
            resetcooldown = Time.time + 5;
            canCooldown = false;
            
            
        }
    }

    public void Reset ()
    {
        if(CooldownReset && Time.time >= resetcooldown)
        {
            isUsing = false;
            CooldownReset = false;
        }
    }
}
