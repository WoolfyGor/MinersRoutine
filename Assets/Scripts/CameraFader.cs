using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFader : MonoBehaviour
{
    SpriteRenderer FadeScreen;
    // Start is called before the first frame update
    void Start()
    {
        FadeScreen = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void FadeOn()
    {
        StartCoroutine(FadeOnCour());
    }
    public void FadeOff()
    {

        StartCoroutine(FadeOffCour());
    }
    IEnumerator FadeOnCour()
    {
        
        float DarkMultiplier = 0;
        while (DarkMultiplier < 1)
        {
            DarkMultiplier += 0.05f;
     
            FadeScreen.color= new Color(0,0,0, DarkMultiplier);
            yield return new WaitForSeconds(0.02f);
        }

        StopCoroutine(FadeOnCour());
        yield return null;
    }
    IEnumerator FadeOffCour()
    {
      
        yield return new WaitForSeconds(4f);
       
        float DarkMultiplier = 1;
  
        while (DarkMultiplier > 0)
        {
            Debug.Log(DarkMultiplier);
          
            FadeScreen.color = new Color(0, 0, 0, DarkMultiplier);
            yield return new WaitForSeconds(0.02f);
        }
        StopCoroutine(FadeOffCour());
        yield return null;
    }
    public IEnumerator FixProblem()
    {
        yield return new WaitForSeconds(6f);
        FadeScreen.color = new Color(0, 0, 0, 0);
        StopAllCoroutines();
    }
}
