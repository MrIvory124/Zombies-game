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

        protected Dice[] currentDice;

        // array for all the dice
        protected Dice[] diceArray;
        protected List<int> usedDice = new List<int>(); // contains the indexes used die, just measuring the length of the array to find this

        Random rand = new Random();

        // create the player
        Player player1 = new Player();
        Player player2 = new Player(); // this can be a bot, change list later

        public Form1()
        {
            InitializeComponent();

            DiceInit(); // need a way to reset this later on maybe

            currentDice = new Dice[3];
        }

        /// <summary>
        /// This button rolls the dice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diceRollbtn_Click(object sender, EventArgs e)
        {
            RollAllDice();
            

            //DiceInit();
            Testcases();
        }

        private void RollAllDice()
        {
            //TODO: make the dice work as intended, currently just choosing the first 3

            // roll 3 die, add them to the list of working dice
            for (int i = 0; i < 3; i++)
            {
                diceArray[i].RollDie();
                currentDice[i] = diceArray[i];
            }

            // set the background color to the dice that is being used
            textBox1.BackColor = currentDice[0].DiceColor;
            textBox2.BackColor = currentDice[1].DiceColor;
            textBox3.BackColor = currentDice[2].DiceColor;

            // show in the text box the result
            textBox1.Text = currentDice[0].ShowFace();
            textBox2.Text = currentDice[1].ShowFace();
            textBox3.Text = currentDice[2].ShowFace();

            ScorePoints(player1);
        }

        /// <summary>
        /// Currently this method adds score if they roll brains, and adds shotguns if they get them
        /// </summary>
        /// <param name="player"></param>
        private void ScorePoints(Player player)
        {
            foreach (Dice dice in currentDice)
            {
                if (dice.CurrentVal == Dice.ZombieOptions.Brains)
                {
                    player.Score += 1;
                }
                else if (dice.CurrentVal == Dice.ZombieOptions.Shotgun)
                {
                    player.Shotguns += 1;
                }
            }

            UpdateScores();
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

            for (int i = 0; i < YELLOWDICENUM; i++)
            {
                i += nextDice(arrayUsed, "yellow");
            }

            for (int i = 0; i < REDDICENUM; i++)
            {
                i += nextDice(arrayUsed, "red");
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
                dice.RollDie();
                Console.WriteLine($"Checking roll func {dice.ShowFace()}");
                dice.RollDie();
                Console.WriteLine($"Checking roll func {dice.ShowFace()}");
                dice.RollDie();
                Console.WriteLine($"Checking roll func {dice.ShowFace()}");
                Console.WriteLine();

            }

            Console.WriteLine("\nChecking the dicelist");
            foreach (Dice dice in diceArray)
            {
                Console.WriteLine(dice.ToString());
            }

            Console.WriteLine("\nDone");
        }

        private void UpdateScores()
        {
            // update player 1
            plyr1Brains.Text = player1.Score.ToString();
            plyr1Shotguns.Text = player1.Shotguns.ToString();

            // update player 2
            plyr2Brains.Text = player2.Score.ToString();
            plyr2Shotguns.Text = player2.Shotguns.ToString();
        }

    }
}
