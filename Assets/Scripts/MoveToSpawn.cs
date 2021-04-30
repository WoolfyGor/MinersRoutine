using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSpawn : MonoBehaviour
{
    GameObject Respawn;
    CameraFader CF;
    bool Fading = false;
    OreRespawn OR;
    InventoryScript IS;
    // Start is called before the first frame update
    void Start()
    {
        Respawn = GameObject.FindGameObjectWithTag("Respawn");
        IS = GameObject.Find("Inventory").GetComponent<InventoryScript>();
        CF = GameObject.Find("FadeWhenFall").GetComponent<CameraFader>();
        OR = GameObject.Find("OreRespawnObj").GetComponent<OreRespawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController PC = collision.GetComponent<PlayerController>();
        if (collision.CompareTag("Player") && PC != null && !PC.Fading)
        {
            PC.Fading = true;
            StartCoroutine(DelaySpawn(collision, PC));
        }
    }
    IEnumerator DelaySpawn(Collider2D collision,PlayerController PC)
    {
  
        CF.FadeOn();
        CF.FadeOff();
      
       CF.StartCoroutine(CF.FixProblem());
        yield return new WaitForSeconds(1f);
      
            collision.transform.position = Respawn.transform.position;
        OR.RespawnOre();
        IS.StuckPenalty();
        PC.Fading = false;
        yield return null;
    }
}
