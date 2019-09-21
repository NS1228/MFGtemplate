using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pearls : MonoBehaviour
{
    
    public GameObject Player;

    public float destroyTimer;
    public bool destroy;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy && Time.time >= destroyTimer)
        {
            destroy = false;
            Destroy(gameObject);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            destroy = true;
            destroyTimer = Time.time + 5;
            Player.GetComponent<Money>().Gems += 25;
            Pearl_Sound.pearlSFX = true;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
    }
}
