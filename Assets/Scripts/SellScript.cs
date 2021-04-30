using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SellScript : MonoBehaviour
{
    InventoryScript Is;
    public TextMeshProUGUI Money;
    bool Seleld = false;
    AudioSource sellSound;
    bool InArea = false;
    // Start is called before the first frame update
    void Start()
    {
        sellSound = GetComponent<AudioSource>();
        Is = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();
    }

    public void sellOres()
    {
        if (InArea) { 
            if (Is.CoalCount != 0)
            {
                Is.Money += Is.CoalCount * 2;
            Seleld = true;
            }
            if (Is.CopperCount != 0)
            {
                Is.Money += Is.CopperCount * 5; Seleld = true;
        }
            if (Is.IronCount != 0)
            {
                Is.Money += Is.IronCount * 8; Seleld = true;
        }
            if (Is.GoldCount != 0)
            {
                Is.Money += Is.GoldCount * 20; Seleld = true;
        }
            if (Is.DiamondCount != 0)
            {
                Is.Money += Is.DiamondCount * 50; Seleld = true;
        }
        if (Seleld)
        {
            sellSound.Play();
            Seleld = false;
        }
            Is.SelledOres();
       }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            InArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InArea = false;
        }
    }

}
