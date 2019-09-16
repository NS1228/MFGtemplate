using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem_Inventory : MonoBehaviour
{
    public float noOfGems;

    public GameObject[] gemText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(noOfGems == 0)
        {
            gemText[0].SetActive(true);
            gemText[1].SetActive(false);
            gemText[2].SetActive(false);
            gemText[3].SetActive(false);
            gemText[4].SetActive(false);
            gemText[5].SetActive(false);

        }
        if (noOfGems == 1)
        {
            gemText[1].SetActive(true);
            gemText[0].SetActive(false);
            gemText[2].SetActive(false);
            gemText[3].SetActive(false);
            gemText[4].SetActive(false);
            gemText[5].SetActive(false);
        }
        if (noOfGems == 2)
        {
            gemText[2].SetActive(true);
            gemText[0].SetActive(false);
            gemText[2].SetActive(false);
            gemText[3].SetActive(false);
            gemText[4].SetActive(false);
            gemText[5].SetActive(false);
        }
        if (noOfGems == 3)
        {
            gemText[3].SetActive(true);
            gemText[1].SetActive(false);
            gemText[2].SetActive(false);
            gemText[0].SetActive(false);
            gemText[4].SetActive(false);
            gemText[5].SetActive(false);
        }
        if (noOfGems == 4)
        {
            gemText[4].SetActive(true);
            gemText[1].SetActive(false);
            gemText[2].SetActive(false);
            gemText[3].SetActive(false);
            gemText[0].SetActive(false);
            gemText[5].SetActive(false);
        }
        if (noOfGems == 5)
        {
            gemText[5].SetActive(true);
            gemText[1].SetActive(false);
            gemText[2].SetActive(false);
            gemText[3].SetActive(false);
            gemText[4].SetActive(false);
            gemText[0].SetActive(false);
        }

    }
}
