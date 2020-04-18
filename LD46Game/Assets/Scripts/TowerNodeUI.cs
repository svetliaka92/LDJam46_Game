using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerNodeUI : MonoBehaviour
{
    [SerializeField] private TowerBuildButton fireBuyButton;
    [SerializeField] private TowerBuildButton iceBuyButton;
    [SerializeField] private TowerBuildButton lightningBuyButton;

    public void UpdateButtons()
    {
        fireBuyButton.SetState(PlayerMoneyManager.Instance.GetMoney()
                               >= PlayerMoneyManager.Instance.GetPrice(TowerType.Fire, 0));

        iceBuyButton.SetState(PlayerMoneyManager.Instance.GetMoney()
                              >= PlayerMoneyManager.Instance.GetPrice(TowerType.Ice, 0));

        lightningBuyButton.SetState(PlayerMoneyManager.Instance.GetMoney()
                                    >= PlayerMoneyManager.Instance.GetPrice(TowerType.Lightning, 0));
    }
}
