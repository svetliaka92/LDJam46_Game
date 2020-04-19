using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [SerializeField] private TowerUpgradeButton upgradeButton;
    [SerializeField] private Tower parentTower;

    private TowerStatsGetter towerStatsGetter;

    public void Init(TowerStatsGetter statsGetter)
    {
        towerStatsGetter = statsGetter;
    }

    public void UpdateButtons()
    {
        upgradeButton.SetState(parentTower.UpgradeLevel < towerStatsGetter.GetTowerMaxLevels(parentTower.TowerType)
            && PlayerMoneyManager.Instance.GetMoney()
               >= PlayerMoneyManager.Instance.GetPrice(parentTower.TowerType, parentTower.UpgradeLevel)
            );
    }
}
