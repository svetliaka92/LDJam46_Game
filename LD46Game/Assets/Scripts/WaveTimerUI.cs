using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveTimerUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup timerGroup;
    [SerializeField] private TextMeshProUGUI timerText;

    public void ShowUI(bool flag = true)
    {
        // fade in timer UI if flag is true
        // else fade out UI
        print("Showing wave timer: " + flag);
        timerGroup.alpha = flag ? 1 : 0;
        timerGroup.interactable = flag;
        timerGroup.blocksRaycasts = flag;
    }

    public void UpdateTimer(float time)
    {
        timerText.text = time.ToString("F0");
    }
}
