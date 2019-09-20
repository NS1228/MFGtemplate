using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead_Screen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mains ()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry ()
    {
        SceneManager.LoadScene(1);
    }

    public void Quits ()
    {
        Application.Quit();
    }
}
