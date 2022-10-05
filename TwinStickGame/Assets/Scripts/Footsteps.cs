using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private PlayerMovementController movementController;
    
    [SerializeField] private AudioClip[] steps;
    [SerializeField] private List<AudioClip> randomList;
    AudioSource source;

    [SerializeField] AudioMixerGroup mixerOutput;
    [SerializeField] float pitchMin = 0.95f, pitchMax = 1.05f, volumeMin = 0.95f, volumeMax  = 1f;

    private bool playerIsMoving;
    
    // Start is called before the first frame update
    void Start()
    {
        randomList = new List<AudioClip>(new AudioClip[steps.Length]);
        // InvokeRepeating("CallFootsteps", 0, walkingSpeed);
        source = gameObject.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = mixerOutput;

        for (int i = 0; i < steps.Length; i++)
        {
            randomList[i] = steps[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(movementController.velocityX) >= 0.03f || Mathf.Abs(movementController.velocityZ) >= 0.03f )
        {
            playerIsMoving = true;
        }
        else
        {
            playerIsMoving = false;
        }
    }

    public void Reset()
    {
        for (int i = 0; i < steps.Length; i++)
        {
            randomList.Add(steps[i]);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            CallFootsteps();
        }
    }

    void CallFootsteps()
    {
        if (playerIsMoving == true)
        {
            PlayRandomSound();

        }
    }

    private void PlayRandomSound()
    {
        int i = Random.Range(0, randomList.Count);
        source.pitch = Random.Range(pitchMin, pitchMax);
        source.volume = Random.Range(volumeMin, volumeMax);
        source.PlayOneShot(randomList[i]);
        randomList.RemoveAt(i);

        if (randomList.Count == 0)
        {
            Reset();
        }
    }
}
