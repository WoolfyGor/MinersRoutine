using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SettinsScript : MonoBehaviour
{

   public Slider MusicSlider, EffectsSlider;
    public AudioMixer MusicMixer;
    bool Opened = false;
    public GameObject[] SettingsButtons;
    GameObject Player, Spawn;
    InventoryScript IS;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Spawn = GameObject.FindGameObjectWithTag("Respawn");
        IS = GameObject.Find("Inventory").GetComponent<InventoryScript>();
        MusicSlider.onValueChanged.AddListener(delegate { ValueChangeCheckMusic(); });
        EffectsSlider.onValueChanged.AddListener(delegate { ValueChangeCheckSFX(); });
        foreach (GameObject obj in SettingsButtons)
        {
            obj.SetActive(Opened);
        }
    }

   public void ValueChangeCheckMusic()
    {
        setMusiclvl(MusicSlider.value);
    }
    public void ValueChangeCheckSFX()
    {
        setSVXlvl(EffectsSlider.value);
    }
    public void setMusiclvl(float sfxLvl)
    {
        MusicMixer.SetFloat("MusicVol", sfxLvl);
    }
    public void setSVXlvl(float sfxLvl)
    {
        MusicMixer.SetFloat("VolSFX", sfxLvl);
    }
    public void OpenSettings()
    {
        Opened = !Opened;
       foreach(GameObject obj in SettingsButtons)
        {
            obj.SetActive(Opened);
        }
    }
   public void Stuck()
    {
        IS.StuckPenalty();
        Player.transform.position = Spawn.transform.position;
    }
}
