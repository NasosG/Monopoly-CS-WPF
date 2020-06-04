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
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        GameController game = GameController.Instance;
        public GameOver()
        {
            InitializeComponent();
        }

        public GameOver(int reason) 
        {
            InitializeComponent();
            winnerTag.Text = findRichestPlayerName() + " has won the game!";
            Console.WriteLine("Reason {0}", reason);
        }

        // Find the richest player - winner and return his/her name
        public String findRichestPlayerName()
        {
            int pos = 0, max = 0;
            List<Player> player = game.players;
            for (int i = 0; i < player.Count; i++) {
                if (player[i].BankAccount == max && max > 0) {    // If 2 players have the same money
                    return "It's a tie! Nobody";                 // It's a tie
                }
                if (player[i].BankAccount > max) {
                    max = player[i].BankAccount;
                    pos = i;
                }

            }
            return player[pos].name;
        }

        public GameOver(int reason, Player player)
        {
            InitializeComponent();
            winnerTag.Text = player.name + " has won the game!";
            Console.WriteLine("Reason {0}", reason);
        }

        private void QuitApp(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            System.Windows.Application.Current.Shutdown();
        }

        // when enter or escape button is pressed
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            // If Enter or Escape button is pressed quit
            if ((e.Key == Key.Return) || (e.Key == Key.Escape)) {
                QuitApp(sender, e);
            }
        }

    }
}
