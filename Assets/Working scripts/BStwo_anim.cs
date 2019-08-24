using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BStwo_anim : MonoBehaviour
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


        if (this.anim.GetCurrentAnimatorStateInfo(7).IsName("Fake") && isPlaying)
        {
            anim.Play("Fake", 6, 0.5f);
            isPlaying = false;
            repeatTimer = Time.time + 1.5f;
            repeat = true;
        }

        if (repeat && Time.time >= repeatTimer)
        {
            isPlaying = true;
        }

    }
}
