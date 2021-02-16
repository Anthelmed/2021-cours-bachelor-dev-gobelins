using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extension
{
    public static float RandomRange(this Vector2 value)
    {
        return Random.Range(value.x, value.y);
    }
}
