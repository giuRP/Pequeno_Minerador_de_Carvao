using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{
    public LayerMask hittableLayerMask;

    public PlayerDetector playerDetector;

    protected Vector2 direction;

    public UnityEvent<AudioClip> OnWeaponSwingSound;

    [SerializeField]
    private bool showGizmos = false;

    protected override void EnterState()
    {
        agent.rb2d.velocity = Vector2.zero;

        agent.animationManager.ResetEvents();
        agent.animationManager.PlayAnimation(AnimationType.attack);
        agent.animationManager.OnAnimationAction.AddListener(PerformAttack);
        agent.animationManager.OnAnimationEnd.AddListener(TransitionToChoseState);

        agent.agentInput.OnMovement -= agent.agentRenderer.FaceDirection;

        if(playerDetector != null)
        {
            direction = playerDetector.DirectionToTarget.normalized;
        }
        else
        {
            direction = agent.transform.right * (agent.transform.localScale.x > 0 ? 1 : -1);
        }
    }

    private void PerformAttack()
    {
        OnWeaponSwingSound?.Invoke(agent.agentWeapon.GetCurrentWeapon().weaponSwingSound);
        agent.animationManager.OnAnimationAction.RemoveListener(PerformAttack);
        agent.agentWeapon.GetCurrentWeapon().PerformAttack(agent, hittableLayerMask, direction);
    }

    private void TransitionToChoseState() //Nesse caso é para Idle ou Fall states;
    {
        agent.animationManager.OnAnimationEnd.RemoveListener(TransitionToChoseState);
        agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
    }

    public override void StateUpdate()
    {
        //Prevent Update;
    }

    public override void StateFixedUpdate()
    {
        //Prevent Fixed Update;
    }

    protected override void HandleAttack()
    {
        //Prevent Attacking again; When we are in the attack state,
        //the only way to transition back is when we finish the attack animation;
    }

    protected override void HandleBlockPressed()
    {
        //Don't allow jumping;
    }

    protected override void HandleBlockReleased()
    {
        //Just for safety;
    }

    protected override void HandleMovement(Vector2 obj)
    {
        //Stop flipping / rotation our agent;
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying == false)
            return;
        if (showGizmos == false)
            return;
        if (agent.agentWeapon.GetCurrentWeapon() == null)
            return;

        Gizmos.color = Color.red;
        var pos = agent.agentWeapon.transform.position;
        agent.agentWeapon.GetCurrentWeapon().DrawWeaponGizmo(pos, direction);
    }

    protected override void ExitState()
    {
        agent.animationManager.ResetEvents();
        agent.agentInput.OnMovement += agent.agentRenderer.FaceDirection;
    }
}
