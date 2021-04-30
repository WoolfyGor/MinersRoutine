using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
public class InventoryScript : MonoBehaviour
{

   public int CoalCount, CopperCount, IronCount, GoldCount, DiamondCount,Money;
   public TextMeshProUGUI[] OresText;
   public GameObject[] Icons;
    // Start is called before the first frame update
    private void Awake()
    {
       //цццццц Icons = GameObject.FindGameObjectsWithTag("IconTag");
        foreach (GameObject obj in Icons)
        {
            obj.SetActive(false);
        }


    }
    void Start()
    {
      
    }

 public void Add(string Ore) {
    switch (Ore)
        {
            case "CoalOre":
                if(CoalCount == 0)
                {
                    Icons[0].SetActive(true);
                }

                CoalCount++;
                OresText[0].text = CoalCount.ToString();
                
                break;

                case "CopperOre":
                if (CopperCount == 0)
                {
                    Icons[1].SetActive(true);
                }
                CopperCount++;
                OresText[1].text = CopperCount.ToString();
                break;
            case "IronOre":
                if (IronCount == 0)
                {
                    Icons[2].SetActive(true);
                }
                IronCount++;
                OresText[2].text = IronCount.ToString();
                break;
            
            case "GoldOre":
                if (GoldCount == 0)
                {
                    Icons[3].SetActive(true);
                }
                GoldCount++;
                OresText[3].text = GoldCount.ToString();
                break;
            case "DiamondOre":
                if (CoalCount == 0)
                {
                    Icons[4].SetActive(true);
                }
                DiamondCount++;
                OresText[4].text = DiamondCount.ToString();
                break;
        }

    }
    public void SelledOres()
    {
        foreach (TextMeshProUGUI txt in OresText)
        {
            txt.text = 0.ToString();
        }
        CoalCount = 0;
        IronCount = 0;
        CopperCount = 0;
        GoldCount = 0;
        DiamondCount = 0;
        OresText[5].text = Money.ToString();
        foreach (GameObject obj in Icons)
        {
            obj.SetActive(false);
        }
    }
    public void UpdateMoney()
    {
        OresText[5].text = Money.ToString();
    }
    public void StuckPenalty()
    {
        if(CoalCount != 0)
        {
            CoalCount = Convert.ToInt32(Math.Ceiling(CoalCount*0.33)); OresText[0].text = CoalCount.ToString();
        }
        if (CopperCount != 0)
        {
            CopperCount = Convert.ToInt32(Math.Ceiling(CopperCount * 0.33)); OresText[1].text = CopperCount.ToString();
        }
        if (IronCount != 0)
        {
            IronCount = Convert.ToInt32(Math.Ceiling(IronCount * 0.33)); OresText[2].text = IronCount.ToString();
        }
        if (GoldCount != 0)
        {
            GoldCount = Convert.ToInt32(Math.Ceiling(GoldCount * 0.33)); OresText[3].text = GoldCount.ToString();
        }
        if (DiamondCount != 0)
        {
            DiamondCount = Convert.ToInt32(Math.Ceiling(DiamondCount * 0.33 )); OresText[4].text = DiamondCount.ToString();
        }
    }
}
