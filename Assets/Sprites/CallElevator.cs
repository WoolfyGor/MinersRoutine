using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CallElevator : MonoBehaviour
{
    public int CurrentFloor;
    LiftController LC;
    void Start()
    {
        CurrentFloor = Convert.ToInt32(name.Substring(4));
        LC = GameObject.Find("Elevator").GetComponent<LiftController>();
    }

    public void MyButtonClick()
    {
        if(LC.CurrentFloor != CurrentFloor)
        {
            LC.ByButton = true;
            switch (CurrentFloor)
            {
                case 0:
                    LC.OnButtonClickFloor0();
                    break;
                case 1:
                    LC.OnButtonClickFloor1();
                    break;
                case 2:
                    LC.OnButtonClickFloor5();
                    break;
                case 3:
                    LC.OnButtonClickFloor10();
                    break;
                case 4:
                    LC.OnButtonClickFloor15();
                    break;
                case 5:
                    LC.OnButtonClickFloor20();
                    break;
                case 6:
                    LC.OnButtonClickFloor25();
                    break;
                case 7:
                    LC.OnButtonClickFloor30();
                    break;
            }
         
        }
    }
}
