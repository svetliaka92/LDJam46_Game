using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNode : MonoBehaviour, IRaycastable
{
    [SerializeField] private TowerNodeUI buildUI;

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

    private void ShowUI(bool show = true)
    {
        buildUI.gameObject.SetActive(show);
    }

    public void UpdateState()
    {
        buildUI.UpdateButtons();
    }
}
