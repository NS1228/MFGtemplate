using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMC_Sound : MonoBehaviour
{
    public AudioClip death;
    AudioSource audioSourcee;

    public static bool deathSFX;
    public bool canDeath;
    public float deathTimer;
    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (deathSFX && canDeath)
        {
            audioSourcee.PlayOneShot(death, 0.7f);
            deathTimer = Time.time + 10f;
        }

        if (Time.time >= deathTimer)
        {
            canDeath = true;
            deathSFX = false;

        }
        else
        {

            canDeath = false;

        }
    }
}
