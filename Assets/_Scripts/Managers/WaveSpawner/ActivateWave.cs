using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWave : MonoBehaviour
{
    public GameObject waveSpawner;
    public GameObject confiners;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Triggered");
        waveSpawner.GetComponent<WaveSpawner>().enabled = true;
        confiners.SetActive(true);
        gameObject.SetActive(false);
        }
}
