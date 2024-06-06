using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIEnemy : MonoBehaviour, IAgentInput
{
    public Vector2 MovementDirection { get; set; }

    public event Action OnAttack;
    public event Action<Vector2> OnMovement;
    public event Action OnBlockPressed;

    public void CallOnAttack()
    {
        OnAttack?.Invoke();
    }

    public void CallOnMovement(Vector2 input)
    {
        OnMovement?.Invoke(input);
    }
}
