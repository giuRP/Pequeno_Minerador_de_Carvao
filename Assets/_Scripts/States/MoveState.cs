using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveState : State
{
    [SerializeField]
    protected MovementData movementData;

    public UnityEvent OnStep;

    private void Awake()
    {
        movementData = GetComponentInParent<MovementData>();
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.move);
        agent.animationManager.OnAnimationAction.AddListener(() => OnStep.Invoke());

        movementData.horizontalMovementDirection = 0;
        movementData.currentSpeed = 0;
        movementData.currentVelocity = Vector2.zero;
    }

    protected override void ExitState()
    {
        agent.animationManager.ResetEvents();
    }

    public override void StateUpdate()
    {
        CalculateVelocity();
        SetPlayerVelocity();

        //if (Mathf.Abs(agent.rb2d.velocity.x) < 0.01f)
        //{
        //    agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        //}

        if (agent.rb2d.velocity.magnitude < 0.01f)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        }
    }

    protected void CalculateVelocity()
    {
        CalculateSpeed(agent.agentInput.MovementDirection, movementData);
        CalculateHorizontalDirection(movementData);

        float xDirection = agent.agentInput.MovementDirection.x;
        float yDirection = agent.agentInput.MovementDirection.y;

        movementData.currentVelocity = new Vector2(xDirection * movementData.currentSpeed, yDirection * movementData.currentSpeed);
    }

    protected void CalculateSpeed(Vector2 movementDirection, MovementData movementData)
    {
        if (Mathf.Abs(movementDirection.x) > 0 || Mathf.Abs(movementDirection.y) > 0)
        {
            movementData.currentSpeed += agent.agentData.acceleration * Time.deltaTime;
        }
        else
        {
            movementData.currentSpeed -= agent.agentData.deacceleration * Time.deltaTime;
        }

        movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, agent.agentData.maxSpeed);
    }

    protected void CalculateHorizontalDirection(MovementData movementData)
    {
        if (agent.agentInput.MovementDirection.x > 0)
        {
            movementData.horizontalMovementDirection = 1;
        }
        else if (agent.agentInput.MovementDirection.x < 0)
        {
            movementData.horizontalMovementDirection = -1;
        }
    }

    protected void SetPlayerVelocity()
    {
        agent.rb2d.velocity = movementData.currentVelocity;
    }
}
