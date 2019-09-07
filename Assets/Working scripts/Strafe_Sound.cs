using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strafe_Sound : MonoBehaviour
{
    public static bool strafeSFX;
    public bool canStrafe;
    public float strafeTimer;

    public static bool bsSFX;
    public bool canBS;
    public float bsTimer;

    public AudioClip boostStrafe;
    public AudioClip strafe;

    AudioSource audioSource;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (strafeSFX && canStrafe && Player.GetComponent<Thirsperson_character>().isGrounded)
        {
            //audioSource.Play();
            audioSource.PlayOneShot(strafe, 0.7f);
            strafeTimer = Time.time + 6f;
            bsTimer = 0;
         }

        if (Time.time >= strafeTimer)
        {
            canStrafe = true;
        }
        else
        {
            canStrafe = false;
        }


        if (bsSFX && canBS && Player.GetComponent<Thirsperson_character>().isGrounded)
        {
            audioSource.PlayOneShot(boostStrafe, 0.7f);
            bsTimer = Time.time + 4.05f;
            strafeTimer = 0;
      
        }

        if (Time.time >= bsTimer)
        {
            canBS = true;
        }
        else
        {
            canBS = false;
        }


        if (!strafeSFX && !bsSFX)
        {

            audioSource.Stop();
           
            strafeTimer = 0;
            
            bsTimer = 0;





        }

    }
}
