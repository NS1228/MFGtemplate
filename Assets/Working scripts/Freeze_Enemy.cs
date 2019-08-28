using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze_Enemy : MonoBehaviour
{

    public float timer;
    Rigidbody m_Rigidbody;

   
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Axer")
        {
            collision.gameObject.GetComponent<Enemy_Movement>().MoveSpeed -= 1;
            timer = Time.time + 5;

            collision.gameObject.GetComponent<Enemy_Movement>().isFrozen = true;

            
        }


        



    }






}
