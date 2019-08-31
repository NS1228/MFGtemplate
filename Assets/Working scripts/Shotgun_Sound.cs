using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_Sound : MonoBehaviour
{
    public AudioClip shotgun;
    AudioSource audioSourcee;

    public static bool shotgunSFX;
    public bool canShotgun;
    public float shotgunTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shotgunSFX && canShotgun)
        {
            audioSourcee.PlayOneShot(shotgun, 0.3f);
            shotgunTimer = Time.time + 1.07f;
        }

        if (Time.time >= shotgunTimer)
        {
            canShotgun= true;
           shotgunSFX = false;

        }
        else
        {

            canShotgun = false;

        }

        if (!shotgunSFX)
        {
            // audioSourcee.Stop();
            shotgunTimer = 0;
        }
    }
}
