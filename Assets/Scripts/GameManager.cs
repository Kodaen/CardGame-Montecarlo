using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player _playerA;
    private Player _playerB;

    private List<Vector2> _points = new List<Vector2>();
    [SerializeField, MinValue(0.1f)] private float _length, _height;
    [SerializeField, Range(0.1f, 5)] private float _maxPointWidth = 1;

    private Vector2 _maxWinrate;

    public List<Card> Cards = new List<Card>();

    private void Awake()
    {
        _playerA = new Player();
        _playerB = new Player();
        Cards = CardSetList.Instance.cards;
    }

    //[Button]
    private float PlayGames(int numberOfGames)
    {
        int playerAWins = 0;
        int playerBWins = 0;

        for (int n = 0; n < numberOfGames / 2; n++)
        {
            Player winner = PlayGame(_playerA, _playerB);
            if (winner == _playerA)
            {
                playerAWins++;
            }
            else
            {
                playerBWins++;
            }
        }

        for (int n = 0; n < numberOfGames / 2; n++)
        {
            Player winner = PlayGame(_playerB, _playerA);
            if (winner == _playerA)
            {
                playerAWins++;
            }
            else
            {
                playerBWins++;
            }
        }
        float winrate = ((float)playerAWins / (float)numberOfGames) * 100f;
        //Debug.Log("Player A win rate : " + ((float)playerAWins / (float)numberOfGames) * 100 + "%");
        return winrate;
    }

    [Button]
    private void MonteCarlo(int numberOfIterations)
    {
        float highestWinrate = 0;
        List<Card> bestDeck = new List<Card>();

        for (int i = 0; i < numberOfIterations; i++)
        {

            float winrate = PlayGames(1000);
            if (winrate > highestWinrate)
            {
                highestWinrate = winrate;
                _maxWinrate = (new Vector2(i, highestWinrate));
                bestDeck.Clear();
                for (int j = 0; j < _playerA.Deck.Count; j++)
                {
                    bestDeck.Add(_playerA.Deck[j]);
                }

                Debug.Log("*NEW* " + i + "| Highest winrate :" + highestWinrate + "%");
            }

            _playerA.Deck.Clear();
            for (int j = 0; j < bestDeck.Count; j++)
            {
                _playerA.Deck.Add(bestDeck[j]);
            }

            _playerA.SwapDeckCardFromList();

            _points.Add(new Vector2(i, winrate));
        }
        string res = "{\"Cards\":[";

        for (int i = 0; i < bestDeck.Count - 1; i++)
        {
            res += bestDeck[i].ToString() + ", ";
        }
        res += bestDeck[bestDeck.Count - 1].ToString();
        res += "]}";
        Debug.Log(res);

    }

    private Player PlayGame(Player playerA, Player playerB)
    {
        Player tmpPlayerA = new Player(playerA);
        Player tmpPlayerB = new Player(playerB);

        int i = 0;
        while (true)
        {
            if (tmpPlayerA.IsDefeated())
            {
                return playerB;
            }
            PlayTurn(tmpPlayerA);
            tmpPlayerA.Attack(tmpPlayerB);

            if (tmpPlayerB.IsDefeated())
            {
                return playerA;
            }
            PlayTurn(tmpPlayerB);
            tmpPlayerB.Attack(tmpPlayerA);

            i++;
        }
    }

    private void PlayTurn(Player player)
    {
        player.MaxMana++;
        player.HandSize++;
        player.DrawCardFromDeck();
        player.FillMana();

        while (player.PlayHighestCostCard());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        // Draw abscissa & ordinate
        Gizmos.DrawLine(Vector3.zero, Vector3.up *100 * _height);
        Gizmos.DrawLine(Vector3.zero, Vector3.right * 1000 * _length);

        // Draw repères
        Vector3 test = Vector3.up * 25 * _height;
        test.x -= 2;
        Gizmos.DrawLine(test, Vector3.up * 25 * _height);

        test = Vector3.up * 50 * _height;
        test.x -= 5;
        Gizmos.DrawLine(test, Vector3.up * 50 * _height);

        test = Vector3.up * 75 * _height;
        test.x -= 2;
        Gizmos.DrawLine(test, Vector3.up * 75 * _height);

        // Draw every line of the curve
        for (int i = 0; i < _points.Count-1; i++)
        {
           
            Gizmos.color = Color.green;
            Vector2 tmpPoint0 = _points[i];
            tmpPoint0.x *= _length;
            tmpPoint0.y *= _height;

            Vector2 tmpPoint1 = _points[i+1];
            tmpPoint1.x *= _length;
            tmpPoint1.y *= _height;

            Gizmos.DrawLine(tmpPoint0, tmpPoint1);

            // Draw point at max winrate and draw line to show the cap
            if (_points[i] == _maxWinrate)
            {
                Gizmos.color = Color.red;
                Vector3 tmp = new Vector3(_maxWinrate.x, _maxWinrate.y, 0);
                tmp.x *= _length;
                tmp.y *= _height;
                Gizmos.DrawSphere(tmp, _maxPointWidth);

                Gizmos.DrawLine(new Vector3(0, _maxWinrate.y * _height, 0), new Vector3(_length * 1000, _maxWinrate.y * _height, 0));

            }
        }
    }
}