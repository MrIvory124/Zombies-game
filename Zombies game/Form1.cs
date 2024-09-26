using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Zombies_game
{
    public partial class Form1 : Form
    {
        readonly int REDDICENUM = 3;
        readonly int GREENDICENUM = 6;
        readonly int YELLOWDICENUM = 4;

        // array for the dice
        protected Dice[] diceArray;
        protected List<int> usedDice = new List<int>();

        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();

            DiceInit(); // need a way to reset this later on maybe
        }

        /// <summary>
        /// This button rolls the dice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diceRollbtn_Click(object sender, EventArgs e)
        {
            GameplayLoop();

            Testcases();


        }

        private void GameplayLoop()
        {
            // set the background color to the dice that is being used
            textBox1.BackColor = diceArray[0].DiceColor;
            textBox2.BackColor = diceArray[1].DiceColor;
            textBox3.BackColor = diceArray[2].DiceColor;

            // show in the text box the result
            textBox1.Text = diceArray[0].RollDie().ToString();
            textBox2.Text = diceArray[0].RollDie().ToString();
            textBox3.Text = diceArray[0].RollDie().ToString();
        }

        /// <summary>
        /// Method for creating all 13 dice and putting them in the array
        /// </summary>
        private void DiceInit()
        {
            diceArray = new Dice[GREENDICENUM + YELLOWDICENUM + REDDICENUM];
            List<int> arrayUsed = new List<int>();

            // initialise all the dice
            // TODO: could make it so that the red can only spawn with at least 1 between them
            for (int i = 0; i < REDDICENUM; i++)
            {
                i += nextDice(arrayUsed, "red");
            }

            for (int i = 0; i < YELLOWDICENUM; i++)
            {
                i += nextDice(arrayUsed, "yellow");
            }

            for (int i = 0;  i < GREENDICENUM; i++)
            {
                i += nextDice(arrayUsed, "green");
            }
        }

        /// <summary>
        /// This is a method that is used for initialising all of the dice.
        /// It takes in some information, and transforms it so that a die can effectively
        /// be placed in the array of dice. 
        /// </summary>
        /// <param name="arrayUsed"></param>
        /// <param name="i"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private int nextDice(List<int> arrayUsed, string color)
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

            // add the dice to the dicelist
            diceList.Add(new GDice());
            diceList.Add(new YDice());
            diceList.Add(new RDice());

            // checks the dice list is working
            foreach (Dice dice in diceList)
            {
                Console.WriteLine($"Checking dice {dice}");
                foreach (Dice.ZombieOptions item in dice.Facelist)
                {
                    Console.WriteLine(item);
                }

                // check roll functionality as well
                Console.WriteLine($"Checking roll func {dice.RollDie()}");
                Console.WriteLine($"Checking roll func {dice.RollDie()}");
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
