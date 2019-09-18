using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems_Script : MonoBehaviour
{
    public GameObject Player;

    public bool destroy;
    public float destroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
     
        if(destroy && Time.time >= destroyTimer)
        {
            destroy = false;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<MeshCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            Player.GetComponent<Gem_Inventory>().noOfGems += 1;
            Gemmy_Soound.gemmySFX = true;
            destroyTimer = Time.time + 3.5f;
            destroy = true;

        }
    }
}
