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
    public abstract class Dice
    {
        // Enum type for storing the only options of a dice face
        public enum ZombieOptions
        {
            Brains = 0, Shotgun = 1, Feet = 2,
        }

        // random for internal rolling
        protected Random raagghh = new Random();

        // fields
        protected ZombieOptions _diceValue;
        protected Color _diceColor;
        protected List<ZombieOptions> _facelist;

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
            // initialise
            _diceValue = new ZombieOptions();
        }

        /// <summary>
        /// Method that returns a random face
        /// </summary>
        public ZombieOptions RollDie()
        {
            int faceRtrn = raagghh.Next(0, 6);
            return _facelist[faceRtrn];
        }

        /// <summary>
        /// Override base tostring
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.DiceColor.ToString() + " " + this.DiceValue.ToString();
        }

    }
}
