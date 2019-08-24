using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf_Target : MonoBehaviour
{

    public float dwarfHealth = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float amount)
    {
        dwarfHealth -= amount;
        if(dwarfHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
