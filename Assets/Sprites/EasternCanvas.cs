using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class EasternCanvas : MonoBehaviour
{
   public GameObject Button, Text,Video;
    // Start is called before the first frame update
    public void OpenLetter() {
      
        Button.SetActive(false);
        Text.SetActive(false);
        Video.GetComponent<SpriteRenderer>().enabled = true;
        Video.GetComponent<VideoPlayer>().Play();
    }
}
