using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoneyManager : MonoBehaviour
{
    private static PlayerMoneyManager _instance;
    public static PlayerMoneyManager Instance => _instance;

    [SerializeField] private TowerStats stats;

    [SerializeField] private int _money = 100;

    public void Init()
    {
        _instance = this;
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    public void AddMoney(int value)
    {
        _money += value;

        UpdateUI();
    }

    private void UpdateUI()
    {

    }

    public int GetMoney()
    {
        return _money;
    }

    public int GetPrice(TowerType towerType, int level)
    {
        if (towerType == TowerType.Fire)
        {
            return stats.fireTowerUpgradeCosts[level];
        }
        else if (towerType == TowerType.Ice)
        {
            return stats.iceTowerUpgradeCosts[level];
        }
        else if (towerType == TowerType.Lightning)
        {
            return stats.lightningTowerUpgradeCosts[level];
        }
        else
            return -1;
    }
}
