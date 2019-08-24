using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrocute_script : MonoBehaviour
{
    public GameObject electroPlatform;

    public bool spawnElectro;
    public float maxElectro = 50;
    public float numElectro = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnElectro = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnElectro && numElectro <= maxElectro)
        {
            Vector3 xPosition = new Vector3(Random.Range(-50.0f, 50.0f), Random.Range(20, 100f), Random.Range(-50.0f, 50.0f));

            Instantiate(electroPlatform, xPosition, Quaternion.identity);

            numElectro += 1;

           
        }
    }
}
