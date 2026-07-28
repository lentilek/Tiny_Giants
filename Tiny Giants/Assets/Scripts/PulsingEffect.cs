using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PulsingEffect : MonoBehaviour
{
    [SerializeField] private float pulseScale = 1.1f;
    [SerializeField] private float pulseDuration = 0.5f;
    [SerializeField] private bool startOnAwake = true;

    private Tween activeTween;

    private void Awake()
    {
        if (startOnAwake)
        {
            StartPulsing();
        }
    }

    public void StartPulsing()
    {
        if (activeTween == null || !activeTween.IsPlaying())
        {
            activeTween = transform.DOScale(pulseScale, pulseDuration)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}