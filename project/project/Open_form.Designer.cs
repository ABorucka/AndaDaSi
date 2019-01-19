namespace project
{
    partial class Open_form
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
            this.title = new System.Windows.Forms.Label();
            this.choose_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Instruction = new System.Windows.Forms.Button();
            this.sound = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Gabriola", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.title.Location = new System.Drawing.Point(277, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(226, 81);
            this.title.TabIndex = 0;
            this.title.Text = "Under the sea";
            // 
            // choose_label
            // 
            this.choose_label.AutoSize = true;
            this.choose_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.choose_label.Location = new System.Drawing.Point(274, 109);
            this.choose_label.Name = "choose_label";
            this.choose_label.Size = new System.Drawing.Size(238, 25);
            this.choose_label.TabIndex = 1;
            this.choose_label.Text = "Choose your character:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(324, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Start_Click);
            // 
            // Instruction
            // 
            this.Instruction.Location = new System.Drawing.Point(618, 411);
            this.Instruction.Name = "Instruction";
            this.Instruction.Size = new System.Drawing.Size(125, 35);
            this.Instruction.TabIndex = 3;
            this.Instruction.Text = "INSTRUCTION";
            this.Instruction.UseVisualStyleBackColor = true;
            this.Instruction.Click += new System.EventHandler(this.Instruction_Click);
            // 
            // sound
            // 
            this.sound.BackColor = System.Drawing.Color.Tan;
            this.sound.BackgroundImage = global::project.Properties.Resources.volume_on;
            this.sound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sound.Location = new System.Drawing.Point(749, 398);
            this.sound.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sound.Name = "sound";
            this.sound.Size = new System.Drawing.Size(49, 48);
            this.sound.TabIndex = 8;
            this.sound.UseVisualStyleBackColor = false;
            this.sound.Click += new System.EventHandler(this.sound_Click);
            // 
            // Open_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::project.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sound);
            this.Controls.Add(this.Instruction);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.choose_label);
            this.Controls.Add(this.title);
            this.Name = "Open_form";
            this.Text = "Open_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label choose_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Instruction;
        private System.Windows.Forms.Button sound;
    }
}