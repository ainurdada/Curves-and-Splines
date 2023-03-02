<h1 align="center"> Curves and Spline<br>
<img src ="https://img.shields.io/badge/status-on%20working-red" </h1>

## Description

This is results of my learning curves and splines.
***

## Methods

type |  Where I can use it?
:----:|:---------------------:
[Bézier](#beziersection) | shapes, fonts & vector graphics
Hermite <br><img src ="https://img.shields.io/badge/status-on%20working-red"> | animation, physics sim & interpolation
Catmull-Rom <br><img src ="https://img.shields.io/badge/status-on%20working-red"> | animation & path smoothing
B-Spline <br><img src ="https://img.shields.io/badge/status-on%20working-red"> | curvature-sensetive shapes &<br> animations, such as camera paths
***

## <a id="beziersection">Bézier curve

![BezierCurve](https://user-images.githubusercontent.com/70095026/222391334-2aa7aea3-6342-4bbd-87d9-0c733c3de936.gif)

### How it works?

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

### sources and inspiration

* [Freya Holmér](https://www.youtube.com/@Acegikmo/featured)
* [Wikipedia](https://en.wikipedia.org/wiki/Bezier_curve)
