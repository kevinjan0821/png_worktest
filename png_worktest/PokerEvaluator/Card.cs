using System;
using System.Collections.Generic;
using System.Text;


namespace PokerEvaluator
{
    public enum SUIT
    {
        HEARTS,
        SPADES,
        DIAMONDS,
        CLUBS
    }

    public enum VALUE
    {
        TWO, THREE, FOUR, FIVE, SIX, SEVEN,
        EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
    }

    public class Card
    {
        public VALUE Value { get; set; }
        public SUIT Suit { get; set; }

        // Array of prime numbers that will represent each card value
        private static int[] primeValue = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41 };
        private static int[] primeSuit = new int[] { 43, 47, 53, 59 }; 

        public int valueProduct { get { return primeValue[(int)Value]; } }
        public int suitProduct { get { return primeSuit[(int)Suit]; } }

    }


}
