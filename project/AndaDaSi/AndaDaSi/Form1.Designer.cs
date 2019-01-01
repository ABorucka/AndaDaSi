namespace AndaDaSi
{
	partial class UnderTheSea
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Metoda wymagana do obsługi projektanta — nie należy modyfikować
		/// jej zawartości w edytorze kodu.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timerSpikeMove = new System.Windows.Forms.Timer(this.components);
			this.theOcean = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// timerSpikeMove
			// 
			this.timerSpikeMove.Tick += new System.EventHandler(this.timerSpikeMove_Tick);
			// 
			// theOcean
			// 
			this.theOcean.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.theOcean.Location = new System.Drawing.Point(1, 1);
			this.theOcean.Name = "theOcean";
			this.theOcean.Size = new System.Drawing.Size(616, 447);
			this.theOcean.TabIndex = 0;
			this.theOcean.Paint += new System.Windows.Forms.PaintEventHandler(this.theOcean_Paint);
			// 
			// UnderTheSea
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.theOcean);
			this.Name = "UnderTheSea";
			this.Text = "Under The Sea";
			this.Load += new System.EventHandler(this.UnderTheSea_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timerSpikeMove;
		private System.Windows.Forms.Panel theOcean;
	}
}

