using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{

    public static bool hasBooster;
    public static bool canBooster;
    public float boosterCooldown;
    public float boosterReset;
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
        if (Input.GetKey(KeyCode.E) && canBooster)
        {
            hasBooster = true;
            boosterCooldown = Time.time + 6f;
            canBooster = false;

        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            hasBooster = false;
        }

    }

    private void Cooldowns ()
    {
        if(Time.time >= boosterCooldown && hasBooster)
        {
            hasBooster = false;
            boosterReset = Time.time + 5f;


        }
    }


    private void Resetcooldowns()
    {
        if(Time.time >= boosterReset && !hasBooster)
        {
            canBooster = true;
            
        }
    }

}
