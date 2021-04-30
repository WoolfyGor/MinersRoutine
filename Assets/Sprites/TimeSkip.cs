using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSkip : MonoBehaviour
{
    CameraFader CF;
    public bool Fading = false;

    OreRespawn OR;
    GameObject CanvasRest;
    // Start is called before the first frame update
    void Start()
    {
        CF = GameObject.Find("FadeWhenFall").GetComponent<CameraFader>();
 
        OR = GameObject.Find("OreRespawnObj").GetComponent<OreRespawn>();
        CanvasRest = transform.GetChild(0).gameObject;
        CanvasRest.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CanvasRest.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CanvasRest.SetActive(false);
    }
    public void Skipping()
    {
        if (!Fading) {
            CF.FadeOn();
            StartCoroutine(UndoFade());
            Fading = true;
        }
    }
    IEnumerator UndoFade()
    {
        yield return new WaitForSeconds(5f);
        CF.FadeOff();
        OR.RespawnOre();
        CF.StartCoroutine(CF.FixProblem());
        Fading = false;
        CanvasRest.SetActive(false);
    }
}
