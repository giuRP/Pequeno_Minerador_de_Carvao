using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee Weapon", menuName = "Weapons/MeleeWeapons")]
public class MeleeWeaponData : WeaponDataSO
{
    public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(agent.agentWeapon.transform.position, direction, range, hittableMask);

        if (hit.collider != null)
        {
            foreach (var hittable in hit.collider.GetComponents<IHittable>())
            {
                hittable.GetHit(agent.gameObject, damage);
            }
        }
    }

    public override void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
    {
        Gizmos.DrawLine(origin, origin + direction * range);
    }
}
