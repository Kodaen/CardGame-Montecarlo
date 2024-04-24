using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int MaxHP = 20;
    public int CurrentHP;
    public int MaxMana = 0;
    public int CurrentMana;
    public int HandSize = 4;

    public List<Card> Deck = new List<Card>();
    private List<Card> Hand = new List<Card>();
    public List<Card> Board = new List<Card>();

    public Player()
    {
        FillDeck();
        FillHand();
        FillMana();
        CurrentHP = MaxHP;
    }

    public Player(Player other)
    {
        // creates a copie of a player
        MaxHP = other.MaxHP;
        CurrentHP = other.CurrentHP;
        MaxMana = other.MaxMana;
        CurrentMana = other.CurrentMana;
        HandSize = other.HandSize;
        
        for (int i = 0; i < other.Deck.Count; i++)
        {
            Deck.Add(other.Deck[i]);
        }

        for (int i = 0; i < other.Hand.Count; i++)
        {
            Hand.Add(other.Hand[i]);
        }

        for (int i = 0; i < other.Board.Count; i++)
        {
            Board.Add(other.Board[i]);
        }        
    }

    private void FillDeck()
    {
        List<Card> SetList = CardSetList.Instance.cards;

        while (Deck.Count < 30)
        {
            int rand = Random.Range(0, SetList.Count - 1);

            if (DeckDoesntContainCardTwice(SetList[rand]))
            {
                Deck.Add(SetList[rand]);
            }
        }
    }

    public void FillHand()
    {
        while (Hand.Count < HandSize)
        {
            DrawCardFromDeck();
        }
    }
    public void FillMana()
    {
        CurrentMana = MaxMana;
    }


    private bool DeckDoesntContainCardTwice(Card element)
    {
        int count = 0;

        foreach (Card value in Deck)
        {
            if (value == element)
            {
                count++;
                if (count > 2) return false;
            }
        }

        return true;
    }

    public bool PlayHighestCostCard()
    {
        Card highestCostCard = null;
        int highestCost = 0;

        foreach (var card in Hand)
        {
            if (card.Cost > highestCost && card.Cost <= CurrentMana)
            {
                highestCostCard = card;
            }
        }

        if (highestCostCard != null)
        {
            CurrentMana -= highestCostCard.Cost;
            Board.Add(highestCostCard);
            Hand.Remove(highestCostCard);
            return true;
        }

        // if we couldn't place any card because their cost is too high;
        return false;
    }

    public bool DrawCardFromDeck()
    {
        if (Hand.Count >= HandSize)
        {
            Debug.Log("Couldn't draw another card, hand already full");
            return false;
        }
        if (Deck.Count == 0) { return false; }
        int rand = Random.Range(0, Deck.Count - 1);

        Hand.Add(Deck[rand]);
        Deck.Remove(Deck[rand]);
        return true;
    }

    public void Attack(Player otherPlayer)
    {
        List<Card> enemyTauntCards = new List<Card>();
        // Check if there are cards with provocation
        foreach (Card enemyCard in otherPlayer.Board)
        {
            if (enemyCard.HasTaunt)
            {
                enemyTauntCards.Add(enemyCard);
            }
        }
        int i = enemyTauntCards.Count -1;

        for (int j = Board.Count - 1; j >= 0; j--)
        {
            if (i >= 0)
            {
                Board[j].TradeDamage(enemyTauntCards[i]);
                if (enemyTauntCards[i].Defense <= 0)
                {

                    enemyTauntCards[i].ResetDefense();
                    enemyTauntCards.Remove(enemyTauntCards[i]);
                    i--;
                }
                if (Board[j].Defense <= 0)
                {
                    Board[j].ResetDefense();
                    Board.Remove(Board[j]);
                }
            }
            else
            {
                Board[j].TradeDamage(otherPlayer);
            }
        }

        foreach (var item in otherPlayer.Board)
        {
            if (item.Defense > 0)
            {
                item.ResetDefense();
            }
        }

        foreach (var item in Board)
        {
            if (item.Defense > 0)
            {
                item.ResetDefense();
            }
        }

    }

    public bool IsDefeated()
    {
        return (CurrentHP <= 0);
    }
    
    public void SwapDeckCardFromList()
    {
        // Remove random card, and put another random card from SetList
        int rand = Random.Range(0, Deck.Count - 1);
        
        Deck.RemoveAt(rand);
        FillDeck();
    }
}
