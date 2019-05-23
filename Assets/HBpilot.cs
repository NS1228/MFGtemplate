using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBpilot : MonoBehaviour
{

    public float speed = 20f;
    public float rotateSpeedLR = 20;
    public float rotateSpeedUD = 20;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        Test();

        //speed -= transform.forward.y * Time.deltaTime * 50.0f;

        if (speed < 0f)
        {
            speed = 0;
        }
        if (speed > 10f)
        {
            speed = 10;
        }

        //transform.Rotate(0.0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed, 0.0f);
    }


    public void Test()
    {
        if (move)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed -= 5 * Time.deltaTime;
            
        }
        else
        {
            
            speed += 5 * Time.deltaTime;
        }

        

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-Input.GetAxis("Vertical") * Time.deltaTime * rotateSpeedUD, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-Input.GetAxis("Vertical")* Time.deltaTime * rotateSpeedUD,0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0.0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeedLR, 0.0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeedLR, 0.0f);
        }
    }
}
