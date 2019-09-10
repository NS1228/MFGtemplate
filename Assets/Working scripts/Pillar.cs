using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public GameObject Player;

    public bool canUse;
    public float pillarGem;

    public GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(pillarGem >= 5)
        {
            portal.SetActive(true);
        }
        

        if(canUse)
        {
            if (Input.GetKey(KeyCode.X) && Player.GetComponent<Gem_Inventory>().noOfGems >= 1)
            {
                Player.GetComponent<Gem_Inventory>().noOfGems -= 1;
                pillarGem = +1;
            }
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUse = true;

        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUse = false;

        }
    }
}
