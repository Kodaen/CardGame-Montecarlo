using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtension
{
    public static Vector3 With(this Vector3 original, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? original.x, y ?? original.y, z ?? original.z);
    }

    public static Vector2 With(this Vector2 original, float? x = null, float? y = null)
    {
        return new Vector2(x ?? original.x, y ?? original.y);
    }

    public static Vector3 MultiplyWith(this Vector3 original, float? x = null, float? y = null, float? z = null)
    {
        return original.With(x * original.x, y * original.y, z * original.z);
    }

    public static Vector2 MultiplyWith(this Vector2 original, float? x = null, float? y = null)
    {
        return original.With(x * original.x, y * original.y);
    }

    public static Vector3 DirectionTo(this Vector3 source, Vector3 destination)
    {
        return Vector3.Normalize(destination - source);
    }

    public static Vector2 DirectionTo(this Vector2 source, Vector2 destination)
    {
        return Vector3.Normalize(destination - source);
    }

    public static Vector2 ToV2(this Vector3 original)
    {
        return new Vector2(original.x, original.y);
    }
}
