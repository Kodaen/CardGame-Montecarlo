
using Sirenix.OdinInspector;
using System;
using UnityEngine;

[Serializable]
public class Card
{
    [HorizontalGroup("1", MarginRight = 0.1f)] public int Cost;
    [HorizontalGroup("1", MarginRight = 0.1f)] public int Attack;
    [HorizontalGroup("1", MarginRight = 0.1f)] public int Defense;
    [HorizontalGroup("1", MarginRight = 0.1f)] public int MaxDefense;
    [HorizontalGroup("1", MarginRight = 0.1f)] public int Value;
    public bool HasTaunt;
    public bool HasTrample;
    public bool HasDistortion;
    public bool HasFirstStrike;

    // Cost
    private float _tauntCost = 1.5f;
    private float _trampleCost = 1;
    private float _firstStrikeCost = 1;
    private float _distorsionCost = 1;

    public Card(int atk, int def)
    {
        Attack = atk;
        Defense = def;
        Value = 0;

        Cost = Mathf.CeilToInt((Attack + Defense) / 2f);
    }

    public Card(int attack, int defense, bool hasTaunt, bool hasTrample, bool hasDistortion, bool hasFirstStrike)
    {
        Attack = attack;
        Defense = defense;
        MaxDefense = defense;
        HasTaunt = hasTaunt;
        HasTrample = hasTrample;
        HasDistortion = hasDistortion;
        HasFirstStrike = hasFirstStrike;

        float cost = (attack + defense) * 0.5f;
        if (HasTaunt) cost += _tauntCost;
        if (HasTrample) cost += _trampleCost;
        if (HasDistortion) cost += _distorsionCost;
        if (HasFirstStrike) cost += _firstStrikeCost;

        Cost = Mathf.CeilToInt(cost);
    }

    public void TradeDamage(object target)
    {
        if (target is Card)
        {
            // TODO : Check initiative later
            ((Card)target).Defense -= Attack;
            Defense -= ((Card)target).Attack;
        }

        if (target is Player)
        {
            ((Player)target).CurrentHP -= Attack;
        }
    }

    public void ResetDefense()
    {
        Defense = MaxDefense;
    }

    public string ToString()
    {
        string res = "";
        res += "{ ";
        res += "\"Cost\":" + Cost + ",";
        res += "\"Attack\":" + Attack + ",";
        res += "\"Defense\":" + Defense +",";
        res += "\"HasTaunt\":" + HasTaunt + ",";
        res += "\"HasTrample\":" + HasTrample + ",";
        res += "\"HasDistortion\":" + HasDistortion + ",";
        res += "\"HasFirstStrike\":" + HasFirstStrike;
        res += " }";
        return res;

    }
}