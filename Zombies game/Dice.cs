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
        public Dice()
        {
            // initialise the enum
            _diceValue = new ZombieOptions();
        }

        /// <summary>
        /// Method to randomly pick from the 3 enum types
        /// </summary>
        public void RollDie()
        {
            int face = raagghh.Next(0,3);
            Console.WriteLine(face);

            // switch that changes the result to desired outcome
            switch (face)
            {
                case 0:
                    _diceValue = ZombieOptions.Brains;
                    break;
                case 1:
                    _diceValue = ZombieOptions.Shotgun;
                    break;
                default:
                    _diceValue = ZombieOptions.Feet;
                    break;
            }

            Console.WriteLine(this.DiceValue.ToString());
        }

        public override string ToString()
        {
            return this.DiceValue.ToString();
        }

    }
}
