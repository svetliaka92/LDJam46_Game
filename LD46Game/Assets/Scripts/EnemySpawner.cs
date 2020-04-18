using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private List<Portal> portals;

    [SerializeField] bool debugging = false;

    private void Update()
    {
        if (debugging)
        {
            if (Input.GetKeyDown(KeyCode.T))
                SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy = Instantiate(enemyPrefab, portals[0].transform.position, portals[0].transform.rotation);
        enemy.Init(portals[0].GetPath());
    }
}
