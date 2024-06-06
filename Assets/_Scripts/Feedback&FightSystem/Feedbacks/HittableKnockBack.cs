using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableKnockBack : MonoBehaviour, IHittable
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float force = 10f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void GetHit(GameObject sender, float damage)
    {
        Vector2 direction = transform.position - sender.transform.position;
        rb2d.AddForce(new Vector2(direction.normalized.x, 0) * force, ForceMode2D.Impulse);
    }
}
