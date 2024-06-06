using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.idle);

        agent.rb2d.velocity = Vector2.zero;
    }

    protected override void HandleMovement(Vector2 input)
    {
        if (Mathf.Abs(input.x) > 0 || Mathf.Abs(input.y) > 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Movement));
        }
    }
}
