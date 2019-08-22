using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    public bool canLand;
    public float landTimer;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        canLand = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(5).IsName("Falland") && canLand)
        {
            //rb.constraints = RigidbodyConstraints.FreezeAll;
            Thirsperson_character.speed = 0f;
            landTimer = Time.time + 0.01f;
            canLand = false;
        }

        if(!canLand && Time.time >= landTimer)
        {
            canLand = true;
            Thirsperson_character.speed = 4f;

        }

    }


}
