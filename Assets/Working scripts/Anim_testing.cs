using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_testing : MonoBehaviour
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
       

        if (this.anim.GetCurrentAnimatorStateInfo(2).IsName("BS1") && isPlaying)
        {
            anim.Play("BS1", 2, 0.2f);
            isPlaying = false;
            repeatTimer = Time.time + 3.41f;
            repeat = true;
        }
        

       if(repeat && Time.time >= repeatTimer)
        {
            isPlaying = true;
        }


       
    }


}
