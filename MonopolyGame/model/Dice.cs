using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    // the class below contains the dice element
    // we use this class to throw two dice in the game (to simulate that process)
    // I could make the whole implementation without this class
    // but in order to follow a more real world view, the dice element was added 
    class Dice
    {
       
        private Random random;        // give a random number
        private int die1FaceValue;     // first die face value
        private int die2FaceValue;      // first die face value
        private const int minDieValue = 1;   // minimum value a die can have
        private const int maxDieValue = 7;   // maximum value a die can have

        public Dice()
        {
            random = new Random();
        }

        //Roll The dice
        public void Roll()
        {
            // 1st dice roll. Generate a number from 1 to 6
            die1FaceValue = random.Next(minDieValue, maxDieValue);
            // 2nd dice roll. Generate a number from 1 to 6
            die2FaceValue = random.Next(minDieValue, maxDieValue);
        }
        
        //Get string value of Die's face value
        public String toString()
        {
            return "The Dice number is: " + (die1FaceValue + die2FaceValue);
        }

        // random number the dice rolled (just add dice 1 and 2)
        public int DiceSum()
        {
            return (die1FaceValue + die2FaceValue);
        }

        //to get just the dice's face value
        public int getDie1FaceValue()
        {
            return die1FaceValue;
        }

        //to get just the dice's face value
        public int getDie2FaceValue()
        {
            return die2FaceValue;
        }

        // check if player rolls doubles
        public bool IsDouble()
        {
            return (die1FaceValue == die2FaceValue);
        }
    }
}
