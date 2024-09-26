using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Zombies_game
{
    public class Dice
    {
        // Enum type for storing the only options of a dice face
        public enum ZombieOptions
        {
            Brains = 0, Shotgun = 1, Feet = 2,
        }

        // random for internal rolling
        Random raagghh = new Random();

        // fields
        ZombieOptions _diceValue;
        Color _diceColor;

        // getter setters
        public Color DiceColor
        {
            get { return _diceColor; }
        }

        public ZombieOptions DiceValue
        {
            get { return _diceValue; }
        }

        // constructors
        public Dice

        /// <summary>
        /// Method to randomly pick from the 3 enum types
        /// </summary>
        public void RollDie()
        {
            int face = raagghh.Next(0,3);

            

            switch (face)
            {
                case 0:
                    // code block
                    break;
                case 1:
                    // code block
                    break;
                case 3:
                    // code block
                    break;
                default:
                    // code block
                    break;
            }

        }

    }
}
