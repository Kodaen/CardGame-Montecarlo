using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class CardSetList
{
    #region singleton
    private static CardSetList instance;

    public static CardSetList Instance
    {
        get
        {
            // Si aucune instance n'existe, en crée une
            if (instance == null)
            {
                instance = new CardSetList();
            }
            return instance;
        }
    }
    #endregion

    public List<Card> cards;


    private CardSetList()
    {
        cards = new List<Card>();
        GenerateCards();
    }

    public void GenerateCards()
    {
        List<Card> cartes = new List<Card>();
        for (int atk = 0; atk <= 12; atk++)
        {
            for (int def = 1; def <= 12; def++)
            {
                Card carte = new Card(atk, def);
                if (carte.Cost <= 6)
                {
                    cartes.Add(carte);
                }
            }
        }
        cards = cartes;
    }
}