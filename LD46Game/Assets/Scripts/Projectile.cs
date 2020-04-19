using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 7f;
    [SerializeField] private GameObject hitVFX;

    private float damage;
    private Enemy target;

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distThisFrame = bulletSpeed * Time.deltaTime;

        transform.Translate(dir.normalized * distThisFrame, Space.World);
        transform.LookAt(target.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy)
            HitEnemy();
    }
    
    private void HitEnemy()
    {
        // update model
        target.TakeDamage(damage);

        // update presentation
        if (hitVFX)
            Instantiate(hitVFX);

        Destroy(gameObject);
    }

    public void SetDamage(float value)
    {
        damage = value;
    }

    public void SetTarget(Enemy enemy)
    {
        target = enemy;
    }
}
