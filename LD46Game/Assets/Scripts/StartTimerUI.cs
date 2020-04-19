using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartTimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    public void UpdateTimer(float value)
    {
        timerText.text = value.ToString("F0") + " " + "seconds";
    }
}
