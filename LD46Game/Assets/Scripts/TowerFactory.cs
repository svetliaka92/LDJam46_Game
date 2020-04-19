using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    private static TowerFactory _instance;
    public static TowerFactory Instance => _instance;

    [SerializeField] private Tower[] towerPrefabs;
    [SerializeField] private Transform towerParent;
    [SerializeField] private TowerStatsGetter towerStatGetter;

    private void Awake()
    {
        _instance = this;

        towerStatGetter.Init();
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    public void BuildTower(TowerNode node, TowerType towerType)
    {
        Tower tower = Instantiate(towerPrefabs[(int)towerType]);
        tower.transform.position = node.transform.position;
        tower.transform.SetParent(towerParent);

        tower.SetStatsGetter(towerStatGetter);
        tower.SetStats(0,
                       towerStatGetter.GetTowerDamage(towerType, 0),
                       towerStatGetter.GetTowerFireRate(towerType, 0),
                       towerStatGetter.GetTowerRange(towerType, 0));

        // hide node mesh
        node.TowerBuiltOnNode();

        PlayerMoneyManager.Instance.UseMoney(PlayerMoneyManager.Instance.GetPrice(towerType, 0));
    }

    public void UpgradeTower(Tower tower, TowerType towerType)
    {
        int towerLevel = tower.UpgradeLevel;
        int maxTowerLevels = towerStatGetter.GetTowerMaxLevels(towerType);

        towerLevel++;

        if (towerLevel < maxTowerLevels)
            tower.SetStats(towerLevel,
                           towerStatGetter.GetTowerDamage(towerType, towerLevel),
                           towerStatGetter.GetTowerFireRate(towerType, towerLevel),
                           towerStatGetter.GetTowerRange(towerType, towerLevel));

        PlayerMoneyManager.Instance.UseMoney(PlayerMoneyManager.Instance.GetPrice(towerType, towerLevel));
    }
}
