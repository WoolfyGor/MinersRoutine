using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    AudioSource AS;
    public bool PlayOnStart = true;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        if (PlayOnStart)
        {
            StartCoroutine("OnStartVolumePlus");

        }

    }
    public void VolumeUp()
    {
        StartCoroutine("OnStartVolumePlus");
    }
    public void VolumeDown()
    {
        StartCoroutine("OnStartVolumeMinus");
    }
    IEnumerator OnStartVolumePlus()
    {
        AS.Play();
        while (AS.volume != 1)
        {
            AS.volume += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator OnStartVolumeMinus()
    {
        while (AS.volume != 0)
        {
            AS.volume -= 0.1f;
            yield return new WaitForSeconds(0.1f);

        }
        AS.Pause();
    }
}
