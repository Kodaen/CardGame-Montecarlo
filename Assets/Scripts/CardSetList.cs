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
        GenerateSetList();
    }

    //public void GenerateCards()
    //{
    //    List<Card> cartes = new List<Card>();
    //    for (int atk = 0; atk <= 12; atk++)
    //    {
    //        for (int def = 1; def <= 12; def++)
    //        {
    //            Card carte = new Card(atk, def);
    //            if (carte.Cost <= 6)
    //            {
    //                cartes.Add(carte);
    //            }
    //        }
    //    }
    //    cards = cartes;
    //}

    public void GenerateSetList()
    {
        int cardMaxCost = 8;
        string str = "";
        List<Card> newSetList = new List<Card>();
        for (int atk = 0; atk <= cardMaxCost * 2; atk++)
        {
            for (int def = 1; def <= cardMaxCost * 2; def++)
            {
                for (int taunt = 0; taunt <= 1; taunt++)
                {
                    for (int trample = 0; trample <= 1; trample++)
                    {
                        for (int distortion = 0; distortion <= 1; distortion++)
                        {
                            for (int firstStrike = 0; firstStrike <= 1; firstStrike++)
                            {
                                Card card = new Card(atk, def, taunt == 1, trample == 1, distortion == 1, firstStrike == 1);

                                if (card.Cost <= 8)
                                {
                                    newSetList.Add(card);
                                    str += card.ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        GUIUtility.systemCopyBuffer = str;

        cards = newSetList;
    }
}