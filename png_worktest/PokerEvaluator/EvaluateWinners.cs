using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerEvaluator
{
    public class EvaluateWinners
    {
        public List<Player> CompareCardsAtHand(List<Player> players)
        {
            List<Player> Winners = new List<Player>();
            Hand hand = new Hand();
            int result = 0;

            // Get the hand ranking / poker card for each player
            foreach (Player player in players)
            {
                hand.GetHandRanking(player);
            }

            // Rank the player by its ranking/poker card
            List<Player> rankedPlayers = players.OrderByDescending(player => player.HandRanking).ToList();

            // Get the highest rank for comparison as the basis
            var tempTopRank = rankedPlayers[0];
            Winners.Add(tempTopRank);

            for (int i = 1; i < rankedPlayers.Count; i++)
            {
                result = hand.EvaluateHands(tempTopRank, rankedPlayers[i]);

                if (result == 2)
                {
                    // if the temporary top ranking is defeated, remove the previous
                    // winner add new winner and be the new basis
                    Winners.Clear();
                    Winners.Add(rankedPlayers[i]);
                    tempTopRank = rankedPlayers[i];
                }
                // if have the same ranking and kicker add new winner
                else if (result == 0) 
                    Winners.Add(rankedPlayers[i]);
            }

            return Winners;

        }
    }
}
