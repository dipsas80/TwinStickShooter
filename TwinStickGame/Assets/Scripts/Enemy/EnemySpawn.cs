using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [Header("Spawnin Position")]
    float xPos;
    [SerializeField] float yPos;
    float zPos;
    [SerializeField] float minXPos;
    [SerializeField] float maxXPos;
    [SerializeField] float minZPos;
    [SerializeField] float maxZPos;

    
    [Header("Enemy Amout")]
    [SerializeField] int enemyAmount;



    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(EnemyDrop());
        Debug.Log("In!!");
    }

    IEnumerator EnemyDrop()
    {
        while (enemyAmount < 10)
        {
            xPos = Random.Range(minXPos, maxXPos);
            zPos = Random.Range(minZPos, maxZPos);
            Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);

            enemyAmount ++;
        }
    }



}
