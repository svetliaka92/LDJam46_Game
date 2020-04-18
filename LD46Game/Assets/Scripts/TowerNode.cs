using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNode : MonoBehaviour, IRaycastable
{
    [SerializeField] private GameObject buildUI;

    public void HandleClick()
    {
        print(gameObject);
        ShowUI();
    }

    public void HandleDeselect()
    {
        ShowUI(false);
    }

    private void ShowUI(bool show = true)
    {
        buildUI.SetActive(show);
    }
}
