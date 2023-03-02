<h1 align="center"> Curves and Spline<br>
<img src ="https://img.shields.io/badge/status-on%20working-red" </h1>

## Description

This is results of my learning curves and splines.
***

## Methods

type |  Where I can use it?
:----:|:---------------------:
[Bézier](#beziersection) | shapes, fonts & vector graphics
[Hermite](#hermitesection) | animation, physics sim & interpolation
Catmull-Rom <br><img src ="https://img.shields.io/badge/status-on%20working-red"> | animation & path smoothing
B-Spline <br><img src ="https://img.shields.io/badge/status-on%20working-red"> | curvature-sensetive shapes &<br> animations, such as camera paths
***

## <a id="beziersection">Bézier curve

![BezierCurve](https://user-images.githubusercontent.com/70095026/222391334-2aa7aea3-6342-4bbd-87d9-0c733c3de936.gif)

### How it works?
![BezierCurve](https://user-images.githubusercontent.com/70095026/222417678-3018c701-a7ef-42e6-83f5-b23be96f3715.png)
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

![Hermite](https://user-images.githubusercontent.com/70095026/222453698-4724b1de-8a2b-474b-9f12-f8d95e8e9d7a.gif)
    
### How it works?
![HermiteCurve](https://user-images.githubusercontent.com/70095026/222454752-3421b256-4d85-437c-9d5e-dcf62a2838df.png)
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

### sources and inspiration

* [Freya Holmér](https://www.youtube.com/@Acegikmo/featured)
* [Wikipedia](https://en.wikipedia.org/wiki/Bezier_curve)
