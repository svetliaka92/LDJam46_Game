using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField] private int wavesToSpawn = 20;
    [SerializeField] private int baseEnemiesPerWave = 10;
    [SerializeField] private int enemiesIncresePerWave = 10;
    [SerializeField] private float baseEnemyHealth = 20f;
    [SerializeField] private float enemyHealthIncreasePerWave = 15f;
    [SerializeField] private int baseEnemyMinRewardPoints = 50;
    [SerializeField] private int baseEnemyMaxRewardPoints = 80;
    [SerializeField] private int enemyRewardPointsIncreasePerWave = 20;

    [SerializeField] private float timeDelayBetweenEnemies = 2;
    [SerializeField] private float timeBetweenWaves = 60;

    [SerializeField] private EnemySpawner enemySpawner;

    [SerializeField] private bool debugging = false;

    public event Action onWaveStart;
    public event Action onWaveTimerStart;
    public event Action onNoMoreWavesEvent;

    private int currentWave = 0;
    private float waveTimer = 0;

    private bool canSpawn = false;
    private bool updateTimers = false;

    public void Init()
    {
        enemySpawner.Init(this);
    }

    public void SetSpawnState(bool state)
    {
        canSpawn = state;
    }

    private void Update()
    {
        if (canSpawn)
        {
            if (waveTimer <= 0)
            {
                canSpawn = false;
                updateTimers = false;
                StartNextWave();
            }
        }

        if (updateTimers)
            UpdateTimers();

        if (debugging)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                StartNextWave();
            }
        }
    }

    private void UpdateTimers()
    {
        waveTimer -= Time.deltaTime;
    }

    public void OnWaveCompleted()
    {
        // increase current wave index
        currentWave++;

        // check if there are waves left
        // if yes - start next wave
        // if not - game is won
        if (currentWave < wavesToSpawn)
        {
            waveTimer = timeBetweenWaves;

            updateTimers = true;
            canSpawn = true;

            // send notification
            onWaveTimerStart?.Invoke();
        }
        else
            onNoMoreWavesEvent?.Invoke();
    }

    public void StartNextWaveImmediately()
    {
        waveTimer = 0f;
    }

    public void StartNextWave()
    {
        enemySpawner.StartWave(EnemiesThisWave(),
                               timeDelayBetweenEnemies,
                               EnemyHealthThisWave(),
                               EnemyMinRewardPointsThisWave(),
                               EnemyMaxRewardPointsThisWave());

        onWaveStart?.Invoke();
    }

    private int EnemiesThisWave()
    {
        return baseEnemiesPerWave + currentWave * enemiesIncresePerWave;
    }

    private float EnemyHealthThisWave()
    {
        return baseEnemyHealth + currentWave * enemyHealthIncreasePerWave;
    }

    private int EnemyMinRewardPointsThisWave()
    {
        return baseEnemyMinRewardPoints + currentWave * enemyRewardPointsIncreasePerWave;
    }

    private int EnemyMaxRewardPointsThisWave()
    {
        return baseEnemyMaxRewardPoints + currentWave * enemyRewardPointsIncreasePerWave;
    }

    public float GetWaveTimer()
    {
        return waveTimer;
    }
}
