using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OreCollection : MonoBehaviour
{
    InventoryScript IS;
   public int Damage = 1;
   public string OreName;
    OreDurability LastLink;
    public AudioPlayableOutput MusicMixerGroup;
    AudioSource HitStone, HitMiss, OreColelction, BlankSource;
    public AudioClip HitStoneClip, HitMissClip, OreColelctionClip;
    BoxCollider2D BC;
    private void Start()
    {
        BC = GetComponent<BoxCollider2D>();
        BlankSource = GetComponent<AudioSource>();
        IS = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();
        HitStone = gameObject.AddComponent<AudioSource>();
        HitMiss = gameObject.AddComponent<AudioSource>();
        HitStone.clip = HitStoneClip;
        HitMiss.clip = HitMissClip;
        OreColelction = gameObject.AddComponent<AudioSource>();
        OreColelction.clip = OreColelctionClip;
        HitStone.outputAudioMixerGroup = BlankSource.outputAudioMixerGroup;
        OreColelction.outputAudioMixerGroup = BlankSource.outputAudioMixerGroup;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Ore" && !BC.isTrigger)
        {
            HitStone.Play();
            LastLink = collision.gameObject.GetComponent<OreDurability>();
            if (LastLink.DecreaseDurability(Damage)) {
                OreName = collision.name.Substring(0, collision.name.IndexOf("(") - 1);
                Destroy(collision.gameObject);
                IS.Add(OreName);
                OreColelction.Play();
            }
        }
    
    }
   

}
