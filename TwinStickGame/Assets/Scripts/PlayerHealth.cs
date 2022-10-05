using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    [SerializeField] private Slider hpBar;
    public Animator animator;


    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (IsDead)
        {
            Debug.Log("dead");

            animator.SetTrigger("death");
        }
        else
        {
            Debug.Log("taking damage");
          animator.SetTrigger("reaction");
        }   
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

    public bool IsDead
    {
        get
        {
            return currentHealth <= 0;
        }
    }
}
