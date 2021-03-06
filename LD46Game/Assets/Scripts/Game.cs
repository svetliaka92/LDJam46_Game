﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game _instance;
    public static Game Instance => _instance;

    [SerializeField] private PlayerLifeManager playerLifeManager;
    [SerializeField] private PlayerMoneyManager playerMoneyManager;
    [SerializeField] private EnemyWaveManager waveManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private HeartPillar heartPillar;

    [SerializeField] private float timeToGameStart = 60f;

    [SerializeField] private StartTimerUI startTimerUI;

    private float gameStartTimer = -1f;

    private bool updateTimers = false;

    private bool isGameWon = false;
    private bool isGameLost = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _instance = this;

        playerLifeManager.Init();
        playerMoneyManager.Init();
        waveManager.Init();
        uiManager.Init(waveManager);
        heartPillar.Init();

        waveManager.onWaveTimerStart += uiManager.WaveCountdownStarted;
        waveManager.onWaveStart += uiManager.WaveStarted;

        waveManager.onNoMoreWavesEvent += WinGame;
        playerLifeManager.playerDeathEvent += LoseGame;

        StartGame();
    }

    private void StartGame()
    {
        gameStartTimer = timeToGameStart;
        updateTimers = true;

        startTimerUI.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    private void Update()
    {
        if (updateTimers)
        {
            gameStartTimer -= Time.deltaTime;

            // update timer UI
            startTimerUI.UpdateTimer(gameStartTimer);

            if (gameStartTimer <= 0)
            {
                updateTimers = false;
                waveManager.StartNextWave();

                startTimerUI.gameObject.SetActive(false);
            }
        }
    }

    private void WinGame()
    {
        if (!isGameWon)
        {
            isGameWon = true;

            // do fade in to win screen
            print("You win!");

            Main.Instance.OnGameWon();
        }
    }

    private void LoseGame()
    {
        if (!isGameLost)
        {
            isGameLost = true;

            // do fade in to lose screen
            print("You lose!");

            Main.Instance.OnGameLost();
        }
    }
}
