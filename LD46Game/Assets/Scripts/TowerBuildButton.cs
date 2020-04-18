using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuildButton : MonoBehaviour
{
    [SerializeField] private TowerType towerToBuildType = TowerType.Fire;
    [SerializeField] private Button button;
    [SerializeField] private TowerNode parentNode;

    public void Click()
    {
        if (TowerFactory.Instance)
            TowerFactory.Instance.BuildTower(parentNode, towerToBuildType);
    }

    public void SetState(bool canBuy)
    {
        button.interactable = canBuy;
    }
}
