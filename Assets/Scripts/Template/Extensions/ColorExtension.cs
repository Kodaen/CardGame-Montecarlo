using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorExtension
{
    public static string ToHex(this Color color)
    {
        return "#" + ColorUtility.ToHtmlStringRGBA(color);
    }

    public static Color ColorFromHex(this string hex)
    {
        if (hex == null || hex == "") return default;
        if (hex[0] != '#') hex = "#" + hex;
        if (ColorUtility.TryParseHtmlString(hex, out Color color)) return color;
        return default;
    }
}
