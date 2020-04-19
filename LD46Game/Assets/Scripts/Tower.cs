using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IRaycastable
{
    [Header("Unity UI elements")]
    [SerializeField] private TowerUI towerUI;

    [Space(10)]
    [Header("Projectile needed elements")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private Projectile projectilePrefab;

    [Space(10)]
    [Header("Tower stats")]
    [SerializeField] private TowerType towerType = TowerType.Fire;
    [SerializeField] private float damage;
    [SerializeField] private float fireRate;
    [SerializeField] private float range;
    [SerializeField] private GameObject[] towerBodies;

    [Space(10)]
    [Header("Enemy targetting specific")]
    [SerializeField] private int enemyLayer = 8;

    public TowerType TowerType => towerType;

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

        UpdatePriceText();
        ShowUI(false);
    }

    public void SetStatsGetter(TowerStatsGetter towerStatsGetter)
    {
        towerUI.Init(towerStatsGetter);
    }

    private void Update()
    {
        TryFire();
    }

    private void TryFire()
    {
        if (fireCD <= 0)
        {
            UpdateTarget();

            if (targetEnemy)
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

        Projectile bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        bullet.SetDamage(damage);
        bullet.SetTarget(targetEnemy);
    }

    protected virtual void UpdateTarget()
    {
        int layerMask = 1 << enemyLayer;
        RaycastHit[] enemies = Physics.SphereCastAll(transform.position, range, Vector3.up, 0, layerMask);

        float distance = float.MaxValue;
        Enemy nearestEnemy = null;

        foreach (RaycastHit hit in enemies)
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            GetClosestEnemy(ref distance, ref nearestEnemy, enemy);

            if (nearestEnemy && distance <= range)
                targetEnemy = nearestEnemy;
            else
                targetEnemy = null;
        }
    }

    protected virtual void GetClosestEnemy(ref float shortestDistance, ref Enemy nearestEnemy, Enemy enemy)
    {
        float distToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

        if (distToEnemy <= shortestDistance)
        {
            shortestDistance = distToEnemy;
            nearestEnemy = enemy;
        }
    }

    public void HandleClick()
    {
        UpdatePriceText();
        UpdateState();
        ShowUI();
    }

    public void HandleDeselect()
    {
        UpdatePriceText();
        UpdateState();
        ShowUI(false);
    }

    private void ShowUI(bool show = true)
    {
        towerUI.gameObject.SetActive(show);
    }

    private void UpdatePriceText()
    {
        towerUI.UpdateText();
    }

    public void UpdateState()
    {
        towerUI.UpdateButtons();
    }
}
