using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class BezierCurveTest : MonoBehaviour
{
     
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    [Range(0f, 1f)]
    public float t;

    public Text tText;

    // Update is called once per frame
    void Update()
    {
        tText.text = "t = " + t;
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
            if (parameter >= t) parameter = t;
            Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
            Gizmos.DrawLine(previousePoint, point);
            previousePoint = point;
        }


        Vector3 p01 = Vector3.Lerp(p0.position, p1.position, t);
        Vector3 p12 = Vector3.Lerp(p1.position, p2.position, t);
        Vector3 p23 = Vector3.Lerp(p2.position, p3.position, t);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(p01, p12);
        Gizmos.DrawLine(p12, p23);

        Vector3 p012 = Vector3.Lerp(p01, p12, t);
        Vector3 p123 = Vector3.Lerp(p12, p23, t);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(p012, p123);

        Vector3 p0123 = Vector3.Lerp(p012, p123, t);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(p0123, 0.1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(p0.position, p1.position);
        Gizmos.DrawLine(p1.position, p2.position);
        Gizmos.DrawLine(p2.position, p3.position);
    }
}
