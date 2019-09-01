using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Sound : MonoBehaviour
{
    public AudioClip grenadexp;
    AudioSource audioSourcee;

    public static bool grenadexpSFX;
    public bool canGrenadexp;
    public float grenadexpTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grenadexpSFX && canGrenadexp)
        {
            audioSourcee.PlayOneShot(grenadexp, 0.7f);
            grenadexpTimer = Time.time + 2.4f;
        }

        if (Time.time >= grenadexpTimer)
        {
            canGrenadexp = true;
            grenadexpSFX = false;

        }
        else
        {

            canGrenadexp = false;

        }

        if (!grenadexpSFX)
        {
            // audioSourcee.Stop();
            grenadexpTimer = 0;
        }
    }
}