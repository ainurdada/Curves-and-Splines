using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSpline : MonoBehaviour
{

    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float k = 1f / 6f;
        return
            (p0 + 4 *p1 + p2) * k +
            t * k * (-3 * p0 + 3 * p2) +
            Mathf.Pow(t, 2) * k * (3 * p0 - 6 * p1 + 3 * p2) +
            Mathf.Pow(t, 3) * k * (-p0 + 3 * p1 - 3 * p2 + p3);
    }
}
