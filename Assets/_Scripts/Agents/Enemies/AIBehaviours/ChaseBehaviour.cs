using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : AIBehaviours
{
    public Agent agent;

    [SerializeField]
    private Vector2 moveDirection = Vector2.zero;
    
    PlayerDetector playerDetector;

    private void Awake()
    {
        if (agent == null)
            return;

        playerDetector = agent.GetComponent<PlayerDetector>();
    }

    private void Update()
    {
        if (playerDetector.PlayerDetected)
        {
            if(playerDetector.DirectionToTarget.magnitude <= 0.5f)
            {
                moveDirection = Vector2.zero;
            }
            else
            {
                moveDirection = playerDetector.DirectionToTarget.normalized;
            }
        }
        else
        {
            moveDirection = Vector2.zero;
        }
    }

    public override void PerformAction(AIEnemy enemyAI)
    {
        if(playerDetector == null)
            moveDirection = Vector2.zero;

        enemyAI.MovementDirection = moveDirection.normalized;
        enemyAI.CallOnMovement(moveDirection.normalized);
    }
}
