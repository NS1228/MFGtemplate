using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{

    public TMPro.TextMeshProUGUI text;
    public float Gems;
    public bool canbuyBoosters;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        text.text = Gems.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gems")
        {
            Destroy(collision.gameObject);
            Gems++;
        }
    }

    public void BuyBoosters ()
    {
        if (Gems >= 1)
        {
            canbuyBoosters = true;
            print(canbuyBoosters);
        }
        else
        {
            canbuyBoosters = false;
            print(canbuyBoosters);
        }
    }

    public void Sellboosters ()
    {
        Gems += 1;
        print("Sold");
    }
}
