using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    // class which has the squares' information
    public class Square
    {
        public String colour;            // square's colour
        public Player owner;             // square's owner
        public int building;             
        public int landPrice;
        public int housePrice;
        public int passLand;
        public int passHouse;
        public string name;
        public int location;     

        // the constructors
        public Square() {}

        public Square(int location, string colour, string name, int landPrice, int housePrice,int passLand, int passHouse)
        {
            this.location = location;
            this.colour = colour;
            this.name = name;
            this.landPrice = landPrice;
            this.housePrice = housePrice;
            this.passHouse = passHouse;
            this.passLand = passLand;
            building = 0;
            owner = null;
        }

    }

}
