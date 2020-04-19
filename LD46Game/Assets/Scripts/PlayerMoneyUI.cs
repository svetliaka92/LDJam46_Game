using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerMoneyText;

    private int money;

    public void UpdateMoneyText(int value)
    {
        money = value;

        playerMoneyText.text = money.ToString();
    }
}
