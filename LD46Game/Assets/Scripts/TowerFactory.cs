using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private Tower[] towerPrefabs;
    [SerializeField] private Transform towerParent;

    public void BuildTower(TowerNode node, TowerType towerType)
    {
        Tower tower = Instantiate(towerPrefabs[(int)towerType]);
        tower.transform.position = node.transform.position;
        tower.transform.SetParent(towerParent);

        // hide node mesh
        node.gameObject.SetActive(false);
    }
}
