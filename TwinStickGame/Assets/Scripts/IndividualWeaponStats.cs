using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualWeaponStats : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private int dmg;
    [SerializeField] private int shots;
    [SerializeField] private float spreadValue;
    [SerializeField] private float timeInbetweenBullets;


    public void getStats()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Weapon>().Shoot(name, dmg, shots, spreadValue, timeInbetweenBullets);
    }
}
