using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier
{

    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return 
            Mathf.Pow(oneMinusT,3) * p0 
            + 3 * Mathf.Pow(oneMinusT,2) * t * p1 
            + 3 * oneMinusT * Mathf.Pow(t,2) * p2
            + Mathf.Pow(t,3) * p3;
    }

    public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return 
            3 * Mathf.Pow(oneMinusT,2) * (p1-p0) 
            + 6 * oneMinusT * t * (p2-p1)
            + 3 * Mathf.Pow(t,2) * (p3-p2);
    }
}
