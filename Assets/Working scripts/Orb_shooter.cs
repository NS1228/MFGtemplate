using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_shooter : MonoBehaviour
{
    public GameObject orbs;
    public Transform spawnPosition;
    public float bulletImpulse;

    

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timer)
        {
            GameObject bullet = Instantiate(orbs,spawnPosition.transform.position, spawnPosition.transform.rotation) as GameObject;
           // bullet.transform.position += transform.forward * Time.deltaTime * bulletImpulse;

            timer = Time.time + 2;
            
        }

        

    }
}
