using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUtil : MonoBehaviour
{
    public void DestroySelf()
    {
        Debug.Log("Destroy Self");
        Destroy(gameObject);
    }

    public void DestroyObject(GameObject objToDestroy)
    {
        Destroy(objToDestroy);
    }
}
