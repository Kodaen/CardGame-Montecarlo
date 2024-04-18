
using Sirenix.OdinInspector;
using System;
using UnityEngine;

[Serializable]
public class Card
{
    [HorizontalGroup("1", MarginRight = 0.1f)] public int Cost;
    [HorizontalGroup("1", MarginRight = 0.1f)] public int Attack;
    [HorizontalGroup("1", MarginRight = 0.1f)] public int Defense;

    public Card(int atk, int def)
    {
        Attack = atk;
        Defense = def;
        Cost = Mathf.CeilToInt((Attack + Defense) / 2f);
    }
}