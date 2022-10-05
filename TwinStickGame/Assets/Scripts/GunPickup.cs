using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [Header("1 = shotgun")]
    [Header("2 = machinegun")]
    public int gunValue;
    public GameObject mesh;
    private bool used;


    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == "Player" && used == false)
        {
            
            
            other.GetComponent<Weapon>().gunsUnlocked[gunValue] = true;
            this.GetComponent<AudioSource>().Play();
            Invoke("DestroyAfterSound", 1f);
            mesh.SetActive(false);
            used = true;
            
        }   
    }

    void Update()
    {
        transform.Rotate( new Vector3(0, 0.3f, 0) );
    }

    void DestroyAfterSound()
    {
        Destroy(this.gameObject);
    }
}
