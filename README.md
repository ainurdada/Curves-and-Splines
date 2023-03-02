# Curves and Spline
## Description
This is results of my learning curves and splines.
***
## Bézier curve

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


### sources and inspiration:
* [Freya Holmér](https://www.youtube.com/@Acegikmo/featured)
* [Wikipedia](https://en.wikipedia.org/wiki/Bezier_curve)