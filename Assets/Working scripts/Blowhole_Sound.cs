using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowhole_Sound : MonoBehaviour
{
    public AudioClip blowgun;
    AudioSource audioSourcee;

    public static bool blowgunSFX;
    public bool canBlowgun;
    public float blowgunTimer;

    public bool soundSwitch;
    public float switchTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (blowgunSFX && canBlowgun)
        {
            audioSourcee.PlayOneShot(blowgun, 0.7f);
            blowgunTimer = Time.time + 3f;
        }

        if (Time.time >= blowgunTimer)
        {
            canBlowgun = true;
            blowgunSFX = false;

        }
        else
        {

            canBlowgun = false;

        }

        if (!blowgunSFX)
        {
            // audioSourcee.Stop();
            blowgunTimer = 0;

            soundSwitch = true;
           
        }

       
    }
}
