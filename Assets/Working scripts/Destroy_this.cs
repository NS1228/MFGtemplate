using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_this : MonoBehaviour
{
    public float destroy;
    public bool now;

    // Start is called before the first frame update
    void Start()
    {
        destroy = Time.time + Random.Range(8.0f, 15.0f);
        now = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= destroy && now)
        {
            Destroy(this.gameObject);
        }
    }
}
