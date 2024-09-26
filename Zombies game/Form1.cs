using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Zombies_game
{
    public partial class GameScreen : Form
    {
        readonly int REDDICENUM = 3;
        readonly int GREENDICENUM = 6;
        readonly int YELLOWDICENUM = 4;

        // array for the dice
        protected Dice[] diceArray;

        Random rand = new Random();

        public GameScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This button rolls the dice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diceRollbtn_Click(object sender, EventArgs e)
        {
            // init setup
            DiceInit();
            Testcases();

        }

        /// <summary>
        /// Method for creating all 13 dice
        /// </summary>
        private void DiceInit()
        {
            diceArray = new Dice[GREENDICENUM + YELLOWDICENUM + REDDICENUM];
            List<int> arrayUsed = new List<int>();

            // initialise all the dice
            // TODO: could make it so that the red can only spawn with at least 1 between them
            for (int i = 0; i < REDDICENUM; i++)
            {
                i += nextDice(arrayUsed, i, "red");
            }

            for (int i = 0; i < YELLOWDICENUM; i++)
            {
                i += nextDice(arrayUsed, i, "yellow");
            }

            for (int i = 0;  i < GREENDICENUM; i++)
            {
                i += nextDice(arrayUsed, i, "green");
            }
        }

        private int nextDice(List<int> arrayUsed, int i, string color)
        {
            // pick random spot
            int nextPlace = rand.Next(0, 13);
            // check to see if already a used place in the array
            if (arrayUsed.Contains(nextPlace))
            {
                //Console.WriteLine($"Duplicate dice at {nextPlace}");
                return -1;
            }
            else
            {
                arrayUsed.Add(nextPlace);
                // select the correct color and add to the array 
                switch (color)
                {
                    case "green":
                        diceArray[nextPlace] = new GDice();
                        break;
                    case "yellow":
                        diceArray[nextPlace] = new YDice();
                        break;
                    default:
                        diceArray[nextPlace] = new RDice();
                        break;
                }
                //Console.WriteLine($"Added dice at {nextPlace}");
                return 0;
            }
        }

        private void Testcases()
        {
            // list for temp dice
            List<Dice> diceList = new List<Dice>();
            // check that all dice are generating with faces

            Console.WriteLine("Generating dice");

            diceList.Add(new GDice());
            diceList.Add(new YDice());
            //diceList.Add(new RDice());

            foreach (Dice dice in diceList)
            {
                Console.WriteLine($"Checking dice {dice}");
                foreach (Dice.ZombieOptions item in dice.Facelist)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine($"Checking roll func {dice.RollDie()}");
                Console.WriteLine();

            }

            Console.WriteLine("\nChecking the dicelist");
            foreach (Dice dice in diceArray)
            {
                Console.WriteLine(dice.ToString());
            }

            Console.WriteLine("\nDone");
        }

    }
}
