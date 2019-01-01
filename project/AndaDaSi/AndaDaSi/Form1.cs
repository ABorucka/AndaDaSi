using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndaDaSi
{
	public partial class UnderTheSea : Form
	{
		Random rand = new Random();
		List<SpikeRight> listSpikesRight = new List<SpikeRight>();
		List<SpikeLeft> listSpikesLeft = new List<SpikeLeft>();
		Ursula ursula = new Ursula();
		public const int spikeSize = 30;
		public const int ursulaSize = 100;
		public const int placeForSpikes = 15;
		public const int numberOfSpikes = 5;
		int[] placesForSpikes = new int[numberOfSpikes];
		bool leftSide;
		bool go;

		public UnderTheSea()
		{
			InitializeComponent();
			timerSpikeMove.Interval = 2000;
		}

		private void NoRepeatingSpikesPosition()
		{
			for (int i = 0; i < numberOfSpikes; i++)
			{
				go = true;
				while (go)
				{
					placesForSpikes[i] = rand.Next(0, placeForSpikes + 1);
					go = false;
					for (int ii = 0; ii < i; ii++)
					{
						if (placesForSpikes[i] == placesForSpikes[ii])
						{
							go = true;
							break;
						}
					}
				}
			}
		}

		private void StartListOfSpikes()
		{
			for (int i = 0; i < numberOfSpikes; i++)
			{
				SpikeRight newSpike = new SpikeRight();
				newSpike.X = theOcean.Width - spikeSize;
				newSpike.Y = placesForSpikes[i] * spikeSize;
				newSpike.Location = new Point(newSpike.X, newSpike.Y);
				listSpikesRight.Add(newSpike);
				theOcean.Controls.Add(newSpike);

				SpikeLeft newSpikeL = new SpikeLeft();
				newSpikeL.X = 0 - spikeSize;
				newSpikeL.Y = placesForSpikes[i] * spikeSize;
				newSpikeL.Location = new Point(newSpikeL.X, newSpikeL.Y);
				listSpikesLeft.Add(newSpikeL);
				theOcean.Controls.Add(newSpikeL);
			}
			ursula.X = rand.Next(spikeSize, theOcean.Width - ursulaSize - spikeSize);
			ursula.Y = rand.Next(0, theOcean.Height - ursulaSize - spikeSize);
			ursula.Location = new Point(ursula.X, ursula.Y);
			theOcean.Controls.Add(ursula);
		}

		private void UnderTheSea_Load(object sender, EventArgs e)
		{
			timerSpikeMove.Enabled = true;
			NoRepeatingSpikesPosition();
			StartListOfSpikes();
			leftSide = false;
		}

		private void theOcean_Paint(object sender, PaintEventArgs e)
		{
			theOcean.Height = spikeSize * 15;
		}

		private void Spikes_spreading()
		{
			Spikes_hide();
			Ursula_hide();
			NoRepeatingSpikesPosition();
			
			if (leftSide == false) { leftSide = true; }
			else if (leftSide == true) { leftSide = false; }

			int n = 0;
			if (leftSide == true)
			{
				foreach (SpikeLeft s in listSpikesLeft)
				{
					s.X = 0 - spikeSize;
					s.Y = placesForSpikes[n] * spikeSize;
					s.Location = new Point(s.X, s.Y);
					theOcean.Controls.Add(s);
					n++;
				}
			}
			else if (leftSide == false)
			{
				foreach (SpikeRight s in listSpikesRight)
				{
					s.X = theOcean.Width;
					s.Y = placesForSpikes[n] * spikeSize;
					s.Location = new Point(s.X, s.Y);
					theOcean.Controls.Add(s);
					n++;
				}
			}
			ursula.X = rand.Next(spikeSize, theOcean.Width - ursulaSize - spikeSize);
			ursula.Y = rand.Next(0, theOcean.Height - ursulaSize - spikeSize);
			ursula.Location = new Point(ursula.X, 0 - ursulaSize);

			theOcean.Refresh();
			Spikes_show();
			Ursula_show();
		}

		private void Spikes_show()
		{
			for (int i = 0; i < 10; i++)
			{
				if (leftSide == true)
				{
					foreach (SpikeLeft s in listSpikesLeft)
					{
						s.X += 3;
						s.Location = new Point(s.X, s.Y);
					}
				}
				else if (leftSide == false)
				{
					foreach (SpikeRight s in listSpikesRight)
					{
						s.X -= 3;
						s.Location = new Point(s.X, s.Y);
					}
				}
				theOcean.Refresh();
			}
		}

		private void Ursula_show()
		{
			int tmpY = theOcean.Height;
			for(int i=0; i<45; i++)
			{
				ursula.Location = new Point(ursula.X, tmpY);
				theOcean.Refresh();
				tmpY -= 10;
				if (tmpY <= ursula.Y) break;
			}
		}

		private void Ursula_hide()
		{
			for (int i = 0; i < 45; i++)
			{
				theOcean.Refresh();
				ursula.Y += 10;
				ursula.Location = new Point(ursula.X, ursula.Y);
				
				if (ursula.Y >= theOcean.Height) break;
			}
		}

		private void Spikes_hide()
		{
			for (int i = 0; i < 10; i++)
			{
				if (leftSide == true)
				{
					foreach (SpikeLeft s in listSpikesLeft)
					{
						s.X -= 3;
						s.Location = new Point(s.X, s.Y);
					}
				}
				else if (leftSide == false)
				{
					foreach (SpikeRight s in listSpikesRight)
					{
						s.X += 3;
						s.Location = new Point(s.X, s.Y);
					}
				}
				theOcean.Refresh();
			}
		}

		private void timerSpikeMove_Tick(object sender, EventArgs e)
		{
			Spikes_spreading();
		}
	}
}
