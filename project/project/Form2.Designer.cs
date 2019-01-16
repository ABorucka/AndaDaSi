namespace project
{
    partial class Instr_window
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
            this.cytat = new System.Windows.Forms.Label();
            this.instruction = new System.Windows.Forms.Label();
            this.instrukcja = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cytat
            // 
            this.cytat.AutoSize = true;
            this.cytat.BackColor = System.Drawing.Color.Transparent;
            this.cytat.Font = new System.Drawing.Font("Mistral", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cytat.Location = new System.Drawing.Point(138, 25);
            this.cytat.Name = "cytat";
            this.cytat.Size = new System.Drawing.Size(504, 60);
            this.cytat.TabIndex = 0;
            this.cytat.Text = "\"Kto nie umiera - żywy jest\"";
            this.cytat.Click += new System.EventHandler(this.cytat_Click);
            // 
            // instruction
            // 
            this.instruction.AutoSize = true;
            this.instruction.BackColor = System.Drawing.Color.Transparent;
            this.instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.instruction.Location = new System.Drawing.Point(454, 114);
            this.instruction.Name = "instruction";
            this.instruction.Size = new System.Drawing.Size(70, 26);
            this.instruction.TabIndex = 4;
            this.instruction.Text = "label1";
            // 
            // instrukcja
            // 
            this.instrukcja.AutoSize = true;
            this.instrukcja.BackColor = System.Drawing.Color.Transparent;
            this.instrukcja.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.instrukcja.Location = new System.Drawing.Point(68, 114);
            this.instrukcja.Name = "instrukcja";
            this.instrukcja.Size = new System.Drawing.Size(70, 26);
            this.instrukcja.TabIndex = 5;
            this.instrukcja.Text = "label1";
            // 
            // Instr_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::project.Properties.Resources.underwater_background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.instrukcja);
            this.Controls.Add(this.instruction);
            this.Controls.Add(this.cytat);
            this.Name = "Instr_window";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cytat;
        private System.Windows.Forms.Label instruction;
        private System.Windows.Forms.Label instrukcja;
    }
}