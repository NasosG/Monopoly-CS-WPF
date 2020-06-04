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
    /// Interaction logic for NumPlayers.xaml
    /// </summary>
    public partial class NumPlayers : Window
    {
        public int num;     //number of players
          
        //class Constructor
        public NumPlayers(int mode)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        //user has checked number 2 (number of players)
        private void Box2Checked(object sender, RoutedEventArgs e)
        {
            num = 2;
        }

        //user has checked number 3 (number of players)
        private void Box3Checked(object sender, RoutedEventArgs e)
        {
            num = 3;
        }

        //user has checked number 4 (number of players)
        private void Box4Checked(object sender, RoutedEventArgs e)
        {
            num = 4;
        }

        //this function is called if user has not selected anything
        private void ValidateOK(object sender, RoutedEventArgs e)
        {
            //if neither one of the boxes is checked
            if ((Box2.IsChecked == false) && (Box3.IsChecked == false) && (Box4.IsChecked == false))
                // show a polite message to the user
                MessageBox.Show("Please select number of players!");

       
            //everything went fine, so call next windows where players' names will be defined
            //and close this window
            else {
                PlayerNames namewindow = new PlayerNames(num, num);
                namewindow.Show();
                this.Close();
            }
        }

        // when enter button is pressed
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) {
                ValidateOK(sender,e);
            }
        }
    }
}
