using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_sound : MonoBehaviour
{

    public AudioClip jump;
   AudioSource audioSourcee;

    public static bool jumpSFX;
    public bool canJump;
    public float jumpTimer;
    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (jumpSFX && canJump)
        {
            audioSourcee.PlayOneShot(jump, 0.7f);
            jumpTimer = Time.time + 1f;
        }

        if (Time.time >= jumpTimer)
        {
            canJump = true;
            jumpSFX = false;

        }
        else
        {
            
            canJump = false;

        }

        if(!jumpSFX)
        {
            //audioSourcee.Stop();
            jumpTimer = 0;
        }

    }
}
