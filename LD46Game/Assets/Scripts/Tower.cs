using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IRaycastable
{
    [Header("Unity UI elements")]
    [SerializeField] private GameObject towerUI;

    [Space(10)]
    [Header("Projectile needed elements")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private Projectile projectilePrefab;

    [Space(10)]
    [Header("Tower stats")]
    [SerializeField] private float damage;
    [SerializeField] private float fireRate;
    [SerializeField] private float range;
    [SerializeField] private GameObject[] towerBodies;

    [Space(10)]
    [Header("Enemy targetting specific")]
    [SerializeField] private int enemyLayer = 8;

    private int _upgradeLevel = 0;
    public int UpgradeLevel => _upgradeLevel;

    private float fireCD;

    private GameObject currentBody = null;

    private Transform currentTarget;
    private Enemy targetEnemy;

    internal void SetStats(int level, float damage, float fireRate, float range)
    {
        _upgradeLevel = level;
        this.damage = damage;
        this.fireRate = fireRate;
        this.range = range;

        // update visuals
        if (currentBody != null)
            currentBody.SetActive(false);

        currentBody = towerBodies[_upgradeLevel];
        currentBody.SetActive(true);
    }

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
        ShowUI();
    }

    public void HandleDeselect()
    {
        ShowUI(false);
    }

    private void ShowUI(bool show = true)
    {
        towerUI.SetActive(show);
    }
}
