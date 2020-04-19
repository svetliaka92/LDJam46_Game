using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLifeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerLifeText;
    [SerializeField] private Image lifeImage;

    private float maxHP;
    private float currentHP;

    public void Init(float maxHP)
    {
        this.maxHP = maxHP;
        currentHP = maxHP;
    }

    public void UpdateValue(float value)
    {
        currentHP = value;

        playerLifeText.text = currentHP.ToString("F0") + "/" + maxHP.ToString("F0");
        lifeImage.fillAmount = currentHP / maxHP;
    }
}
