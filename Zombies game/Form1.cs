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

        Random rand = new Random();

        GameState currentGame;

        public Form1()
        {
            InitializeComponent();
            currentGame = new GameState(YELLOWDICENUM, REDDICENUM, GREENDICENUM);
            turnTxtbox.Text = currentGame.Turn.ToString(); // this might be an error
            
        }

        /// <summary>
        /// This button rolls the dice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diceRollbtn_Click(object sender, EventArgs e)
        {
            currentGame.RollAllDice();
            bool isTurnOver = currentGame.IsTurnOver();

            Console.WriteLine("Diff chk, dice 1 rolled: " + currentGame.CurrentDice[1].CurrentVal);

            UpdateTextBoxes();

            if (isTurnOver)
            {
                MessageBox.Show("You got gunned down!");
            }

            //// check if they got 3 shotguns
            //bool isRoundOver = ShotgunCheck();

            //if (isRoundOver)
            //{
            //    MessageBox.Show("You got gunned down!"); // could turn any message boxes into a delegate
            //    handler("Inverting turn");
            //    handler("Turn before: " + player1Turn);
            //    PlayerDoesNotScore();
            //    handler("Turn after: " + player1Turn);

            //    // if they failed in their final round, consider it over
            //    if (finalround)
            //    {

            //        TriggerEndGame(WhichPlayerTurn());
            //    }
            //}

            //debugging options
            //DiceInit();
            Testcases();

           
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
            if (currentGame.CurrentDice[0] == null)
            {
                MessageBox.Show("You must roll first!");
                return;
            }
            
            int win = currentGame.PlayerScores();

            if (win == 1)
            {
                // player 2 gets their final turn
            }
            else if (win == 2){
                TriggerEndGame(currentGame.WhoWon());
            }

            UpdateTextBoxes();

            // this is supposed to be instead: in a round of 3 people, if the person who went first wins, then the other
            // 2 get to finish their turn, otherwise its game over. wtf is this shit
            // if its the final round
            //if (currentGame.FinalRound == true) // TODO: REWORK THIS FUCKING SHIT BECAUSE ITS INCORRECT

            //{
            //    handler("In final rounds");
            //    if (currentPlayer == player1)
            //    {
            //        // if their score is higher, hand it back for one more turn
            //        if (player1.Score >= player2.Score)
            //        {
            //            handler("Score is greater or equal, doing one more round");
            //            MessageBox.Show("They caught up! Quick run away!");
            //            player1Turn = false;
            //            UpdateTextBoxes();
            //        }
            //        else // if it isnt, call the other person the winner
            //        {
            //            handler("Triggering endgame");
            //            TriggerEndGame(player2);
            //        };

            //    }
            //    else
            //    {
            //        // if their score is higher, hand it back for one more turn
            //        if (player2.Score >= player1.Score)
            //        {
            //            handler("Score is greater or equal, doing one more round");
            //            MessageBox.Show("They caught up! Quick run away!");
            //            player1Turn = true;
            //            UpdateTextBoxes();
            //        }
            //        else // if it isnt, call the other person the winner
            //        {
            //            handler("Triggering endgame");
            //            TriggerEndGame(player1);
            //        };
            //    }

            //}
            //else
            //{
            //    //handler("Turn before: " + player1Turn);
            //    //player1Turn = !player1Turn;
            //    //handler("Inverting turn " + player1Turn);
            //}

            //// check if they have 13 points, we only run this if we are not in the final round
            //if (finalround == false)
            //{
            //    if (CheckScore(currentPlayer))
            //    {
            //        MessageBox.Show("You have 1 round to catch them!");
            //    }
            //}


            //// make sure to invert turn when done

            //Testcases();
            //handler("Player1's turn? " + player1Turn);
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


            handler("\nDone");
        }

        private void UpdateTextBoxes()
        {
            turnTxtbox.Text = currentGame.TurnString;

            // for the turn information in the middle
            turnBrainsTxt.Text = currentGame.ThisTurnBrains.ToString();
            turnShotgunTxt.Text = currentGame.ThisTurnShotguns.ToString();

            Dice[] currentDice = currentGame.CurrentDice;

            // set the background color to the dice that is being used
            textBox1.BackColor = currentDice[0].DiceColor;
            textBox1.Text = currentDice[0].CurrentVal.ToString();

            textBox2.BackColor = currentDice[1].DiceColor;
            textBox2.Text = currentDice[1].CurrentVal.ToString();

            textBox3.BackColor = currentDice[2].DiceColor;
            textBox3.Text = currentDice[2].CurrentVal.ToString();

            // update score boxes
            plyr1Brains.Text = currentGame.player1.Score.ToString();
            plyr2Brains.Text = currentGame.player2.Score.ToString();

            cupTxtbox.Text = currentGame.DiceLeft.ToString() ;

            handler("==========");
        }

        private void TriggerEndGame(Player player)
        {
            //timer1.Stop();
            // announce the winner
            string _ = "";
            if (player == currentGame.player1)
            {
                _ = "Player 1";
            }
            else
            {
                _ = "Player 2";
            }

            MessageBox.Show($"Congratualtions {_}, you won!");


            // reset everything
            currentGame = new GameState(YELLOWDICENUM, REDDICENUM, GREENDICENUM);

            UpdateTextBoxes();
        }


        private void forTesting_Click(object sender, EventArgs e)
        {
            currentGame.player1.Score = 12;
            currentGame.player2.Score = 11;
            UpdateTextBoxes();
        }
    }
}
