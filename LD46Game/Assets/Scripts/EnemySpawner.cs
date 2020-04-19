using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private List<Portal> portals;
    [SerializeField] private int minEnemyRewardPoints = 20;
    [SerializeField] private int maxEnemyRewardPoints = 100;

    [SerializeField] bool debugging = false;

    public event Action onWaveCompleted;

    private int enemiesThisWave = 0;
    private int spawnedEnemies = 0;
    private int defeatedEnemies = 0;
    private float enemyHealth = 0f;
    private float enemyDelay = 0f;
    private float enemySpawnTimer = -1f;
    private bool canSpawn = false;
    private bool updateTimers = false;

    public void Init(EnemyWaveManager waveManager)
    {
        onWaveCompleted += waveManager.OnWaveCompleted;
    }

    public void StartWave(int numEnemies, float delayBetweenEnemies, float enemyHealth)
    {
        enemiesThisWave = numEnemies;
        enemyDelay = delayBetweenEnemies;
        this.enemyHealth = enemyHealth;

        canSpawn = true;
    }

    private void Update()
    {
        if (canSpawn)
        {
            if (enemySpawnTimer <= 0 && spawnedEnemies < enemiesThisWave)
            {
                SpawnEnemy();

                // reset the timer
                enemySpawnTimer = enemyDelay;
                updateTimers = true;
            }
        }

        if (updateTimers)
            UpdateTimers();

        if (debugging)
        {
            if (Input.GetKeyDown(KeyCode.T))
                SpawnEnemy();
        }
    }

    private void UpdateTimers()
    {
        enemySpawnTimer -= Time.deltaTime;
    }

    private void OnEnemyDeath(int points)
    {
        defeatedEnemies++;
        
        CheckForWaveComplete();
    }

    private void OnEnemyEndReach()
    {
        defeatedEnemies++;
        
        CheckForWaveComplete();
    }

    private void CheckForWaveComplete()
    {
        if (defeatedEnemies >= enemiesThisWave)
        {
            canSpawn = false;
            updateTimers = false;

            onWaveCompleted?.Invoke();
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy = Instantiate(enemyPrefab, portals[0].transform.position, portals[0].transform.rotation);
        enemy.Init(portals[0].GetPath(), enemyHealth, UnityEngine.Random.Range(minEnemyRewardPoints, maxEnemyRewardPoints));
        enemy.onDeathEvent += PlayerMoneyManager.Instance.AddMoney;
        enemy.onDeathEvent += OnEnemyDeath;
        enemy.endReachedEvent += OnEnemyEndReach;

        spawnedEnemies++;
    }
}
