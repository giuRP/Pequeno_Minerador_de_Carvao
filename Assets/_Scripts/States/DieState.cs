using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    public float timeToWaitBeforeDieAction = 2;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.die);
        agent.animationManager.OnAnimationEnd.AddListener(WaitBeforeDieAction);
    }

    private void WaitBeforeDieAction()
    {
        agent.animationManager.OnAnimationEnd.RemoveListener(WaitBeforeDieAction);
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(timeToWaitBeforeDieAction);
        agent.OnAgentDie?.Invoke();
    }

    public override void StateUpdate()
    {
        agent.rb2d.velocity = new Vector2(0, agent.rb2d.velocity.y);
    }

    //Prevent transition to other states:

    protected override void HandleAttack()
    {
        //prevent attack
    }

    protected override void HandleBlockPressed()
    {
        //prevent block
    }

    public override void HandleGetHit()
    {
        //prevent get hit twice
        //Ainda nao previne de perder vida - imortalidade tempor�ria - 
    }

    public override void HandleDie()
    {
        //prevent die again
    }

    protected override void ExitState()
    {
        StopAllCoroutines();
        agent.animationManager.ResetEvents();
    }
}
