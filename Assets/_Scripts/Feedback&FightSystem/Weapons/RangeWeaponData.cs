using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Range Weapon", menuName = "Weapons/RangeWeapons")]
public class RangeWeaponData : WeaponDataSO
{
    public GameObject rangeWeaponPrefab;

    public float weaponThrowSpeed = 1;

    public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
    {
        GameObject throwable = Instantiate(rangeWeaponPrefab, agent.agentWeapon.transform.position, Quaternion.identity);
        throwable.GetComponent<ThrowableProjectile>().Initialize(this, direction, hittableMask);
    }
}
