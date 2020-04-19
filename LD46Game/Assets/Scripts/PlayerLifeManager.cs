using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    private static PlayerLifeManager _instance;
    public static PlayerLifeManager Instance => _instance;

    [SerializeField] private PlayerLifeUI playerLifeUI;
    [SerializeField] private int maxLife;
    private int currentLife;

    public event Action playerDeathEvent;

    public void Init()
    {
        _instance = this;

        Restart();

        playerLifeUI.Init(maxLife);
        playerLifeUI.UpdateValue(maxLife);
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    private void Restart()
    {
        currentLife = maxLife;
    }

    public void TakeDamage()
    {
        currentLife -= 1;

        if (currentLife <= 0)
        {
            currentLife = 0;

            playerDeathEvent?.Invoke();
        }

        playerLifeUI.UpdateValue(currentLife);
    }
}
