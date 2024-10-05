using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Zombies_game
{
    public class GameState
    {
        // fields 
        Random random = new Random();

        // create the player
        public Player player1 = new Player();
        public Player player2 = new Player(); // this can be a bot, change list later

        // for monitoring which players turn it is
        private Player _playerTurn;
        // seeing if we are in the final round of the game
        private bool _finalRound;

        private int _roundNum;
        // for keeping track of this persons score and shotguns
        private int _turnScore;
        private int _turnShotguns;

        // ints for keeping track of how many dice there are
        private int _yDice;
        private int _rDice;
        private int _gDice;

        private Dice[] rolledDice = new Dice[3]; // array for the 3 rolled dice
        private List<Dice> diceList; // list for all 13 dice

        // constructor
        public GameState(int yDiceNum, int rDiceNum, int gDiceNum) {
        diceList = new List<Dice>();

            _yDice = yDiceNum;
            _rDice = rDiceNum;
            _gDice = gDiceNum;

            RoundNum = 0;
            _playerTurn = player1;
            ThisTurnShotguns = 0;
            ThisTurnBrains = 0;
            _finalRound = false;
            InitDice(_yDice, _rDice, _gDice);
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

        public string TurnString
        {
            get { if (Turn == player1) { return "Player 1"; } else { return "Player 2"; } ; }
        }

        public Dice[] CurrentDice
        {
            get { return rolledDice; }
        }

        public int DiceLeft
        {
            get { return diceList.Count;}
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
            // if there are no dice, initialise
            if (rolledDice[0] == null)
            {
                for (int i = 0;i < 3; i++)
                {
                    // pull random dice from dicelist
                    int randomLocation = random.Next(diceList.Count);
                    rolledDice[i] = diceList[randomLocation];
                    diceList.RemoveAt(randomLocation);
                }
            }

            //if (diceList.Count == 0)
            //{
            //    InitDice(_yDice, _rDice, _gDice);
            //}

            // check if any dice in the rolledDice array are feet
            for (int i = 0; i < rolledDice.Length; i++)
            {
                if (rolledDice[i].CurrentVal == Dice.ZombieOptions.Feet)
                {
                    // If the die is Feet, keep it
                    Console.WriteLine("Face is Feet - keeping the same die");
                }
                else
                {
                    Console.WriteLine("Face is shotgun/brains");
                    int nextDice = random.Next(diceList.Count);
                    try // roll the die
                    {
                        rolledDice[i] = diceList[nextDice];
                    }
                    catch // if error reset the list
                    {
                        InitDice(_yDice, _rDice, _gDice);
                        rolledDice[i] = diceList[nextDice];
                    }

                    // remove from the list as we are done
                    diceList.Remove(rolledDice[i]);
                }

                // then roll it
                rolledDice[i].RollDie();
                Console.WriteLine("Dice rolled: " + rolledDice[i].CurrentVal);
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
        public bool IsTurnOver() {
            if (ThisTurnShotguns >= 3)
            {
                Console.WriteLine("Shotgun check returned true");
                PlayerNotScores();
                this.SwitchTurn();
                return true;
            }

            Console.WriteLine("Shotgun check returned false");
            return false;

        }

        /// <summary>
        /// If the player scores, update their score
        /// </summary>
        public int PlayerScores()
        {
            _playerTurn.Score += ThisTurnBrains;
            // if the player has enough points to win
            if (_playerTurn.Score >= 13) {
                // if the player is player 2
                if (_playerTurn == player2)
                {
                    return 1;
                }
                else 
                {
                    // enable the final round to allow player 2 one more turn to catch them
                    FinalRound = true;
                    return 2;
                }

            }
            
            PlayerNotScores();
            return 0;
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

        /// <summary>
        /// only to be used when the game is done.
        /// </summary>
        /// <returns></returns>
        public Player WhoWon()
        {
            if (player1.Score >= player2.Score)
            {
                return player1;
            }
            else
            {
                return player2;
            }
        }

    }
}
