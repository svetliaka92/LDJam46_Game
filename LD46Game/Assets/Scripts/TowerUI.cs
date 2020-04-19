using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUI : MonoBehaviour
{
    [SerializeField] private TowerUpgradeButton upgradeButton;
    [SerializeField] private TextMeshProUGUI upgradePriceText;
    [SerializeField] private Tower parentTower;

    private TowerStatsGetter towerStatsGetter;

    public void Init(TowerStatsGetter statsGetter)
    {
        towerStatsGetter = statsGetter;
    }

    public void UpdateText()
    {
        if (parentTower.UpgradeLevel >= towerStatsGetter.GetTowerMaxLevels(parentTower.TowerType) - 1)
            upgradePriceText.gameObject.SetActive(false);
        else
            upgradePriceText.text = PlayerMoneyManager.Instance.GetPrice(
                parentTower.TowerType,
                parentTower.UpgradeLevel + 1).ToString();
    }

    public void UpdateButtons()
    {
        if (parentTower.UpgradeLevel >= towerStatsGetter.GetTowerMaxLevels(parentTower.TowerType) - 1)
            upgradeButton.SetState(false);
        else
            upgradeButton.SetState(parentTower.UpgradeLevel < towerStatsGetter.GetTowerMaxLevels(parentTower.TowerType)
                && PlayerMoneyManager.Instance.GetMoney()
                   >= PlayerMoneyManager.Instance.GetPrice(parentTower.TowerType, parentTower.UpgradeLevel + 1)
                );
    }
}
