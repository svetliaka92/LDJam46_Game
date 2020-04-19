using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float maxHealth = 50f;

    [SerializeField] private float currentHealth;

    public event Action<int> onDeathEvent;
    public event Action endReachedEvent;

    private int rewardPoints;
    private Vector3[] path;
    private float timeToMove;

    private int followPathId = -1;

    private bool isDead = false;

    public void Init(List<Vector3> path, float health, int points)
    {
        maxHealth = health;
        currentHealth = maxHealth;
        rewardPoints = points;
        isDead = false;

        // we're using the LeanTween MoveSpline method, so were duplicating the first and last point of the path
        // as the first and last entries of the array are used for orientation

        CalculatePath(path);

        FollowPath();
    }

    private void CalculatePath(List<Vector3> path)
    {
        List<Vector3> inputPath = path;
        inputPath.Insert(0, inputPath[0]);
        inputPath.Insert(inputPath.Count - 1, inputPath[inputPath.Count - 1]);

        this.path = new Vector3[inputPath.Count];

        for (int i = 0; i < this.path.Length; i++)
            this.path[i] = inputPath[i];

        float pathLength = CalculateTotalPathLength(path);

        timeToMove = pathLength / movementSpeed;
    }

    private float CalculateTotalPathLength(List<Vector3> path)
    {
        float length = 0f;
        for (int i = 0; i < path.Count - 1; i++)
        {
            length += Vector3.Distance(path[i], path[i + 1]);
        }

        return length;
    }

    private void FollowPath()
    {
        followPathId = LeanTween.moveSpline(gameObject, path, timeToMove)
                                .setOnComplete(OnEndReached)
                                .uniqueId;
    }

    public void TakeDamage(float value)
    {
        currentHealth = Mathf.Max(currentHealth - value, 0);
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            onDeathEvent?.Invoke(rewardPoints);
            Die();
        }
    }

    private void Die()
    {
        CancelMovement();
        Destroy(gameObject);
    }

    private void CancelMovement()
    {
        if (followPathId != -1)
        {
            LeanTween.cancel(followPathId);
            followPathId = -1;
        }
    }

    private void OnEndReached()
    {
        if (!isDead)
        {
            // hit heart
            if (PlayerLifeManager.Instance)
                PlayerLifeManager.Instance.TakeDamage();

            isDead = true;
            endReachedEvent?.Invoke();
        }
        
        Die();
    }
}
