using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourOOP
{
    using System;

    class Board
    {
        private char[,] grid = new char[6, 7];

        public Board()
        {
            Initialize();
        }

        public void Initialize()
        {
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 7; c++)
                    grid[r, c] = '#';
        }

        public bool DropDisc(int col, char symbol)
        {
            if (col < 0 || col >= 7) return false;

            for (int r = 5; r >= 0; r--)
            {
                if (grid[r, col] == '#')
                {
                    grid[r, col] = symbol;
                    return true;
                }
            }
            return false;
        }

        public void PrintBoard()
        {
            for (int r = 0; r < 6; r++)
            {
                Console.Write("| ");
                for (int c = 0; c < 7; c++)
                {
                    Console.Write(grid[r, c] + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(" 1 2 3 4 5 6 7");
        }

        public bool CheckWin(char symbol)
        {
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 4; c++)
                    if (grid[r, c] == symbol &&
                        grid[r, c + 1] == symbol &&
                        grid[r, c + 2] == symbol &&
                        grid[r, c + 3] == symbol)
                        return true;

            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 7; c++)
                    if (grid[r, c] == symbol &&
                        grid[r + 1, c] == symbol &&
                        grid[r + 2, c] == symbol &&
                        grid[r + 3, c] == symbol)
                        return true;

            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 4; c++)
                    if (grid[r, c] == symbol &&
                        grid[r + 1, c + 1] == symbol &&
                        grid[r + 2, c + 2] == symbol &&
                        grid[r + 3, c + 3] == symbol)
                        return true;

            for (int r = 3; r < 6; r++)
                for (int c = 0; c < 4; c++)
                    if (grid[r, c] == symbol &&
                        grid[r - 1, c + 1] == symbol &&
                        grid[r - 2, c + 2] == symbol &&
                        grid[r - 3, c + 3] == symbol)
                        return true;

            return false;
        }
        public bool IsFull()
        {
            for (int c = 0; c < 7; c++)
            {
                if (grid[0, c] == '#')
                    return false;
            }
            return true;
        }
    }
}
