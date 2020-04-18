using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [SerializeField] private TowerUpgradeButton upgradeButton;
    [SerializeField] private Tower parentTower;

    public void UpdateButtons()
    {
        upgradeButton.SetState(PlayerMoneyManager.Instance.GetMoney()
            >= PlayerMoneyManager.Instance.GetPrice(parentTower.TowerType, parentTower.UpgradeLevel));
    }
}
