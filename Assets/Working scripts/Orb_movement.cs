using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_movement : MonoBehaviour
{
    public float speed = 10;

    public bool destroy;
    public float destroyTimer;

    public AudioClip orbExp;
    AudioSource audioSourcee;

    public GameObject orbexp;
    public GameObject expPoint;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position += transform.forward * Time.deltaTime * speed;
        
        //transform.rotation = 
        if(destroy && Time.time >= destroyTimer)
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision other)
    {
    if(other.gameObject.tag == "Axer")
        {
            other.gameObject.GetComponent<AI_health>().health -= 40;
            // Destroy(gameObject);
            this.GetComponent<SphereCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            destroy = true;
            destroyTimer = Time.time + 3f;
            print("COLLIDE");
            audioSourcee.PlayOneShot(orbExp, 0.7f);
            Instantiate(orbexp, expPoint.transform.position, expPoint.transform.rotation);
        }

        if (other.gameObject.tag == "Shotguner")
        {
            other.gameObject.GetComponent<AI_health>().health -= 40;
            this.GetComponent<SphereCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            destroy = true;
            destroyTimer = Time.time + 3f;
            print("COLLIDE");
            audioSourcee.PlayOneShot(orbExp, 0.7f);
            Instantiate(orbexp, expPoint.transform.position, expPoint.transform.rotation);
        }

        if (other.gameObject.tag == "Blowguner")
        {
            other.gameObject.GetComponent<AI_health>().health -= 40;
            this.GetComponent<SphereCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            destroy = true;
            destroyTimer = Time.time + 3f;
            print("COLLIDE");
            audioSourcee.PlayOneShot(orbExp, 0.7f);
            Instantiate(orbexp, expPoint.transform.position, expPoint.transform.rotation);
        }
    }


}
