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


namespace MonopolyGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameController game;                // game controller
        List<Player> players;               // list of players
        Board board;                        // the board
        Player currentPlayer;               // current player
        Dictionary<int, Square> lands;      // information about the land and its number

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void StartButton(object sender, RoutedEventArgs e)
        {
            NumPlayers numplayer = new NumPlayers(1);
            numplayer.Show();
            game = GameController.Instance;             // create new game instance
            board = game.board;
            players = game.players;
            lands = game.board.lands;

            currentPlayer = game.currentPlayer();
            this.Close();
        }

        private void QuitApp(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // when enter or escape button is pressed
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            // If Enter button is pressed
            if (e.Key == Key.Return) { 
                StartButton(sender, e);
            }

            // If Escape Button is pressed
            if (e.Key == Key.Escape) {
                QuitApp(sender, e);
            }
        }

    }

}
