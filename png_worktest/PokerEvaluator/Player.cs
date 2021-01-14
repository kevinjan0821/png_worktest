using System;
using System.Collections.Generic;
using System.Text;

namespace PokerEvaluator
{
    public class Player
    {
        public string PlayerName { get; set; }
        public List<Card> CardsAtHand { get; set; }
        public HandRanking HandRanking { get; set; }
        public List<int> HandKickers { get; set; }

        public Player()
        {
            PlayerName = "";
            CardsAtHand = new List<Card>();
            HandKickers = new List<int>();

        }

    }
}
