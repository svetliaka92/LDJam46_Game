using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeBuyButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private HeartPillar parentPillar;

    public void Click()
    {
        parentPillar.BuyNode();
    }

    public void SetState(bool state)
    {
        button.interactable = state;
    }
}
