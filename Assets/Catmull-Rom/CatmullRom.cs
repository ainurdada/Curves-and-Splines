using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class CatmullRom
{
    public static Vector3[] GetVelocities(Vector3[] points, float scale)
    {
        Vector3[] velocities = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            if (i == 0)
            {
                velocities[0] = (2 * points[1] - 2 * points[0]) * scale;
                continue;
            }
            if (i == points.Length - 1)
            {
                velocities[i] = (2 * points[i] - 2 * points[i - 1]) * scale;
                break;
            }
            velocities[i] = (points[i + 1] - points[i - 1]) * scale;
        }
        return velocities;
    }

}
