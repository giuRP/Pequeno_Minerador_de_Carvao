using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : AIBehaviours
{
    public Agent agent;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>(); 
    }

    private void Update()
    {
        float xDirection = mainCamera.transform.position.x - agent.transform.position.x;
        float yDirection = (mainCamera.transform.position.y - 1.5f) - agent.transform.position.y;

        movementDirection = new Vector2(xDirection, yDirection); 
        
        if(movementDirection.magnitude <= 0.5f)
        {
            movementDirection = Vector2.zero;
        }
    }

    public override void PerformAction(AIEnemy enemyAI)
    {
        enemyAI.MovementDirection = movementDirection.normalized;
        enemyAI.CallOnMovement(movementDirection.normalized);
    }
}
