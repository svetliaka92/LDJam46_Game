using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private CameraArm cameraArm;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float cameraZoomSpeed;

    [SerializeField] private float minCameraDistance;
    [SerializeField] private float maxCameraDistance;

    [SerializeField] bool isSprinting;

    private float cameraZoom = 20;

    float horizontalPos = 0f;
    float verticalPos = 0f;

    private void Start()
    {
        cameraArm.Init();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        float sprint = Input.GetAxis("Sprint");

        isSprinting = sprint > 0.3f;

        float speed = isSprinting ? sprintSpeed : moveSpeed;

        horizontalPos += (h * speed * Time.deltaTime);
        verticalPos += (v * speed * Time.deltaTime);
        cameraZoom = Mathf.Clamp(cameraZoom -zoom * cameraZoomSpeed, minCameraDistance, maxCameraDistance);

        playerTransform.localPosition = new Vector3(horizontalPos, 0, verticalPos);

        cameraArm.SetTargetPosition(cameraZoom);
    }
}
