using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class TestHermite : MonoBehaviour
{
    public Transform p0;
    public Transform v0;
    public Transform p1;
    public Transform v1;

    [Range(0f, 1f)]
    public float t;
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        int sigmentNumber = 20;
        Vector3 previousePoint = p0.position;

        for (int i = 0; i <= sigmentNumber; i++) // white line
        {

            float parameter = (float)i / sigmentNumber;
            Vector3 point = Hermite.GetPoint(p0.position, v0.position- p0.position, p1.position, v1.position - p1.position, parameter);
            Gizmos.DrawLine(previousePoint, point);
            previousePoint = point;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawLine(p0.position, v0.position);
        Gizmos.DrawLine(p1.position, v1.position);
    }
}
