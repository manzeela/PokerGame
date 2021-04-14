using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class DealCards : DeckOfCards
    {
        private Card[][] Hands = new Card[4][];
        private Card[][] SortedHand= new Card[4][];
        // define the hand of four players
        private Card[] firstHand, secondHand, thirdHand, fourthHand;
        // define the sorted hand for four players
        private Card[] sortedFirstHand, sortedSecondHand, sortedThirdHand, sortedFourthHand;
        public DealCards()
        {
          for(int i = 0; i < 4; i++)
            {
                Hands[i] = new Card[5];
                SortedHand[i] = new Card[5];
            }

        }


        //public DealCards() {
        //    firstHand = new Card[5];
        //    secondHand = new Card[5];
        //    thirdHand = new Card[5];
        //    fourthHand = new Card[5];
        //    sortedFirstHand = new Card[5];
        //    sortedSecondHand = new Card[5];
        //    sortedThirdHand = new Card[5];
        //    sortedFourthHand = new Card[5];

        //}

        public void deal() {
            setDeck(); //create the deck of cards
            shuffleCards(); //shuffle the cards
            getHand(); // get four hands - one for each player
            sortCards(); //sort the cards in each hand
            displayCards(); // display the cards in each hand
            evaluateHands(); //evaluate the cards in each hand and determine winner
        }
        public void getHand()
        {

            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0;  j < 5; j++)
                {
                    Hands[i][j] = getDeck[k];
                    k ++;
                }

            }
           
        }


        //public void getHand()
        //{
        //    //5 unique cards for first hand
        //    for (int i = 0; i < 5; i++) {
        //        firstHand[i] = getDeck[i];
        //    }

        //    //5 unique cards for second hand
        //    for (int i = 5; i < 10; i++)
        //    {
        //        secondHand[i-5] = getDeck[i];
        //    }

        //    //5 unique cards for third hand
        //    for (int i = 10; i < 15; i++)
        //    {
        //        thirdHand[i-10] = getDeck[i];
        //    }

        //    //5 unique cards for fourth hand
        //    for (int i = 15; i < 20; i++)
        //    {
        //        fourthHand[i-15] = getDeck[i];
        //    }
        //}

        public void sortCards()
        {

            for (int i = 0; i < 4; i++)
            {
                var query = Hands[i].OrderBy(hand => hand.cFace);
                for (int j = 0; j < query.ToList().Count; j++)
                {
                    SortedHand[i][j] = (query.ToList())[j];
                }
            }

        }

        private void displayCards()
        {
            for(int i = 0; i < 4; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(i.ToString() +" hand" );
                Console.ResetColor();
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine(SortedHand[i][j].cFace + " of " + SortedHand[i][j].cSuit);
                }

            }
            
        }

        public void evaluateHands() {
            //create player's and computer's evaluation objects by passing sortedhand for each player to constructor
            EvaluateHands firstHandEvaluator = new EvaluateHands(SortedHand[0]);
            EvaluateHands secondhandEvaluator = new EvaluateHands(SortedHand[1]);
            EvaluateHands thirdHandEvaluator = new EvaluateHands(SortedHand[2]);
            EvaluateHands fourthHandEvaluator = new EvaluateHands(SortedHand[3]);

            //get evaluated hand for all players

            hand firstHand = firstHandEvaluator.evaluateHand();
            hand secondHand = secondhandEvaluator.evaluateHand();
            hand thirdHand = thirdHandEvaluator.evaluateHand();
            hand fourthHand = fourthHandEvaluator.evaluateHand();



            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\nResult: ");
            Console.ResetColor();


            //display each hands
            Console.WriteLine("\nfirst Hand: " + firstHand);
            Console.WriteLine("\nsecond Hand: " + secondHand);
            Console.WriteLine("\nthird Hand: " + thirdHand);
            Console.WriteLine("\nfourth Hand: " + fourthHand);

            Console.ForegroundColor = ConsoleColor.Green;
            //evaluate who has higher hands and higher hand wins
            if (firstHand > secondHand && firstHand > thirdHand && firstHand > fourthHand)
            {
                Console.WriteLine("First Hand wins!");
            }
            else if (secondHand > firstHand && secondHand > thirdHand && secondHand > fourthHand)
            {
                Console.WriteLine("Second Hand wins!");
            }
            else if (thirdHand > secondHand && thirdHand > firstHand && thirdHand > fourthHand)
            {
                Console.WriteLine("Third Hand wins!");
            }
            else if (fourthHand > secondHand && fourthHand > firstHand && fourthHand > thirdHand)
            {
                Console.WriteLine("Fourth Hand wins!");
            }
            else // if the hands are same evaluate values
            {
                //highest value of poker hand if not check for highest card and highest card wins
                if (firstHandEvaluator.handValues.total > secondhandEvaluator.handValues.total &&
                    firstHandEvaluator.handValues.total > thirdHandEvaluator.handValues.total &&
                    firstHandEvaluator.handValues.total > fourthHandEvaluator.handValues.total)
                {
                    Console.WriteLine("First Hand Wins");
                }
                else if (secondhandEvaluator.handValues.total > firstHandEvaluator.handValues.total &&
                    secondhandEvaluator.handValues.total > thirdHandEvaluator.handValues.total &&
                    secondhandEvaluator.handValues.total > fourthHandEvaluator.handValues.total)
                {
                    Console.WriteLine("Second Hand Wins");
                }
                else if (thirdHandEvaluator.handValues.total > secondhandEvaluator.handValues.total &&
                    thirdHandEvaluator.handValues.total > firstHandEvaluator.handValues.total &&
                    thirdHandEvaluator.handValues.total > fourthHandEvaluator.handValues.total)
                {
                    Console.WriteLine("Third Hand Wins");
                }
                else if (fourthHandEvaluator.handValues.total > secondhandEvaluator.handValues.total &&
                    fourthHandEvaluator.handValues.total > thirdHandEvaluator.handValues.total &&
                    fourthHandEvaluator.handValues.total > firstHandEvaluator.handValues.total)
                {
                    Console.WriteLine("Fourth Hand Wins");
                }
                else if (firstHandEvaluator.handValues.highCard > secondhandEvaluator.handValues.highCard &&
                   firstHandEvaluator.handValues.highCard > thirdHandEvaluator.handValues.highCard &&
                   firstHandEvaluator.handValues.highCard > fourthHandEvaluator.handValues.highCard)
                {
                    Console.WriteLine("First Hand Wins");
                }
                else if (secondhandEvaluator.handValues.highCard > firstHandEvaluator.handValues.highCard &&
                  secondhandEvaluator.handValues.highCard > thirdHandEvaluator.handValues.highCard &&
                  secondhandEvaluator.handValues.highCard > fourthHandEvaluator.handValues.highCard)
                {
                    Console.WriteLine("Second Hand Wins");
                }
                else if (thirdHandEvaluator.handValues.highCard > secondhandEvaluator.handValues.highCard &&
                  thirdHandEvaluator.handValues.highCard > firstHandEvaluator.handValues.highCard &&
                  thirdHandEvaluator.handValues.highCard > fourthHandEvaluator.handValues.highCard)
                {
                    Console.WriteLine("Third Hand Wins");
                }
                else if (fourthHandEvaluator.handValues.highCard > secondhandEvaluator.handValues.highCard &&
                  fourthHandEvaluator.handValues.highCard > thirdHandEvaluator.handValues.highCard &&
                  fourthHandEvaluator.handValues.highCard > firstHandEvaluator.handValues.highCard)
                {
                    Console.WriteLine("Fourth Hand Wins");
                }
                else
                {
                    Console.WriteLine("Draw, No one wins!");
                }
            }

            Console.ResetColor();
            Console.WriteLine();


        }
    }
}
