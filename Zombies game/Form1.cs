using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Zombies_game
{
    public partial class Form1 : Form
    {
        // array for the dice
        protected Dice[] diceArray;

        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This button rolls the dice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diceRollbtn_Click(object sender, EventArgs e)
        {
            DiceInit();

            textBox1.BackColor = diceArray[0].DiceColor;
            textBox1.Text = (diceArray[0].RollDie()).ToString();

            Testcases();

        }

        /// <summary>
        /// Method for creating all 13 dice
        /// </summary>
        private void DiceInit()
        {
            diceArray = new Dice[13];

            for (int i = 0; i < diceArray.Length; i++)
            {
                diceArray[i] = new GDice();
            }
        }

        private void Testcases()
        {
            // list for temp dice
            List<Dice> diceList = new List<Dice>();
            // check that all dice are generating with faces

            Console.WriteLine("Generating dice");

            diceList.Add(new GDice());
            diceList.Add(new YDice());
            //diceList.Add(new RDice());

            foreach (Dice dice in diceList)
            {
                Console.WriteLine($"Checking dice {dice}");
                foreach (Dice.ZombieOptions item in dice.Facelist)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine($"Checking roll func {dice.RollDie()}");
                Console.WriteLine();

            }



        }

    }
}
