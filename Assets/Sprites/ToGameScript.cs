using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ToGameScript : MonoBehaviour
{
    public GameObject Player, MenuUi,Cinemachine, OxBar;
    // Start is called before the first frame update

    private void Start()
    {
        MenuUi.SetActive(false);
    }
    // Update is called once per frame
    public void GameStart()
    {
        Cinemachine.GetComponent<CinemachineVirtualCamera>().Follow = Player.transform;
        MenuUi.SetActive(true);
        OxBar.transform.parent = MenuUi.transform;
        OxBar.SetActive(true);
    }
}
