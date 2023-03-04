using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteAlways]
public class TestBSpline : MonoBehaviour
{
    public Transform[] points;

    private void OnDrawGizmos()
    {
        int sigmentNumber = 20;
        Vector3 previousePoint = BSpline.GetPoint(points[0].position, points[1].position, points[2].position, points[3].position, 0);
        Gizmos.color = Color.white;
        for (int splineCount = 0; splineCount < points.Length - 3; splineCount++) {
            for (int i = 0; i <= sigmentNumber; i++) // white line
            {
                float parameter = (float)i / sigmentNumber;
                Vector3 point = BSpline.GetPoint(
                    points[splineCount].position, 
                    points[splineCount + 1].position, 
                    points[splineCount + 2].position, 
                    points[splineCount + 3].position, 
                    parameter);
                Gizmos.DrawLine(previousePoint, point);
                previousePoint = point;
            } 
        }

        Gizmos.color = Color.red;

        previousePoint = points[0].position;
        for (int i = 1; i < points.Length; i++)
        {
            Gizmos.DrawLine(points[i].position, previousePoint);
            previousePoint = points[i].position;
        }
        //Gizmos.color = Color.red;
        //previousePoint = points[1].position;
        //for (int i = 0; i <= sigmentNumber; i++) // white line
        //{
        //    float parameter = (float)i / sigmentNumber;
        //    Vector3 point = BSpline.GetPoint(points[1].position, points[2].position, points[3].position, points[4].position, parameter);
        //    Gizmos.DrawLine(previousePoint, point);
        //    previousePoint = point;
        //}

        //Gizmos.color = Color.yellow;
        //previousePoint = points[2].position;
        //for (int i = 0; i <= sigmentNumber; i++) // white line
        //{
        //    float parameter = (float)i / sigmentNumber;
        //    Vector3 point = BSpline.GetPoint(points[2].position, points[3].position, points[4].position, points[5].position, parameter);
        //    Gizmos.DrawLine(previousePoint, point);
        //    previousePoint = point;
        //}
    }
}
