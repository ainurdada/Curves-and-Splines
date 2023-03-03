using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class TestCatmull : MonoBehaviour
{
    public Text scaleText;

    public Transform[] points;

    [Range(0f, 1f)]
    public float scale;
    void Update()
    {
        scaleText.text = "scale = " + scale; 

    }

    private void OnDrawGizmos()
    {
        Vector3[] pointsPosition = new Vector3[points.Length];
        for(int i = 0; i < pointsPosition.Length; i++)
        {
            pointsPosition[i] = points[i].position;
        }
        Vector3[] velocities = CatmullRom.GetVelocities(pointsPosition, scale);

        int sigmentNumber = 20;
        Vector3 previousePoint = points[0].position;

        for (int n = 0; n < points.Length - 1; n++)
        {
            for (int i = 0; i <= sigmentNumber; i++) // white line
            {

                float parameter = (float)i / sigmentNumber;
                Vector3 point = Hermite.GetPoint(points[n].position, velocities[n], points[n + 1].position, velocities[n + 1], parameter);
                Gizmos.color = Color.white;
                Gizmos.DrawLine(previousePoint, point);
                previousePoint = point;
            }
            Gizmos.color = Color.red;
            Gizmos.DrawLine(points[n].position, points[n].position + velocities[n] * scale);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawLine(points[points.Length - 1].position, points[points.Length - 1].position + velocities[points.Length - 1] * scale);
    }
}
