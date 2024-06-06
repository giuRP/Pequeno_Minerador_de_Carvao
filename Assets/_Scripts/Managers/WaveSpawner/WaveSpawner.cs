using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
    public int enemyLimit;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public GameObject confiners;
    public GameObject Arrow;
    public GameObject NextLevel;
    public GameObject MiddleCollider;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;


    GameObject[] totalEnemies;
    
    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        SpawnWave();
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (currentWaveNumber+1 == waves.Length && totalEnemies.Length <= 0)
        {
            confiners.SetActive(false);
            Arrow.SetActive(true);
            NextLevel.SetActive(true);
            gameObject.SetActive(false);
            MiddleCollider.SetActive(false);
        }
        //Esse if ativa a próxima Wave
        if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber+1 != waves.Length && !(currentWave.noOfEnemies > 0))
        {
            currentWaveNumber++;
            canSpawn = true;
        }
        if ((totalEnemies.Length == 0 | totalEnemies.Length == currentWave.enemyLimit-1) && !canSpawn && !(currentWave.noOfEnemies == 0))
        {
            canSpawn = true;

        }


    }


    //Essa função spawna inimigos até todos os inimigos da wave forem spawnados
    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            Debug.Log("Wave = "+(currentWaveNumber+1)+" Enemies left to spawn= "+(currentWave.noOfEnemies-1));
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0,currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0,spawnPoints.Length)];
            Instantiate(randomEnemy,randomPoint.position,Quaternion.identity);
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            Arrow.SetActive(false);
            NextLevel.SetActive(false);
            if (currentWave.noOfEnemies == 0 | totalEnemies.Length == currentWave.enemyLimit-1)
            {
                canSpawn = false;
            }
        }
    }
}
//