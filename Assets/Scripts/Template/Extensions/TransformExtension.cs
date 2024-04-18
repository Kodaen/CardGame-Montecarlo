using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension
{
    public static void ChangePositionWith(this Transform transform, float? x = null, float? y = null, float? z = null)
    {
        transform.position = transform.position.With(x, y, z);
    }

    public static void ChangeScaleWith(this Transform transform, float? x = null, float? y = null, float? z = null)
    {
        transform.localScale = transform.localScale.With(x, y, z);
    }

    public static void MultiplyPositionWith(this Transform transform, float? x = null, float? y = null, float? z = null)
    {
        transform.position = transform.position.MultiplyWith(x, y, z);
    }

    public static void MultiplyScaleWith(this Transform transform, float? x = null, float? y = null, float? z = null)
    {
        transform.localScale = transform.localScale.MultiplyWith(x, y, z);
    }

    public static void DestroyAllChildren(this Transform parent)
    {
        parent.PerformActionOnChildren(child => Object.Destroy(child.gameObject));
    }

    public static void PerformActionOnChildren(this Transform parent, System.Action<Transform> action)
    {
        int childCount = parent.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            action(parent.GetChild(i));
        }
    }
}
