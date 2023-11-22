using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToeConsole;
using TicTacToe;

namespace TicTacToeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ViewInterface
    {
        private readonly Presenter _presenter;
        private char[,] _board;

        public MainWindow()
        {
            InitializeComponent();
            _board = new char[3, 3] {
            {' ',' ',' ' },
            {' ',' ',' ' },
            {' ',' ',' ' }
            };
            _presenter = new Presenter(this);
            
        }


        //View Interface
        public void Start()
        {
            _board = new char[3, 3] {
            {' ',' ',' ' },
            {' ',' ',' ' },
            {' ',' ',' ' }
            };
            _presenter.NewGame();
        }

        public void ShowBoard(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string buttonName = $"r{i}c{j}";
                    Button button = FindName(buttonName) as Button;
                    button.Content = board[i, j];
                }
            }
        }

        public void ShowWinner(int winner)
        {
            MessageBox.Show($"Congratulations Player {winner}, you won!");
            PlayAgain();
        }

        public void ShowDrawnGame()
        {
            MessageBox.Show("The game ended in a draw.");
            PlayAgain();
        }

        public void ShowError(string message)
        {
            MessageBox.Show($"{message}, Try Again","Error",MessageBoxButton.OK,MessageBoxImage.Error);
        }

        public void Refresh()
        {
            if(_board != null)
                ShowBoard(_board);
        }

        public void PlayAgain()
        {
            MessageBoxResult result = MessageBox.Show("Would you like to play again?", "Play Again?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Start();
            }
            else
            {
                Close();
            }
        }

        public void SetCharacterInBoard(int row, int col, char character)
        {
            string buttonName = $"r{row}c{col}";
            Button button = FindName(buttonName) as Button;
            button.Content = character;
            _board[row, col] = character;
        }


        //Event handlers
        private void Game_Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the location of Swhich button was clicked
            Button clickedButton = (Button)sender;
            int row = Grid.GetRow(clickedButton);
            int col = Grid.GetColumn(clickedButton);

            // Call the presenter to process the turn
            _presenter.ProcessTurn(row, col);
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }


    }
}
