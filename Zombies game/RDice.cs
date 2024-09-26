using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies_game
{
    public class RDice : Dice
    {
        public RDice()
        {
            _facelist = new List<ZombieOptions>();

            base._diceColor = Color.Red;

            // add our faces to the facelist
            _facelist.Add(ZombieOptions.Feet);
            _facelist.Add(ZombieOptions.Feet);
            _facelist.Add(ZombieOptions.Brains);
            _facelist.Add(ZombieOptions.Shotgun);
            _facelist.Add(ZombieOptions.Shotgun);
            _facelist.Add(ZombieOptions.Shotgun);
        }
    }
}
