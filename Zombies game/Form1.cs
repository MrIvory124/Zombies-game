using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Zombies_game
{
    public partial class Form1 : Form
    {
        //public delegate void Callback(string message);
       
        // delegate for consolewriting
        //public static void DelegateMethod(string message)
        //{
        //    Console.WriteLine(message);
        //}

        //// Instantiate the delegate.
        //readonly Callback handler = DelegateMethod;

        // constants for the number of dice
        const int REDDICENUM = 3;
        const int GREENDICENUM = 6;
        const int YELLOWDICENUM = 4;

        Random rand = new Random();

        GameState currentGame;

        /// <summary>
        /// For creating the game form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            currentGame = new GameState(YELLOWDICENUM, REDDICENUM, GREENDICENUM);
            turnTxtbox.Text = "Player 1"; // this might be an error
            
        }

        /// <summary>
        /// The player has clicked this button if they want to keep rolling. 
        /// What it does is roll the dice, it also checks some game logic around whether someone 
        /// has won or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diceRollbtn_Click(object sender, EventArgs e)
        {
            DisableInterface();
            currentGame.RollAllDice(); // there is a problem here, we are automatically adding dice to the dice array at the beginning of each
            // players turn which means they just straight up get less dice to roll with. Maybe add a check to see if the dice is exactly
            // 10 and just roll those dice in the dice thing instead of getting new ones.
            bool isTurnOver = currentGame.IsTurnOver(); // triggers here

            UpdateTextBoxes();

            if (isTurnOver)
            {
                // in the case that the 2nd player gets gunned down, and its their final turn
                if (currentGame.FinalRound == true && currentGame.Turn == currentGame.player1)
                {
                    MessageBox.Show("You got gunned down!");
                    // player 2 scored above or at 13, game is over
                    TriggerEndGame(currentGame.player1);
                    UpdateTextBoxes();
                }
                else
                {
                    MessageBox.Show("You got gunned down!");
                    //currentGame.PlayerNotScores();
                    currentGame.pubInitDice();
                }

            }
            UpdateTextBoxes();
            EnableInterface();
           
        }

        /// <summary>
        /// The player has clicked this button if they want to score all the brains that they have.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopScoreBtn_Click(object sender, EventArgs e)
        {
            DisableInterface();
            // quick test to see if the user pressed the roll button
            if (currentGame.CurrentDice[0] == null)
            {
                MessageBox.Show("You must roll first!");
                return;
            }
            
            int win = currentGame.PlayerScores();
            UpdateTextBoxes();
            // if we are in the final round
            if (currentGame.FinalRound == true)
            {
                // check to see which player just had their turn
                Console.WriteLine("Checking winner");
                if (currentGame.player1.Score > currentGame.player2.Score)
                {
                    TriggerEndGame(currentGame.player1);
                }
                else if (currentGame.player1.Score < currentGame.player2.Score)
                {
                    TriggerEndGame(currentGame.player2);
                }
                else // player 2 wins because they caught them
                {
                    TriggerEndGame(currentGame.player2);
                }
            }
            else // if we are not in the final round
            {
                if (win == 1) // in the case that its player 2's turn
                {
                    TriggerEndGame(currentGame.WhoWon());
                    UpdateTextBoxes();
                }
                else if (win == 2) // in the case that its player 1's turn
                {
                    currentGame.FinalRound = true; // make it the final round
                    UpdateTextBoxes();
                    MessageBox.Show("Player 2, you have 1 round to catch them!");
                }
            }

            // redo the dice list for the next player to start fresh
            currentGame.pubInitDice();

            // clear things
            UpdateTextBoxes();
            EnableInterface();
        }

        /// <summary>
        /// This method updates all of the text boxes based on information in the respective classes.
        /// </summary>
        private void UpdateTextBoxes()
        {
            turnTxtbox.Text = currentGame.TurnString;
            roundNumtxtbox.Text = currentGame.RoundNum.ToString();

            // for the turn information in the middle
            turnBrainsTxt.Text = currentGame.ThisTurnBrains.ToString();
            turnShotgunTxt.Text = currentGame.ThisTurnShotguns.ToString();

            // prepare the array for displaying
            Dice[] currentDice = currentGame.CurrentDice;

            // try, set the background color/face to the dice that is being used
            if (!(currentDice[0] == null))
            {

                textBox1.BackColor = currentDice[0].DiceColor;
                textBox1.Text = currentDice[0].CurrentVal.ToString();

                textBox2.BackColor = currentDice[1].DiceColor;
                textBox2.Text = currentDice[1].CurrentVal.ToString();

                textBox3.BackColor = currentDice[2].DiceColor;
                textBox3.Text = currentDice[2].CurrentVal.ToString();
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox1.Text = "";

                textBox2.BackColor = Color.White;
                textBox2.Text = "";

                textBox3.BackColor = Color.White;
                textBox3.Text = "";
            }

            // update score boxes
            plyr1Brains.Text = currentGame.player1.Score.ToString();
            plyr2Brains.Text = currentGame.player2.Score.ToString();

            int redDice = 0;
            int greenDice = 0;
            int yellowDice = 0;
            foreach (var dice in currentGame.DiceInCup) {

                if (dice is GDice) { greenDice++; };
                if (dice is RDice) { redDice++; };
                if (dice is YDice) { yellowDice++; };
            }

            redDiceTxt.Text = redDice.ToString();
            greenDiceTxt.Text = greenDice.ToString();
            yellowDiceTxt.Text = yellowDice.ToString();

            cupTxtbox.Text = currentGame.DiceLeft.ToString() ;
        }

        /// <summary>
        /// This disables the buttons, this will be helpful for when using rolling animations
        /// </summary>
        private void DisableInterface()
        {
            diceRollBtn.Enabled = false;
            stopScoreBtn.Enabled = false;
        }

        /// <summary>
        /// .This is code for reenabling the buttons
        /// </summary>
        private void EnableInterface()
        {
            diceRollBtn.Enabled = true;
            stopScoreBtn.Enabled = true;
        }

        /// <summary>
        /// This is the code that handles when someone has won
        /// </summary>
        /// <param name="player"></param>
        private void TriggerEndGame(Player player)
        {
            // determine and announce the winner
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
            currentGame.pubInitDice();

            UpdateTextBoxes();
        }

        /// <summary>
        /// This is a method for testing purposes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forTesting_Click(object sender, EventArgs e)
        {
            currentGame.player1.Score = 12;
            currentGame.player2.Score = 11;
            UpdateTextBoxes();
        }
    }
}
