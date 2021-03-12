using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            DealCards dc = new DealCards();
            bool play = true;
            while (play) {
                dc.deal();
                char select = ' ';
                while (select != 'Y' && select != 'N') 
                {
                    Console.WriteLine("Would you like to play again? If yes press 'Y' else press 'N'.");
                    select = Convert.ToChar(Console.ReadLine().ToUpper());

                    if (select.Equals('Y'))
                        play = true;
                    else if (select.Equals('N'))
                        play = false;
                    else
                        Console.WriteLine("Invalid selection. Try again. \n");
                }
                
            }
            Console.WriteLine("Thank you for playing. Press any key to exit.");
            Console.ReadLine();

        }
    }
}
