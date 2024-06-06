using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    void GetHit(GameObject sender, float damage);
}
