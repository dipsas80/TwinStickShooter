using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] public int selectedWeapon = 0;
    private InputAction NextWeapon;
    [SerializeField] private PlayerInput playerInput;

    private void Awake()
    {
    }

    private void Start()
    {
        NextWeapon = playerInput.actions["NextWeapon"];
        SelectWeapon();
    }

    private void Update()
    {
        SwitchingWeapon();

        int previousSelectedWeapon = selectedWeapon;
        
        if (NextWeapon.triggered)
        {
            Debug.Log("current weapon is " + selectedWeapon);
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    private void SwitchingWeapon()
    {

    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
