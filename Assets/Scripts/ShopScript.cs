using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopScript : MonoBehaviour
{
    InventoryScript Is;
    OreCollection OC;
    CampLevelupper CLL;
    AudioSource BuySound;
   public GameObject Campimg, PickImg;
    int PickAxeUpCost = 20, CampUpCost = 100;
    public TextMeshProUGUI PickAxeCostText,CampCostText;
    // Start is called before the first frame update
    void Start()
    {
        BuySound = GetComponent<AudioSource>();
        Is = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();
        OC = GameObject.FindGameObjectWithTag("Pickaxe").GetComponent<OreCollection>();
        PickAxeCostText = GameObject.Find("PickAxeCost").GetComponent<TextMeshProUGUI>();
        CampCostText = GameObject.Find("CampUpCost").GetComponent<TextMeshProUGUI>();
        PickAxeCostText.text = "$"+PickAxeUpCost.ToString();
        CampCostText.text = "$"+CampUpCost.ToString();
        CLL = GameObject.Find("Camp").GetComponent<CampLevelupper>();
    }
   public void BuyPickaxeUp()
    {
       
        if(Is.Money >= PickAxeUpCost)
        {
            OC.Damage++;
            Is.Money -= PickAxeUpCost;
            PickAxeUpCost += 20;
            PickAxeCostText.text = "$" + PickAxeUpCost.ToString();
            BuySound.Play();
            Is.UpdateMoney();
        }
    }
    public void BuyCampUp()
    {

        if (Is.Money >= CampUpCost)
        {
            CLL.CurrentLvl++;
            Is.Money -= CampUpCost;
            CampUpCost += 100;
            CampCostText.text = "$" + CampUpCost.ToString();
            BuySound.Play();
            Is.UpdateMoney();
            CLL.UpdateLvl();
            if (CLL.CurrentLvl == 6)
            {
                Destroy(CampCostText);
                Destroy(Campimg);
            }
        }
    }

}
