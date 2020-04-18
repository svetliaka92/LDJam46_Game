using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeButton : MonoBehaviour
{
    [SerializeField] private TowerType towerType = TowerType.Fire;
    [SerializeField] private Button button;
    [SerializeField] private Tower parentTower;

    public void Click()
    {
        TowerFactory.Instance.UpgradeTower(parentTower, towerType);
    }

    public void SetState(bool flag)
    {
        button.interactable = flag;
    }
}
