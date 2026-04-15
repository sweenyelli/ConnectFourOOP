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
            Console.Write("Enter column (1-7): ");
            int col = int.Parse(Console.ReadLine());
            return col - 1;
        }
    }
}
