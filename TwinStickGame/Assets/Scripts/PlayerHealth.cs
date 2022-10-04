using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    [SerializeField] private Slider hpBar;

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    public void Heal(int health)
    {
        if(currentHealth != maxHealth)
        {
            currentHealth += health;
        }
    }

    private void Update()
    {
        hpBar.maxValue = maxHealth;
        hpBar.value = currentHealth;
    }
}
