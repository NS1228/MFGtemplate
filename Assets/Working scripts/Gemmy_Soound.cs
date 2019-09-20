using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemmy_Soound : MonoBehaviour
{
    public AudioClip gem;
    AudioSource audioSourcee;

    public static bool gemmySFX;
    public bool canGem;
    public float gemTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gemmySFX && canGem)
        {
            audioSourcee.PlayOneShot(gem, 0.5f);
            gemTimer = Time.time + 3.5f;
        }

        if (Time.time >= gemTimer)
        {
            canGem = true;
            gemmySFX = false;

        }
        else
        {

            canGem = false;

        }
    }
}
