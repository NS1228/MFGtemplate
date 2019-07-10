using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADA : MonoBehaviour
{
    public static bool hasGrednadeFall;
    public static bool canGrenadeFall;
    public static bool isGrenadeFall;

    public float grenadeFallCooldown = 0;
    public float grenadeCooldownReset = 0f;

    public GameObject grednadespawner;

    public bool resetGrenadeFall;
    public bool cooldownGrenadeFall;


    // Start is called before the first frame update
    void Start()
    {
        hasGrednadeFall = true;
        canGrenadeFall = true;
        isGrenadeFall = false;

        resetGrenadeFall = false;
        cooldownGrenadeFall = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        ADAbilities();
        Cooldowns();
        Resetcooldowns();
          
       

        
    }

    public void ADAbilities ()
    {
        if (canGrenadeFall && Input.GetKey(KeyCode.E))
        {
            grednadespawner.SetActive(true);
            isGrenadeFall = true;
            grenadeFallCooldown = Time.time + 10f;
            canGrenadeFall = false;
            cooldownGrenadeFall = true;
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

        }
       else if (grenadeFallCooldown >= Time.time && cooldownGrenadeFall)
        {
            print("is using");
            resetGrenadeFall = false;
        }
    }

    public void Resetcooldowns ()
    {
        if(Time.time >= grenadeCooldownReset && resetGrenadeFall)
        {
            canGrenadeFall = true;
            resetGrenadeFall = false;
            print("can use now");
        }
        else if (grenadeCooldownReset >= Time.time && resetGrenadeFall)
        {
            print("on cooldown");
        }
    }
   
  

   
}
