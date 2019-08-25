using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbClapSound : MonoBehaviour
{
    public AudioClip orb;
    AudioSource audioSourcee;

    public static bool orbSFX;
    public bool canOrb;
    public float orbTimer;
    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (orbSFX && canOrb)
        {
            audioSourcee.PlayOneShot(orb, 0.7f);
            orbTimer = Time.time + 1f;
        }

        if (Time.time >= orbTimer)
        {
            canOrb = true;
            orbSFX = false;

        }
        else
        {

            canOrb = false;

        }

        
    }
}
