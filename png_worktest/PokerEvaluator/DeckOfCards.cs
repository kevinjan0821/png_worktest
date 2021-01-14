using System;
using System.Collections.Generic;
using System.Text;

namespace PokerEvaluator
{
    public class DeckOfCards: Card
    {

        const int NUM_OF_CARDS = 52; // Count of all cards
        private Card[] deck;

        public DeckOfCards()
        {
            deck = new Card[NUM_OF_CARDS];
        }

        public Card[] getDeck { get { return deck;  } } // get current deck

        public void GenerateDeck()
        {
            // Create Deck
            int i = 0;
            foreach(SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach(VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new Card { Suit = s, Value = v };
                    i++;
                }
            }

            ShuffleDeck();
        }

        public void ShuffleDeck()
        {
            // Shuffle Deck
            Random rand = new Random();
            Card temp;

            // Shuffle it 52 times
            for (int shuffle  = 0; shuffle < NUM_OF_CARDS; shuffle++)
            {
                for (int  i = 0; i < NUM_OF_CARDS; i++)
                {
                    // Swap card values
                    int k = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[k];
                    deck[k] = temp;
                }
            }


        }
    }
}
