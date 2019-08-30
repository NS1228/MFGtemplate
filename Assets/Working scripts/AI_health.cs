using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_health : MonoBehaviour
{

    public float health = 100;
    Animator anim;

    public bool dead;
    public float deadTimer;

    public bool hasDied;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        hasDied = true;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
       // print(health);
    }

   void Death ()
    {
        if(health <= 0 && hasDied)
        {
            hasDied = false;
            anim.SetBool("Dead", true);
            dead = true;
            deadTimer = Time.time + 7.38f;
            
            Death_Sound.dwarfdeathSFX = true;

            if(this.gameObject.tag == "Axer")
            {
                this.GetComponent<Enemy_Movement>().enabled = false;
            }
            if (this.gameObject.tag == "Shotguner")
            {
                this.GetComponent<New_ShotgunMovement>().enabled = false;
            }
            if (this.gameObject.tag == "Blowguner")
            {
                this.GetComponent<Blowguner_Movement>().enabled = false;
            }

        }

        if(dead && Time.time >= deadTimer)
        {
            dead = false;
            Destroy(gameObject);
            Death_Sound.dwarfdeathSFX = false;
        }

     
    }
}
