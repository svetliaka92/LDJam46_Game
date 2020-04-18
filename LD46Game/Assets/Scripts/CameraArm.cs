using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArm : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    
    [SerializeField] private float cameraZoomEasing;

    private float cameraDistance = 22;

    float currentPosition;
    float targetPosition;

    bool doUpdate = false;

    public void Init()
    {
        currentPosition = cameraDistance;
        targetPosition = cameraDistance;

        cameraTransform.localPosition = new Vector3(0, 0, -currentPosition);

        doUpdate = true;
    }

    private void LateUpdate()
    {
        if (!doUpdate)
            return;

        if (currentPosition != targetPosition)
        {
            currentPosition += (targetPosition - currentPosition) / cameraZoomEasing;
            currentPosition = (Mathf.Abs(targetPosition - currentPosition) < 0.1f)
                              ? targetPosition
                              : currentPosition;
        }

        cameraTransform.localPosition = new Vector3(0, 0, -currentPosition);
    }

    public void SetTargetPosition(float value)
    {
        targetPosition = value;
    }
}
