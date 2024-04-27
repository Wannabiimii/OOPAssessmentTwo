using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignmentTwo
{
    internal class Die
    {
        //creating a static instance of random so that random number generation is possible.
        private static readonly Random randomNumber = new Random();
        //Property
        private int _diceValue;

        // getter and setter for diceValue
        public int DiceValue
        {
            get
            {
                return _diceValue;
            }
           
        }
       

        public int Roll()
        {
            //sets dice value to a random number
            _diceValue = randomNumber.Next(1, 7);
            
            
            return _diceValue;
        }

    }
}
