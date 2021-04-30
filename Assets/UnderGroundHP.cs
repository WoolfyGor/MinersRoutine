using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnderGroundHP : MonoBehaviour
{
    GameObject Character,Spawn;
    public float Oxygen = 1 ;
    public Slider SE;
    bool Underground = true, Fading = false;
    InventoryScript IS;
    CameraFader CF;
    // Start is called before the first frame update
    private void Awake()
    {
        SE = GetComponent<Slider>();
        Character = GameObject.Find("Character");
        Spawn = GameObject.Find("Respawn");
        CF = GameObject.Find("FadeWhenFall").GetComponent<CameraFader>();
        IS = GameObject.Find("Inventory").GetComponent<InventoryScript>();
        StartCoroutine(CheckState());
        StartCoroutine(OxygenManager());
    }
    void Start()
    {
       
    }

  IEnumerator CheckState()
    {
        while (true)
        {
            if(Character.transform.position.y > -5)
            {
                Underground = true; 
            }
            else
            {
                Underground = false;
            }

            yield return new WaitForSeconds(5f);
            
        }
    }
    IEnumerator OxygenManager()
    {
        while (true) {

            if (!Underground)
            {
                Oxygen -= 0.03f;
                if (Oxygen < 0.1)
                {
                    if (!Fading)
                    {
                        CF.FadeOn();
                        StartCoroutine(UndoFade());
                        Fading = true;
                       
                    }
                }
            }
            else
            {
                if (Oxygen < 1) { 
            Oxygen += 0.1f;
                }
            }
            ChangeSliderPosition(Oxygen);
            yield return new WaitForSeconds(2f);
        }
    }
    IEnumerator UndoFade()
    {
        IS.StuckPenalty();
    
        yield return new WaitForSeconds(5f);
        Oxygen = 1f;
        Character.transform.position = Spawn.transform.position;
        CF.FadeOff();
        CF.StartCoroutine(CF.FixProblem());
        Fading = false;
      
    }
    void ChangeSliderPosition(float position)
    {
        SE.value = position;
    }
}
