using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourOOP
{
    using System;

    class ComputerPlayer : Player
    {
        private Random rand = new Random();

        public ComputerPlayer(char symbol) : base(symbol) { }

        public override int GetMove()
        {
            int col;

            do
            {
                col = rand.Next(0, 7);
            } while (!IsValidColumn(col));

            Console.WriteLine($"Computer chooses column {col + 1}");
            return col;
        }

        private bool IsValidColumn(int col)
        {
            return col >= 0 && col < 7;
        }
    }
}
