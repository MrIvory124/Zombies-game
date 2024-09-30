using System;
using System.Collections.Generic;
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

        // turn and score keeping
        bool player1Turn = true;
        int score = 0;
        int shotguns = 0;
        bool finalround = false;

        public Form1()
        {
            InitializeComponent();

            DiceInit(); // need a way to reset this later on maybe

            currentDice = new Dice[3];
            turnTxtbox.Text = "Player 1's turn";
        }

        /// <summary>
        /// This button rolls the dice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diceRollbtn_Click(object sender, EventArgs e)
        {
            // roll the dice
            //RollAllDice();

            //CheckContinueStatus();

            //debugging options
            //DiceInit();
            Testcases(sender, e);



        }

        /// <summary>
        /// When triggered, it will roll the dice and show to the user
        /// </summary>
        private void RollAllDice()
        {
            //TODO: make the dice work as intended, currently just choosing the first 3

            // roll 3 die, add them to the list of working dice
            for (int i = 0; i < 3; i++)
            {
                diceArray[i].RollDie();
                currentDice[i] = diceArray[i];
            }

            // put the relevant points in the relevant boxes
            foreach (Dice thisDice in currentDice)
            {
                if (thisDice.CurrentVal == Dice.ZombieOptions.Brains)
                {
                    score += 1;
                }
                else if (thisDice.CurrentVal == Dice.ZombieOptions.Shotgun)
                {
                    shotguns += 1;
                }
            }

            UpdateTextBoxes();

        }

        /// <summary>
        /// This method checks if the user has been caught by shotguns.
        /// If not we do nothing.
        /// </summary>
        private void CheckContinueStatus()
        {
            if (shotguns > 2)
            {
                if (finalround == true) // if its the round they got to catch the other player
                {
                    // end the game
                    TriggerEndGame();
                }
                else
                {
                    MessageBox.Show("You got gunned down!");
                    shotguns = 0;
                    score = 0;
                    player1Turn = !player1Turn;
                }

                UpdateTextBoxes();
            }
            else if (player1.Score >= 13)
            {
                finalround = true;
                MessageBox.Show("Player 2, you get 1 round to catch them!");
            }
            else if (player2.Score >= 13)
            {
                finalround = true;
                MessageBox.Show("Player 1, you get 1 round to catch them!");
            }
        }


        /// <summary>
        /// If the player clicks the stop button, we move to scoring for
        /// the other player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopScoreBtn_Click(object sender, EventArgs e)
        {
            if (shotguns < 3) // if theyre not out
            {
                if (finalround)
                {
                    if (player1Turn)
                    {
                        if (player1.Score > player2.Score)
                        {
                            TriggerEndGame();
                        }
                        else
                        {
                            MessageBox.Show("You caught them! Keep going!");

                            // invert whos turn it is and clear text boxes
                            player1Turn = !player1Turn;

                            score = 0;
                            shotguns = 0;

                        }
                    }
                    else
                    {
                        if (player2.Score > player1.Score)
                        {
                            TriggerEndGame();
                        }
                        else
                        {
                            MessageBox.Show("You caught them! Keep going!");

                            // invert whos turn it is and clear text boxes
                            player1Turn = !player1Turn;

                            score = 0;
                            shotguns = 0;

                        }
                    }
                }
                // add scores
                else if (player1Turn)
                {
                    player1.Score += score;
                    // invert whos turn it is and clear text boxes
                    player1Turn = !player1Turn;

                    score = 0;
                    shotguns = 0;
                }
                else
                {
                    player2.Score += score;
                    // invert whos turn it is and clear text boxes
                    player1Turn = !player1Turn;

                    score = 0;
                    shotguns = 0;
                }

            }

            UpdateTextBoxes();
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

            for (int i = 0; i < GREENDICENUM; i++)
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

        private void Testcases(object sender, EventArgs e)
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

            // test case for checking points
            bool checkPointsWorking = true;
            if (checkPointsWorking)
            {
                // it is player 1s turn
                player1Turn = true;

                // player 1 is about to win
                player1.Score = 13;
                player2.Score = 10;

                // they have 0 shotguns
                shotguns = 0;

                // they click the roll button
                RollAllDice();

                Console.WriteLine("Is final round: " + finalround);
                // this should enable the final round
                CheckContinueStatus();
                Console.WriteLine("Is final round: " + finalround);

                // the person in this case has 2 shotguns
                // they gained no additional points
                shotguns = 2;
                score = 0;
                // the person clicks stop, just to simulate
                stopScoreBtn_Click(sender, e);
            }



            Console.WriteLine("\nDone");
        }

        private void UpdateTextBoxes()
        {
            if (player1Turn)
            {
                turnTxtbox.Text = "Player 1's Turn";
            }
            else
            {
                turnTxtbox.Text = "Player 2's Turn";
            }

            // for the turn information in the middle
            turnBrainsTxt.Text = score.ToString();
            turnShotgunTxt.Text = shotguns.ToString();

            // set the background color to the dice that is being used
            textBox1.BackColor = currentDice[0].DiceColor; // could fix this by adding them to a list and doing it that way
            textBox2.BackColor = currentDice[1].DiceColor;
            textBox3.BackColor = currentDice[2].DiceColor;

            // show in the text box the result
            textBox1.Text = currentDice[0].ShowFace();
            textBox2.Text = currentDice[1].ShowFace();
            textBox3.Text = currentDice[2].ShowFace();

            // update score boxes
            plyr1Brains.Text = player1.Score.ToString();
            plyr2Brains.Text = player2.Score.ToString();
        }

        private void TriggerEndGame()
        {
            // announce the winner
            string text = "Player 1";
            if (player1Turn)
            {
                text = "Player 2";
            }

            MessageBox.Show($"Congratualtions {text}, you won!");

            // reset everything
            DiceInit();
            currentDice = new Dice[3];
            turnTxtbox.Text = "Player 1's turn";
            rand = new Random();

            // create the player
            player1 = new Player();
            player2 = new Player(); // this can be a bot, change list later

            // turn and score keeping
            player1Turn = true;
            score = 0;
            shotguns = 0;
            finalround = false;
        }
    }
}
