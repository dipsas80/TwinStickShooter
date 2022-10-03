using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    [SerializeField] private float fireRate = 0.2f;
    private float nextFire = 0f;

    private void OnFire(InputValue Fire)
    {
        if(Fire.isPressed)
        {
            nextFire = Time.deltaTime + fireRate;
            var ball = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            ball.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
