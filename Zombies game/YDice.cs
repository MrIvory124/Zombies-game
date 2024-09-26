﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies_game
{
    public class YDice : Dice
    {
        public YDice() 
        {
            _facelist = new List<ZombieOptions>();

            base._diceColor = Color.Yellow;

            // add our faces to the facelist
            for ( int i = 0; i < 2; i++ ) {
                _facelist.Add(ZombieOptions.Feet);
                _facelist.Add(ZombieOptions.Brains);
                _facelist.Add(ZombieOptions.Shotgun);
            }
        }
    }
}