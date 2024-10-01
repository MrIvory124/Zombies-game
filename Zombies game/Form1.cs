using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zombies_game
{
    public partial class Form1 : Form
    {
        public delegate void Callback(string message);
        // delegate for consolewriting
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        // Instantiate the delegate.
        readonly Callback handler = DelegateMethod;

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
            RollAllDice();

            // check if they got 3 shotguns
            bool isRoundOver = ShotgunCheck();

            if (isRoundOver)
            {
                MessageBox.Show("You got gunned down!"); // could turn any message boxes into a delegate
                handler("Inverting turn");
                handler("Turn before: " + player1Turn);
                PlayerDoesNotScore();
                handler("Turn after: " + player1Turn);

                // if they failed in their final round, consider it over
                if (finalround)
                {
                    
                    TriggerEndGame(WhichPlayerTurn());
                }
            }

            //debugging options
            //DiceInit();
            Testcases();

        }

        /// <summary>
        /// This method will update the player scores in the appropriate cases
        /// </summary>
        private void PlayerScores()
        {
            handler("Adding scores, below is score before and after");
            handler(WhichPlayerTurn().Score.ToString());
            WhichPlayerTurn().Score += score;
            handler(WhichPlayerTurn().Score.ToString());

            // wipe the stage for the next persons turn
            PlayerDoesNotScore();
        }

        /// <summary>
        /// This turn resets everything and does not update the score
        /// </summary>
        private void PlayerDoesNotScore()
        {
            handler("Adding no score/clearing");
            // reset the things
            shotguns = 0;
            score = 0;

            player1Turn = !player1Turn;
            // invert the turns
            UpdateTextBoxes();
        }

        /// <summary>
        /// Check the players score, if it meets the threshold, enter the final round
        /// </summary>
        /// <returns></returns>
        private bool CheckScore(Player player) // check that this is used in the right place
        {
            handler("Checking scores");
            if (player.Score > 12)
            {
                handler("Score greater than 12");
                return finalround = true;
            }

            handler("Score lesser than 12");
            return false;

        }

        /// <summary>
        /// When triggered, it will roll the dice and show to the user
        /// </summary>
        private void RollAllDice()
        {
            //TODO: make the dice work as intended, currently just choosing the first 3

            //timer1.Enabled = true;

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
        /// Returns true if their turn is over by force
        /// </summary>
        private bool ShotgunCheck()
        {
            if (shotguns >= 3)
            {
                handler("Shotgun check returned true");
                return true;
            }

            handler("Shotgun check returned false");
            return false;
        }


        /// <summary>
        /// If the player clicks the stop button, we move to scoring for
        /// the other player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopScoreBtn_Click(object sender, EventArgs e)
        {

            // quick test to see if the user pressed the roll button
            if (currentDice[0] == null)
            {
                MessageBox.Show("You must roll first!");
                return;
            }
            Player currentPlayer = WhichPlayerTurn();
            PlayerScores();

            // if its the final round
            if (finalround == true)
            {
                handler("In final rounds");
                if (currentPlayer == player1)
                {
                    // if their score is higher, hand it back for one more turn
                    if (player1.Score >= player2.Score)
                    {
                        handler("Score is greater or equal, doing one more round");
                        MessageBox.Show("They caught up! Quick run away!");
                        player1Turn = false;
                        UpdateTextBoxes();
                    }
                    else // if it isnt, call the other person the winner
                    {
                        handler("Triggering endgame");
                        TriggerEndGame(player2);
                    };

                }
                else
                {
                    // if their score is higher, hand it back for one more turn
                    if (player2.Score >= player1.Score)
                    {
                        handler("Score is greater or equal, doing one more round");
                        MessageBox.Show("They caught up! Quick run away!");
                        player1Turn = true;
                        UpdateTextBoxes();
                    }
                    else // if it isnt, call the other person the winner
                    {
                        handler("Triggering endgame");
                        TriggerEndGame(player1);
                    };
                }

            }
            else
            {
                //handler("Turn before: " + player1Turn);
                //player1Turn = !player1Turn;
                //handler("Inverting turn " + player1Turn);
            }

            // check if they have 13 points, we only run this if we are not in the final round
            if (finalround == false)
            {
                if (CheckScore(currentPlayer))
                {
                    MessageBox.Show("You have 1 round to catch them!");
                }
            }


            // make sure to invert turn when done

            Testcases();
            handler("Player1's turn? " + player1Turn);
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
                //handler($"Duplicate dice at {nextPlace}");
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
                //handler($"Added dice at {nextPlace}");
                return 0;
            }
        }

        private void Testcases()
        {
            //// list for temp dice
            //List<Dice> diceList = new List<Dice>();
            //// check that all dice are generating with faces

            //handler("Generating dice");

            //// add the dice to the dicelist
            //diceList.Add(new GDice());
            //diceList.Add(new YDice());
            //diceList.Add(new RDice());

            //// checks the dice list is working
            //foreach (Dice dice in diceList)
            //{
            //    handler($"Checking dice {dice}");
            //    foreach (Dice.ZombieOptions item in dice.Facelist)
            //    {
            //        handler(item);
            //    }

            //    // check roll functionality as well
            //    dice.RollDie();
            //    handler($"Checking roll func {dice.ShowFace()}");
            //    dice.RollDie();
            //    handler($"Checking roll func {dice.ShowFace()}");
            //    dice.RollDie();
            //    handler($"Checking roll func {dice.ShowFace()}");
            //    handler();

            //}

            //handler("\nChecking the dicelist");
            //foreach (Dice dice in diceArray)
            //{
            //    handler(dice.ToString());
            //}

            handler("Player1 score: " + player1.Score);
            handler("Player2 score: " + player2.Score);
            handler("Final around: " + finalround);

            handler("\nDone");
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
            try
            {
                if (currentDice != null && currentDice.Length >= 3)
                {
                    if (currentDice[0] != null)
                    {
                        textBox1.BackColor = currentDice[0].DiceColor;
                        textBox1.Text = currentDice[0].ShowFace();
                    }
                    if (currentDice[1] != null)
                    {
                        textBox2.BackColor = currentDice[1].DiceColor;
                        textBox2.Text = currentDice[1].ShowFace();
                    }
                        
                    if (currentDice[2] != null)
                    {
                        textBox3.BackColor = currentDice[2].DiceColor;
                        textBox3.Text = currentDice[2].ShowFace();
                    }
                       
                }
                else
                {
                    throw new Exception("currentDice array is not properly initialized or does not have enough elements.");
                }
            }
            catch (Exception ex)
            {
                handler($"Error in textbox updating: {ex.Message}");
            }

            // update score boxes
            plyr1Brains.Text = player1.Score.ToString();
            plyr2Brains.Text = player2.Score.ToString();
            handler("==========");
        }

        private void TriggerEndGame(Player player)
        {
            //timer1.Stop();
            // announce the winner
            string _ = "";
            if (player == player1)
            {
                _ = "Player 1";
            }
            else
            {
                _ = "Player 2";
            }

            MessageBox.Show($"Congratualtions {_}, you won!");


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
            //timer1.Start();

            UpdateTextBoxes();
        }

        /// <summary>
        /// A temp method that returns which players turn it is.
        /// This could be replaced with a class that is called "gamestate" though
        /// </summary>
        /// <returns></returns>
        private Player WhichPlayerTurn()
        {
            if (player1Turn)
            {
                return player1;
            }
            else
            {
                return player2;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTextBoxes();
        }

        private void forTesting_Click(object sender, EventArgs e)
        {
            player1.Score = 12;
            player2.Score = 11;
            UpdateTextBoxes();
        }
    }
}
