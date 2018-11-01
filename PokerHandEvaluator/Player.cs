using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator
{
    public class Player
    {
        public string Name { get; set; }
        public PokerHand Hand { get; set; }
        public HandType HandType { get; set; }
    }
}
