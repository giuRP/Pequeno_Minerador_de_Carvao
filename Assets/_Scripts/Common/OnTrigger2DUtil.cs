using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTrigger2DUtil : MonoBehaviour
{
    public LayerMask collisionMask;
    public UnityEvent OnTriggerEnterEvent, OnTriggerExitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //BitShift : 1 (0001) << 2 => 0100.

        //AND Operator & : checar se dois bin�rios tem algum '1' na mesma posi��o => 0100 & 0001 = 0 (false);
        //0100 & 0101 = 1 (true).

        //A matr�z de colis�o da unity funciona com o AND operator, colocando '1' nas layers que colidem e '0' nas que nao colidem.

        if ((1 << collision.gameObject.layer & collisionMask) != 0)
        {
            OnTriggerEnterEvent?.Invoke();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & collisionMask) != 0)
        {
            OnTriggerExitEvent?.Invoke();
        }
    }
}
