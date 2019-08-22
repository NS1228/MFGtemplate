using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_anim : MonoBehaviour
{
    Animator anim;
    public bool isPlaying;

    public float repeatTimer;
    public bool repeat;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.anim.GetCurrentAnimatorStateInfo(6).IsName("FlyingLOOP") && isPlaying)
        {
            anim.Play("FlyingLOOP", 6, 0.25f);
            isPlaying = false;
            repeatTimer = Time.time + 4.57f;
            repeat = true;
            print("IT WORKS");
        }

        if (repeat && Time.time >= repeatTimer)
        {
            isPlaying = true;
            
        }

    }
}
