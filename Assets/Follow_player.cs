using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_player : MonoBehaviour
{

    public GameObject targ;
    public Transform start;
    public Transform end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, 100);
        transform.position = Vector3.Lerp(start.position, end.position, Time.time);
    }
}
