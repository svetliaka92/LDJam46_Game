using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerStats")]
public class TowerStats : ScriptableObject
{
    [Header("Fire tower")]
    public int fireTowerMaxLevels = 3;
    public float[] fireTowerDamage;
    public float[] fireTowerFireRate;
    public float[] fireTowerRange;

    [Header("Ice tower")]
    public int iceTowerMaxLevels = 3;
    public float[] iceTowerDamage;
    public float[] iceTowerFireRate;
    public float[] iceTowerRange;

    [Header("Lightning tower")]
    public int lightningTowerMaxLevels = 3;
    public float[] lightningTowerDamage;
    public float[] lightningTowerFireRate;
    public float[] lightningTowerRange;
}
