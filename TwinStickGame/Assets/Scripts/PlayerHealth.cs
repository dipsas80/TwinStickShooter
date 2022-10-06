using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class PlayerHealth : MonoBehaviour
{

    

    public int currentHealth;
    public int maxHealth;
    [SerializeField] LevelManager levelManager;
    [SerializeField] private Slider hpBar;
    public Animator animator;
    private PlayerMovementController playerMovement;
    public PlayerInput playerInput;
    [SerializeField] private AudioClip[] damageSound;
    [SerializeField] private List<AudioClip> randomList;

    [SerializeField] private AudioClip death01;
    [SerializeField] private AudioClip death02;
    AudioSource source;
    [SerializeField] AudioMixerGroup mixerOutput;
    [SerializeField] float pitchMin = 0.90f, pitchMax = 1.1f;


    private bool isDeathPlayed;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = mixerOutput;
        isDeathPlayed = false;
        
        randomList = new List<AudioClip>(new AudioClip[damageSound.Length]);
        
        for (int i = 0; i < damageSound.Length; i++)
        {
            randomList[i] = damageSound[i];
        }

        //playerInput = this.GetComponent<PlayerInput>();
    }


    public void TakeDamage(int damage)
    {
        Gamepad.current.SetMotorSpeeds(1f, 1f);
        Invoke("StopRumble", 0.1f);

        currentHealth -= damage;

        if (IsDead)
        {
            Invoke("StopRumble", 0f);
            animator.SetBool("IsDead", true);
            DeathFeedback();
            playerInput.actions = null;
            Invoke("LoadGameoverScreen", 4f);
           
        }
        else
        {
            animator.SetTrigger("reaction");

            int i = Random.Range(0, randomList.Count);
     
            source.pitch = Random.Range(pitchMin, pitchMax);
            source.PlayOneShot(randomList[i], volumeScale:0.2f);
        }   
    }

    private void DeathFeedback()
    {
        if (isDeathPlayed == false)
        {
            source.PlayOneShot(death01, volumeScale:0.75f);
            source.PlayOneShot(death02, volumeScale:0.2f);
            isDeathPlayed = true;
        }
    
    }
    
    public void Reset()
    {
        for (int i = 0; i < damageSound.Length; i++)
        {
            randomList.Add(damageSound[i]);
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
    void StopRumble()
    {
        Gamepad.current.SetMotorSpeeds(0f, 0f);
    }
    
    
}
