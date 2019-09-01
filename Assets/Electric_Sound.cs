using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric_Sound : MonoBehaviour
{
    public AudioClip shock;
    AudioSource audioSourcee;

    public static bool shockSFX;
    public bool canShock;
    public float shockTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shockSFX && canShock)
        {
            audioSourcee.PlayOneShot(shock, 0.7f);
            shockTimer = Time.time + 0.7f;
        }

        if (Time.time >= shockTimer)
        {
            canShock = true;
            shockSFX = false;

        }
        else
        {

            canShock = false;

        }

        if (!shockSFX)
        {
            // audioSourcee.Stop();
            shockTimer = 0;
        }
    }
}
