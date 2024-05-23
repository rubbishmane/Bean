using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
     [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){TakeDamage(10);}
        if(Input.GetKeyDown(KeyCode.K)){Heal(10);}

    }

    public void TakeDamage (int amount)
    {
        currentHealth -=  amount; 
        if (currentHealth <= 0) 
        {
            currentHealth = 0; 
            Die();
        }
    } 

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        //Implemeent what happens when you die
        Debug.Log("You have died tragically");

    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

}
