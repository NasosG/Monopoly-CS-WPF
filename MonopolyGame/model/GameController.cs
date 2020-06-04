using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace MonopolyGame
{
    // this singleton class is used for all the underlying operations 
    public class GameController
    {
        int turn;
        static Player staticCurrentPlayer;
        private List<Player> Players;
        private Board Board;
        public List<Window> possibleWindows;


        public Board board
        {
            get { return Board; }
        }

        public List<Player> players
        {
            get { return Players; }
        }

        private GameController()
        {
            turn = 0;
            Players = new List<Player>();
            Board = new Board();
            possibleWindows = new List<Window>();
        }

        public void addPlayer(Player player) {
            Players.Add(player);
            staticCurrentPlayer = Players[0];
        }

        public Player nextTurn()
        {
            turn = (turn + 1) % (Players.Count);      // next turn and start from the beginning when end is reached
            staticCurrentPlayer = Players[turn];  
            return Players[turn];
        }

        public Player currentPlayer()
        {
            return staticCurrentPlayer;
        }
        
        public void DelatePlayer(Player player)
        {
            if (turn == Players.Count - 1) {
                turn = -1;
            }
            else {
                turn--;
            }
            Players.Remove(player);
        }

        static private GameController instance;
        public void Gameover(int reason)
        {
            /*
            * Show final window
            * when someone wins or game ends
            */
            GameOver endwindow = new GameOver(reason);
            endwindow.Show();
            foreach (Window window in possibleWindows) 
                window.Close();
        }

        public void Gameover(int reason, Player player)
        {
            /*
            * Show final window
            * when someone wins or game ends
            */
            GameOver endwindow = new GameOver(reason, player);
            endwindow.Show();
            foreach (Window window in possibleWindows)
                window.Close();
        }

        public static GameController Instance
        {
            get {
                if (instance == null) // if instance doesn't exist
                    instance = new GameController();
                return instance;
            }
        }

    }
}
