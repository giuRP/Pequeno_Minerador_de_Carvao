using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackBehaviour : AIBehaviours
{
    [SerializeField]
    private bool isWaiting;

    [SerializeField]
    private float attackDelay = 1;

    public override void PerformAction(AIEnemy enemyAI)
    {
        if (isWaiting)
            return;

        enemyAI.CallOnAttack();
        isWaiting = true;
        StartCoroutine(AttackDelayCoroutine());
    }

    IEnumerator AttackDelayCoroutine()
    {
        yield return new WaitForSeconds(attackDelay);
        isWaiting = false;
    }
}
