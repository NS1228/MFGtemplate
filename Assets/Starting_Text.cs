using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_Text : MonoBehaviour
{
    public GameObject text;
    public float timer = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timer)
        {
            text.SetActive(false);
        }
        
    }

}
