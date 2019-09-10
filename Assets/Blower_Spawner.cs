using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower_Spawner : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    public bool canSpawn;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        canSpawn = true;
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        

        if (canSpawn)
        {
            Instantiate(spawnee, transform.position, transform.rotation);
            canSpawn = false;
        }
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
