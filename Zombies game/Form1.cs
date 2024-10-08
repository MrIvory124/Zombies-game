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

        const int REDDICENUM = 3;
        const int GREENDICENUM = 6;
        const int YELLOWDICENUM = 4;

        const int totalDice = REDDICENUM + GREENDICENUM + YELLOWDICENUM;

        Random rand = new Random();

        GameState currentGame;

        public Form1()
        {
            InitializeComponent();
            currentGame = new GameState(YELLOWDICENUM, REDDICENUM, GREENDICENUM);
            turnTxtbox.Text = "Player 1"; // this might be an error
            
        }

        /// <summary>
        /// This button rolls the dice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diceRollbtn_Click(object sender, EventArgs e)
        {
            DisableInterface();
            currentGame.RollAllDice();
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
        /// If the player clicks the stop button, we move to scoring for
        /// the other player
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
            if (currentGame.FinalRound == true)
            {
                Console.WriteLine("Checking winner");
                if (currentGame.player1.Score > currentGame.player2.Score)
                {
                    TriggerEndGame(currentGame.player1);
                }
                else if (currentGame.player1.Score < currentGame.player2.Score)
                {
                    TriggerEndGame(currentGame.player2);
                }
                else // player 1 wins by default
                {
                    TriggerEndGame(currentGame.player1);
                    Console.WriteLine("tie");
                }
            }
            else
            {
                if (win == 1)
                {
                    // player 2 scored above or at 13, game is over
                    TriggerEndGame(currentGame.WhoWon());
                    Console.WriteLine(win);
                    UpdateTextBoxes();
                }
                else if (win == 2)
                {
                    // player 1 scored at or above 13, player 2 gets one more turn
                    Console.WriteLine(win);
                    currentGame.FinalRound = true;
                    UpdateTextBoxes();
                    MessageBox.Show("Player 2, you have 1 round to catch them!");
                }
            }

            // redo the dice list for the next player to start fresh
            currentGame.pubInitDice();

            UpdateTextBoxes();
            EnableInterface();
        }

        private void UpdateTextBoxes()
        {
            turnTxtbox.Text = currentGame.TurnString;
            roundNumtxtbox.Text = currentGame.RoundNum.ToString();

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

        private void DisableInterface()
        {
            diceRollBtn.Enabled = false;
            stopScoreBtn.Enabled = false;
        }

        private void EnableInterface()
        {
            diceRollBtn.Enabled = true;
            stopScoreBtn.Enabled = true;
        }

        private void TriggerEndGame(Player player)
        {
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
            currentGame.pubInitDice();

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
