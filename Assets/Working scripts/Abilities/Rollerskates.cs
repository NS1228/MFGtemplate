using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollerskates : MonoBehaviour
{

    public float speed;
    public bool skating;
    public Animator animator;


    public bool canSkate;
    public float skateTimer;
    public bool skateCooldown;

    public bool skateReset;
    public float resetTimer;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8;
        skating = false;
        animator = this.GetComponent<Animator>();
        canSkate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(skating && Input.GetKeyDown(KeyCode.F))
        {
            skating = false; 
        }

        if (!skating)
        {
            if (Input.GetKeyDown(KeyCode.Q) && canSkate)
            {
                skating = true;
                animator.SetBool("isSkating", true);
                canSkate = false;
                skateTimer = Time.time + 11;
                skateCooldown = true;

            }
        }

            if (skating)
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    skating = false;
                animator.SetBool("isSkating", false);
            }
            }
        






        if (skating)
        {
            RS_Sound.skatingSFX = true;
            this.GetComponent<Thirsperson_character>().enabled = false;

            transform.position += transform.forward * Time.deltaTime * speed;
            speed += 0.1f;
            if (speed >= 20)
            {
                speed = 20f;
            }
        }

        if(!skating)
        {
            RS_Sound.skatingSFX = false;
            speed -= 0.1f;
            if (speed <= 8)
            {
                speed = 8;
                this.GetComponent<Thirsperson_character>().enabled = true;

            }

            if(speed > 8)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }

        }

        if(skateCooldown && Time.time >= skateTimer)
        {
            skateCooldown = false;
            skateReset = true;
            resetTimer = Time.time + 18;
            skating = false;
            animator.SetBool("isSkating", false);
        }

        if(skateReset && Time.time >= resetTimer)
        {
            canSkate = true;
            skateReset = false;
        }
        

           
        }
    }

