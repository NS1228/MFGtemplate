using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Bounce : MonoBehaviour
{
    public AudioClip gbounce;
    AudioSource audioSourcee;

    public static bool gbounceSFX;
    public bool canGbounce;
    public float gbounceTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gbounceSFX && canGbounce)
        {
            audioSourcee.PlayOneShot(gbounce, 0.05f);
            gbounceTimer = Time.time + 50f;
        }

        if (Time.time >= gbounceTimer)
        {
            canGbounce = true;
            gbounceSFX = false;

        }
        else
        {

            canGbounce = false;

        }

        if (!gbounceSFX)
        {
            //audioSourcee.Stop();
            gbounceTimer = 0;
        }
    }
}