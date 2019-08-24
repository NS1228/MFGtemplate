using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greande_Kill : MonoBehaviour
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

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player.GetComponent<Health_script>().health -= 10;
        }
    }
}
