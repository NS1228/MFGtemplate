using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep_Sound : MonoBehaviour
{
    public GameObject Dwarf;

    public AudioClip sleep;
    AudioSource audioSourcee;

    public static bool sleepingSFX;
    public bool canSleeping;
    public float sleepingTimer;
    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Dwarf.GetComponent<Sleeping_Enemies>().takeSleepDMG)
        {
            sleepingSFX = true;
        }
        else
        {
            sleepingSFX = false;
        }

        if (sleepingSFX && canSleeping)
        {
            audioSourcee.PlayOneShot(sleep, 0.7f);
            sleepingTimer = Time.time + 10f;
             

        }

        if (Time.time >= sleepingTimer)
        {
            canSleeping = true;
        }
        else
        {
            canSleeping = false;
        }

        if (!sleepingSFX)
        {

            audioSourcee.Stop();

            sleepingTimer = 0;



        }
    }
}
