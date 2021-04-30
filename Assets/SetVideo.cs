using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class SetVideo : MonoBehaviour
{

    VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "EasterEgg.mp4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
