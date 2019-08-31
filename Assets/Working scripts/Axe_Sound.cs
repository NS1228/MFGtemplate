using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe_Sound : MonoBehaviour
{
    public AudioClip axe;
    AudioSource audioSourcee;

    public static bool axeSFX;
    public bool canAxe;
    public float axeTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (axeSFX && canAxe)
        {
            audioSourcee.PlayOneShot(axe, 0.3f);
            axeTimer = Time.time + 1.07f;
        }

        if (Time.time >= axeTimer)
        {
           canAxe = true;
           axeSFX = false;

        }
        else
        {

            canAxe = false;

        }

        if (!axeSFX)
        {
           // audioSourcee.Stop();
           axeTimer = 0;
        }
    }
}
