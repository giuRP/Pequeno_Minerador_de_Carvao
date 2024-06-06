using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrainElfRanged : AIEnemy
{
    public AIBehaviours attackBehaviour, moveBehaviour;

    public Agent agent;

    PlayerDetector playerDetector;
    AgentRenderer agentRenderer;

    private void Awake()
    {
        agent = GetComponentInChildren<Agent>();
        playerDetector = agent.GetComponent<PlayerDetector>();
        agentRenderer = agent.GetComponentInChildren<AgentRenderer>();
    }

    private void Update()
    {
        if (playerDetector.PlayerDetected)
        {
            agentRenderer.FaceDirection(playerDetector.DirectionToTarget.normalized);
            attackBehaviour.PerformAction(this);
            return;
        }

        moveBehaviour.PerformAction(this);
    }
}
