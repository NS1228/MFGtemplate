using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Sound : MonoBehaviour
{
    public AudioClip heal;
    AudioSource audioSourcee;

    public static bool healSFX;
    public bool canHeal;
    public float healTimer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healSFX && canHeal)
        {
            audioSourcee.PlayOneShot(heal, 0.7f);
            healTimer = Time.time + 5f;
        }

        if (Time.time >= healTimer)
        {
            canHeal = true;
            healSFX = false;

        }
        else
        {

            canHeal = false;

        }
    }
}
