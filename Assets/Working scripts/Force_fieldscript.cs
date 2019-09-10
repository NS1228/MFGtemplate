using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force_fieldscript : MonoBehaviour
{
    public float moveTimer1;
    public float moveTimer2;
    public float moveTimer3;
    public float moveTimer4;
    public float moveTimer5;


    public float speed;

    public Vector3 wave1;
    public Vector3 wave2;
    public Vector3 wave3;
    public Vector3 wave4;
    public Vector3 wave5;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;




    // Start is called before the first frame update
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= moveTimer1)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, wave1, speed * Time.deltaTime);
            spawn2.SetActive(true);
            spawn1.SetActive(false);

        }
        if (Time.time >= moveTimer2)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, wave2, speed * Time.deltaTime);
            spawn3.SetActive(true);
            spawn2.SetActive(false);


        }
        if (Time.time >= moveTimer3)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, wave3, speed * Time.deltaTime);
            spawn4.SetActive(true);
            spawn3.SetActive(false);
        }
        if (Time.time >= moveTimer4)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, wave4, speed * Time.deltaTime);
            spawn5.SetActive(true);
            spawn4.SetActive(false);
        }
        if (Time.time >= moveTimer5)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, wave5, speed * Time.deltaTime);
            spawn6.SetActive(true);
            spawn5.SetActive(false);
        }






    }
}
