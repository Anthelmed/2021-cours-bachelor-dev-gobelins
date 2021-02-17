using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    [SerializeField] private Vector2 minMaxIntensity;
    [SerializeField] private Material material;
    [SerializeField] private float duration = 1f;

    private Color _defaultEmissionColor;

    private void Awake()
    {
        _defaultEmissionColor = material.GetColor("_EmissionColor");
    }

    private void Start()
    {
        var color = material.GetColor("_EmissionColor");
        //var hdrColor = color * intensity
        
        material.SetColor("_EmissionColor", color * minMaxIntensity.x);
        material.DOColor(color * minMaxIntensity.y, "_EmissionColor", duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.OutCubic);
    }

    private void OnDestroy()
    {
        material.SetColor("_EmissionColor", _defaultEmissionColor);
    }
}
