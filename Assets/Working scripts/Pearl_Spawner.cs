using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl_Spawner : MonoBehaviour
{
    public GameObject pearls;

    public float pearlCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pearlCount <= 500)
        {
            Vector3 xPosition = new Vector3(Random.Range(-60.0f, 60.0f), Random.Range(2, 70f), Random.Range(-60.0f, 60.0f));
            Instantiate(pearls, xPosition, Quaternion.identity);
            pearlCount++;
        }
    }
}
