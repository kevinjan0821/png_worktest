using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerEvaluator.UnitTest
{
    [TestClass]
    public class AutomatedTest
    {
        [TestMethod]
        public void CompareCardsAtHand_TwoRoyalFlushOneStraight_TwoWinners()
        {
            // Arrange
            EvaluateWinners Evaluate = new EvaluateWinners();
            List<Player> players = new List<Player>();
            Card card = new Card();

            // Player_1
            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TEN });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.JACK });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.QUEEN });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.KING });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.ACE });

            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TEN });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.JACK });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.QUEEN });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.KING });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.ACE });

            Player player3 = new Player();
            player3.PlayerName = "Player_3";
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TWO });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.THREE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FIVE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SIX });

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);


            // Act
            var winners = Evaluate.CompareCardsAtHand(players);

            // Assert
            Assert.AreEqual(2, winners.Count); // 2 Winners
            Assert.AreEqual(player1.PlayerName, winners[0].PlayerName, "PlayerName");
            Assert.AreEqual(HandRanking.RoyalFlush, winners[0].HandRanking, "PokerHandRanking");
            Assert.AreEqual(player2.PlayerName, winners[1].PlayerName, "PlayerName");
            Assert.AreEqual(HandRanking.RoyalFlush, winners[1].HandRanking, "PokerHandRanking");
        }

        [TestMethod]
        public void CompareCardsAtHand_TwoStraightFlushOneFourOfAKind_StraightFlushWithHigherCardValueWin()
        {
            // Arrange
            EvaluateWinners Evaluate = new EvaluateWinners();
            List<Player> players = new List<Player>();
            Card card = new Card();

            // Player_1
            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.THREE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FIVE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });

            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.EIGHT });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.NINE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TEN });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.JACK });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.QUEEN });

            Player player3 = new Player();
            player3.PlayerName = "Player_3";
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SEVEN });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.SEVEN });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SEVEN });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.SEVEN });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SIX });

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            // Act
            var winners = Evaluate.CompareCardsAtHand(players);

            // Assert
            Assert.AreEqual(winners.Count, 1); // 1 Winners
            foreach (Player winner in winners)
            {
                Assert.AreEqual(player2.PlayerName, winner.PlayerName, "PlayerName");
                Assert.AreEqual(HandRanking.StraightFlush, winner.HandRanking, "Higher Straight Flush");
            }

        }

        [TestMethod]
        public void CompareCardsAtHand_FourOfAKindFullHouseFlush_FourOfAKindWin()
        {
            // Arrange
            EvaluateWinners Evaluate = new EvaluateWinners();
            List<Player> players = new List<Player>();
            Card card = new Card();

            // Player_3
            Player player3 = new Player();
            player3.PlayerName = "Player_3";
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TWO });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.TWO });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.TWO });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });

            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.EIGHT });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.EIGHT });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.EIGHT });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.QUEEN });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.QUEEN });

            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.THREE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.FOUR });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.KING });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.JACK });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SEVEN });

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            // Act
            var winners = Evaluate.CompareCardsAtHand(players);

            // Assert
            Assert.AreEqual(1, winners.Count); // 1 Winners
            foreach (Player winner in winners)
            {
                Assert.AreEqual(player3.PlayerName, winner.PlayerName, "PlayerName");
                Assert.AreEqual(HandRanking.FourOfAKind, winner.HandRanking, "IsFourOfAKind");
            }

        }

        [TestMethod]
        public void CompareCardsAtHand_FullHouseFlushStraight_FullHouseWin()
        {
            // Arrange
            EvaluateWinners Evaluate = new EvaluateWinners();
            List<Player> players = new List<Player>();
            Card card = new Card();

            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.THREE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FIVE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.EIGHT });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.NINE });

            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.JACK });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.JACK });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.JACK });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.QUEEN });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.QUEEN });

            Player player3 = new Player();
            player3.PlayerName = "Player_3";
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TWO });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.THREE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FIVE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SIX });

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            // Act
            var winners = Evaluate.CompareCardsAtHand(players);

            // Assert
            Assert.AreEqual(winners.Count, 1); // 1 Winner
            foreach (Player winner in winners)
            {
                Assert.AreEqual(player2.PlayerName, winner.PlayerName, "PlayerName");
                Assert.AreEqual(HandRanking.FullHouse, winner.HandRanking, "IsFullHouse");
            }

        }

        [TestMethod]
        public void CompareCardsAtHand_FlushStraightThreeOfAKind_FlushWin()
        {
            // Arrange
            EvaluateWinners Evaluate = new EvaluateWinners();
            List<Player> players = new List<Player>();
            Card card = new Card();

            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.THREE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FIVE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.EIGHT });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.NINE });

            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.JACK });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.JACK });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.JACK });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.KING });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.QUEEN });

            Player player3 = new Player();
            player3.PlayerName = "Player_3";
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TWO });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.THREE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FIVE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SIX });

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            // Act
            var winners = Evaluate.CompareCardsAtHand(players);

            // Assert
            Assert.AreEqual(winners.Count, 1); // 1 Winner
            foreach (Player winner in winners)
            {
                Assert.AreEqual(player1.PlayerName, winner.PlayerName, "PlayerName");
                Assert.AreEqual(HandRanking.Flush, winner.HandRanking, "IsFlush");
            }
        }

        [TestMethod]
        public void CompareCardsAtHand_TwoStraightThreeOfAKind_TwoStraightWinners()
        {
            // Arrange
            EvaluateWinners Evaluate = new EvaluateWinners();
            List<Player> players = new List<Player>();
            Card card = new Card();

            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.THREE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FOUR });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.FIVE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });

            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.ACE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.ACE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.ACE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.KING });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.SEVEN });

            Player player3 = new Player();
            player3.PlayerName = "Player_3";
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TWO });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.THREE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FIVE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SIX });

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            // Act
            var winners = Evaluate.CompareCardsAtHand(players);

            // Assert
            Assert.AreEqual(winners.Count, 2); // 2 Winners
            Assert.AreEqual(player1.PlayerName, winners[0].PlayerName, "PlayerName");
            Assert.AreEqual(HandRanking.Straight, winners[0].HandRanking, "PokerHandRanking Straight");
            Assert.AreEqual(player3.PlayerName, winners[1].PlayerName, "PlayerName");
            Assert.AreEqual(HandRanking.Straight, winners[1].HandRanking, "PokerHandRanking Straight");
        }

        [TestMethod]
        public void CompareCardsAtHand_ThreeOfAKindTwoPairOnePair_ThreeOfAKindWin()
        {
            // Arrange
            EvaluateWinners Evaluate = new EvaluateWinners();
            List<Player> players = new List<Player>();
            Card card = new Card();

            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.FIVE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });

            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.QUEEN });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.QUEEN });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.KING });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.KING });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.SEVEN });

            Player player3 = new Player();
            player3.PlayerName = "Player_3";
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.ACE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.ACE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FIVE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SIX });

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            // Act
            var winners = Evaluate.CompareCardsAtHand(players);

            // Assert
            Assert.AreEqual(winners.Count, 1); // 1 Winners
            foreach (Player winner in winners)
            {
                Assert.AreEqual(player1.PlayerName, winner.PlayerName, "PlayerName");
                Assert.AreEqual(HandRanking.ThreeOfAKind, winner.HandRanking, "Three of a kind");
            }
        }

        [TestMethod]
        public void CompareCardsAtHand_TwoTwoPairOnePair_HigherTwoPairWin()
        {
            // Arrange
            EvaluateWinners Evaluate = new EvaluateWinners();
            List<Player> players = new List<Player>();
            Card card = new Card();

            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FIVE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.FIVE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });

            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.QUEEN });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.QUEEN });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.KING });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.KING });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.SEVEN });

            Player player3 = new Player();
            player3.PlayerName = "Player_3";
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.JACK });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.JACK });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FIVE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SIX });

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            // Act
            var winners = Evaluate.CompareCardsAtHand(players);

            // Assert
            Assert.AreEqual(winners.Count, 1); // 1 Winners
            foreach (Player winner in winners)
            {
                Assert.AreEqual(player2.PlayerName, winner.PlayerName, "PlayerName");
                Assert.AreEqual(HandRanking.TwoPair, winner.HandRanking, "Two Pair");
            }
        }

        [TestMethod]
        public void CompareCardsAtHand_TwoOnepairAndHighCard_HigherOnePairWin()
        {
            // Arrange
            EvaluateWinners Evaluate = new EvaluateWinners();
            List<Player> players = new List<Player>();
            Card card = new Card();

            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TEN });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TEN });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FIVE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.SIX });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.EIGHT });

            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TWO });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.ACE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FOUR });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.NINE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.QUEEN });

            Player player3 = new Player();
            player3.PlayerName = "Player_3";
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.JACK });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.JACK });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FIVE });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SIX });

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            // Act
            var winners = Evaluate.CompareCardsAtHand(players);

            // Assert
            Assert.AreEqual(winners.Count, 1); // 1 Winners
            foreach (Player winner in winners)
            {
                Assert.AreEqual(player3.PlayerName, winner.PlayerName, "PlayerName");
                Assert.AreEqual(HandRanking.OnePair, winner.HandRanking, "One Pair");
            }
        }

        [TestMethod]
        public void CompareCardsAtHand_AllHighCards_HighestHigCardWin()
        {
            // Arrange
            EvaluateWinners Evaluate = new EvaluateWinners();
            List<Player> players = new List<Player>();
            Card card = new Card();

            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.FOUR });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.SIX });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.EIGHT });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.ACE });

            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.THREE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FIVE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.JACK });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.QUEEN });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.KING });

            Player player3 = new Player();
            player3.PlayerName = "Player_3";
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.TEN });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.TWO });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.EIGHT });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.QUEEN });
            player3.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.JACK });

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            // Act
            var winners = Evaluate.CompareCardsAtHand(players);

            // Assert
            Assert.AreEqual(winners.Count, 1); // 1 Winners
            foreach (Player winner in winners)
            {
                Assert.AreEqual(player1.PlayerName, winner.PlayerName, "PlayerName");
                Assert.AreEqual(HandRanking.HighCard, winner.HandRanking, "One Pair");
            }
        }
        // RANDOM CARDS
        [TestMethod]
        public void CompareCardsAtHand_RandomCardGenerator_ThereWillBeWinner()
        {
            // Arrange
            EvaluateWinners Evaluate = new EvaluateWinners();
            Hand hand = new Hand();
            List<Player> players = new List<Player>();

            hand.GenerateDeck();

            // Player_1
            Player player1 = new Player();
            player1.PlayerName = "Player_1";

            // Player_2
            Player player2 = new Player();
            player1.PlayerName = "Player_2";

            // Player_3
            Player player3 = new Player();
            player3.PlayerName = "Player_3";

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);


            hand.GetHand(players);

            // Act
            var winners = Evaluate.CompareCardsAtHand(players);

            // Assert
            Assert.IsNotNull(winners);
            Assert.AreNotEqual(0, winners.Count);
        }
    }
}
