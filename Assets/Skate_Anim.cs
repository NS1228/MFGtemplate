using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skate_Anim : MonoBehaviour
{

    Animator anim;
    public bool isPlaying;

    public float repeatTimer;
    public bool repeat;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (repeat && Time.time >= repeatTimer)
        {
            isPlaying = true;
        }

        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Slow") && isPlaying)
        {
            anim.Play("Slow", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }
        if(this.anim.GetCurrentAnimatorStateInfo(3).IsName("Med") && isPlaying)
        {
            anim.Play("Med", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }
        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast") && isPlaying)
        {
            anim.Play("Fast", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }

        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast1") && isPlaying)
        {
            anim.Play("Fast1", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }

        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast2") && isPlaying)
        {
            anim.Play("Fast2", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }

        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast3") && isPlaying)
        {
            anim.Play("Fast3", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }
        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast5") && isPlaying)
        {
            anim.Play("Fast5", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }
        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast6") && isPlaying)
        {
            anim.Play("Fast6", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }
        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast7") && isPlaying)
        {
            anim.Play("Fast7", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }
        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast8") && isPlaying)
        {
            anim.Play("Fast8", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }
        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast9") && isPlaying)
        {
            anim.Play("Fast9", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }
        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast10") && isPlaying)
        {
            anim.Play("Fast10", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }
        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast11") && isPlaying)
        {
            anim.Play("Fast11", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }
        if (this.anim.GetCurrentAnimatorStateInfo(3).IsName("Fast12") && isPlaying)
        {
            anim.Play("Fast12", 3, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 2.2f;
            repeat = true;
        }

    }
}
