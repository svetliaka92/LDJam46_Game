using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform pathTransform;

    private List<Vector3> path;

    private void Start()
    {
        foreach (Transform child in pathTransform)
            path.Add(child.position);
    }

    public List<Vector3> GetPath()
    {
        return path;
    }
}
