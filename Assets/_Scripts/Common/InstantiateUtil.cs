using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtil : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToInstantiate, object1, object2;

    float dropChance, lootPercentage;

    public void CreateObject()
    {
        dropChance = Random.value;
        if(dropChance >= 0.5f)
        {
            Debug.Log("Drop");
            lootPercentage = Random.value;
            if (lootPercentage >= 0.75f)
            {
                objectToInstantiate = object1;
            }
            else
            {
                objectToInstantiate = object2;
            }

            Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("No Drop");
        }
    }
}
