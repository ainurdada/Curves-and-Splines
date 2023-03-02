# Curves and Spline
## Description
This is results of my learning curves and splines.  
<span style="color:red;font-weight:700;font-size:15px">Repo is on working!</span>
***
## Types
type |  Where I can use it?
----|---------------------
[Bézier](#beziersection) | shapes, fonts & vector graphics
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
### sources and inspiration:
* [Freya Holmér](https://www.youtube.com/@Acegikmo/featured)
* [Wikipedia](https://en.wikipedia.org/wiki/Bezier_curve)
