using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPickUp : MonoBehaviour
{
    InventoryScript IS;
    // Start is called before the first frame update
    void Start()
    {
        IS = GameObject.Find("Inventory").GetComponent<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IS.Money += 150;
            IS.UpdateMoney();
            Destroy(gameObject);
        }
    }
}
