using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IRaycastable
{
    [Header("Projectile needed elements")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private Projectile projectilePrefab;

    [Space(10)]
    [Header("Tower stats")]
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [SerializeField] private float fireRate;

    [Space(10)]
    [Header("Enemy targetting specific")]
    [SerializeField] private int enemyLayer = 8;

    private float fireCD;
    private Transform currentTarget;
    private Enemy targetEnemy;

    private void Start()
    {
        StartCoroutine(UpdateTarget());
    }

    private void Update()
    {
        TryFire();
    }

    private void TryFire()
    {
        if (fireCD <= 0)
        {
            if (currentTarget)
            {
                Fire();
                fireCD = 1 / fireRate;
            }
        }

        fireCD -= Time.deltaTime;
    }

    private void Fire()
    {
        // firing

        Projectile bullet = Instantiate(projectilePrefab);
        bullet.SetDamage(damage);
        bullet.SetTarget(targetEnemy);
    }

    private IEnumerator UpdateTarget()
    {
        yield return null;
        //while (true)
        //{

        //}
    }

    public void HandleClick()
    {
        // show tower upgrade UI
    }

    public void HandleDeselect()
    {
        
    }
}
