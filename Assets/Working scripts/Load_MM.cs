using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_MM : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject controlsMenu;
    public GameObject creditssMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MM()
    {
        SceneManager.LoadScene(0);
    }

    public void Player()
    {
        SceneManager.LoadScene(1);
    }



    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void OptionsBack()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Controls ()
    {
        controlsMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ControlsBack()
    {
        controlsMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Credits()
    {
        creditssMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void CreditsBack()
    {
        creditssMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
