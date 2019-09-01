using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze_Soundy : MonoBehaviour
{
   

    public AudioClip freeze;
    AudioSource audioSourcee;

    public static bool freezeSFX;
    public bool canFreeze;
    public float freezeTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (freezeSFX && canFreeze)
        {
            //audioSource.Play();
            audioSourcee.PlayOneShot(freeze, 1f);
            freezeTimer = Time.time + 8.5f;
            
        }

        if (Time.time >= freezeTimer)
        {
            canFreeze = true;
        }
        else
        {
            canFreeze = false;
        }

        if (!freezeSFX)
        {
           
            audioSourcee.Stop();
              

            freezeTimer = 0;



        }
    }
}
