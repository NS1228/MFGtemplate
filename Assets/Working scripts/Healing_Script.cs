using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing_Script : MonoBehaviour
{

    public GameObject Player;

    public float destroyTimer;
    public bool destroy;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(destroy && Time.time >= destroyTimer)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            destroy = true;
            destroyTimer = Time.time + 5;
            Player.GetComponent<Health_script>().health += 50;
            Heal_Sound.healSFX = true;
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
    }
}
