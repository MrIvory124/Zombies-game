using System;
using System.Collections.Generic;

namespace Zombies_game
{
    public class GameState
    {
        // fields 
        Random random = new Random();

        // create the players
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
        private List<Dice> shotgunDice;

        // ints for keeping track of how many dice there are
        private int _yDice;
        private int _rDice;
        private int _gDice;

        private Dice[] rolledDice = new Dice[3];
        private List<Dice> diceList;
        private List<Dice> removedDiceLst;

        // constructor
        public GameState(int yDiceNum, int rDiceNum, int gDiceNum)
        {
            // default constructor initialises things
            diceList = new List<Dice>();

            _yDice = yDiceNum;
            _rDice = rDiceNum;
            _gDice = gDiceNum;

            RoundNum = 0;
            _playerTurn = player1;
            ThisTurnShotguns = 0;
            shotgunDice = new List<Dice>();
            ThisTurnBrains = 0;
            _finalRound = false;
            InitDice(_yDice, _rDice, _gDice);
        }

        // getter setters

        public Player Turn
        {
            get { return _playerTurn; }
        }

        public bool FinalRound
        {
            get { return _finalRound; }
            set { _finalRound = value; ; }
        }

        public int RoundNum
        {
            get { return _roundNum; }
            set { _roundNum += 1; }
        }

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

        // Getting a string for which players turn it is
        public string TurnString
        {
            get { if (Turn == player1) { return "Player 1"; } else { return "Player 2"; }; }
        }

        public Dice[] CurrentDice
        {
            get { return rolledDice; }
        }

        public int DiceLeft
        {
            get { return diceList.Count; }
        }


        // methods
        /// <summary>
        /// This is the method for when a class outside of this wants to redo the dice list
        /// this should be changed to shuffle around the dice that exist currently rather than just calling for new objects
        /// </summary>
        public void pubInitDice()
        {
            // InitDice(_yDice, _rDice, _gDice);
            // take all the dice from the rolled pile and add them to the main list
            for (int i = removedDiceLst.Count - 1; i >= 0; i--)
            {
                if (!(shotgunDice.Contains(removedDiceLst[i])))
                {
                    diceList.Add(removedDiceLst[i]);
                    removedDiceLst.RemoveAt(i);
                }

            }
        }

        /// <summary>
        /// This method creates the array of 13 dice that is used for the game
        /// </summary>
        /// <param name="yDiceNum"></param>
        /// <param name="rDiceNum"></param>
        /// <param name="gDiceNum"></param>
        private void InitDice(int yDiceNum, int rDiceNum, int gDiceNum)
        {
            diceList = new List<Dice>();
            removedDiceLst = new List<Dice>();

            // initialise all the dice
            Console.WriteLine("recreating list");
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
            Console.WriteLine($"Init Dicelist has {diceList.Count} and removeddicelist has {removedDiceLst.Count}");
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
                for (int i = 0; i < 3; i++)
                {
                    // pull random dice from dicelist
                    int randomLocation = random.Next(diceList.Count);
                    rolledDice[i] = diceList[randomLocation];
                    removedDiceLst.Add(diceList[randomLocation]);
                    diceList.RemoveAt(randomLocation);

                    // the below code is repeated, this only runs once though, first time roll is pressed

                    // then roll it
                    rolledDice[i].RollDie();

                    // add to points for this round
                    if (rolledDice[i].CurrentVal == Dice.ZombieOptions.Brains)
                    {
                        ThisTurnBrains += 1;
                    }
                    // add shotguns if appropriate
                    else if (rolledDice[i].CurrentVal == Dice.ZombieOptions.Shotgun)
                    {
                        ThisTurnShotguns += 1;
                        shotgunDice.Add(rolledDice[i]);
                    }
                }
            }
            else
            {
                // check if any dice in the rolledDice array are feet
                for (int i = 0; i < rolledDice.Length; i++)
                {
                    if (rolledDice[i].CurrentVal == Dice.ZombieOptions.Feet)
                    {
                        // If the die is Feet, do nothing
                    }
                    else
                    {
                        int nextDice = random.Next(diceList.Count);
                        try // roll the die
                        {
                            rolledDice[i] = diceList[nextDice];
                        }
                        catch // if error reset the list, in this case there are no dice left
                        {
                            pubInitDice();
                            rolledDice[i] = diceList[nextDice];
                        }

                        // remove from the list as we are done
                        removedDiceLst.Add(rolledDice[i]);
                        diceList.Remove(rolledDice[i]);
                    }

                    // then roll it
                    rolledDice[i].RollDie();

                    // add to points for this round
                    if (rolledDice[i].CurrentVal == Dice.ZombieOptions.Brains)
                    {
                        ThisTurnBrains += 1;
                    }
                    // add shotguns if appropriate
                    else if (rolledDice[i].CurrentVal == Dice.ZombieOptions.Shotgun)
                    {
                        ThisTurnShotguns += 1;
                        shotgunDice.Add(rolledDice[i]);
                    }

                }

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
        public bool IsTurnOver()
        {
            if (ThisTurnShotguns >= 3)
            {
                Console.WriteLine("Shotgun check returned true");
                PlayerNotScores();
                return true;
            }

            Console.WriteLine("Shotgun check returned false");
            return false;

        }

        /// <summary>
        /// This returns 0-2 for each outcome. 
        /// 1 means that it was player 2 who scored 13.
        /// 2 means it was player 1 that scored 13.
        /// 0 means no one scored 13, and we can move on.
        /// </summary>
        public int PlayerScores()
        {
            _playerTurn.Score += ThisTurnBrains;
            // if the player has enough points to win
            if (_playerTurn.Score >= 13)
            {
                // if the player is player 2, do not allow another turn
                if (_playerTurn == player2)
                {
                    _finalRound = true;
                    PlayerNotScores();
                    return 1;
                }
                else // if it was player 1, player 2 gets one more turn
                {
                    // enable the final round to allow player 2 one more turn to catch them
                    PlayerNotScores();
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
            shotgunDice = new List<Dice>();
            Console.WriteLine(removedDiceLst.Count.ToString());
            // put all the dice objects back into the dicelist
            // reset the lists
            for (int i = removedDiceLst.Count - 1; i >= 0; i--)
            {
                diceList.Add(removedDiceLst[i]);
                removedDiceLst.RemoveAt(i);
            }

            // clear the dice in hand
            for (int i = 0; i < rolledDice.Length; i++)
            {
                rolledDice[i] = null;
            }

            Console.WriteLine("turn being switched");
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
