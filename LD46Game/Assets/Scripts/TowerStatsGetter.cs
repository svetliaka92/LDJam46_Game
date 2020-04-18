using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatsGetter : MonoBehaviour
{
    [SerializeField] private TowerStats towerStats;

    private Dictionary<TowerType, int> towerMaxLevels;
    private Dictionary<TowerType, Dictionary<int, float>> towerDamageFromLevel;
    private Dictionary<TowerType, Dictionary<int, float>> towerFireRateFromLevel;
    private Dictionary<TowerType, Dictionary<int, float>> towerRangeFromLevel;

    public void Init()
    {
        LoadStatsIntoDicts();
    }

    private void LoadStatsIntoDicts()
    {
        towerMaxLevels = new Dictionary<TowerType, int>();
        towerDamageFromLevel = new Dictionary<TowerType, Dictionary<int, float>>();
        towerFireRateFromLevel = new Dictionary<TowerType, Dictionary<int, float>>();
        towerRangeFromLevel = new Dictionary<TowerType, Dictionary<int, float>>();

        // max levels
        towerMaxLevels.Add(TowerType.Fire, towerStats.fireTowerMaxLevels);
        towerMaxLevels.Add(TowerType.Ice, towerStats.iceTowerMaxLevels);
        towerMaxLevels.Add(TowerType.Lightning, towerStats.lightningTowerMaxLevels);

        // damage
        // fire
        Dictionary<int, float> table = new Dictionary<int, float>();
        for (int i = 0; i < towerMaxLevels[TowerType.Fire]; i++)
            table.Add(i, towerStats.fireTowerDamage[i]);

        towerDamageFromLevel.Add(TowerType.Fire, table);

        // ice
        table = new Dictionary<int, float>();
        for (int i = 0; i < towerMaxLevels[TowerType.Ice]; i++)
            table.Add(i, towerStats.iceTowerDamage[i]);

        towerDamageFromLevel.Add(TowerType.Ice, table);

        // lightning
        table = new Dictionary<int, float>();
        for (int i = 0; i < towerMaxLevels[TowerType.Lightning]; i++)
            table.Add(i, towerStats.lightningTowerDamage[i]);

        towerDamageFromLevel.Add(TowerType.Lightning, table);

        // fire rate
        // fire
        table = new Dictionary<int, float>();
        for (int i = 0; i < towerMaxLevels[TowerType.Ice]; i++)
            table.Add(i, towerStats.fireTowerFireRate[i]);

        towerFireRateFromLevel.Add(TowerType.Fire, table);

        // ice
        table = new Dictionary<int, float>();
        for (int i = 0; i < towerMaxLevels[TowerType.Ice]; i++)
            table.Add(i, towerStats.iceTowerFireRate[i]);

        towerFireRateFromLevel.Add(TowerType.Ice, table);

        // lightning
        table = new Dictionary<int, float>();
        for (int i = 0; i < towerMaxLevels[TowerType.Ice]; i++)
            table.Add(i, towerStats.lightningTowerFireRate[i]);

        towerFireRateFromLevel.Add(TowerType.Lightning, table);

        // range
        // fire
        table = new Dictionary<int, float>();
        for (int i = 0; i < towerMaxLevels[TowerType.Ice]; i++)
            table.Add(i, towerStats.fireTowerRange[i]);

        towerRangeFromLevel.Add(TowerType.Fire, table);

        // ice
        table = new Dictionary<int, float>();
        for (int i = 0; i < towerMaxLevels[TowerType.Ice]; i++)
            table.Add(i, towerStats.iceTowerRange[i]);

        towerRangeFromLevel.Add(TowerType.Ice, table);

        // lightning
        table = new Dictionary<int, float>();
        for (int i = 0; i < towerMaxLevels[TowerType.Ice]; i++)
            table.Add(i, towerStats.lightningTowerRange[i]);

        towerRangeFromLevel.Add(TowerType.Lightning, table);
    }

    public int GetTowerMaxLevels(TowerType type)
    {
        if (towerMaxLevels.ContainsKey(type))
            return towerMaxLevels[type];

        return -1;
    }

    public float GetTowerDamage(TowerType type, int towerLevel)
    {
        if (towerDamageFromLevel.ContainsKey(type))
            if (towerDamageFromLevel[type].ContainsKey(towerLevel))
                return towerDamageFromLevel[type][towerLevel];
        
        return -1;
    }

    public float GetTowerFireRate(TowerType type, int towerLevel)
    {
        if (towerFireRateFromLevel.ContainsKey(type))
            if (towerFireRateFromLevel[type].ContainsKey(towerLevel))
                return towerFireRateFromLevel[type][towerLevel];

        return -1;
    }

    public float GetTowerRange(TowerType type, int towerLevel)
    {
        if (towerRangeFromLevel.ContainsKey(type))
            if (towerRangeFromLevel[type].ContainsKey(towerLevel))
                return towerRangeFromLevel[type][towerLevel];

        return -1;
    }
}
