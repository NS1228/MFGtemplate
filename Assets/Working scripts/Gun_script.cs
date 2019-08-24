using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_script : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera fpscam;

    private float nextTimeToFire = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >=  nextTimeToFire)
        {
            Shoot();
            nextTimeToFire = Time.time + 1f / fireRate;
            print("fire");
        }
        
    }

   void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range));
        {
            Debug.Log(hit.transform.name);

            Dwarf_Target target = hit.transform.GetComponent<Dwarf_Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal *impactForce);
            }
        }
    }
}
