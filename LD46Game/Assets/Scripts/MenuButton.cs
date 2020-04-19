using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private Vector3 downScale = new Vector3(0.95f, 0.95f, 0.95f);
    private Vector3 upScale = Vector3.one;
    private float scaleTime = 0.3f;

    private int scaleTweenId = -1;

    public virtual void Click()
    {
        //..overwrite to do what it needs to do
    }

    public void OnPointerDown()
    {
        CancelAnimation();

        scaleTweenId = LeanTween.scale(gameObject, downScale, scaleTime)
                                .setEaseInCubic()
                                .setOnComplete(CompleteAnimation)
                                .uniqueId;
    }

    public void OnPointerUp()
    {
        CancelAnimation();

        scaleTweenId = LeanTween.scale(gameObject, upScale, scaleTime)
                                .setEaseInCubic()
                                .setOnComplete(CompleteAnimation)
                                .uniqueId;
    }

    private void CancelAnimation()
    {
        if (scaleTweenId != -1)
        {
            LeanTween.cancel(scaleTweenId);
            scaleTweenId = -1;
        }
    }

    private void CompleteAnimation()
    {
        scaleTweenId = -1;
    }
}
