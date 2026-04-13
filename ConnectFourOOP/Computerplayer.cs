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
            return rand.Next(0, 7);
        }
    }
}
