using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Sound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip fp;

    public static bool fpSFX;
    public bool canFP;
    public float fpTimer;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fpSFX && canFP)
        {
            audioSource.PlayOneShot(fp, 0.7f);
            fpTimer = Time.time + 8.85f;



        }

        if (Time.time >= fpTimer)
        {
            canFP = true;
        }
        else
        {
            canFP = false;
        }

        if (!fpSFX)
        {
            audioSource.Stop();
            fpTimer = 0;
        }
    }
}

