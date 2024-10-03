using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        /// <summary>
        /// An array that will be length 3, this is all the dice we are using
        /// </summary>
        protected Dice[] currentDice;

        /// <summary>
        /// A list for all 13 dice
        /// </summary>
        protected List<Dice> diceList; // replacing the stupid array with this list

        /// <summary>
        /// A list that contains the indexxes of used die. Mesure the length of this array to see which die we are up to
        /// </summary>
        protected List<int> usedDice;

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

            currentDice = new Dice[3];
            DiceInit(); // need a way to reset this later on maybe

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
        /// Method for creating all 13 dice and putting them in the array
        /// </summary>
        private void DiceInit()
        {
            diceList = new List<Dice>();
            usedDice = new List<int>();

            // initialise all the dice
            // TODO: could make it so that the red can only spawn with at least 1 between them

            for (int i = 0; i < YELLOWDICENUM; i++)
            {
                diceList.Add(new YDice());
            }

            for (int i = 0; i < REDDICENUM; i++)
            {
                diceList.Add(new RDice());
            }

            for (int i = 0; i < GREENDICENUM; i++)
            {
                diceList.Add(new GDice());
            }

            // also add 3 to the current dice array, to avoid errors.
            for (int i = 0; i < 3; i++)
            {
                diceList[i].RollDie();
                currentDice[i] = diceList[i];
                // make sure we keep track of the dice we are up to
                usedDice.Add(i);
            }
        }

        /// <summary>
        /// When triggered, it will roll the dice and show to the user
        /// </summary>
        private void RollAllDice()
        {
            // swap to new dice if needed
            for (int i = 0; i < 3; i++)
            {
                // if we have reached the end of the array, re-init the dice array and reset the count
                if (usedDice.Count >= 13)
                {
                    usedDice.Clear();
                    DiceInit();
                }

                // if any of the dice have shotguns or brains showing, get rid of them and move on to the next
                if (currentDice[i].CurrentVal == Dice.ZombieOptions.Shotgun || currentDice[i].CurrentVal == Dice.ZombieOptions.Brains)
                {
                    currentDice[i] = diceList[usedDice.Count]; 

                    usedDice.Add(i);
                    handler("Not feet, rechosing");
                }

                // roll the dice
                foreach (Dice dice in currentDice)
                {
                    dice.RollDie();
                    handler(dice.ToString());
                }
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

            handler($"Amount of dice used: {usedDice.Count}");
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

            // this is supposed to be instead: in a round of 3 people, if the person who went first wins, then the other
            // 2 get to finish their turn, otherwise its game over. wtf is this shit
            // if its the final round
            if (finalround == true) // TODO: REWORK THIS FUCKING SHIT BECAUSE ITS INCORRECT
                
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

            cupTxtbox.Text = (13 - usedDice.Count).ToString();

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

        private void forTesting_Click(object sender, EventArgs e)
        {
            player1.Score = 12;
            player2.Score = 11;
            UpdateTextBoxes();
        }
    }
}
