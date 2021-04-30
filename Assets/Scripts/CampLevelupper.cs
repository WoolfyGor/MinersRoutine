using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampLevelupper : MonoBehaviour
{
  public  Sprite[] CampLevels;
   public int CurrentLvl = 0;
    SpriteRenderer CurrentSprite;
    // Start is called before the first frame update
    private void Start()
    {
        CurrentSprite = GetComponent<SpriteRenderer>();
    }

    public void UpdateLvl()
    {
        
        CurrentSprite.sprite = CampLevels[CurrentLvl];
    }
}
