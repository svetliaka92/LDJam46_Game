using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPillar : MonoBehaviour, IRaycastable
{
    [SerializeField] private List<TowerNode> nodes;
    [SerializeField] private HeartPillarUI heartPillarUI;

    [SerializeField] private int baseNodeCost = 100;
    [SerializeField] private int nodeCostIncreasePerBoughtNode = 50;

    [SerializeField] private int startNodeCount = 4;

    private List<TowerNode> availableNodesToBuy;

    public void Init()
    {
        availableNodesToBuy = new List<TowerNode>();
        foreach (TowerNode node in nodes)
            if (!node.IsBought)
                availableNodesToBuy.Add(node);

        for (int i = 0; i < startNodeCount; i++)
        {
            TowerNode nodeToActivate = availableNodesToBuy[UnityEngine.Random.Range(0, availableNodesToBuy.Count)];
            OnNodeBought(nodeToActivate);

            availableNodesToBuy.Remove(nodeToActivate);
        }

        UpdateNodeBuyButtonState();
    }

    public void HandleClick()
    {
        UpdateBuyText();
        UpdateNodeBuyButtonState();
        ShowUI();
    }

    public void HandleDeselect()
    {
        UpdateBuyText();
        UpdateNodeBuyButtonState();
        ShowUI(false);
    }

    private void ShowUI(bool show = true)
    {
        heartPillarUI.gameObject.SetActive(show);
    }

    private void UpdateBuyText()
    {
        heartPillarUI.UpdateText(GetNextNodePrice());
    }

    private void UpdateNodeBuyButtonState()
    {
        heartPillarUI.UpdateButtonState();
    }

    public void BuyNode()
    {
        // do node buying
        PlayerMoneyManager.Instance.UseMoney(GetNextNodePrice());

        TowerNode node = availableNodesToBuy[UnityEngine.Random.Range(0, availableNodesToBuy.Count)];
        OnNodeBought(node);
        availableNodesToBuy.Remove(node);

        UpdateBuyText();
        UpdateNodeBuyButtonState();

        ShowUI(false);
    }

    private void OnNodeBought(TowerNode node)
    {
        node.OnNodeBuy();
    }

    public bool CanBuyNode()
    {
        foreach (TowerNode node in nodes)
            if (!node.IsBought)
                return true;

        return false;
    }

    public int GetNextNodePrice()
    {
        return baseNodeCost + GetBuiltNodeCount() * nodeCostIncreasePerBoughtNode;
    }

    private int GetBuiltNodeCount()
    {
        int count = 0;
        foreach (TowerNode node in nodes)
        {
            if (node.IsBought)
                count++;
        }

        return count;
    }
}
