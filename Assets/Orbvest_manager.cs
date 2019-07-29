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
    // Start is called before the first frame update
    void Start()
    {
        isUsing = false;
        CooldownReset = false;
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
        if(Input.GetKey(KeyCode.E) && !isUsing)
        {
            vestBarrel1.GetComponent<Orb_shooter>().enabled = true;
            vestBarrel2.GetComponent<Orb_shooter>().enabled = true;
            vestBarrel3.GetComponent<Orb_shooter>().enabled = true;
            vestBarrel4.GetComponent<Orb_shooter>().enabled = true;
            isUsing = true;
            cooldown = Time.time + 8;
            canCooldown = true;
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
