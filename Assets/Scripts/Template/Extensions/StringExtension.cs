using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtension
{
    /// <summary>
    /// Return the path without the part after the last '/'.
    /// </summary>
    public static string RemoveObjectNameFromPath(this string path)
    {
        int length = path.LastIndexOf('/');

        if (length == -1)
        {
            Debug.LogWarning("string must contain at least one '/' to be considered as a <b>path</b>");
            return path;
        }
            
        return path.Substring(0, length + 1);
    }
}