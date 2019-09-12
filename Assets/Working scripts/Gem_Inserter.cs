using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem_Inserter : MonoBehaviour
{
    public GameObject Player;
    public GameObject pillar;
    public bool canUse;

    public GameObject gem;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        pillar = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUse)
        {
            if (Input.GetKey(KeyCode.X) && Player.GetComponent<Gem_Inventory>().noOfGems >= 1)
            {
                Player.GetComponent<Gem_Inventory>().noOfGems -= 1;
                pillar.GetComponent<Pillar>().pillarGem += 1;
                gem.SetActive(true);
                Destroy(gameObject);
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
