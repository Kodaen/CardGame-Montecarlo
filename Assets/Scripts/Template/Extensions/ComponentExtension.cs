using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentExtension 
{
    public static T IfNullGetComponent<T>(this GameObject target, T reference) where T : Component
    {
        if (reference != null) return reference;
        return target.GetComponent<T>();
    }

    public static T GetOrAddComponent<T>(this GameObject target) where T : Component
    {
        T component = target.GetComponent<T>();
        if (component != null) return component;
        return target.AddComponent<T>();
    }

    public static bool TryGetComponentInParent<T>(this GameObject target, out T component)
    {
        if (target.transform.parent == null)
        {
            component = default;
            return false;
        }

        return target.transform.parent.TryGetComponent(out component);
    }
}
