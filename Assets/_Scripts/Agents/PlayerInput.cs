using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour, IAgentInput
{
    [SerializeField]
    public Vector2 MovementDirection { get; private set; }

    public event Action OnAttack, OnBlockPressed, OnBlockReleased;

    public event Action<Vector2> OnMovement;

    public KeyCode attackKey, blockKey, menuKey;

    public UnityEvent OnMenuKeyPressed;

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            GetMovementInput();
            GetAttackInput();
            GetBlockInput();
        }

        GetMenuInput();
    } 

    private void GetMenuInput()
    {
        if (Input.GetKeyDown(menuKey))
        {
            OnMenuKeyPressed?.Invoke();
        }
    }

    private void GetAttackInput()
    {
        if (Input.GetKeyDown(attackKey))
        {
            OnAttack?.Invoke();
        }
    }

    private void GetBlockInput()
    {
        if (Input.GetKeyDown(blockKey))
        {
            OnBlockPressed?.Invoke();
        }

        if (Input.GetKeyUp(blockKey))
        {
            OnBlockReleased?.Invoke();
        }
    }

    private void GetMovementInput()
    {
        MovementDirection = GetMovementDirection();
        OnMovement?.Invoke(MovementDirection);
    }

    protected Vector2 GetMovementDirection()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
