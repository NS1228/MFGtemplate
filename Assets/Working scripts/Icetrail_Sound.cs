using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icetrail_Sound : MonoBehaviour
{

    AudioSource audioSource;

    public static bool iceSFX;
    public bool canIce;
    public float iceTimer;
    public AudioClip Ice;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iceSFX && canIce)
        {
            audioSource.PlayOneShot(Ice, 0.7F);
            iceTimer = Time.time + 7f;
        }

        if (Time.time >= iceTimer)
        {

            canIce= true;

        }
        else
        {
            canIce = false;
        }

        if(!iceSFX)
        {
            audioSource.Stop();
            iceTimer = 0;
        }

    }
}
