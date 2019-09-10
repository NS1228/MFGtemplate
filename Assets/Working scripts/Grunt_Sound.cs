using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Sound : MonoBehaviour
{
    public AudioClip grunt;
    AudioSource audioSourcee;

    public static bool gruntSFX;
    public bool canGrunt;
    public float gruntTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gruntSFX && canGrunt)
        {
            audioSourcee.PlayOneShot(grunt, 0.7f);
            gruntTimer = Time.time + 2.4f;
        }

        if (Time.time >= gruntTimer)
        {
            canGrunt = true;
            gruntSFX = false;

        }
        else
        {

            canGrunt = false;

        }

        
    }
}
