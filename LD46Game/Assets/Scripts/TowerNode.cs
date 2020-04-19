using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNode : MonoBehaviour, IRaycastable
{
    [SerializeField] private TowerNodeUI buildUI;
    [SerializeField] private GameObject nodeBody;
    [SerializeField] private Collider nodeCollider;

    private bool isBought = false;
    public bool IsBought => isBought;

    private bool isUsed = false;
    public bool IsUsed => isUsed;

    public void HandleClick()
    {
        UpdateState();
        ShowUI();
    }

    public void HandleDeselect()
    {
        UpdateState();
        ShowUI(false);
    }

    public void OnNodeBuy()
    {
        isBought = true;

        nodeBody.SetActive(true);
        nodeCollider.enabled = true;

        buildUI.Init();
    }

    private void ShowUI(bool show = true)
    {
        buildUI.gameObject.SetActive(show);
    }

    public void UpdateState()
    {
        buildUI.UpdateButtons();
    }

    public void TowerBuiltOnNode()
    {
        isUsed = true;

        nodeBody.SetActive(false);
        nodeCollider.enabled = false;

        ShowUI(false);
    }
}
