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
                Console.Clear();
                Console.WriteLine("=== CONNECT FOUR ===");
                Console.WriteLine("1. Human vs Human");
                Console.WriteLine("2. Human vs Computer");
                Console.Write("Choose option: ");

                int mode;
                while (!int.TryParse(Console.ReadLine(), out mode) || (mode != 1 && mode != 2))
                {
                    Console.Write("Invalid choice. Enter 1 or 2: ");
                }

                SetupPlayers(mode);

                board.Initialize();
                currentPlayer = player1;
                bool gameOver = false;

                while (!gameOver)
                {
                    Console.Clear();
                    board.PrintBoard();
                    Console.WriteLine($"Player {currentPlayer.Symbol}'s turn");

                    int col;
                    //do
                    //{
                    //    col = currentPlayer.GetMove();
                    //} while (!board.DropDisc(col, currentPlayer.Symbol));

                    bool validMove = false;

                    do
                    {
                        col = currentPlayer.GetMove();
                        validMove = board.DropDisc(col, currentPlayer.Symbol);

                        if (!validMove)
                        {
                            Console.WriteLine("Column full or invalid. Try again.");
                            System.Threading.Thread.Sleep(1000);
                        }

                    } while (!validMove);

                    if (board.CheckWin(currentPlayer.Symbol))
                    {
                        Console.Clear();
                        board.PrintBoard();
                        Console.WriteLine($"Player {currentPlayer.Symbol} Wins!");
                        gameOver = true;
                    }
                    else if (board.IsFull())
                    {
                        Console.Clear();
                        board.PrintBoard();
                        Console.WriteLine("It's a DRAW!");
                        gameOver = true;
                    }
                    else
                    {
                        SwitchPlayer();
                    }
                }

                Console.Write("Restart? Yes(1) No(0): ");
                int choice;
                int.TryParse(Console.ReadLine(), out choice);
                if (choice == 0)
                    playing = false;
            }
        }

        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == player1) ? player2 : player1;
        }

        private void SetupPlayers(int mode)
        {
            player1 = new HumanPlayer('X');

            if (mode == 1)
                player2 = new HumanPlayer('O');
            else
                player2 = new ComputerPlayer('O');
        }
    }
}
