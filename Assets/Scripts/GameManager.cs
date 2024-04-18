using Sirenix.OdinInspector;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    private Player _playerA;
    private Player _playerB;

    private void Awake()
    {
        _playerA = new Player();
        _playerB = new Player();
    }

    [Button]
    private void PlayGames(int numberOfGames)
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

        Debug.Log("Player A win rate : " + ((float)playerAWins / (float)numberOfGames) * 100 + "%");
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
        player.FillHand();
        player.FillMana();

        while (player.PlayHighestCostCard());
    }
}