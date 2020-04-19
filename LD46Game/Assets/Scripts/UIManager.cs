using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance => _instance;

    [SerializeField] private WaveTimerUI waveTimerUI;

    private EnemyWaveManager waveManager;

    private bool updateUI = false;

    float waveTimer = 0f;

    public void Init(EnemyWaveManager waveManager)
    {
        _instance = this;

        this.waveManager = waveManager;
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    public void WaveCountdownStarted()
    {
        waveTimerUI.ShowUI();
        updateUI = true;
    }

    public void WaveStarted()
    {
        waveTimerUI.ShowUI(false);
        updateUI = false;
    }

    private void Update()
    {
        if (updateUI)
        {
            waveTimerUI.UpdateTimer(waveManager.GetWaveTimer());
        }
    }
}
