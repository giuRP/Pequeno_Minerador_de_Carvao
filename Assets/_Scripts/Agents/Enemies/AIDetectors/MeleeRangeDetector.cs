using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeRangeDetector : MonoBehaviour
{
    public LayerMask targetMask;

    public UnityEvent<GameObject> OnPlayerDetected;

    public Vector2 detectorSize = Vector2.one;
    public Vector2 detectorOffSet = Vector2.zero;

    public bool PlayerDetected { get; private set; }

    [Header("Gizmos Parameters")]
    public Color gizmoColor = Color.green;
    public bool showGizmos = true;

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapBox((Vector2)transform.position + detectorOffSet, detectorSize, 0, targetMask);
        PlayerDetected = collider != null;
        
        if (PlayerDetected)
        {
            OnPlayerDetected?.Invoke(collider.gameObject);
        }          
    }

    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawCube((Vector2)transform.position + detectorOffSet, detectorSize);
        }
    }
}
