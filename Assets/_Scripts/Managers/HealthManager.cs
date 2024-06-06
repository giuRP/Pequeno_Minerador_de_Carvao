using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : Singleton<HealthManager>
{
    public static float health = 1337;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log(health);
    }

}
