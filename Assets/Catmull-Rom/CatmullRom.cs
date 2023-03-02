using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class CatmullRom
{
    public static Vector3[] GetVelocities(Transform[] points, float scale)
    {
        Vector3[] velocities = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            if (i == 0)
            {
                velocities[0] = (2 * points[1].position - 2 * points[0].position) * scale;
                continue;
            }
            if (i == points.Length - 1)
            {
                velocities[i] = (2 * points[i].position - 2 * points[i - 1].position) * scale;
                break;
            }
            velocities[i] = (points[i + 1].position - points[i - 1].position) * scale;
        }
        return velocities;
    }

}
