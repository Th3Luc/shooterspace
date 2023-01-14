using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyRarity[] enemyTypes;
    public float[] enemyRarities;
    public float spawnInterval = 1.0f;
    public float spawnRadius = 10.0f;
    public float offscreenMargin = 5.0f;
    public int maxEnemies = 10;
    public CinemachineVirtualCamera virtualCamera;
    
    private float spawnTimer;
    [SerializeField] private int currentEnemies;

    private void Start()
    {
        enemyRarities = new float[enemyTypes.Length];

        for (int i = 0; i < enemyTypes.Length; i++)
        {
            enemyRarities[i] = enemyTypes[i].rarity;
        }

        spawnTimer = spawnInterval;
        currentEnemies = 0;
    }

    private void Update()
    {
        if (currentEnemies >= maxEnemies)
        {
            return;
        }

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            float raritySum = 0;

            foreach (float rarity in enemyRarities)
            {
                raritySum += rarity;
            }

            Vector2 spawnPoint = Random.insideUnitCircle * spawnRadius;
            Vector3 worldSpawnPoint = virtualCamera.transform.position + virtualCamera.transform.TransformVector(new Vector3(spawnPoint.x, spawnPoint.y, virtualCamera.m_Lens.NearClipPlane + offscreenMargin));
            float randomNumber = Random.Range(0, raritySum);

            for (int i = 0; i < enemyTypes.Length; i++)
            {
                if (randomNumber < enemyRarities[i])
                {
                    GameObject enemy = enemyTypes[i].gameObject;
                    enemy.transform.position = new Vector3(worldSpawnPoint.x, worldSpawnPoint.y, enemy.transform.position.z);
                    Instantiate(enemy);

                    currentEnemies++;
                    spawnTimer = spawnInterval;
                    break;
                }
                else
                {
                    randomNumber -= enemyRarities[i];
                }
            }
        }
    }

    public void OnEnemyDeath()
    {
        PlayerStats.kills++;
        currentEnemies--;
        UpdateEnemyCount();
    }
    public void UpdateEnemyCount()
{
    // increase the max number of enemies based on the number of enemies killed
    maxEnemies = Mathf.RoundToInt(10 + PlayerStats.kills * 0.5f);
}
}