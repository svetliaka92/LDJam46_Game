using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxHealth;

    [SerializeField] private float currentHealth;

    List<Vector3> path;

    public void Init(List<Vector3> path)
    {
        this.path = path;
        currentHealth = maxHealth;

        FollowPath();
    }

    private void FollowPath()
    {
        
    }
}
