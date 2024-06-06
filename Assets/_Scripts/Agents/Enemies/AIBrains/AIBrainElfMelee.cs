using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrainElfMelee : AIEnemy
{
    public AIBehaviours chaseBehaviour, attackBehaviour;

    public Agent agent;

    PlayerDetector playerDetector;

    private void Awake()
    {
        agent = GetComponentInChildren<Agent>();
        playerDetector = agent.GetComponent<PlayerDetector>();
    }

    private void Update()
    {
        attackBehaviour.PerformAction(this);
        chaseBehaviour.PerformAction(this);
    }
}
