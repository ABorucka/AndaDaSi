namespace project
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.timerMarmaidMove = new System.Windows.Forms.Timer(this.components);
            this.oxygen_label = new System.Windows.Forms.Label();
            this.oxygen_progers = new System.Windows.Forms.ProgressBar();
            this.points_label = new System.Windows.Forms.Label();
            this.points_display = new System.Windows.Forms.Label();
            this.timerOxygen = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 426);
            this.panel1.TabIndex = 0;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MoveClick);
            // 
            // oxygen_label
            // 
            this.oxygen_label.AutoSize = true;
            this.oxygen_label.Location = new System.Drawing.Point(593, 26);
            this.oxygen_label.Name = "oxygen_label";
            this.oxygen_label.Size = new System.Drawing.Size(56, 17);
            this.oxygen_label.TabIndex = 1;
            this.oxygen_label.Text = "Oxygen";
            // 
            // oxygen_progers
            // 
            this.oxygen_progers.Location = new System.Drawing.Point(593, 61);
            this.oxygen_progers.Name = "oxygen_progers";
            this.oxygen_progers.Size = new System.Drawing.Size(204, 23);
            this.oxygen_progers.TabIndex = 2;
            this.oxygen_progers.Value = 100;
            // 
            // points_label
            // 
            this.points_label.AutoSize = true;
            this.points_label.Location = new System.Drawing.Point(593, 122);
            this.points_label.Name = "points_label";
            this.points_label.Size = new System.Drawing.Size(47, 17);
            this.points_label.TabIndex = 3;
            this.points_label.Text = "Points";
            // 
            // points_display
            // 
            this.points_display.BackColor = System.Drawing.SystemColors.ControlLight;
            this.points_display.Location = new System.Drawing.Point(593, 150);
            this.points_display.Name = "points_display";
            this.points_display.Size = new System.Drawing.Size(123, 23);
            this.points_display.TabIndex = 4;
            this.points_display.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.points_display);
            this.Controls.Add(this.points_label);
            this.Controls.Add(this.oxygen_progers);
            this.Controls.Add(this.oxygen_label);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerMarmaidMove;
        private System.Windows.Forms.Label oxygen_label;
        private System.Windows.Forms.ProgressBar oxygen_progers;
        private System.Windows.Forms.Label points_label;
        private System.Windows.Forms.Label points_display;
        private System.Windows.Forms.Timer timerOxygen;
    }
}

