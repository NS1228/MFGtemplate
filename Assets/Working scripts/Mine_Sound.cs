using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_Sound : MonoBehaviour
{

    AudioSource audioSource;

    public static bool mineSFX;
    public bool canMine;
    public float mineTimer;
    public AudioClip mine;

    public static bool sleeperSFX;
    public bool canSleep;
    public float sleepTimer;
    public AudioClip sleeper;

    public static bool turretSFX;
    public bool canTurret;
    public float turretTimer;
    public AudioClip turret;

    public static bool lightningSFX;
    public bool canLightning;
    public float lightningTimer;
    public AudioClip lightning;

    public static bool grenadeSFX;
    public bool canGrenade;
    public float grenadeTimer;
    public AudioClip grenade;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mineSFX && canMine)
        {
            audioSource.PlayOneShot(mine, 0.7F);
            mineTimer = Time.time + 2f;
        }

        if (Time.time >= mineTimer)
        {

            canMine = true;

        }
        else
        {
            canMine = false;
        }

        if (sleeperSFX && canSleep)
        {
            audioSource.PlayOneShot(sleeper, 0.7F);
            sleepTimer = Time.time + 5f;
        }

        if (Time.time >= sleepTimer)
        {

            canSleep = true;

        }
        else
        {
            canSleep = false;
        }


        if (turretSFX && canTurret)
        {
            audioSource.PlayOneShot(turret, 0.7F);
            turretTimer = Time.time + 0.69f;
        }

        if (Time.time >= turretTimer)
        {

            canTurret = true;

        }
        else
        {
            canTurret = false;
        }

        if (lightningSFX && canLightning)
        {
            audioSource.PlayOneShot(lightning, 0.7F);
           lightningTimer = Time.time + 5f;
        }

        if (Time.time >= lightningTimer)
        {

            canLightning = true;

        }
        else
        {
            canLightning = false;
        }

        if (grenadeSFX && canGrenade)
        {
            audioSource.PlayOneShot(grenade, 0.7F);
            grenadeTimer = Time.time + 10f;
        }

        if (Time.time >= grenadeTimer)
        {

            canGrenade = true;

        }
        else
        {
            canGrenade = false;
        }


    }
}
