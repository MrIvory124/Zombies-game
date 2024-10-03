using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies_game
{
    public class GameState
    {
        // fields 
        Random random = new Random();

        // create the player
        Player player1 = new Player();
        Player player2 = new Player(); // this can be a bot, change list later

        // for monitoring which players turn it is
        private Player _playerTurn;
        // seeing if we are in the final round of the game
        private bool _finalRound;

        private int _roundNum;
        // for keeping track of this persons score and shotguns
        private int _turnScore;
        private int _turnShotguns;

        private Dice[] rolledDice = new Dice[3]; // array for the 3 rolled dice
        private List<Dice> diceList; // list for all 13 dice

        // constructor
        public GameState(int yDiceNum, int rDiceNum, int gDiceNum) {
        diceList = new List<Dice>();

            RoundNum = 0;
            _playerTurn = player1;
            ThisTurnShotguns = 0;
            ThisTurnBrains = 0;
            _finalRound = false;
            InitDice(yDiceNum, rDiceNum, gDiceNum);
        }

        // getter setters
        // toggle for changing turns
        public Player Turn
        {
            get { return _playerTurn; }
        }

        // getter setter for toggling the final round bool
        public bool FinalRound
        {
            get { return _finalRound; }
            set { _finalRound = !_finalRound; }
        }

        // incrementing and asking for round number
        public int RoundNum
        {
            get { return _roundNum; }
            set { _roundNum += 1; }
        }

        // incrementing and asking for round number

        public int ThisTurnShotguns
        {
            get { return _turnShotguns; }
            set { _turnShotguns = value; }
        }

        public int ThisTurnBrains
        {
            get { return _turnScore; }
            set { _turnScore = value; }
        }

        // methods
        /// <summary>
        /// This method creates the array of 13 dice that is used for the game
        /// </summary>
        /// <param name="yDiceNum"></param>
        /// <param name="rDiceNum"></param>
        /// <param name="gDiceNum"></param>
        private void InitDice(int yDiceNum, int rDiceNum, int gDiceNum)
        {
            diceList = new List<Dice>();

            // initialise all the dice
            for (int i = 0; i < yDiceNum; i++)
            {
                diceList.Add(new YDice());
            }

            for (int i = 0; i < rDiceNum; i++)
            {
                diceList.Add(new RDice());
            }

            for (int i = 0; i < gDiceNum; i++)
            {
                diceList.Add(new GDice());
            }

        }

        /// <summary>
        /// This method rolls the 3 dice that are in the dice array, after checking if they
        /// can be swapped out.
        /// </summary>
        public void RollAllDice()
        {
            // check if any dice in the rolledDice array are feet
            int diceIndex = 0;
            foreach (Dice dice in rolledDice)
            { 
                if (dice.CurrentVal == Dice.ZombieOptions.Feet)
                {
                    // do nothing
                    Console.WriteLine("Face is feet");
                }
                else
                {
                    Console.WriteLine("Face is shotgun/brains");
                    int nextDice = random.Next(diceList.Count)
                    rolledDice[diceIndex]= diceList[nextDice];
                    // remove from the list as we are done
                    diceList.Remove(dice);
                }
                diceIndex++;

                // then roll it
                dice.RollDie();
            }

        }

        /// <summary>
        /// This method switches which players turn it is
        /// </summary>
        public void SwitchTurn()
        {
            if (_playerTurn == player1)
            {
                _playerTurn = player2;
            }
            else
            {
                // if player 2 just finished their turn, increment the round counter
                RoundNum += 1;
                _playerTurn = player1;
            }
        }

        /// <summary>
        /// This method checks if the person who is going has been shot and 
        /// switches provided they have
        /// </summary>
        public void IsTurnOver() {
            if (ThisTurnShotguns >= 3)
            {
                Console.WriteLine("Shotgun check returned true");
                PlayerNotScores();
                this.SwitchTurn();
            }

            Console.WriteLine("Shotgun check returned false");

        }

        /// <summary>
        /// If the player scores, update their score
        /// </summary>
        public void PlayerScores()
        {
            _playerTurn.Score += ThisTurnBrains;
            // if the player has enough points to win
            if (_playerTurn.Score >= 13) {
                // if the player is player 2
                if (_playerTurn == player2)
                {
                    // end the game
                }
                else 
                {
                    // enable the final round to allow player 2 one more turn to catch them
                    FinalRound = true;
                }

            }
            PlayerNotScores();
        }

        /// <summary>
        /// If the player does not score, reset things and invert their turn
        /// </summary>
        public void PlayerNotScores()
        {
            ThisTurnBrains = 0;
            ThisTurnShotguns = 0;
            this.SwitchTurn();
        }

    }
}
