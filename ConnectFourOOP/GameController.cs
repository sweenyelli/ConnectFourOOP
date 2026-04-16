using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourOOP
{
    using System;

    class GameController
    {
        private Board board;
        private Player player1;
        private Player player2;
        private Player currentPlayer;

        public GameController()
        {
            board = new Board();
            player1 = new HumanPlayer('X');
            player2 = new HumanPlayer('O');
            currentPlayer = player1;
        }

        public void StartGame()
        {
            bool playing = true;

            while (playing)
            {
                board.Initialize();
                bool gameOver = false;

                while (!gameOver)
                {
                    Console.Clear();
                    board.PrintBoard();

                    Console.WriteLine($"Player {currentPlayer.Symbol}'s turn");

                    int col;
                    do
                    {
                        col = currentPlayer.GetMove();
                    } while (!board.DropDisc(col, currentPlayer.Symbol));

                    if (board.CheckWin(currentPlayer.Symbol))
                    {
                        Console.Clear();
                        board.PrintBoard();
                        Console.WriteLine($"Player {currentPlayer.Symbol} Wins!");
                        gameOver = true;
                    }
                    else
                    {
                        SwitchPlayer();
                    }
                }

                Console.Write("Restart? Yes(1) No(0): ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                    playing = false;
            }
        }

        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == player1) ? player2 : player1;
        }
    }
}
