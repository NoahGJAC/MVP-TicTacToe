using TicTacToe;

namespace TicTacToeConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            ConsoleView cv = new ConsoleView();
            cv.Start();

            while (true)
            {
                Console.WriteLine("Player 1: X\nPlayer 2: O");
                Console.WriteLine("Input column: ");
                string col = Console.ReadLine();
                Console.WriteLine("Input row: ");
                string row = Console.ReadLine();
                cv.presenter.ProcessTurn(int.Parse(row), int.Parse(col));
                
              
            }
        }
    }
    class ConsoleView : ViewInterface
    {
        public readonly Presenter presenter;
        private char[,] _board;


        public ConsoleView()
        {
            presenter = new Presenter(this);
        }

        public void Start()
        {
            _board = new char[3, 3] {
            {' ',' ',' ' },
            {' ',' ',' ' },
            {' ',' ',' ' } 
            };
            Console.WriteLine("Welcome to Tic Tac Toe!");
            presenter.NewGame();
        }

        public void SetCharacterInBoard(int row,int col,char character)
        {
            _board[row,col] = character;
        }

        public void ShowBoard(char[,] board)
        {
            Console.Clear();
            Console.WriteLine("  0 1 2");
            Console.WriteLine(" +-+-+-+");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i}|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i, j]}|");
                }
                Console.WriteLine();
                Console.WriteLine(" +-+-+-+");
            }
        }

        public void ShowWinner(int winner)
        {
            Console.WriteLine($"Congratulations player {winner}, you won!");
            PlayAgain();
        }

        public void ShowDrawnGame()
        {
            Console.WriteLine("The game ended in a draw.");
            PlayAgain();
        }

        public void ShowError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }




        public void Refresh()
        {
            if (_board != null)
                ShowBoard(_board);
        }



        public void PlayAgain()
        {
            Console.WriteLine("Would you like to play again? Press enter");
            Console.ReadLine();
            Start();
        }
    }
}


