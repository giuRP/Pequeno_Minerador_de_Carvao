using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    [SerializeField]
    private WeaponDataSO weaponData;

    public WeaponDataSO GetCurrentWeapon()
    {
        return weaponData;
    }
}
