using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_thecamera : MonoBehaviour
{

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = target.transform.rotation;
    }
}
