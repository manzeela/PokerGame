using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    //types of hand
    public enum hand { 
        Nothing, OnePair, TwoPairs, ThreeKind, Straight, Flush, FullHouse, FourKind
    }

    public struct handValue { 
        public int total { get; set; }
        public int highCard { get; set; }
    }
    class EvaluateHands : Card
    {
        private int heartSum;
        private int diamondSum;
        private int clubSum;
        private int spadeSum;
        public Card[] cards;
        private handValue handValue;

        public EvaluateHands(Card[] sortedHand) {
            heartSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadeSum = 0;
            cards = new Card[5];
            Cards = sortedHand;
            handValue = new handValue();
        }

        public handValue handValues {
            get { return handValue; }
            set { handValue = value; }
        }

        public Card[] Cards {
            get { return cards; }
            set {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
        }

        public hand evaluateHand() {
            //get number of suits on hand
            numOfSuits();
            if (fourOfKind())
                return hand.FourKind;
            else if (fullHouse())
                return hand.FullHouse;
            else if (flush())
                return hand.Flush;
            else if (straight())
                return hand.Straight;
            else if (threeofKind())
                return hand.ThreeKind;
            else if (twoPairs())
                return hand.TwoPairs;
            else if (onePair())
                return hand.OnePair;
            else
            {
                handValue.highCard = (int)cards[4].cFace;
                return hand.Nothing;
            }
               
        }

        private void numOfSuits() {
            foreach (var element in Cards) {
                if (element.cSuit == Card.suit.Hearts)
                    heartSum++;
                if (element.cSuit == Card.suit.Diamonds)
                    diamondSum++;
                if (element.cSuit == Card.suit.Spades)
                    spadeSum++;
                if (element.cSuit == Card.suit.Clubs)
                    clubSum++;
            }
        }

        private bool fourOfKind() {
            //if the first four cards are same, add value of four cards as total and the last card is highest
            if (cards[0].cFace == cards[1].cFace && cards[0].cFace == cards[2].cFace && cards[0].cFace == cards[3].cFace)
            {
                handValue.total = (int)cards[1].cFace * 4;
                handValue.highCard = (int)cards[4].cFace;
                return true;
            }

            else if (cards[1].cFace == cards[2].cFace && cards[1].cFace == cards[3].cFace && cards[1].cFace == cards[4].cFace)
            {
                handValue.total = (int)cards[1].cFace * 4;
                handValue.highCard = (int)cards[0].cFace;
                return true;
            }
            else
                return false;

        }

        private bool fullHouse() {
            // the first three cards are same and the last two are same or
            // the last three cards are same and the first two are same
            if ((cards[0].cFace == cards[1].cFace && cards[0].cFace == cards[2].cFace && cards[3].cFace == cards[4].cFace) ||
                (cards[0].cFace == cards[1].cFace && cards[2].cFace == cards[3].cFace && cards[2].cFace == cards[4].cFace))
            {
                handValue.total = (int)(cards[0].cFace) + (int)(cards[1].cFace) + (int)(cards[2].cFace) + (int)(cards[3].cFace) + (int)(cards[4].cFace);
                return true;
            }

            else
                return false;
 
        }

        private bool flush() {
            //if all suits are same
            if (heartSum == 5 || diamondSum == 5 || clubSum == 5 || spadeSum == 5)
            {
                //if flush, the player with higher card wins
                handValue.total = (int)(cards[4].cFace);
                return true;
            }
            else
                return false;
        }

        private bool straight() {
            //if 5 cards have consecutive value
            if (cards[0].cFace + 1 == cards[1].cFace &&
                cards[1].cFace + 1 == cards[2].cFace &&
                cards[2].cFace + 1 == cards[3].cFace &&
                cards[3].cFace + 1 == cards[4].cFace + 1)
            {
                //player with highest value of the last card wins
                handValue.total = (int)cards[4].cFace;
                return true;
            }

            else
                return false;
        }

        private bool threeofKind() {
            //if 1,2,3 cards are same or 2,3,4 cards are same or 3,4,5 cards are same
            if ((cards[0].cFace == cards[1].cFace && cards[0].cFace == cards[2].cFace) ||
                (cards[1].cFace == cards[2].cFace && cards[1].cFace == cards[3].cFace))
            {
                handValue.total = (int)cards[2].cFace * 3;
                handValue.highCard = (int)cards[4].cFace;
                return true;
            }
            else if (cards[2].cFace == cards[3].cFace && cards[2].cFace == cards[4].cFace)
            {
                handValue.total = (int)cards[2].cFace * 3;
                handValue.highCard = (int)cards[1].cFace;
                return true;
            }
            else
                return false;
        }

        private bool twoPairs() {
            // if cards at position 1,2 and 3,4 are same
            //if cards at position 1,2 and 4,5 are same
            //if cards at position 2,3 and 4,5 are same

            if (cards[0].cFace == cards[1].cFace && cards[2].cFace == cards[3].cFace)
            {
                handValue.total = ((int)cards[1].cFace * 2) + ((int)cards[3].cFace * 2);
                handValue.highCard = (int)cards[4].cFace;
                return true;
            }
            else if (cards[0].cFace == cards[1].cFace && cards[3].cFace == cards[4].cFace)
            {
                handValue.total = ((int)cards[1].cFace * 2) + ((int)cards[3].cFace * 2);
                handValue.highCard = (int)cards[2].cFace;
                return true;
            }
            else if (cards[1].cFace == cards[2].cFace && cards[3].cFace == cards[4].cFace)
            {
                handValue.total = ((int)cards[1].cFace * 2) + ((int)cards[3].cFace * 2);
                handValue.highCard = (int)cards[0].cFace;
                return true;
            }
            else
                return false;
        }

        private bool onePair() {
            //if cards at position 1 & 2 are same
            //if cards at position 2 & 3 are same
            //if cards at position 3 & 4 are same
            //if cards at position 4 & 5 are same

            if (cards[0].cFace == cards[1].cFace)
            {
                handValue.total = (int)cards[0].cFace * 2;
                handValue.highCard = (int)cards[4].cFace;
                return true;
            }
            else if (cards[1].cFace == cards[2].cFace)
            {
                handValue.total = (int)cards[1].cFace * 2;
                handValue.highCard = (int)cards[4].cFace;
                return true;
            }
            else if (cards[2].cFace == cards[3].cFace)
            {
                handValue.total = (int)cards[2].cFace * 2;
                handValue.highCard = (int)cards[4].cFace;
                return true;
            }
            else if (cards[3].cFace == cards[4].cFace)
            {
                handValue.total = (int)cards[3].cFace * 2;
                handValue.highCard = (int)cards[2].cFace;
                return true;
            }
            else
                return false;

        }

    }
}
