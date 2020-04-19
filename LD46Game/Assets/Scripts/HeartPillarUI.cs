using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartPillarUI : MonoBehaviour
{
    [SerializeField] private NodeBuyButton nodeBuyButton;
    [SerializeField] private TextMeshProUGUI nodeBuyText;
    [SerializeField] private HeartPillar parentPillar;

    public void Init(HeartPillar pillar)
    {
        parentPillar = pillar;
    }

    public void UpdateButtonState()
    {
        nodeBuyButton.SetState(parentPillar.CanBuyNode()
            && PlayerMoneyManager.Instance.GetMoney()
               >= parentPillar.GetNextNodePrice());
    }

    public void UpdateText(int price)
    {
        nodeBuyText.text = price.ToString();
    }
}
