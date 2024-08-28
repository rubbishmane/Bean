using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    Health healthScript;

    public float healthBooster;
    public int heroinDuration;

    void Awake()
    {
        healthScript = transform.parent.GetComponentInChildren<Health>();

    }
    void Lean()
    {

    }

    void StartHeroin()
    {   
        StartCoroutine(Heroin());
    }

    IEnumerator Heroin()
    {
        
        healthScript.health += 50f;
        Debug.Log("Current health =" + healthScript.health);

        yield return new WaitForSeconds(heroinDuration);

        healthScript.health -= 50f;
        Debug.Log("Current health =" + healthScript.health);

        yield return null;
    }
}