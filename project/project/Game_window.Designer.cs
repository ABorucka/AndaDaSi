﻿namespace project
{
    partial class UnderTheSea
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
            this.theOcean = new System.Windows.Forms.Panel();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.playAgainButton = new System.Windows.Forms.Button();
            this.timerMarmaidMove = new System.Windows.Forms.Timer(this.components);
            this.oxygen_label = new System.Windows.Forms.Label();
            this.oxygen_progers = new System.Windows.Forms.ProgressBar();
            this.points_label = new System.Windows.Forms.Label();
            this.points_display = new System.Windows.Forms.Label();
            this.timerOxygen = new System.Windows.Forms.Timer(this.components);
            this.timerSpikeMove = new System.Windows.Forms.Timer(this.components);
            this.jumpButton = new System.Windows.Forms.Button();
            this.sound = new System.Windows.Forms.Button();
            this.seagull = new System.Windows.Forms.PictureBox();
            this.weed = new System.Windows.Forms.PictureBox();
            this.sea = new System.Windows.Forms.PictureBox();
            this.theOcean.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seagull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sea)).BeginInit();
            this.SuspendLayout();
            // 
            // theOcean
            // 
            this.theOcean.BackColor = System.Drawing.Color.PowderBlue;
            this.theOcean.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.theOcean.Controls.Add(this.weed);
            this.theOcean.Controls.Add(this.sea);
            this.theOcean.Controls.Add(this.gameOverLabel);
            this.theOcean.Location = new System.Drawing.Point(12, 12);
            this.theOcean.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.theOcean.Name = "theOcean";
            this.theOcean.Size = new System.Drawing.Size(799, 554);
            this.theOcean.TabIndex = 0;
            this.theOcean.Paint += new System.Windows.Forms.PaintEventHandler(this.theOcean_Paint);
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.BackColor = System.Drawing.Color.LightCoral;
            this.gameOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameOverLabel.Location = new System.Drawing.Point(284, 231);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(223, 39);
            this.gameOverLabel.TabIndex = 5;
            this.gameOverLabel.Text = "GAME OVER";
            // 
            // playAgainButton
            // 
            this.playAgainButton.BackColor = System.Drawing.Color.LightPink;
            this.playAgainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playAgainButton.Location = new System.Drawing.Point(848, 303);
            this.playAgainButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playAgainButton.Name = "playAgainButton";
            this.playAgainButton.Size = new System.Drawing.Size(135, 39);
            this.playAgainButton.TabIndex = 6;
            this.playAgainButton.Text = "Play again!";
            this.playAgainButton.UseVisualStyleBackColor = false;
            this.playAgainButton.Click += new System.EventHandler(this.PlayAgain_Click);
            // 
            // oxygen_label
            // 
            this.oxygen_label.AutoSize = true;
            this.oxygen_label.Location = new System.Drawing.Point(816, 27);
            this.oxygen_label.Name = "oxygen_label";
            this.oxygen_label.Size = new System.Drawing.Size(56, 17);
            this.oxygen_label.TabIndex = 1;
            this.oxygen_label.Text = "Oxygen";
            // 
            // oxygen_progers
            // 
            this.oxygen_progers.Location = new System.Drawing.Point(816, 59);
            this.oxygen_progers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.oxygen_progers.Name = "oxygen_progers";
            this.oxygen_progers.Size = new System.Drawing.Size(204, 23);
            this.oxygen_progers.TabIndex = 2;
            this.oxygen_progers.Value = 100;
            // 
            // points_label
            // 
            this.points_label.AutoSize = true;
            this.points_label.Location = new System.Drawing.Point(816, 132);
            this.points_label.Name = "points_label";
            this.points_label.Size = new System.Drawing.Size(47, 17);
            this.points_label.TabIndex = 3;
            this.points_label.Text = "Points";
            // 
            // points_display
            // 
            this.points_display.BackColor = System.Drawing.SystemColors.ControlLight;
            this.points_display.Location = new System.Drawing.Point(816, 164);
            this.points_display.Name = "points_display";
            this.points_display.Size = new System.Drawing.Size(123, 23);
            this.points_display.TabIndex = 4;
            this.points_display.Text = "0";
            // 
            // jumpButton
            // 
            this.jumpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.jumpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.jumpButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.jumpButton.Location = new System.Drawing.Point(848, 348);
            this.jumpButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.jumpButton.Name = "jumpButton";
            this.jumpButton.Size = new System.Drawing.Size(135, 117);
            this.jumpButton.TabIndex = 5;
            this.jumpButton.Text = "Jump!";
            this.jumpButton.UseVisualStyleBackColor = false;
            this.jumpButton.Click += new System.EventHandler(this.JumpButton_Click);
            // 
            // sound
            // 
            this.sound.BackColor = System.Drawing.Color.Tan;
            this.sound.BackgroundImage = global::project.Properties.Resources.volume_on;
            this.sound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sound.Location = new System.Drawing.Point(971, 526);
            this.sound.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sound.Name = "sound";
            this.sound.Size = new System.Drawing.Size(49, 48);
            this.sound.TabIndex = 7;
            this.sound.UseVisualStyleBackColor = false;
            this.sound.Click += new System.EventHandler(this.sound_Click);
            // 
            // seagull
            // 
            this.seagull.BackColor = System.Drawing.Color.Transparent;
            this.seagull.BackgroundImage = global::project.Properties.Resources.seagull;
            this.seagull.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.seagull.Location = new System.Drawing.Point(864, 209);
            this.seagull.Name = "seagull";
            this.seagull.Size = new System.Drawing.Size(106, 89);
            this.seagull.TabIndex = 9;
            this.seagull.TabStop = false;
            // 
            // weed
            // 
            this.weed.BackgroundImage = global::project.Properties.Resources.seaweed;
            this.weed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.weed.Location = new System.Drawing.Point(413, 514);
            this.weed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.weed.Name = "weed";
            this.weed.Size = new System.Drawing.Size(385, 50);
            this.weed.TabIndex = 8;
            this.weed.TabStop = false;
            // 
            // sea
            // 
            this.sea.BackgroundImage = global::project.Properties.Resources.seaweed;
            this.sea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sea.Location = new System.Drawing.Point(0, 514);
            this.sea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sea.Name = "sea";
            this.sea.Size = new System.Drawing.Size(413, 50);
            this.sea.TabIndex = 7;
            this.sea.TabStop = false;
            // 
            // UnderTheSea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 578);
            this.Controls.Add(this.seagull);
            this.Controls.Add(this.sound);
            this.Controls.Add(this.jumpButton);
            this.Controls.Add(this.points_display);
            this.Controls.Add(this.playAgainButton);
            this.Controls.Add(this.points_label);
            this.Controls.Add(this.oxygen_progers);
            this.Controls.Add(this.oxygen_label);
            this.Controls.Add(this.theOcean);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "UnderTheSea";
            this.Text = "Under the Sea";
            this.Load += new System.EventHandler(this.UnderTheSea_Load);
            this.theOcean.ResumeLayout(false);
            this.theOcean.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seagull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel theOcean;
        private System.Windows.Forms.Timer timerMarmaidMove;
        private System.Windows.Forms.Label oxygen_label;
        private System.Windows.Forms.ProgressBar oxygen_progers;
        private System.Windows.Forms.Label points_label;
        private System.Windows.Forms.Label points_display;
        private System.Windows.Forms.Timer timerOxygen;
		private System.Windows.Forms.Timer timerSpikeMove;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Button playAgainButton;
        private System.Windows.Forms.PictureBox sea;
        private System.Windows.Forms.PictureBox weed;
		private System.Windows.Forms.Button jumpButton;
        private System.Windows.Forms.Button sound;
        private System.Windows.Forms.PictureBox seagull;
    }
}

