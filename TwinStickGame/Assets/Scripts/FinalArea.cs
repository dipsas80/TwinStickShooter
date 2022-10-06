using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalArea : MonoBehaviour
{
    private bool startTimer;
    private float timer;
    public TextMeshProUGUI timerUI;

    void Update()
    {
        if(startTimer)
        {
            timer += Time.deltaTime;
            timerUI.gameObject.SetActive(true);
            timerUI.text = "Survive for " + (60 - Mathf.RoundToInt(timer)) + " seconds";
            this.GetComponent<BoxCollider>().enabled = false;
        }

        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == "Player")
        {
            startTimer = true;
            Invoke("Win", 60f);
        }
    }
    void Win()
    {
        if(GameObject.Find("Player").GetComponent<PlayerHealth>().currentHealth > 0)
        {
            print("You won!");
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            
        }
    }
}
