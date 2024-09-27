namespace Zombies_game
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.diceRollBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.plyr1Brains = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.plyr1Shotguns = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.plyr2Brains = new System.Windows.Forms.TextBox();
            this.plyr2Shotguns = new System.Windows.Forms.TextBox();
            this.stopScoreBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(217, 163);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dice";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(342, 163);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dice";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(478, 163);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Dice";
            // 
            // diceRollBtn
            // 
            this.diceRollBtn.Location = new System.Drawing.Point(310, 211);
            this.diceRollBtn.Name = "diceRollBtn";
            this.diceRollBtn.Size = new System.Drawing.Size(75, 23);
            this.diceRollBtn.TabIndex = 2;
            this.diceRollBtn.Text = "Roll";
            this.diceRollBtn.UseVisualStyleBackColor = true;
            this.diceRollBtn.Click += new System.EventHandler(this.diceRollbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Player 1 Brains";
            // 
            // plyr1Brains
            // 
            this.plyr1Brains.Location = new System.Drawing.Point(40, 58);
            this.plyr1Brains.Name = "plyr1Brains";
            this.plyr1Brains.Size = new System.Drawing.Size(100, 20);
            this.plyr1Brains.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Player 1 Shotguns";
            // 
            // plyr1Shotguns
            // 
            this.plyr1Shotguns.Location = new System.Drawing.Point(40, 97);
            this.plyr1Shotguns.Name = "plyr1Shotguns";
            this.plyr1Shotguns.Size = new System.Drawing.Size(100, 20);
            this.plyr1Shotguns.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(658, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Player 2 Brains";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(642, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Player 2 Shotguns";
            // 
            // plyr2Brains
            // 
            this.plyr2Brains.Location = new System.Drawing.Point(644, 58);
            this.plyr2Brains.Name = "plyr2Brains";
            this.plyr2Brains.Size = new System.Drawing.Size(100, 20);
            this.plyr2Brains.TabIndex = 4;
            // 
            // plyr2Shotguns
            // 
            this.plyr2Shotguns.Location = new System.Drawing.Point(644, 97);
            this.plyr2Shotguns.Name = "plyr2Shotguns";
            this.plyr2Shotguns.Size = new System.Drawing.Size(100, 20);
            this.plyr2Shotguns.TabIndex = 4;
            // 
            // stopScoreBtn
            // 
            this.stopScoreBtn.Location = new System.Drawing.Point(401, 211);
            this.stopScoreBtn.Name = "stopScoreBtn";
            this.stopScoreBtn.Size = new System.Drawing.Size(75, 23);
            this.stopScoreBtn.TabIndex = 5;
            this.stopScoreBtn.Text = "Stop";
            this.stopScoreBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stopScoreBtn);
            this.Controls.Add(this.plyr2Shotguns);
            this.Controls.Add(this.plyr2Brains);
            this.Controls.Add(this.plyr1Shotguns);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.plyr1Brains);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.diceRollBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button diceRollBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox plyr1Brains;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox plyr1Shotguns;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox plyr2Brains;
        private System.Windows.Forms.TextBox plyr2Shotguns;
        private System.Windows.Forms.Button stopScoreBtn;
    }
}

