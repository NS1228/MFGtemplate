using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems_Script : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Player.GetComponent<Gem_Inventory>().noOfGems += 1;

        }
    }
}
