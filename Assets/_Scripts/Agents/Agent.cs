using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Agent : MonoBehaviour
{
    public AgentDataSO agentData;

    public Rigidbody2D rb2d;
    public IAgentInput agentInput;
    public AgentAnimation animationManager;
    public AgentRenderer agentRenderer;

    public State currentState = null, previousState = null;

    [HideInInspector]
    public AgentWeapon agentWeapon;

    public StateFactory stateFactory;

    [Header("State Debbuging: ")]
    public string stateName = "";

    private Damageable damageable;

    [field: SerializeField]
    private UnityEvent OnRespawnRequired { get; set; }

    [field: SerializeField]
    public UnityEvent OnAgentDie { get; set; }

    private void Awake()
    {
        agentInput = GetComponentInParent<IAgentInput>();
        rb2d = GetComponent<Rigidbody2D>();
        animationManager = GetComponentInChildren<AgentAnimation>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        stateFactory = GetComponentInChildren<StateFactory>();
        damageable = GetComponent<Damageable>();
        agentWeapon = GetComponentInChildren<AgentWeapon>();

        stateFactory.InitializeStates(this);
    }

    private void Start()
    {
        agentInput.OnMovement += agentRenderer.FaceDirection;
        InitializeAgent();
    }

    private void InitializeAgent()
    {
        TransitionToState(stateFactory.GetState(StateType.Idle));
        damageable.InitializeHealth(agentData.health);
    }

    private void Update()
    {
        currentState.StateUpdate();
    }

    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }

    internal void TransitionToState(State goaltState)
    {
        if (goaltState == null)
            return;

        if (currentState != null)
            currentState.Exit();

        previousState = currentState;
        currentState = goaltState;
        currentState.Enter();

        DisplayState();
    }

    private void DisplayState()
    {
        if (previousState == null || previousState.GetType() != currentState.GetType())
        {
            stateName = currentState.GetType().ToString();
        }
    }

    public void GetHitInCurrentState() //callback em um evento do damageable
    {
        currentState.HandleGetHit();
    }

    public void AgentDied() //callback em um evento do damageable
    {
        if (damageable.CurrentHealth > 0)
        {
            OnRespawnRequired?.Invoke();
        }
        else
        {
            currentState.HandleDie();
        }
    }
}
