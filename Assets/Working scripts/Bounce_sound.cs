using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_sound : MonoBehaviour
{
    public GameObject Player;

    AudioSource audioSource;
    public AudioClip skating;

    public static bool bounceSFX;
    public bool canBounce;
    public float bounceTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bounceSFX && canBounce)
        {
            audioSource.PlayOneShot(skating, 0.7f);
            bounceTimer = Time.time + 0.7f;



        }

        if (Time.time >= bounceTimer)
        {
            canBounce = true;
           // bounceSFX = false;
        }
        else
        {
            canBounce = false;
        }

        if (!bounceSFX)
        {
           // bounceTimer = 0;
            //audioSource.Stop();
           
        }

        
    }
}
