using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foilage_Gen : MonoBehaviour
{
    public GameObject foilage;

    public float foilageCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (foilageCount <= 5000)
        {
            Vector3 xPosition = new Vector3(Random.Range(-60.0f, 60.0f), Random.Range(2, 70f), Random.Range(-60.0f, 60.0f));
            Instantiate(foilage, xPosition, Quaternion.identity);
            foilageCount++;
        }

    }
}
