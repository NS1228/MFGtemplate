using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS_Sound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip skating;

    public static bool skatingSFX;
    public bool canSkate;
    public float skatingTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (skatingSFX && canSkate)
        {
            audioSource.PlayOneShot(skating, 0.7f);
           skatingTimer = Time.time + 18f;



        }

        if (Time.time >= skatingTimer)
        {
            canSkate = true;
        }
        else
        {
            canSkate = false;
        }

        if (!skatingSFX)
        {
            audioSource.Stop();
            skatingTimer = 0;
        }
    }
}

