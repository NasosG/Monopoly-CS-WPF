using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    // This class contains information about the player like his/her name, colour or bank account.
    public class Player
    {

        public string name;                                 // Players name
        private int bankAccount;                            // Players money
        private bool bankrupt;                              // A player is out of money
        private int Location;                               // Players location
        private int Stoptime;                               // Time (rounds) out of the game (jail e.t.c)                            
        public Dictionary<string, int> dominates;           // Land name and number a player dominates
        private int Railways;                               // Players rail roads
        private int Utility;                                // Players utilities (water works, electric co)
        private bool CouldBuyLand;                          // Is player able to buy a property?
        private bool CouldBuyHouse;                         // Is player able to buy house in a property?

        public int railways
        { 
            get { return Railways; }
            set { Railways = value; }
        }
        public int utility
        {
            get { return Utility; }
            set { Utility = value; }
        }

        public int location
        {
            get { return Location; }
            set { Location = value; }
        }

        public int stoptime
        {
            get { return Stoptime; }
            set { Stoptime = value; }
        }

        public bool Bankrupt
        {
            get { return bankrupt; }
            set { bankrupt = value; }
        }

        public bool couldBuyHouse
        {
            get { return CouldBuyHouse; }
            set { CouldBuyHouse = value; }
        }

        public bool couldBuyLand
        {
            get { return CouldBuyLand; }
            set { CouldBuyLand = value; }
        }

        public int BankAccount
        {
            get { return bankAccount; }

        }

        public void addBankAccount(int money)
        {
            bankAccount += money;
        }


        public Player(string Name)
        {
            name = Name;
            Bankrupt = false;
            bankAccount = 1500/*2000*//*3000*/;
            location = 0;
            stoptime = 0;
            dominates = new Dictionary<string, int>();
            couldBuyLand = false;
            couldBuyHouse = false;
        }
    }
}
