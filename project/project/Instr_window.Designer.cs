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
			this.Author_cite = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cytat
			// 
			this.cytat.AutoSize = true;
			this.cytat.BackColor = System.Drawing.Color.Transparent;
			this.cytat.Font = new System.Drawing.Font("Gabriola", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.cytat.Location = new System.Drawing.Point(104, 20);
			this.cytat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.cytat.Name = "cytat";
			this.cytat.Size = new System.Drawing.Size(364, 74);
			this.cytat.TabIndex = 0;
			this.cytat.Text = "\"Kto nie umiera - żywy jest\"";
			// 
			// instruction
			// 
			this.instruction.AutoSize = true;
			this.instruction.BackColor = System.Drawing.Color.Transparent;
			this.instruction.Font = new System.Drawing.Font("Gabriola", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.instruction.Location = new System.Drawing.Point(339, 106);
			this.instruction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.instruction.Name = "instruction";
			this.instruction.Size = new System.Drawing.Size(48, 31);
			this.instruction.TabIndex = 4;
			this.instruction.Text = "label1";
			// 
			// instrukcja
			// 
			this.instrukcja.AutoSize = true;
			this.instrukcja.BackColor = System.Drawing.Color.Transparent;
			this.instrukcja.Font = new System.Drawing.Font("Gabriola", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.instrukcja.Location = new System.Drawing.Point(50, 106);
			this.instrukcja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.instrukcja.Name = "instrukcja";
			this.instrukcja.Size = new System.Drawing.Size(48, 31);
			this.instrukcja.TabIndex = 5;
			this.instrukcja.Text = "label1";
			// 
			// Author_cite
			// 
			this.Author_cite.AutoSize = true;
			this.Author_cite.BackColor = System.Drawing.Color.Transparent;
			this.Author_cite.Font = new System.Drawing.Font("Gabriola", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Author_cite.Location = new System.Drawing.Point(392, 74);
			this.Author_cite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Author_cite.Name = "Author_cite";
			this.Author_cite.Size = new System.Drawing.Size(70, 37);
			this.Author_cite.TabIndex = 6;
			this.Author_cite.Text = "Hercules";
			// 
			// Instr_window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::project.Properties.Resources.underwater_background;
			this.ClientSize = new System.Drawing.Size(600, 366);
			this.Controls.Add(this.Author_cite);
			this.Controls.Add(this.instrukcja);
			this.Controls.Add(this.instruction);
			this.Controls.Add(this.cytat);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.Name = "Instr_window";
			this.Text = "Form2";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cytat;
        private System.Windows.Forms.Label instruction;
        private System.Windows.Forms.Label instrukcja;
        private System.Windows.Forms.Label Author_cite;
    }
}