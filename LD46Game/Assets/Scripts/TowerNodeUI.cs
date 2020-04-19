using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerNodeUI : MonoBehaviour
{
    [SerializeField] private TowerBuildButton fireBuyButton;
    [SerializeField] private TowerBuildButton iceBuyButton;
    [SerializeField] private TowerBuildButton lightningBuyButton;

    [SerializeField] private TextMeshProUGUI fireText;
    [SerializeField] private TextMeshProUGUI iceText;
    [SerializeField] private TextMeshProUGUI lightningText;

    public void Init()
    {
        fireText.text = PlayerMoneyManager.Instance.GetPrice(TowerType.Fire, 0).ToString();
        iceText.text = PlayerMoneyManager.Instance.GetPrice(TowerType.Ice, 0).ToString();
        lightningText.text = PlayerMoneyManager.Instance.GetPrice(TowerType.Lightning, 0).ToString();
    }

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
