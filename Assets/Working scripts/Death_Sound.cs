using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Sound : MonoBehaviour
{
    public AudioClip dwarfdeath;
    AudioSource audioSourcee;

    public static bool dwarfdeathSFX;
    public bool canDwarfDeath;
    public float dwarfdeathTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dwarfdeathSFX && canDwarfDeath)
        {
            audioSourcee.PlayOneShot(dwarfdeath, 0.7f);
            dwarfdeathTimer = Time.time + 10f;
        }

        if (Time.time >= dwarfdeathTimer)
        {
            canDwarfDeath = true;
            dwarfdeathSFX = false;

        }
        else
        {

            canDwarfDeath = false;

        }

        if (!dwarfdeathSFX)
        {
            audioSourcee.Stop();
            dwarfdeathTimer = 0;
        }
    }
}
