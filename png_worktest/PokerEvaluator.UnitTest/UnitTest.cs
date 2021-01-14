using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PokerEvaluator.UnitTest
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void GetHandRanking_RoyalFlush_HandRankingRoyalFlush()
        {
            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            Player player = new Player();
            player.PlayerName = "Player";
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.TEN });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.JACK });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.QUEEN });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.KING });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.ACE });

            // Act
            hand.GetHandRanking(player);

            // Assert
            Assert.AreEqual(HandRanking.RoyalFlush, player.HandRanking, "IsRoyalFlush");
        }

        [TestMethod]
        public void GetHandRanking_StraightFlush_HandRankingStraightFlush()
        {
            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            Player player = new Player();
            player.PlayerName = "Player";
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.TWO });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.THREE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.FOUR });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.FIVE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.SIX });

            // Act
            hand.GetHandRanking(player);

            // Assert
            Assert.AreEqual(HandRanking.StraightFlush, player.HandRanking, "IsStraightFlush");
        }

        [TestMethod]
        public void GetHandRanking_FourOfAKind_HandRankingFourOfAKind()
        {
            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            Player player = new Player();
            player.PlayerName = "Player";
            player.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SIX });
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.SIX });
            player.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.SIX });
            player.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SEVEN });

            // Act
            hand.GetHandRanking(player);

            // Assert
            Assert.AreEqual(HandRanking.FourOfAKind, player.HandRanking,"IsFourOfAKind");
        }

        [TestMethod]
        public void GetHandRanking_FullHouse_HandRankingFullHouse()
        {
            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            Player player = new Player();
            player.PlayerName = "Player";
            player.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SIX });
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.SIX });
            player.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.SEVEN });
            player.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.SEVEN });

            // Act
            hand.GetHandRanking(player);

            // Assert
            Assert.AreEqual(HandRanking.FullHouse, player.HandRanking, "IsFullHouse");
        }

        [TestMethod]
        public void GetHandRanking_Flush_HandRankingFlush()
        {
            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            Player player = new Player();
            player.PlayerName = "Player";
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.EIGHT });
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TEN });

            // Act
            hand.GetHandRanking(player);

            // Assert
            Assert.AreEqual(HandRanking.Flush, player.HandRanking,"IsFlush");
        }

        [TestMethod]
        public void GetHandRanking_Straight_HandRankingStraight()
        {
            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            Player player = new Player();
            player.PlayerName = "Player";
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.THREE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.FOUR });
            player.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FIVE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });

            // Act
            hand.GetHandRanking(player);

            // Assert
            Assert.AreEqual(HandRanking.Straight, player.HandRanking,"IsStraight");
        }

        [TestMethod]
        public void GetHandRanking_ThreeOfAKind_HandRankingThreeOfAKind()
        {
            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            Player player = new Player();
            player.PlayerName = "Player";
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.ACE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.ACE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.ACE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FIVE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });

            // Act
            hand.GetHandRanking(player);

            // Assert
            Assert.AreEqual(HandRanking.ThreeOfAKind, player.HandRanking,"IsThreeOfAKind");
        }

        [TestMethod]
        public void GetHandRanking_TwoPair_HandRankingTwoPair()
        {
            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            Player player = new Player();
            player.PlayerName = "Player";
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.ACE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.ACE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.KING });
            player.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.KING });
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.QUEEN });

            // Act
            hand.GetHandRanking(player);

            // Assert
            Assert.AreEqual(HandRanking.TwoPair, player.HandRanking,"IsTwoPair");
        }

        [TestMethod]
        public void GetHandRanking_OnePair_HandRankingOnePair()
        {
            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            Player player = new Player();
            player.PlayerName = "Player";
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.ACE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.ACE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.KING });
            player.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.JACK });
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.QUEEN });

            // Act
            hand.GetHandRanking(player);

            // Assert
            Assert.AreEqual(HandRanking.OnePair, player.HandRanking,"IsOnePair");
        }

        [TestMethod]
        public void GetHandRanking_HighCard_HandRankingHighCard()
        {
            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            Player player = new Player();
            player.PlayerName = "Player";
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.ACE });
            player.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.SEVEN });
            player.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.JACK });
            player.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.QUEEN });

            // Act
            hand.GetHandRanking(player);

            // Assert
            Assert.AreEqual(HandRanking.HighCard, player.HandRanking, "IsHighCard");
        }

        [TestMethod]
        public void EvaluateHands_TwoDifferentPokerCards_Player_1Win()
        {

            // Arrange
            Card card = new Card();
            Hand hand = new Hand();


            // ROYAL FLUSH
            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.TEN });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.JACK });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.QUEEN });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.KING });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.ACE });

            // STRAIGHT FLUSH
            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.THREE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FIVE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });

            // Act
            hand.GetHandRanking(player1);
            hand.GetHandRanking(player2);
            int result = hand.EvaluateHands(player1, player2);

            // Assert
            Assert.AreEqual(1, result, "Result - Player_1 Wins");
        }

        [TestMethod]
        public void EvaluateHands_SamepokerCardsDifferentValues_Player_2Win()
        {

            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            // FLUSH
            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.FOUR });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.SIX });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.EIGHT });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.NINE });

            // FLUSH
            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.EIGHT});
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TEN });

            // Act
            hand.GetHandRanking(player1);
            hand.GetHandRanking(player2);
            int result = hand.EvaluateHands(player1, player2);

            // Assert
            Assert.AreEqual(2, result, "Result - Player_2 Wins");
        }

        [TestMethod]
        public void EvaluateHands_SamepokerCardsSameValues_BothWinners()
        {

            // Arrange
            Card card = new Card();
            Hand hand = new Hand();

            Player player1 = new Player();
            player1.PlayerName = "Player_1";
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.TWO });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.THREE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.FOUR });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FIVE });
            player1.CardsAtHand.Add(new Card { Suit = SUIT.DIAMONDS, Value = VALUE.SIX });

            Player player2 = new Player();
            player2.PlayerName = "Player_2";
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.TWO });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.SPADES, Value = VALUE.THREE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.FOUR });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.HEARTS, Value = VALUE.FIVE });
            player2.CardsAtHand.Add(new Card { Suit = SUIT.CLUBS, Value = VALUE.SIX });

            // Act
            hand.GetHandRanking(player1);
            hand.GetHandRanking(player2);
            int result = hand.EvaluateHands(player1, player2);

            // Assert
            Assert.AreEqual(0, result, "Result - Both Winners");
        }

    }
}
