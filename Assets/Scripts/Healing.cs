using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    Health health;

    void Awake()
    {
        health = transform.parent.GetComponentInChildren<Health>();
    }
    void Lean()
    {

    }

    void Heroin()
    {
        
    }
}