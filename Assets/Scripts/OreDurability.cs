using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreDurability : MonoBehaviour
{
    public int HP;
    public ParticleSystem PS;
    bool invincibility = false;
    // Start is called before the first frame update
    void Start()
    {
        PS = transform.GetChild(0).GetComponent<ParticleSystem>();
    }
    public bool DecreaseDurability(int Damage)
    {
        PS.Play();
        if (!invincibility) { 
            HP -= Damage;
            invincibility = true;
            StartCoroutine("UndoInvi");
        }

        if (HP <= 0)
        {

            return true;
        }
       
        return false;
    }
    // Update is called once per frame
    IEnumerator UndoInvi()
    {
        yield return new WaitForSeconds(0.3f);
        invincibility = false;
        yield return null;
    }
}
