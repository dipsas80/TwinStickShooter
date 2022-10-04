using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    private float nextFire = 0f;


    //Different Guns
    public GameObject[] gunModels;
    private int gunCycle = 0;
    public bool isShooting;


    private void OnFire(InputValue Fire)
    {
        if(Fire.isPressed && isShooting == false)
        {
            gunModels[gunCycle].GetComponent<IndividualWeaponStats>().getStats();
        }
    }
    private void OnNextWeapon(InputValue NextWeapon)
    {
        if(NextWeapon.isPressed)
        {
            gunModels[gunCycle].SetActive(false);
            gunCycle = ((gunCycle + 1) % gunModels.Length);
            gunModels[gunCycle].SetActive(true);
        }
    }

    public void Shoot(string name, int damage, int shotAmount, float bulletSpread, float timeInbetweenBullets)
    {
        Debug.Log(name + " was fired");
        StartCoroutine(Fire(shotAmount, timeInbetweenBullets, bulletSpread, damage));        

    }
    
    IEnumerator Fire(int shots, float time, float bulletSpread, int damage)
    {
        isShooting = true;
        for(int i = 0; i < shots; i++)
        {
            Quaternion spreadAngle = Quaternion.identity;
            spreadAngle.eulerAngles = new Vector3(Random.Range(-bulletSpread, bulletSpread), Random.Range(-bulletSpread, bulletSpread), 0);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = spreadAngle * bulletSpawnPoint.forward * bulletSpeed;
            bullet.GetComponent<Bullet>().dmg = damage;
            yield return new WaitForSeconds(time);
        }
        isShooting = false;
    }
}
