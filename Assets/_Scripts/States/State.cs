using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent agent;

    public UnityEvent OnEnter, OnExit;

    public void InitializeState(Agent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        this.agent.agentInput.OnAttack += HandleAttack;
        this.agent.agentInput.OnBlockPressed += HandleBlockPressed;
        this.agent.agentInput.OnMovement += HandleMovement;

        OnEnter?.Invoke();

        EnterState();
    }

    public void Exit()
    {
        this.agent.agentInput.OnAttack -= HandleAttack;
        this.agent.agentInput.OnBlockPressed -= HandleBlockPressed;
        this.agent.agentInput.OnMovement -= HandleMovement;

        OnExit?.Invoke();

        ExitState();
    }

    protected virtual void EnterState()
    {
    }

    protected virtual void ExitState()
    {
    }

    public virtual void StateUpdate()
    {       
    }

    public virtual void StateFixedUpdate()
    {
    }

    protected virtual void HandleMovement(Vector2 obj)
    {
    }

    protected virtual void HandleAttack()
    {
        TestAttackTransition();
    }

    protected virtual void HandleBlockPressed()
    {
    }

    protected virtual void HandleBlockReleased()
    {
    }

    public virtual void HandleGetHit()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.GetHit));
    }

    public virtual void HandleDie()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.Die));
    }

    protected virtual void TestAttackTransition()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.Attack));
    }
}
