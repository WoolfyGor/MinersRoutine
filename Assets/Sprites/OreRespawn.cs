using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class OreRespawn : MonoBehaviour
{
    public GameObject[] OreSpots;
   public GameObject CoalOre, CopperOre, IronOre, GoldOre, DiamondOre;
    public System.Random rnd;
    // Start is called before the first frame update
    void Start()
    {
        OreSpots = GameObject.FindGameObjectsWithTag("OreSpotHub");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnOre()
    {
        rnd = new System.Random();
        int ChildCount = 0;
       
        foreach (GameObject Hub in OreSpots)
        {
           
            int SpawnProbability = rnd.Next(0, 3);
     
            ChildCount = Hub.transform.childCount;
            for (int i = 0; i < ChildCount; i++)
            {
              
                if (Hub.transform.GetChild(i).childCount != 0)
                {
                    continue;
                }
                else
                {
                  
               

                    if ( SpawnProbability ==1) { 
                    switch (Hub.transform.GetChild(i).tag)
                    {
                        case "CoalSpot":
                           GameObject SpawnedOre = Instantiate(CoalOre, Hub.transform.GetChild(i));
                            break;
                            case "CopperSpot":
                                GameObject SpawnedOreC = Instantiate(CopperOre, Hub.transform.GetChild(i));
                                break;
                            case "IronSpot":
                                GameObject SpawnedOreI = Instantiate(IronOre, Hub.transform.GetChild(i));
                                break;
                            case "GoldSpot":
                                GameObject SpawnedOreG = Instantiate(GoldOre, Hub.transform.GetChild(i));
                                break;
                            case "DiamondSpot":
                                GameObject SpawnedOreD = Instantiate(DiamondOre, Hub.transform.GetChild(i));
                                break;
                        }
                    }
                }
            }
        }
    }
}
