using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDataSO : ScriptableObject
{
    public float damage = 0;
    public float range = 0;
    public AudioClip weaponSwingSound;

    public abstract void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction);

    public virtual void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
    {

    }
}
