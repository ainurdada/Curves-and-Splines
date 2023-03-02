using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[ExecuteAlways]
public class BezierCurveTest : MonoBehaviour
{
     
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    [Range(0f, 1f)]
    public float t;

    // Update is called once per frame
    void Update()
    {
        transform.position = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, t);
        transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(p0.position, p1.position, p2.position, p3.position, t));
    }

    private void OnDrawGizmos()
    {
        int sigmentNumber = 20;
        Vector3 previousePoint = p0.position;

        for (int i = 0; i <= sigmentNumber; i++) // white line
        {
            
            float parameter = (float)i / sigmentNumber;
            Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
            Gizmos.DrawLine(previousePoint, point);
            previousePoint = point;
        }

        Gizmos.DrawLine(p0.position, p1.position);
        Gizmos.DrawLine(p2.position, p3.position);
    }
}
