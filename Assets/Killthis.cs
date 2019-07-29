using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killthis : MonoBehaviour
{

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + 0.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timer)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        Destroy(this.gameObject, 6f);
    }


}
