using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourOOP
{
    abstract class Player
    {
        public char Symbol { get; set; }

        public Player(char symbol)
        {
            Symbol = symbol;
        }

        public abstract int GetMove();
    }
}
