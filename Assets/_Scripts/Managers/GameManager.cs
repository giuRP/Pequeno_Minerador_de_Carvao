using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Agent playerAgent;

    [SerializeField]
    private Agent agent;

    private void Awake()
    {
        playerAgent = FindObjectOfType<PlayerInput>().GetComponentInChildren<Agent>();
        agent = playerAgent;
    }
}
