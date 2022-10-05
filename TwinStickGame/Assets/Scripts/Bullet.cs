using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            other.transform.GetComponent<EnemyAI>().TakeDamage(dmg);
            Destroy(this.gameObject);
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag != "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
    public void DecayStart(float decayTime)
    {
        //bullet despawns if no collision happened for x amount of time. This method is called when bullet spawns
        Invoke("Decay", decayTime);
    }

    void Decay()
    {
        Destroy(this.gameObject);
    }
}
