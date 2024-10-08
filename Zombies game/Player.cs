using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Zombies_game
{
    public class Player
    {
        // fields
        protected int _brains;
        protected int _shotguns;

        // getter setter
        public int Score
        {
            get { return _brains; }
            set { _brains = value; }
        }

        public int Shotguns
        {
            get { return _shotguns; }
            set { _shotguns = value; }
        }

        // constructor
        public Player() 
        {
        
        }


    }
}
