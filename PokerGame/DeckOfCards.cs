using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class DeckOfCards : Card
    {
        
        private Card[] deck; //array of cards to store all cards i.e. 52 cards
        private const int numOfCards = 52; //number of cards in deck
        Random ran;

        public DeckOfCards() {
            deck = new Card[numOfCards];
        }

        //get current deck
        public Card[] getDeck
        {
            get { return deck; }
        }

        //create deck of cards with  4 suits and 13 faces to a total of 52 cards
        public void setDeck() {
            int i = 0;
            foreach(suit s in Enum.GetValues(typeof(suit))) {
                foreach (face f in Enum.GetValues(typeof(face))) {
                    deck[i] = new Card { cSuit = s , cFace = f };
                    i++;
                }
            }
        }

        //shuffle the deck of cards
        public void shuffleCards() {
            Card temp;
            ran = new Random();
            //run shuffle 10 times
            for (int shuffleTime = 0; shuffleTime < 10; shuffleTime++)
            {
                for (int i = 0; i < deck.Length; i++)
                {
                    //create random position for cards
                    int second = ran.Next(52);
                    //swap the cards to random position
                    temp = deck[i];
                    deck[i] = deck[second];
                    deck[second] = temp;
                }
            }
           
        }
        
    }
}
