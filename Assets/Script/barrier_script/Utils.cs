﻿using System.Collections;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static IEnumerator MoveToTarget(Transform obj, Vector3 target)
    {
        Vector3 startPosition = obj.position;
        float t = 0;

        const float animationDuration = 2f;
        while (t<1)
        {
            obj.position = Vector3.Lerp(startPosition, target, t);
            t += Time.deltaTime / animationDuration;
            yield return null;
        }
    }
}
