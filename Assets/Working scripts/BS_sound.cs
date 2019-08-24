using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BS_sound : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip rolling;

    public static bool rollingSFX;
    public bool canRolling;
    public float rollingTimer;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rollingSFX && canRolling)
        {
            audioSource.PlayOneShot(rolling, 0.7f);
            rollingTimer = Time.time + 3.8f;
            


        }

        if (Time.time >= rollingTimer)
        {
            canRolling = true;
        }
        else
        {
            canRolling = false;
        }

        if (!rollingSFX)
        {
           audioSource.Stop();
           rollingTimer = 0;
        }
    }
}
