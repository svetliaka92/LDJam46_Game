using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNodeUI : MonoBehaviour
{
    private void Update()
    {
        // turn towards the camera
        if (CameraRaycaster.Instance)
            transform.LookAt(CameraRaycaster.Instance.mainCam.transform);
    }
}
