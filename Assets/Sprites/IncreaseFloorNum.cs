using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFloorNum : MonoBehaviour
{
    LiftController LC;
    // Start is called before the first frame update
    void Start()
    {
        LC = GameObject.Find("Elevator").GetComponent<LiftController>();  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            LC.OpenedFloors++;
            Destroy(gameObject);
        }
    }
}
