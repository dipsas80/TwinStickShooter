using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg;

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            other.transform.GetComponent<EnemyAI>().TakeDamage(dmg);
            Destroy(this.gameObject);
        }
        else if(other.transform.tag != "Bullet")
        {
            Destroy(this.gameObject);
        }
        
    }
    private void Awake()
    {
        //bullet despawns if no collision happened for 10s
        Invoke("Decay", 10f);
    }

    void Decay()
    {
        Destroy(this.gameObject);
    }
}
