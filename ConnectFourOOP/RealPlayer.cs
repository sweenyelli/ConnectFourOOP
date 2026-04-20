using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourOOP
{
    using System;

    class HumanPlayer : Player
    {
        public HumanPlayer(char symbol) : base(symbol) { }

        public override int GetMove()
        {
            int col;
            Console.Write("Enter column (1-7): ");

            while (!int.TryParse(Console.ReadLine(), out col) || col < 1 || col > 7)
            {
                Console.Write("Invalid input. Enter number (1-7): ");
            }

            return col - 1;
        }
    }
}
