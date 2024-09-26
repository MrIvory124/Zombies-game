using System.Collections.Generic;
using System.Drawing;

namespace Zombies_game
{
    public class GDice : Dice
    {
        public GDice()
        {
            _facelist = new List<ZombieOptions>();

            base._diceColor = Color.Green;

            // add our faces to the facelist

            _facelist.Add(ZombieOptions.Feet);
            _facelist.Add(ZombieOptions.Feet);
            _facelist.Add(ZombieOptions.Brains);
            _facelist.Add(ZombieOptions.Brains);
            _facelist.Add(ZombieOptions.Brains);
            _facelist.Add(ZombieOptions.Shotgun);
        }
    }
}
