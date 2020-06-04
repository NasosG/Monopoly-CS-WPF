using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for Monopoly.xaml
    /// </summary>
    public partial class Monopoly : Window
    {
        private MediaPlayer playDiceSound; // the media player
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private const int roundsTotal = 200;
        private int rounds = 0;
        Player currentPlayer;
        List<Player> players;
        GameController game = GameController.Instance;
        List<Rectangle> Tiles = new List<Rectangle>();
        List<Ellipse> Tokens = new List<Ellipse>();
        List<TextBlock> Labels = new List<TextBlock>();          
        List<TextBlock> cashInfo = new List<TextBlock>();       
        public List<Image> dices = new List<Image>();

        private void StartTimer()
        {
            // assign the delegate to call in each tick
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            foreach (Player player in players)
            {
                if (players.IndexOf(player) == 0) {
                    Canvas.SetLeft(Tokens[players.IndexOf(player)], Canvas.GetLeft(Tiles[player.location]));
                    Canvas.SetTop(Tokens[players.IndexOf(player)], Canvas.GetTop(Tiles[player.location]));
                }
                if (players.IndexOf(player) == 1) {
                    Canvas.SetLeft(Tokens[players.IndexOf(player)], Canvas.GetLeft(Tiles[player.location]) + Tiles[player.location].Width - Tokens[0].Width);
                    Canvas.SetTop(Tokens[players.IndexOf(player)], Canvas.GetTop(Tiles[player.location]));
                }
                if (players.IndexOf(player) == 2) {
                    Canvas.SetLeft(Tokens[players.IndexOf(player)], Canvas.GetLeft(Tiles[player.location]));
                    Canvas.SetTop(Tokens[players.IndexOf(player)], Canvas.GetTop(Tiles[player.location]) + Tiles[player.location].Height - Tokens[0].Width);
                }
                if (players.IndexOf(player) == 3) {

                    Canvas.SetLeft(Tokens[players.IndexOf(player)], Canvas.GetLeft(Tiles[player.location]) + Tiles[player.location].Width - Tokens[0].Width);
                    Canvas.SetTop(Tokens[players.IndexOf(player)], Canvas.GetTop(Tiles[player.location]) +Tiles[player.location].Height - Tokens[0].Width);
                }
            }
            for (int i = 0; i < players.Count; i++) {
                cashInfo[i].Text = "Cash: $" + players[i].BankAccount;
            }
           
        }

        public Monopoly()
        {
            currentPlayer = game.currentPlayer();
            players = game.players;
            InitializeComponent();
            playDiceSound = new MediaPlayer(); // Make a new instance of the media player
            //this.WindowState = WindowState.Maximized;
            addTileToList();
            addTokenToList();
            StartTimer();
            // set players turn textblock in the beginning
            whosTurn.Text = (string)game.currentPlayer().name + " 's turn";
        }

        public void addTokenToList()
        {
            // Player tokens (pieces)
            Tokens.Add(player1);
            Tokens.Add(player2);
            Tokens.Add(player3);
            Tokens.Add(player4);
            
            // Player labels
            Labels.Add(player1_label);
            Labels.Add(player2_label);
            Labels.Add(player3_label);
            Labels.Add(player4_label);

            // Cash of player text
            cashInfo.Add(player1_account);
            cashInfo.Add(player2_account);
            cashInfo.Add(player3_account);
            cashInfo.Add(player4_account);

            foreach (Ellipse token in Tokens) {
                if (Tokens.IndexOf(token) < players.Count) {
                    token.Visibility = Visibility.Visible;
                }
                else token.Visibility = Visibility.Hidden;
            }
          
            foreach (TextBlock token in Labels) {
                if (Labels.IndexOf(token) < players.Count) {
                    token.Visibility = Visibility.Visible;
                }
                else token.Visibility = Visibility.Hidden;
            }

            foreach (TextBlock token in cashInfo) {
                if (cashInfo.IndexOf(token) < players.Count) {
                    token.Visibility = Visibility.Visible;
                }
                else token.Visibility = Visibility.Hidden;
            }

            for (int i = 0; i < players.Count; i++) {
                Labels[i].Text = players[i].name;
            }
        }
        
        // Add tiles (rectangles) to the list
        public void addTileToList()
        {
            Tiles.Add(Tile0);
            Tiles.Add(Tile1);
            Tiles.Add(Tile2);
            Tiles.Add(Tile3);
            Tiles.Add(Tile4);
            Tiles.Add(Tile5);
            Tiles.Add(Tile6);
            Tiles.Add(Tile7);
            Tiles.Add(Tile8);
            Tiles.Add(Tile9);
            Tiles.Add(Tile10);
            Tiles.Add(Tile11);
            Tiles.Add(Tile12);
            Tiles.Add(Tile13);
            Tiles.Add(Tile14);
            Tiles.Add(Tile15);
            Tiles.Add(Tile16);
            Tiles.Add(Tile17);
            Tiles.Add(Tile18);
            Tiles.Add(Tile19);
            Tiles.Add(Tile20);
            Tiles.Add(Tile21);
            Tiles.Add(Tile22);
            Tiles.Add(Tile23);
            Tiles.Add(Tile24);
            Tiles.Add(Tile25);
            Tiles.Add(Tile26);
            Tiles.Add(Tile27);
            Tiles.Add(Tile28);
            Tiles.Add(Tile29);
            Tiles.Add(Tile30);
            Tiles.Add(Tile31);
            Tiles.Add(Tile32);
            Tiles.Add(Tile33);
            Tiles.Add(Tile34);
            Tiles.Add(Tile35);
            Tiles.Add(Tile36);
            Tiles.Add(Tile37);
            Tiles.Add(Tile38);
            Tiles.Add(Tile39);

            foreach (Rectangle tile in Tiles)
                tile.Opacity = 0;
            
        }

        public void init()
        {
            currentPlayer = game.currentPlayer();
            players = game.players;
        }

        // Function used to show a square next to a property that a player bought
        public void dominate(Player p)
        {
            Rectangle occupy = new Rectangle();
            canvas.Children.Add(occupy);
            occupy.Fill = Tokens[players.IndexOf(p)].Fill;
            occupy.Width = Tokens[players.IndexOf(p)].Width;
            occupy.Height = Tokens[players.IndexOf(p)].Height;

            if (p.location < 10) {  //Bottom squares occupy space when player gets property
                Canvas.SetLeft(occupy, Canvas.GetLeft(Tiles[p.location]) + 0.4 * (Tiles[p.location].Width - 10));
                Canvas.SetTop(occupy, Canvas.GetTop(Tiles[p.location]) - occupy.Width);
            }
            else if (p.location < 20) { //Left squares occupy space when player gets property
                Canvas.SetLeft(occupy, Canvas.GetLeft(Tiles[p.location]) + Tiles[p.location].Width + 3);
                Canvas.SetTop(occupy, Canvas.GetTop(Tiles[p.location]) + 0.5 * (Tiles[p.location].Height - 10));
            }
            else if (p.location < 30) { // Top squares occupy space when player gets property
                Canvas.SetLeft(occupy, Canvas.GetLeft(Tiles[p.location]) + 0.5 * (Tiles[p.location].Width - 10));
                Canvas.SetTop(occupy, Tiles[p.location].Height);
            }
            else if (p.location < 40) { //Right squares occupy space when player gets property
                Canvas.SetLeft(occupy, Canvas.GetLeft(Tiles[p.location]) - occupy.Width);
                Canvas.SetTop(occupy, Canvas.GetTop(Tiles[p.location]) + 0.5 * (Tiles[p.location].Height - 10));
            }
        }

        // make a bitmap images then insert the corresponding uri and return the correct images
        private BitmapImage MakeImage(int a) {
            BitmapImage images = new BitmapImage();
            images.BeginInit();
            var Uri = new Uri("pack://application:,,,/images/dice" + a + ".png");
            images.UriSource = Uri;
            images.EndInit();
            return images;
        }

        private void playGame(object sender, RoutedEventArgs e)
        {
            // If we pass the limit of rounds, game ends and the player who owns more cash wins
            if (rounds >= roundsTotal) {
                game.Gameover(0);
                return;
            }

           
            playDiceSound.Volume = 40; // lower to 40 percent
            var uri = new Uri("sounds/rollingDice.mp3", UriKind.Relative); // browsing to the sound folder and then the mp3 file location
            playDiceSound.Open(uri); // Insert the URI to the media player
            playDiceSound.Play(); // Play the media file from the media player class

            // Make round actions
            playRound();

            // Rounds iteration
            rounds++;
        }

        private void playRound()
        {
            currentPlayer = game.currentPlayer();

            //TextBlock turnText = TextBlock 
            game.board.RollDice(currentPlayer);

            // set first dice's source to the first dice's value with the help of the function we made
            dice1.Source = MakeImage(game.board.getdice1Value);
            // set dice 2 too
            dice2.Source = MakeImage(game.board.getdice2Value);

            if (currentPlayer.couldBuyLand)
            {
                string message = currentPlayer.name + "," + " would you like to purchase " + game.board.lands[currentPlayer.location].name + " for $" + game.board.lands[currentPlayer.location].landPrice + "?";
                //string message = "Hello "+currentPlayer.name+"! " + "Do you want to spend $"+ game.board.lands[currentPlayer.location].landPrice+ " to buy " + game.board.lands[currentPlayer.location].name+"?";
                if (MessageBox.Show(message, "Purchase Property", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (game.board.ChanceOfBuying() == 1) {
                        game.board.BuyLand(currentPlayer, game.board.lands[currentPlayer.location]);
                        dominate(currentPlayer);
                    }
                    else if (game.board.ChanceOfBuying() == 2) {
                        MessageBox.Show("You hadn't payed your taxes. Money goes to the government", "Oooops!!");
                        game.board.ChangeMoney(currentPlayer, -game.board.lands[currentPlayer.location].landPrice); //take player's money
                    }
                    else if (game.board.ChanceOfBuying() == 3) {
                        MessageBox.Show("Dealer took your money. Sorry that's life", "Oooops!!");
                        game.board.ChangeMoney(currentPlayer, -game.board.lands[currentPlayer.location].landPrice); //take player's money
                    }
                    else {
                        MessageBox.Show("The money were stolen on the way. Try to transfer them safer next time", "Oooops!!");
                        game.board.ChangeMoney(currentPlayer, -game.board.lands[currentPlayer.location].landPrice); //take player's money
                    }
                }
                currentPlayer.couldBuyLand = false;
            }

            if (currentPlayer.couldBuyHouse)
            {
                string message = game.board.lands[currentPlayer.location].name + " is yours, do you want to spend $" + game.board.lands[currentPlayer.location].housePrice + " to update house?";
                if (MessageBox.Show(message, "Update or not?", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    game.board.BuyHouse(currentPlayer, game.board.lands[currentPlayer.location]);
                }
                currentPlayer.couldBuyHouse = false;
            }

            if (game.board.PlayerLost(currentPlayer)) {
                game.DelatePlayer(currentPlayer);
                MessageBox.Show(currentPlayer.name + " has bankrupted!");

                // if only one player is left in the game
                if (players.Count == 1) {
                    game.Gameover(0, currentPlayer);
                }
            }

            currentPlayer = game.nextTurn();
            // set players turn textblock
            whosTurn.Text = (string) game.currentPlayer().name + " 's turn";
        }

        // Event listeners area
        // to make the rectangles around the board interactive

        // Listener when mouse enters the area
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle source = e.Source as Rectangle;
            Console.WriteLine("mouse entered the area of a square");
            if (source != null) {
                source.Opacity = 0.25;
                source.Fill = Brushes.AliceBlue;
            }
        }

        // Listener when mouse leaves the area
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {

            // Cast the source of the event to a Button. 
            Rectangle source = e.Source as Rectangle;

            // If source is a Button. 
            if (source != null) {
                source.Opacity = 0;
            }

        }
    }
}
