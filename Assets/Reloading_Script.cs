using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloading_Script : MonoBehaviour
{
    public AudioClip reload;
    AudioSource audioSourcee;

    public static bool reloadSFX;
    public bool canReload;
    public float reloadTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadSFX && canReload)
        {
            audioSourcee.PlayOneShot(reload, 0.3f);
            reloadTimer = Time.time + 3.65f;
        }

        if (Time.time >= reloadTimer)
        {
            canReload = true;
            reloadSFX = false;

        }
        else
        {

            canReload = false;

        }

        if (!reloadSFX)
        {
            // audioSourcee.Stop();
            reloadTimer = 0;
        }
    }
}
