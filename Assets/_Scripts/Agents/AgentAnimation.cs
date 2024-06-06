using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentAnimation : MonoBehaviour
{
    private Animator animator;

    public UnityEvent OnAnimationAction;
    public UnityEvent OnAnimationEnd;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(AnimationType animationType)
    {
        switch (animationType)
        {
            case AnimationType.die:
                Play("Die");
                break;

            case AnimationType.hit:
                Play("GetHit");
                break;

            case AnimationType.idle:
                Play("Idle");
                break;

            case AnimationType.attack:
                Play("Attack");
                break;

            case AnimationType.block:
                Play("Block");
                break;

            case AnimationType.move:
                Play("Move");
                break;

            default:
                break;
        }
    }

    public void Play(string name)
    {
        animator.Play(name, -1, 0f);
    }

    internal void StartAnimation()
    {
        animator.enabled = true;
    }

    internal void StopAnimation()
    {
        animator.enabled = false;
    }

    public void ResetEvents() //N�o remove callbacks adicionados no Inspector!!!!
    {
        OnAnimationAction.RemoveAllListeners();
        OnAnimationEnd.RemoveAllListeners();
    }

    public void InvokeAnimationAction()
    {
        OnAnimationAction?.Invoke();
    }

    public void InvokeAnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }
}

public enum AnimationType
{
    die,
    hit,
    idle,
    attack,
    block,
    move  
}
