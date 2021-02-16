using System;
using UnityEngine;

public static class GameplayController
{
    private static int _points = 0;
    
    public static event Action<int> PointChangeEvent;

    public static void AddPoint()
    {
        _points++;
        Debug.Log($"point: {_points}");

        PointChangeEvent?.Invoke(_points);
    }
}
