using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private GameObject fadeCanvas;
    [SerializeField] private Image fadeImage;

    public event Action onFadeInCompleteEvent;
    public event Action onFadeOutCompleteEvent;

    float imageAlpha = 1f;

    private int imageFadeTweenId = -1;

    public void Fade(bool fade, float seconds)
    {
        if (fade)
            FadeIn(seconds);
        else
            FadeOut(seconds);
    }

    private void FadeIn(float seconds)
    {
        CancelFade();

        imageFadeTweenId = LeanTween.value(imageAlpha, 1, seconds)
                           .setEaseOutCubic()
                           .setOnComplete(OnFadeIdComplete)
                           .setOnUpdate(UpdateImageAlpha)
                           .uniqueId;
    }

    private void FadeOut(float seconds)
    {
        CancelFade();

        imageFadeTweenId = LeanTween.value(imageAlpha, 0, seconds)
                           .setEaseOutCubic()
                           .setOnComplete(OnFadeOutComplete)
                           .setOnUpdate(UpdateImageAlpha)
                           .uniqueId;
    }

    private void UpdateImageAlpha(float value)
    {
        imageAlpha = value;
        Color color = fadeImage.color;
        color.a = value;
        fadeImage.color = color;
    }

    private void OnFadeIdComplete()
    {
        // notify complete
        onFadeInCompleteEvent?.Invoke();
        CompleteFade();
    }

    private void OnFadeOutComplete()
    {
        // notify complete
        onFadeOutCompleteEvent?.Invoke();
        CompleteFade();
    }

    private void CancelFade()
    {
        if (imageFadeTweenId != -1)
        {
            LeanTween.cancel(imageFadeTweenId);
            imageFadeTweenId = -1;
        }
    }

    private void CompleteFade()
    {
        imageFadeTweenId = -1;
    }
}
