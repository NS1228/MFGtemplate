using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icetrail_Manager : MonoBehaviour
{

    public bool duration;
    public float durationTimer;

    public bool isUsing;


    public bool cooldown;
    public float cooldownTimer;

    public bool canUse;

    
    // Start is called before the first frame update
    void Start()
    {
        isUsing = false;
        duration = false;
        cooldown = false;
        canUse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && canUse)
        {
            durationTimer = 0;
        }

        if (Input.GetKey(KeyCode.E) && !isUsing && !canUse && this.GetComponent<Thirsperson_character>().hasBall == false && AbilityManager.hasBooster == false && this.GetComponent<Rollerskates>().skating == false && this.GetComponent<Bouncy>().canBounce == false && this.GetComponent<Fly_test>().canFly == false && HBspawner.Riding == false)
        {
            this.gameObject.GetComponent<Spawn_Icetrail>().enabled = true;
            canUse = true;
            duration = true;
            durationTimer = Time.time + 10;
            Icetrail_Sound.iceSFX = true;
        }

        if(duration && Time.time >= durationTimer)
        {
            duration = false;
            cooldown = true;
            cooldownTimer = Time.time + 5;
            isUsing = true;
            Icetrail_Sound.iceSFX = false;
        }

        if(cooldown && Time.time >= cooldownTimer)
        {
            cooldown = false;
            isUsing = false;
            canUse = false;
            
        }

        if(isUsing)
        {
            this.gameObject.GetComponent<Spawn_Icetrail>().enabled = false;
        }
    }

    
}
