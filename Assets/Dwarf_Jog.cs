using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf_Jog : MonoBehaviour
{
    public AudioClip dwarfjog;
    AudioSource audioSourcee;

    public static bool dwarfjogSFX;
    public bool canDwarfJog;
    public float dwarfjogTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dwarfjogSFX && canDwarfJog)
        {
            audioSourcee.PlayOneShot(dwarfjog, 0.3f);
            dwarfjogTimer = Time.time + 4f;
        }

        if (Time.time >= dwarfjogTimer)
        {
            canDwarfJog = true;
            dwarfjogSFX = false;

        }
        else
        {

            canDwarfJog = false;

        }

        if (!dwarfjogSFX)
        {
            audioSourcee.Stop();
            dwarfjogTimer = 0;
        }
    }
}
