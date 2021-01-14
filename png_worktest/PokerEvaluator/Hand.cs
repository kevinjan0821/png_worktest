using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerEvaluator
{

    public enum HandRanking
    {
        HighCard, OnePair, TwoPair, ThreeOfAKind, Straight,
        Flush, FullHouse, FourOfAKind, StraightFlush, RoyalFlush
    }

    public class Hand : DeckOfCards
    {
        public void GetHand(List<Player> players)
        {
            // Get card for each player
            int init = 0;
            int maxCount = 5;
            int i = 0;

            foreach (Player player in players)
            {
                for(i = init; i < maxCount; i++)
                {
                    player.CardsAtHand.Add(getDeck[i]);
                }

                init = i;
                maxCount += 5;
            }
        }

        public void GetHandRanking(Player player)
        {
            // Check if the player have the valid card count
            if (player.CardsAtHand.Count == 5)
            {
                // Calulate the product of prime numbers that will be used in checking the rank
                player.CardsAtHand = player.CardsAtHand.OrderBy(card => card.valueProduct * 1 + card.suitProduct).ToList();
                int valueProduct = player.CardsAtHand.Select(card => card.valueProduct).Aggregate((a, b) => a * b);
                int suitProduct = player.CardsAtHand.Select(card => card.suitProduct).Aggregate((a, b) => a * b);

                // Check if straight
                bool straight = CheckIfStraight(valueProduct);

                // Check if flush
                bool flush = CheckIfFlush(suitProduct);

                // Check if royal flush
                bool royalFlush = valueProduct == 31367009  // Highest combination means there's an ACE
                    && straight == true // Straight 
                    && flush == true; // flush, same suit

                // Count card with same value
                int fourOfAKind = -1;
                int threeOfAkind = -1;
                int twoPair = -1;
                int onePair = -1;

                // Group the card by value to check for possible pairs
                var cardCount = player.CardsAtHand.GroupBy(card => (int) card.Value).Select(group => group).ToList();

                foreach (var group in cardCount)
                {
                    var value = group.Key;
                    var count = group.Count();

                    if (count == 4) fourOfAKind = value;
                    else if (count == 3) threeOfAkind = value;
                    else if (count == 2)
                    {
                        twoPair = onePair;
                        onePair = value;
                    }

                }

                if (straight && flush)
                {
                    if (royalFlush)
                    {
                        player.HandRanking = HandRanking.RoyalFlush;
                    }
                    else
                    {
                        player.HandRanking = HandRanking.StraightFlush;
                        player.HandKickers = player.CardsAtHand.Select(card => (int)card.Value).Reverse().ToList();
                    }
                }
                else if (fourOfAKind >= 0)
                {
                    player.HandRanking = HandRanking.FourOfAKind;
                    player.HandKickers.Add(fourOfAKind);
                    player.HandKickers.AddRange(player.CardsAtHand
                        .Where(card => (int)card.Value != fourOfAKind)
                        .Select(card => (int)card.Value));
                }
                else if (threeOfAkind >= 0 && onePair >= 0)
                {
                    player.HandRanking = HandRanking.FullHouse;
                    player.HandKickers.Add(threeOfAkind);
                    player.HandKickers.Add(onePair);
                }
                else if (flush)
                {
                    player.HandRanking = HandRanking.Flush;
                    player.HandKickers.AddRange(player.CardsAtHand
                        .Select(card => (int)card.Value).Reverse());
                }
                else if (straight)
                {
                    player.HandRanking = HandRanking.Straight;
                    player.HandKickers.AddRange(player.CardsAtHand
                        .Select(card => (int)card.Value).Reverse());
                }
                else if (threeOfAkind >= 0)
                {
                    player.HandRanking = HandRanking.ThreeOfAKind;
                    player.HandKickers.Add(threeOfAkind);
                    player.HandKickers.AddRange(player.CardsAtHand
                        .Where(card => (int)card.Value != threeOfAkind)
                        .Select(card => (int)card.Value));

                }
                else if(twoPair >= 0)
                {
                    player.HandRanking = HandRanking.TwoPair;
                    player.HandKickers.Add(Math.Max(twoPair, onePair));
                    player.HandKickers.Add(Math.Min(twoPair, onePair));
                    player.HandKickers.AddRange(player.CardsAtHand
                        .Where(card => (int)card.Value != twoPair && (int)card.Value != onePair)
                        .Select(card => (int)card.Value));

                }
                else if (onePair >= 0)
                {
                    player.HandRanking = HandRanking.OnePair;
                    player.HandKickers.Add(onePair);
                    player.HandKickers.AddRange(player.CardsAtHand
                        .Where(card => (int)card.Value != onePair)
                        .Select(card => (int)card.Value));
                }
                else
                {
                    player.HandRanking = HandRanking.HighCard;
                    player.HandKickers.AddRange(player.CardsAtHand
                        .Select(card => (int)card.Value).Reverse());
                }
            }
            else
            {
                throw new ArgumentException("Invalid card at hand");
            }

        }

        public bool CheckIfStraight(int valueProduct)
        {
            bool isStraight = false;

            // Calculation was based on the values respective prime numbers
            if (valueProduct == 2310 // 2 3 4 5 6 Combination
                || valueProduct == 15015 // 3 4 5 6 7 Combination
                || valueProduct == 85085  // 4 5 6 7 8 Combination
                || valueProduct == 323323 // 5 6 7 8 9 Combination
                || valueProduct == 1062347 // 6 7 8 9 10 Combination
                || valueProduct == 2800733 // 7 8 9 10 J Combination 
                || valueProduct == 6678671 // 8 9 10 J Q Combination 
                || valueProduct == 14535931 // 9 10 J Q K Combination 
                || valueProduct == 31367009) // 10 J Q K A Combination 
            {
                isStraight =  true;
            }

            return isStraight;

        }

        public bool CheckIfFlush(int suitProduct)
        {
            bool isFlush = false;

            // Calculation was based on the values respective prime numbers
            if (suitProduct == 147008443 // HEARTS 
                || suitProduct == 229345007 // SPADES
                || suitProduct == 418195493  // DIAMONDS
                || suitProduct == 714924299) // CLUBS
            {
                isFlush = true;
            }

            return isFlush;

        }

        public int EvaluateHands(Player player1, Player player2)
        {
            // 1 means player 1 wins, 2 means player 2 wins and 0 means draw (both are winners).
            int result = 0;

            // Check the ranking first
            if (player1.HandRanking > player2.HandRanking) result = 1;
            else if (player1.HandRanking < player2.HandRanking) result = 2;
            else
            {
                // if same ranking, evaluate each cards and kickers
                // Sort the kickers descending order to get the highest first
                player1.HandKickers = player1.HandKickers.OrderByDescending(kicker => kicker).ToList();
                player2.HandKickers = player2.HandKickers.OrderByDescending(kicker => kicker).ToList();

                for (int i = 0; i < player1.HandKickers.Count; i++)
                {
                    // Compare each kicker
                    if (player1.HandKickers[i] > player2.HandKickers[i]) result = 1;
                    else if (player1.HandKickers[i] < player2.HandKickers[i]) result = 2;

                    if (result > 0) break ;

                }
            }
            return result;
        }

    }
}

