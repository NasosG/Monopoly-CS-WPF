using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MonopolyGame
{
    // the class below contains the logic for how the game's board works 
    public class Board
    {
        public delegate void Callback(Player player);
        public int maplength;

        // the are six kinds of grid in the game broad. “Go”, “FreeParking”, ”Jail”, ”GoToJail”, “Chance", "Land", 
        // each location has its corresponding type. For example, the type of the second grid is “Jail”, then map[1] = “Jail” e.t.c 
        private List<string> map;

        // for each kind of grid, there is a relevant function.For example, for grid “Go”, there is a function called addSalary in this category which gives players some money, methodConductOnCurrentLocation[“Go”] = addSalary;
        private Dictionary<string, Callback> methodConductOnCurrentLocation;

        // give a random number
        private Random rnd;     
        public Dictionary<int, Square> lands;
        Dice dice = new Dice();
        private int dice1Value;
        private int dice2Value;

        // getters
        public List<string> Map { get { return map; } }
        public int getdice1Value { get { return dice1Value; } }
        public int getdice2Value { get { return dice2Value; } }

        public Board()
        {
            rnd = new Random();
            map = new List<string>();
            lands = new Dictionary<int, Square>();      //Each land object is stored in corresponding location inside our dictionary 

            methodConductOnCurrentLocation = new Dictionary<string, Callback>();

            BoardInit();
            maplength = map.Count;

            methodConductOnCurrentLocation["FreeParking"] = FreeParking;
            methodConductOnCurrentLocation["Go"] = AddSalary;
            methodConductOnCurrentLocation["Jail"] = Jail;
            methodConductOnCurrentLocation["GoToJail"] = GoToJail;
            methodConductOnCurrentLocation["Chance"] = Chance;
            methodConductOnCurrentLocation["IncomeTax"] = IncomeTax;
            methodConductOnCurrentLocation["LuxuryTax"] = LuxuryTax;
            methodConductOnCurrentLocation["Land"] = LandAnalysis;
        }


        public void BoardInit()
        {
            lands[1] = (new Square(1, "brown", "Mediterranean Avenue", 60, 50, 30, 50));    //property    
            lands[3] = (new Square(3, "brown", "Baltic Avenue", 60, 50, 30, 50));           //property 

            lands[5] = (new Square(5, "black", "Reading Railroad", 200, 100, 100, 150));    //railroad

            lands[6] = (new Square(6, "teal", "Oriental Avenue", 100, 70, 50, 70));         //property 
            lands[8] = (new Square(8, "teal", "Vermont Avenue", 100, 70, 50, 70));          //property 
            lands[9] = (new Square(9, "teal", "Connecticut Avenue", 120, 70, 50, 70));      //property 
            lands[11] = (new Square(11, "pink", "St. Charles Place", 140, 100, 70, 100));   //property 
            lands[12] = (new Square(12, "utility", "Electric Company", 150, 100, 100, 150));  //electric company
            lands[13] = (new Square(13, "pink", "States Avenue", 140, 100, 70, 100));       //property 
            lands[14] = (new Square(14, "pink", "Virginia Avenue", 160, 100, 70, 100));     //property 

            lands[15] = (new Square(15, "black", "Pennsylvania Railroad", 200, 100, 100, 150)); //railroad

            lands[16] = (new Square(16, "orange", "St. James Place", 180, 120, 90, 120));   //property 
            lands[18] = (new Square(18, "orange", "Tennessee Avenue", 180, 120, 90, 120));  //property 
            lands[19] = (new Square(19, "orange", "New York Avenue", 200, 120, 90, 120));   //property 
            lands[21] = (new Square(21, "red", "Kentucky Avenue", 220, 150, 110, 150));     //property 
            lands[23] = (new Square(23, "red", "Indiana Avenue", 220, 150, 110, 150));      //property 
            lands[24] = (new Square(24, "red", "Illinois Avenue", 240, 150, 110, 150));     //property 

            lands[25] = (new Square(25, "black", "B. & O. Railroad", 200, 100, 100, 150)); //railroad

            lands[26] = (new Square(26, "yellow", "Atlantic Avenue", 260, 150, 130, 150));  //property 
            lands[27] = (new Square(27, "yellow", "Ventinor Avenue", 260, 150, 130, 150));  //property 
            lands[28] = (new Square(28, "utility", "Water Works", 150, 100, 100, 150));       //water works
            lands[29] = (new Square(29, "yellow", "Marvin Gardens", 280, 150, 130, 150));   //property 
            lands[31] = (new Square(31, "green", "Pacific Avenue", 300, 190, 150, 190));    //property 
            lands[32] = (new Square(32, "green", "North Carolina Avenue", 300, 190, 150, 190));//property 
            lands[34] = (new Square(34, "green", "Pennsylvania Avenue", 320, 190, 150, 190));//property 

            lands[35] = (new Square(35, "black", "Short Line", 200, 100, 100, 150));        //railroad

            lands[37] = (new Square(37, "blue", "Park Place", 350, 220, 180, 220));         //property 
            lands[39] = (new Square(39, "blue", "Boardwalk", 400, 220, 180, 220));          //property 

            map.Add("Go");      // starting point  
            map.Add("Land");
            map.Add("Chance");
            map.Add("Land");
            map.Add("IncomeTax");  
            map.Add("Land");        // railway land
            map.Add("Land");
            map.Add("Chance");
            // 2 teal properties, so add land 2 times to our map
            for (int i = 0; i < 2; i++)
                map.Add("Land");
            // a jail square
            map.Add("Jail");
            map.Add("Land");
            map.Add("Land");
            // 2 pink properties, so add land 2 times to our map
            for (int i = 0; i < 2; i++)
                map.Add("Land");
            map.Add("Land");      // a railway land square
            map.Add("Land");
            map.Add("Chance");
            // 2 orange properties, so add land 2 times to our map
            for (int i = 0; i < 2; i++)
                map.Add("Land");
            map.Add("FreeParking");     // free parking square
            map.Add("Land");
            map.Add("Chance");
            //2 red properties, so add land 2 times to our map
            for (int i = 0; i < 2; i++)
                map.Add("Land");
            map.Add("Land");      // a railway station square
            //2 red properties, so add land 2 times to our map
            for (int i = 0; i < 2; i++)
                map.Add("Land");
            map.Add("Land");
            map.Add("Land");
            map.Add("GoToJail");    // a jail square
            for (int i = 0; i < 2; i++)
                map.Add("Land");
            map.Add("Chance");
            map.Add("Land");
            map.Add("Land");      // a railway station land
            map.Add("Chance");      // a chance square
            map.Add("Land");
            map.Add("LuxuryTax");
            map.Add("Land");

        }

        public void RollDice(Player player)
        {
            // dice roll
            dice.Roll();
            // get 1st dice value
            dice1Value = dice.getDie1FaceValue();
            // get 2nd dice value
            dice2Value = dice.getDie2FaceValue();
          
            // sum of the two dice which is calculated in DiceSum method
            int steps = dice.DiceSum();
            // move the piece to the location 
            MoveToLocation(player, steps);
        }

        public void ShowBoardInfo(Player player)
        {
            int location = player.location;
            string correntType = map[location];
           
            if (correntType == "Land") {
                Square land = lands[location];
                MessageBox.Show(player.name + " moves to " + land.name + "\n");
            }
            else if (correntType == "GoToJail") {
                MessageBox.Show(player.name + " is sent to Jail!\n", "Straight to Jail");
            }
            else if (correntType == "Jail") {
                MessageBox.Show(player.name + " visits Jail.\n", "Visiting Jail");
            }
            else {
                MessageBox.Show(player.name + " moves to " + correntType + "\n");
            }
        }

        // move current player to the posistion according to the dice number
        public void MoveToLocation(Player player, int step)
        {
            if (player.stoptime > 0) {
                Console.WriteLine("{0} more round to wait\n", player.stoptime);
                MessageBox.Show(player.name + " has " + player.stoptime + " more turns to get out of Jail.\n");
                player.stoptime--;
            }
            else {
                Console.WriteLine("Player {0} move {1} step", player.name, step);
                player.location += step;
                if (player.location >= maplength) {
                    player.location -= maplength;
                }
                ShowBoardInfo(player);
                FunctionOnPlayer(player);
            }
        }


        public void FreeParking(Player player) {
            //JUST A FREE PARKING
            MessageBox.Show("You can relax here\n", "Free Parking");
        }

        public void AddSalary(Player player)
        {
            player.addBankAccount(200);
            MessageBox.Show(player.name + " gains 200\n");
        }

        public void Jail(Player player)
        {
            // JAIL SQUARE (VISITED OR SENT)
        }

        public void GoToJail(Player player)
        {
            player.location = 10;
            player.stoptime = 3;
            Jail(player);
        }

        public void Chance(Player player)
        {
            // a random chance either to gain or lose money or go to jail
            int Chance = rnd.Next(5);

            if (Chance == 0) {
                MessageBox.Show(player.name + "! Caught not wearing your belt. Pay $50 fine!\n", "Chance Card");
                ChangeMoney(player, -50);
            }
            else if (Chance == 1) {
                MessageBox.Show(player.name + "! You have won the lottery! Collect $200!\n", "Chance Card");
                AddSalary(player);
            }
            else if (Chance == 2) {
                MessageBox.Show(player.name + "! Pay poor tax of $15!\n", "Chance Card");
                ChangeMoney(player, -15);
            }
            else if (Chance == 3) {
                MessageBox.Show(player.name + "! You have won a crossword competition. Collect $100!\n", "Chance Card");
                ChangeMoney(player, 100);
            }
            else {
                MessageBox.Show(player.name + "! Go directly to Jail!\n", "Chance Card");
                GoToJail(player);
            }
        }

        public int ChanceOfBuying()
        {
            // a random chance ranging from 0 to 19
            int Chance = rnd.Next(20);

            if (Chance < 14)      return 1;     //[possibility = 70%]
            else if (Chance < 16) return 2;     //[possibility = 10%]
            else if (Chance < 18) return 3;     //[possibility = 10%]
            else return 4;                      //[possibility = 10%]
        }

        // Change money amount(increase or decrease)
        public void ChangeMoney(Player player, int money)
        {
            //MessageBox.Show(player.name + " loses $" + losingMoney + "\n");
            player.addBankAccount(money);
            if (player.BankAccount < 0) {
                player.Bankrupt = true;
                MessageBox.Show(player.name + " gets out of the game. \n");
            }
        }

        // Income tax
        public void IncomeTax(Player player)
        {
            int losingMoney = 200;
            MessageBox.Show(player.name + " loses $" + losingMoney + "\n");
            ChangeMoney(player, -losingMoney);
        }

        // Luxury tax
        public void LuxuryTax(Player player)
        {
            int losingMoney = 100;
            MessageBox.Show(player.name + " loses $" + losingMoney + "\n");
            ChangeMoney(player, -losingMoney);
        }

        // if the land is owned by other player, current player transform some money to land owner 
        // if the land is empty, current player has chance to buy land
        // if current player has every property with that colour, he can build a hotel. 
        public void LandAnalysis(Player player)
        {
            int location = player.location;
            Square land = lands[location];

            if (land.owner == null) {
                if (player.BankAccount >= land.landPrice)
                    player.couldBuyLand = true;
            }
            else if (land.owner != player) {
                int total;
                if (land.colour == "black") {   //railroad
                    // 2 ^ railways-1 because
                    // for 1 => (2^0) railway we get 25, for 2 => (2^1)*25 = 50, for 3 => (2^2)*25 = 100, for 4 => (2^3)*25 = 200
                    total = (int)Math.Pow(2, land.owner.railways-1) * 25;
                }
                else if (land.colour == "utility") {    //electric company or water works
                    if (land.owner.utility > 1) //if both 2 utilities are owned
                        total = 10 * (dice1Value + dice2Value);
                    else total = 4 * (dice1Value + dice2Value);
                }
                else
                    total = land.passLand + land.passHouse * land.building; //standard payment plus number of houses multiplied by houses' value
                player.addBankAccount(-total);
                land.owner.addBankAccount (total);
                MessageBox.Show(player.name + " pays " + total+ " to "+ land.owner.name + "\n");
                if (player.BankAccount < 0) {
                    player.Bankrupt = true;
                    MessageBox.Show(player.name + " gets out of the game because he/she is bankrupt\n");
                }
            }
            else if (land.colour == "black") {     //railroad
                Console.WriteLine("Cannot buy house");
            }
            else if (land.colour == "utility") {    //electric company or water works
                Console.WriteLine("Cannot buy house");
            }
            // can buy house when all 3 properties of the same colour are owned
            else if (player.dominates[land.colour] > 2 && land.building < 2) {
                if (player.BankAccount >= land.housePrice)
                    player.couldBuyHouse = true;
                Console.WriteLine("Can buy house");
            }
            // can buy house when all 2 properties of the same colour are owned as blue and brown regions have only 2 properties
            else if (player.dominates[land.colour] > 1 && land.building < 1 && (land.colour == "blue" || land.colour == "brown")) {
                if (player.BankAccount >= land.housePrice)
                    player.couldBuyHouse = true;
                Console.WriteLine("Can buy house");
            }

        }

        public void BuyLand(Player player, Square land)
        {
            MessageBox.Show(player.name + " buys " + land.name + "\n");
            Console.WriteLine("BuyLand");
            player.addBankAccount(-land.landPrice);

            if (player.BankAccount < 0) {
                player.Bankrupt = true;
            }

            land.owner = player;
            String colour = land.colour;
            if (land.colour == "black") {           //railroad
                player.railways++;
            }
            else if (land.colour == "utility") {    //electric company or water works
                player.utility++;
            }
            if (player.dominates.ContainsKey(land.colour)) {
                player.dominates[land.colour]++;
            }
            else {
                player.dominates[land.colour] = 1;
            }
        }

        public void BuyHouse(Player player, Square land)
        {
            MessageBox.Show(player.name + " updates house on " + land.name + "\n");
            Console.WriteLine("BuyHouse");
            player.addBankAccount(-land.housePrice);
            if (player.BankAccount < 0) { //bankcrupt
                player.Bankrupt = true;
            }
            land.building++;
        }

        // analysis of the type of grid according to player’s location, and conduct relevant function on player after look up the dictionary
        public void FunctionOnPlayer(Player player)
        {
            int location = player.location;
            string correntType = map[location];

            methodConductOnCurrentLocation[correntType](player);
        }

        //check player's bank account (if it's less than 0, player goes bankcrupt)
        public bool PlayerLost(Player player)
        {
            return player.BankAccount < 0;
        }

    }

}
