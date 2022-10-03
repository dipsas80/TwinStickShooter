using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [Header("Spawnin Position")]
    [SerializeField] float xPos;
    [SerializeField] float yPos;
    [SerializeField] float zPos;
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
            xPos = Random.Range(57, 95);
            zPos = Random.Range(21, 60);
            Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);

            enemyAmount ++;
        }
    }



}
