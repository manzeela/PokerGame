using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Card
    {
        public enum suit
        {Clubs, Diamonds, Hearts,
            Spades};
        public enum face
        {Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King};

        //proporties of cards
        public suit cSuit { get; set; }
        public face cFace { get; set; }
    }
}
