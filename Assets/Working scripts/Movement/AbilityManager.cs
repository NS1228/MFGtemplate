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
            Time.fixedDeltaTime = 0.0075f;
            this.GetComponent<Shop_Menu>().enabled = false;


        }
        if(Input.GetKeyDown(KeyCode.F) && hasBooster)
        {
            hasBooster = false;
            Time.fixedDeltaTime = 0.02f;
            this.GetComponent<Shop_Menu>().enabled = true;
        }

    }

    private void Cooldowns ()
    {
       if(boostCD && Time.time >= boosterCooldown)
        {
            boostCD = false;
            resetCD = true;
            boosterReset = Time.time + 5;
            hasBooster = false;
            Time.fixedDeltaTime = 0.02f;
            this.GetComponent<Shop_Menu>().enabled = true;
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
