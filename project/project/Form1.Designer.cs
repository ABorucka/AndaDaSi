namespace project
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
			this.timerMarmaidMove = new System.Windows.Forms.Timer(this.components);
			this.oxygen_label = new System.Windows.Forms.Label();
			this.oxygen_progers = new System.Windows.Forms.ProgressBar();
			this.points_label = new System.Windows.Forms.Label();
			this.points_display = new System.Windows.Forms.Label();
			this.timerOxygen = new System.Windows.Forms.Timer(this.components);
			this.timerSpikeMove = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// theOcean
			// 
			this.theOcean.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.theOcean.Location = new System.Drawing.Point(9, 10);
			this.theOcean.Margin = new System.Windows.Forms.Padding(2);
			this.theOcean.Name = "theOcean";
			this.theOcean.Size = new System.Drawing.Size(599, 450);
			this.theOcean.TabIndex = 0;
			this.theOcean.Paint += new System.Windows.Forms.PaintEventHandler(this.theOcean_Paint);
			this.theOcean.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MoveClick);
			// 
			// oxygen_label
			// 
			this.oxygen_label.AutoSize = true;
			this.oxygen_label.Location = new System.Drawing.Point(612, 22);
			this.oxygen_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.oxygen_label.Name = "oxygen_label";
			this.oxygen_label.Size = new System.Drawing.Size(43, 13);
			this.oxygen_label.TabIndex = 1;
			this.oxygen_label.Text = "Oxygen";
			// 
			// oxygen_progers
			// 
			this.oxygen_progers.Location = new System.Drawing.Point(612, 48);
			this.oxygen_progers.Margin = new System.Windows.Forms.Padding(2);
			this.oxygen_progers.Name = "oxygen_progers";
			this.oxygen_progers.Size = new System.Drawing.Size(153, 19);
			this.oxygen_progers.TabIndex = 2;
			this.oxygen_progers.Value = 100;
			// 
			// points_label
			// 
			this.points_label.AutoSize = true;
			this.points_label.Location = new System.Drawing.Point(612, 107);
			this.points_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.points_label.Name = "points_label";
			this.points_label.Size = new System.Drawing.Size(36, 13);
			this.points_label.TabIndex = 3;
			this.points_label.Text = "Points";
			// 
			// points_display
			// 
			this.points_display.BackColor = System.Drawing.SystemColors.ControlLight;
			this.points_display.Location = new System.Drawing.Point(612, 133);
			this.points_display.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.points_display.Name = "points_display";
			this.points_display.Size = new System.Drawing.Size(92, 19);
			this.points_display.TabIndex = 4;
			this.points_display.Text = "0";
			// 
			// timerSpikeMove
			// 
			this.timerSpikeMove.Tick += new System.EventHandler(this.timerSpikeMove_Tick);
			// 
			// UnderTheSea
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 463);
			this.Controls.Add(this.points_display);
			this.Controls.Add(this.points_label);
			this.Controls.Add(this.oxygen_progers);
			this.Controls.Add(this.oxygen_label);
			this.Controls.Add(this.theOcean);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "UnderTheSea";
			this.Text = "Under the Sea";
			this.Load += new System.EventHandler(this.UnderTheSea_Load);
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
	}
}

