using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentData", menuName = "Agent/Data")]
public class AgentDataSO : ScriptableObject
{
    [Header("Health Data")]
    [Space]
    public int health = 0;

    [Header("Movement Data")]
    [Space]
    public float maxSpeed = 0;
    public float acceleration = 0;
    public float deacceleration = 0;
}
