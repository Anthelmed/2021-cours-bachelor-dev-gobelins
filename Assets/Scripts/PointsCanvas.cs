using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    private void OnEnable()
    {
        GameplayController.PointChangeEvent += OnPointChanged;
    }
    
    private void OnDisable()
    {
        GameplayController.PointChangeEvent -= OnPointChanged;
    }

    private void OnPointChanged(int value)
    {
        textMesh.text = $"Score : {value}";
    }
}
