<h1 align="center"> Curves and Spline</h1>

## Description
This is results of my learning curves and splines.
***

## Methods

type |  Where I can use it?
:----:|:---------------------:
[Bézier](#beziersection) | shapes, fonts & vector graphics
[Hermite](#hermitesection) | animation, physics sim & interpolation
[Catmull-Rom](#catmullsection) | animation & path smoothing
[B-Spline](#bsplinelsection) | curvature-sensetive shapes &<br> animations, such as camera paths
***

## <a id="beziersection">Bézier curve
A Bézier curve is formed by four points. Two of them are control points, namely the beginning and the end of the curve. The other two are auxiliary points, the curve does not pass through them, but they are needed to calculate the curve itself.  
![BezierCurve](https://user-images.githubusercontent.com/70095026/222391334-2aa7aea3-6342-4bbd-87d9-0c733c3de936.gif)

### How it works?
![BezierVisualisation](https://user-images.githubusercontent.com/70095026/222672969-e8243aeb-ad4b-4cdf-a50f-15b24948141a.gif)  
![BezierCurve](https://user-images.githubusercontent.com/70095026/222417678-3018c701-a7ef-42e6-83f5-b23be96f3715.png)  
    
Matrix form:
    
$$
    P(t)=
    \left\lbrack \matrix{1 & t & t^2 & t^3} \right\rbrack
    \left\lbrack \matrix{1 & 0 & 0 & 0 \cr
                        -3 & 3 & 0 & 0 \cr
                        3 & -6 & 3 & 0 \cr
                        -1 & 3 & -3 & 1} \right\rbrack
    \left\lbrack \matrix{P_0 \cr
                        P_1 \cr
                        P_2 \cr
                        P_3} \right\rbrack
$$
```C#
public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        return
            p0 +
            t * (-3 * p0 + 3 * p1) +
            Mathf.Pow(t, 2) * (3 * p0 - 6 * p1 + 3 * p2) +
            Mathf.Pow(t, 3) * (-p0 + 3 * p1 - 3 * p2 + p3);
    }
```
***

## <a id="hermitesection">Hermite curve
Unlike the [Bézier curve](#beziersection), the Hermite curve is formed by two points (the beginning and the end of the curve) and by vectors coming out of these points, in which these vectors are realized as tangents to the curve
![Hermite](https://user-images.githubusercontent.com/70095026/222453698-4724b1de-8a2b-474b-9f12-f8d95e8e9d7a.gif)
    
### How it works?
![HermiteCurve](https://user-images.githubusercontent.com/70095026/222454752-3421b256-4d85-437c-9d5e-dcf62a2838df.png)
    
Matrix form:
    
$$
    P(t)=
    \left\lbrack \matrix{1 & t & t^2 & t^3} \right\rbrack
    \left\lbrack \matrix{1 & 0 & 0 & 0 \cr
                        0 & 1 & 0 & 0 \cr
                        3 & -2 & 3 & -1 \cr
                        2 & 1 & -2 & 1} \right\rbrack
    \left\lbrack \matrix{P_0 \cr
                        v_0 \cr
                        P_1 \cr
                        v_1} \right\rbrack
$$
```C#
public static Vector3 GetPoint(Vector3 p0, Vector3 v0, Vector3 p1, Vector3 v1, float t)
    {
        t = Mathf.Clamp01(t);
        return
            p0 +
            t * v0 +
            Mathf.Pow(t, 2) * (-3 * p0 - 2 * v0 + 3 * p1 - v1) +
            Mathf.Pow(t, 3) * (2 * p0 + v0 - 2 * p1 + v1);
    }
```
***

## <a id="catmullsection">Catmull-Rom spline
This is the most popular type of splines in game development. Because of its ease of construction and sufficient degree of curvature, it is used to create animations and build geometries where smoothness throughout the spline is important.  
![Catmull](https://user-images.githubusercontent.com/70095026/222519774-63d88ab6-d2ec-4d29-8a1a-80e2f03a99a3.gif)
### How it works?

Matrix form:
    
$$
    P(t)=
    \left\lbrack \matrix{1 & t & t^2 & t^3} \right\rbrack * {1 \over 2}
    \left\lbrack \matrix{0 & 2 & 0 & 0 \cr
                        -1 & 0 & 1 & 0 \cr
                        2 & -5 & 4 & -1 \cr
                        -1 & 3 & -3 & 1} \right\rbrack
    \left\lbrack \matrix{P_0 \cr
                        P_1 \cr
                        P_2 \cr
                        P_3} \right\rbrack
$$  

To get the tangent (velocity) vectors at the points, we can take the vector between two neighboring points and multiply it by the value `scale`  

Getting velocities for points:
```C#
public static Vector3[] GetVelocities(Vector3[] points, float scale = .5f)
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
```
For getting points use [Hermite method](#hermitesection)  

We can change `scale` (from 0 to 1) to control curvation degree. But in Catmull-Rom method it's 0,5.  
![CatmullScale](https://user-images.githubusercontent.com/70095026/222517405-ecaba1a1-9af7-48bb-b772-275a93b51f69.gif)

***

## <a id="bsplinelsection">B-spline
B-spline is very smooth. However, the control points of this spline are not included in the curve itself. B-spline is great for camera spans or curvature-sensetive things.  
![BSpline](https://user-images.githubusercontent.com/70095026/222896302-37c3aa92-2f4b-44fe-8935-8e9061613141.gif)
### How it works?

Matrix form:
  
$$
    P(t)=
    \left\lbrack \matrix{1 & t & t^2 & t^3} \right\rbrack * {1 \over 6}
    \left\lbrack \matrix{1 & 4 & 1 & 0 \cr
                        -3 & 0 & 3 & 0 \cr
                        3 & -6 & 3 & 0 \cr
                        -1 & 3 & -3 & 1} \right\rbrack
    \left\lbrack \matrix{P_0 \cr
                        P_1 \cr
                        P_2 \cr
                        P_3} \right\rbrack
$$
            
```C#
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
```
***

### sources and inspiration

* [Freya Holmér](https://www.youtube.com/@Acegikmo/featured)
* [Wikipedia](https://en.wikipedia.org/wiki/Bezier_curve)
