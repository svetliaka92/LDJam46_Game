using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    private static PlayerLifeManager _instance;
    public static PlayerLifeManager Instance => _instance;

    [SerializeField] private int maxLife;
    private int currentLife;

    private void Awake()
    {
        _instance = this;
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    private void Start()
    {
        currentLife = maxLife;
    }

    public void TakeDamage()
    {
        currentLife -= 1;

        if (currentLife <= 0)
        {
            currentLife = 0;

            print("You lose!");
        }
    }
}
