using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            transform.position += Vector3.up * Time.deltaTime * 2;
            this.GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
       
    }
}
