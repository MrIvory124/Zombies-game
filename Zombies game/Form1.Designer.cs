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
            this.components = new System.ComponentModel.Container();
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
            this.label6 = new System.Windows.Forms.Label();
            this.plyr2Brains = new System.Windows.Forms.TextBox();
            this.stopScoreBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.turnBrainsTxt = new System.Windows.Forms.TextBox();
            this.turnShotgunTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.turnTxtbox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.forTesting = new System.Windows.Forms.Button();
            this.cupTxtbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(216, 322);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dice";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(341, 322);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dice";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(477, 322);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Dice";
            // 
            // diceRollBtn
            // 
            this.diceRollBtn.Location = new System.Drawing.Point(309, 370);
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
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 3;
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
            // plyr2Brains
            // 
            this.plyr2Brains.Location = new System.Drawing.Point(644, 58);
            this.plyr2Brains.Name = "plyr2Brains";
            this.plyr2Brains.Size = new System.Drawing.Size(100, 20);
            this.plyr2Brains.TabIndex = 4;
            // 
            // stopScoreBtn
            // 
            this.stopScoreBtn.Location = new System.Drawing.Point(400, 370);
            this.stopScoreBtn.Name = "stopScoreBtn";
            this.stopScoreBtn.Size = new System.Drawing.Size(75, 23);
            this.stopScoreBtn.TabIndex = 5;
            this.stopScoreBtn.Text = "Stop";
            this.stopScoreBtn.UseVisualStyleBackColor = true;
            this.stopScoreBtn.Click += new System.EventHandler(this.stopScoreBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(373, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Brains";
            // 
            // turnBrainsTxt
            // 
            this.turnBrainsTxt.Location = new System.Drawing.Point(15, 46);
            this.turnBrainsTxt.Name = "turnBrainsTxt";
            this.turnBrainsTxt.Size = new System.Drawing.Size(100, 20);
            this.turnBrainsTxt.TabIndex = 4;
            // 
            // turnShotgunTxt
            // 
            this.turnShotgunTxt.Location = new System.Drawing.Point(15, 101);
            this.turnShotgunTxt.Name = "turnShotgunTxt";
            this.turnShotgunTxt.Size = new System.Drawing.Size(100, 20);
            this.turnShotgunTxt.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 145);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(630, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 145);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(186, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 129);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cupTxtbox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.turnShotgunTxt);
            this.groupBox4.Controls.Add(this.turnBrainsTxt);
            this.groupBox4.Location = new System.Drawing.Point(327, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(130, 193);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "This turn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Shotguns";
            // 
            // turnTxtbox
            // 
            this.turnTxtbox.Location = new System.Drawing.Point(342, 265);
            this.turnTxtbox.Name = "turnTxtbox";
            this.turnTxtbox.Size = new System.Drawing.Size(100, 20);
            this.turnTxtbox.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            // 
            // forTesting
            // 
            this.forTesting.Location = new System.Drawing.Point(27, 415);
            this.forTesting.Name = "forTesting";
            this.forTesting.Size = new System.Drawing.Size(75, 23);
            this.forTesting.TabIndex = 7;
            this.forTesting.Text = "Fake scores";
            this.forTesting.UseVisualStyleBackColor = true;
            this.forTesting.Click += new System.EventHandler(this.forTesting_Click);
            // 
            // cupTxtbox
            // 
            this.cupTxtbox.Location = new System.Drawing.Point(15, 148);
            this.cupTxtbox.Name = "cupTxtbox";
            this.cupTxtbox.Size = new System.Drawing.Size(100, 20);
            this.cupTxtbox.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Dice in cup";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.forTesting);
            this.Controls.Add(this.stopScoreBtn);
            this.Controls.Add(this.plyr2Brains);
            this.Controls.Add(this.turnTxtbox);
            this.Controls.Add(this.plyr1Brains);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.diceRollBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox plyr2Brains;
        private System.Windows.Forms.Button stopScoreBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox turnBrainsTxt;
        private System.Windows.Forms.TextBox turnShotgunTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox turnTxtbox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button forTesting;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox cupTxtbox;
    }
}

