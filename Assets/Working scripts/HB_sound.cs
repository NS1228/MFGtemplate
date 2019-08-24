using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HB_sound : MonoBehaviour
{
    AudioSource audioSource;

    public static bool hbSFX;
    public bool canHB;
    public float hbTimer;
    public AudioClip hoverboard;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hbSFX && canHB)
        {
            audioSource.PlayOneShot(hoverboard, 0.7F);
            hbTimer = Time.time + 11.65f;
        }

        if(Time.time >= hbTimer)
        {
            canHB = true;
        }
        else
        {
            canHB = false;
        }

        if(!hbSFX)
        {
            audioSource.Stop();
            hbTimer = 0;
        }
    }
}
