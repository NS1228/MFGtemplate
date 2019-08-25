using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_movement : MonoBehaviour
{
    public float speed = 10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        
        //transform.rotation = 


    }

    void OnCollisionEnter(Collision other)
    {
    if(other.gameObject.tag == "Shotguner")
        {
            other.gameObject.GetComponent<AI_health>().health -= 100;
            Destroy(gameObject, 10f);
        }
    }
}
