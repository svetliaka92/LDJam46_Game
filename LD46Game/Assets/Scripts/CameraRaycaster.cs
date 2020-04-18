using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRaycaster : MonoBehaviour
{
    private static CameraRaycaster _instance;
    public static CameraRaycaster Instance => _instance;

    public Camera mainCam;
    IRaycastable selection;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            RaycastForTarget();
    }

    private void RaycastForTarget()
    {
        if (ClickedOnUI())
            return;

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;
        if (Physics.Raycast(ray, out info))
        {
            IRaycastable raycastable = info.collider.GetComponent<IRaycastable>();
            if (raycastable != null)
            {
                if (selection != null)
                    selection.HandleDeselect();

                selection = raycastable;

                selection.HandleClick();
            }
            else
            {
                if (selection != null)
                    selection.HandleDeselect();

                selection = null;
            }
        }
    }

    private bool ClickedOnUI()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        foreach (RaycastResult raycastResult in results)
        {
            if (raycastResult.gameObject.layer == 5)
                return true;
        }

        return false;
    }
}
