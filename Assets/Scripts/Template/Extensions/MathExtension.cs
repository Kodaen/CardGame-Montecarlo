using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathExtension 
{
    /// <summary>
    /// Modulo operator but ensures that the value remains positive.
    /// </summary>
    public static int Mod(this int n, int mod)
    {
        int reste = n % mod;
        return reste < 0 ? reste + mod : reste;
    }

    /// <summary>
    /// Sign of the value, can be -1, 0 or 1.
    /// </summary>
    public static int Sign(this int value)
    {
        if (value < 0) return -1;
        if (value > 0) return 1;
        return 0;
    }
}
