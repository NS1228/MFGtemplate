using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Switch : MonoBehaviour
{
    public static bool muteSound;

    AudioSource audios;
    // Start is called before the first frame update
    void Start()
    {
        audios = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        print(muteSound);

        if (this.GetComponent<Mine_Generator>().deployMine == true)
        {
            muteSound = true;
        }
        else if (this.GetComponent<Enemy_Sleeper>().inUse == true)
        {
            
            
        }
        else if (this.GetComponent<Spawn_Objects>().animPlay == true)
          {
            
        }
        else
        {
            muteSound = false;
        }
        
    }
}
