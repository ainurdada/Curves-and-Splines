using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Hermite
{
    public static Vector3 GetPoint(Vector3 p0, Vector3 v0, Vector3 p1, Vector3 v1, float t)
    {
        t = Mathf.Clamp01(t);
        return
            p0 +
            t * v0 +
            Mathf.Pow(t, 2) * (-3 * p0 - 2 * v0 + 3 * p1 - v1) +
            Mathf.Pow(t, 3) * (2 * p0 + v0 - 2 * p1 + v1);
    }
}
