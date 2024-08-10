using System;
using System.Collections;
using UnityEngine;

public static class ToTween
{
    public static IEnumerator TOPath (this Transform tr, Transform[] pathPoints, Action onComplete = null)
    {
        bool completed = false;

        int currentPoint = 0;

        while (!completed)
        {
            if (Vector3.Distance(tr.position, pathPoints[currentPoint].position) > 0.1f)
            {
                tr.position = Vector3.MoveTowards(tr.position, pathPoints[currentPoint].position, 0.025f);
                tr.LookAt(pathPoints[currentPoint].position);
            }
            else
            {
                currentPoint++;

                if (currentPoint == pathPoints.Length)
                {
                    completed = true;
                }
            }

            yield return null;
        }

        onComplete?.Invoke();
    }

    public static IEnumerator TOMove (this Transform tr, Transform pathPoint, Action onComplete = null)
    {
        bool completed = false;

        while (!completed)
        {
            if (Vector3.Distance(tr.position, pathPoint.position) > 0.1f)
            {
                tr.position = Vector3.MoveTowards(tr.position, pathPoint.position, 0.025f);
                tr.LookAt(pathPoint.position);
            }
            else
            {
                completed = true;
            }

            yield return null;
        }

        onComplete?.Invoke();
    }
}
