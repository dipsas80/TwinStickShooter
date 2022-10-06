using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    [SerializeField] LevelManager levelManager;
    [SerializeField] private Slider hpBar;
    public Animator animator;
    private PlayerMovementController playerInput;

    private void Start()
    {
        playerInput = gameObject.GetComponent<PlayerMovementController>();
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (IsDead)
        {
            Debug.Log("dead");

            playerInput.enabled = false;
            animator.SetBool("IsDead", true);
            Invoke("LoadGameoverScreen", 4f);
            
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

    public void LoadGameoverScreen()
    {
        levelManager.YouDied();
        Debug.Log("loading dead screen");
    }
    
}
