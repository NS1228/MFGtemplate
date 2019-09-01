using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Audio : MonoBehaviour
{
    public AudioClip turret;
    AudioSource audioSourcee;

    public static bool turretSFX;
    public bool canTurret;
    public float turretTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turretSFX && canTurret)
        {
            audioSourcee.PlayOneShot(turret, 0.3f);
            turretTimer = Time.time + 0.7f;
        }

        if (Time.time >= turretTimer)
        {
            canTurret = true;
            turretSFX = false;

        }
        else
        {

            canTurret = false;

        }

        if (!turretSFX)
        {
            // audioSourcee.Stop();
            turretTimer = 0;
        }
    }
}
