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
using System.Windows.Shapes;

namespace MonopolyGame
{
    /// <summary>
    /// Interaction logic for PlayerNames.xaml
    /// </summary>
    public partial class PlayerNames : Window
    {
        public int playerIndex;
        public int numofPlayers;
     
        GameController game = GameController.Instance;

        public PlayerNames(int num,int maxnum)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.playerIndex = num;
            this.numofPlayers = maxnum;
           
            inputplayername.Text =  "please enter " + "Player " + (maxnum - num + 1) + "'s name";
        }

        private void ValidateOK(object sender, RoutedEventArgs e)
        {
            if (name.Text == "")
                MessageBox.Show("Please enter your name!");
            else {
                game.addPlayer(new Player(name.Text));
                if (playerIndex > 1) {
                    playerIndex--;
                    PlayerNames namewindow = new PlayerNames(playerIndex, numofPlayers);
                    namewindow.Show();
                    this.Close();
                }
                else {
                    Monopoly m_View = new Monopoly();
                    game.possibleWindows.Add(m_View);
                    m_View.Show();
                    this.Close();
                }

            }
        }

        private void NameTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        // when enter button is pressed
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ValidateOK(sender, e);
            }
        }
    }
}
