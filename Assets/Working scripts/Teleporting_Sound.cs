using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting_Sound : MonoBehaviour
{
    AudioSource audioSource;

    public static bool tpSFX;
    public bool canTP;
    public float tpTimer;
    public AudioClip teleport;

    public static bool muteWalk;
    public bool muteWalking;
    public float muteTimer;

    public GameObject player;

  
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (tpSFX && canTP)
            {
                audioSource.PlayOneShot(teleport, 0.7F);
                tpTimer = Time.time + 3f;
            muteWalk = true;
            muteWalking = true;
            muteTimer = Time.time + 1;
            Sound_Manager.jogSFX = false;
            Strafe_Sound.strafeSFX = false;
            player.GetComponent<Normal_jump>().enabled = false;
          
            
            
            }

            if (Time.time >= tpTimer)
            {

                canTP = true;

            }
            else
            {
                canTP = false;
            }


            if(muteWalking && Time.time >= muteTimer)
        {
            muteWalk = false;
            Sound_Manager.jogSFX = true;
            Strafe_Sound.strafeSFX = true;
            muteWalking = false;
            player.GetComponent<Normal_jump>().enabled = true;


        }

          

            
        }
    }

