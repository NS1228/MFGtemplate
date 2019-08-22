using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{

    public static bool hasBooster;
    public static bool canBooster;
    public float boosterCooldown;
    public float boosterReset;

    public bool boostCD;
    public bool resetCD;
    
    // Start is called before the first frame update
    void Start()
    {
        hasBooster = false;
        canBooster = true;
        boosterCooldown = 0f;
        boosterReset = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        Abilities();
        Cooldowns();
        Resetcooldowns();

        if(!canBooster)
        {
            //print("On Cooldown");
        }
        

    }


    private void Abilities ()
    {
        if (Input.GetKey(KeyCode.Q) && canBooster)
        {
            hasBooster = true;
            boosterCooldown = Time.time + 5f;
            canBooster = false;
             boostCD = true;
            

        }
        if(Input.GetKeyDown(KeyCode.F) && hasBooster)
        {
            hasBooster = false;
        }

    }

    private void Cooldowns ()
    {
       if(boostCD && Time.time >= boosterCooldown)
        {
            boostCD = false;
            resetCD = true;
            boosterReset = Time.time + 6;
            hasBooster = false;
        }
    }


    private void Resetcooldowns()
    {
       if(resetCD && Time.time>=boosterReset)
        {
            resetCD = false;
            canBooster = true;
        }
    }

}
