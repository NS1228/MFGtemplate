using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public AudioClip impact;
    public AudioClip strafe;
    public AudioClip boost;
    
    public AudioClip boostStrafe;
    
    AudioSource audioSource;

    public static bool jogSFX;
    public bool canJog;
    public float jogTimer;

    public static bool strafeSFX;
    public bool canStrafe;
    public float strafeTimer;

    public static bool boostSFX;
    public bool canBoost;
    public float boostTimer;

    public static bool bsSFX;
    public bool canBS;
    public float bsTimer;

   
    
   

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if (jogSFX && canJog)
        {
            //audioSource.Play();
            audioSource.PlayOneShot(impact, 0.7F);
            jogTimer = Time.time + 4f;
            boostTimer = 0;
            strafeTimer = 0;
            bsTimer = 0;
           


        }

        if (Time.time >= jogTimer)
        {
            
                canJog = true;
           
        }
        else
        {
            canJog = false;
        }

        if (!jogSFX && !strafeSFX && !boostSFX && !bsSFX)
        {
           
            audioSource.Stop();
            jogTimer = 0;
            strafeTimer = 0;
            boostTimer = 0;
            bsTimer = 0;
            
           
           
           

        }

        

        if (strafeSFX && canStrafe)
        {
            //audioSource.Play();
            audioSource.PlayOneShot(strafe, 0.7f);
            strafeTimer = Time.time + 6f;
            bsTimer = 0;
            jogTimer = 0;
            boostTimer = 0;
           


        }

        if (Time.time >= strafeTimer)
        {
            canStrafe = true;
        }
        else
        {
            canStrafe = false;
        }


        if (boostSFX && canBoost)
        {
            audioSource.PlayOneShot(boost, 0.7f);
            boostTimer = Time.time + 3f;
            jogTimer = 0;
            strafeTimer = 0;
            bsTimer = 0;
            


        }

        if (Time.time >= boostTimer)
        {
            canBoost = true;
        }
        else
        {
            canBoost = false;
        }


     

        if (bsSFX && canBS)
        {
            audioSource.PlayOneShot(boostStrafe, 0.7f);
            bsTimer = Time.time + 4.05f;
            strafeTimer = 0;
            boostTimer = 0;
            jogTimer = 0;
           
           

        }

        if (Time.time >= bsTimer)
        {
            canBS = true;
        }
        else
        {
            canBS = false;
        }


        

    }
}

