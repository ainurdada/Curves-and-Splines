using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

[ExecuteAlways]
public class BezierSplinesTest : MonoBehaviour
{
    public Transform[] points;

    [Range(0f, 1f)]
    public float t;

    void Update()
    {
        int splineNumber = (int)(t * (points.Length / 3));
        float localT = (t * (points.Length / 3)) % 1;
        if (splineNumber >= points.Length / 3)
        {
            splineNumber--;
            localT = 1;
        }

        for (int i = 0; i < points.Length / 3; i++)
        {
            if (i > 0)
                points[1 + 3 * i].position = 2 * points[3 + 3 * (i - 1)].position - points[2 + 3 * (i - 1)].position;
        }

        Debug.Log(points.Length / 3);
        transform.position = Bezier.GetPoint
                (points[0 + 3 * splineNumber].position,
                points[1 + 3 * splineNumber].position,
                points[2 + 3 * splineNumber].position,
                points[3 + 3 * splineNumber].position, localT);
    }

    private void OnDrawGizmos()
    {
        int sigmentNumberPerSpline = 20;
        int sigmentNumber = sigmentNumberPerSpline * (points.Length / 3);
        Vector3 previousePoint = points[0].position;

        for (int i = 0; i <= sigmentNumber; i++) // white line
        {

            float parameter = (float)i / sigmentNumberPerSpline;
            int splineNumber = (int)parameter;
            parameter = parameter % 1;

            if (splineNumber >= points.Length / 3)
            {
                splineNumber--;
                parameter = 1;
            }

            Vector3 point = Bezier.GetPoint
                (points[0 + 3 * splineNumber].position,
                points[1 + 3 * splineNumber].position,
                points[2 + 3 * splineNumber].position,
                points[3 + 3 * splineNumber].position, parameter);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(previousePoint, point);
            previousePoint = point;
        }

        //previousePoint = points[0].position;
        //for (int i = 0; i <= sigmentNumber; i++) // red line
        //{

        //    float parameter = (float)i / sigmentNumberPerSpline;
        //    int splineNumber = (int)parameter;
        //    parameter = parameter % 1;

        //    if (splineNumber >= points.Length / 3)
        //    {
        //        splineNumber--;
        //        parameter = 1;
        //    }
        //    if (parameter + splineNumber < t * points.Length / 3)
        //    {
        //        Vector3 point = Bezier.GetPoint
        //            (points[0 + 3 * splineNumber].position,
        //            points[1 + 3 * splineNumber].position,
        //            points[2 + 3 * splineNumber].position,
        //            points[3 + 3 * splineNumber].position, parameter);
        //        Gizmos.color = Color.red;
        //        Gizmos.DrawLine(previousePoint, point);
        //        previousePoint = point;
        //    }
        //    else
        //    {
        //        Vector3 point = Bezier.GetPoint
        //            (points[0 + 3 * splineNumber].position,
        //            points[1 + 3 * splineNumber].position,
        //            points[2 + 3 * splineNumber].position,
        //            points[3 + 3 * splineNumber].position, parameter);
        //        Gizmos.color = Color.red;
        //        Gizmos.DrawLine(previousePoint, point);
        //        break;
        //    }
        //}
    }
}
