using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning_Gen : MonoBehaviour
{
    public GameObject lightning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 xPosition = new Vector3(Random.Range(-60.0f, 60.0f), Random.Range(2, 70f), Random.Range(-60.0f, 60.0f));
        Instantiate(lightning, xPosition, Quaternion.identity);
        
    }
}
