using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl_Sound : MonoBehaviour
{
    public AudioClip pearl;
    AudioSource audioSourcee;

    public static bool pearlSFX;
    public bool canPearl;
    public float pearlTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pearlSFX && canPearl)
        {
            audioSourcee.PlayOneShot(pearl, 0.05f);
            pearlTimer = Time.time + 5f;
        }

        if (Time.time >= pearlTimer)
        {
            canPearl= true;
            pearlSFX = false;

        }
        else
        {

            canPearl = false;

        }
    }
}
