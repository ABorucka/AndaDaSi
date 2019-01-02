﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace project
{

    public partial class UnderTheSea : Form
    {

        class_character marmaid;
        int impulsTime = 0;
        int point = 0;
        bool move = false;
        int obstackles = 0;
        bool newGame = true;

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
        int ursulaTmpY = 0;
        int ursulaRand = 0;

		public UnderTheSea(Image character_image)
        {
            InitializeComponent();
            marmaid = new class_character(character_image);
            marmaid.Location = new Point(theOcean.Width/2-25, theOcean.Height/2-35);
            theOcean.Controls.Add(marmaid);

            timerMarmaidMove.Interval = 30;
            timerMarmaidMove.Enabled = true;
            timerMarmaidMove.Start();
            timerMarmaidMove.Tick += new EventHandler(TimerMove_Tick);

            timerOxygen.Interval = 10 * timerMarmaidMove.Interval;
            timerOxygen.Tick += new EventHandler(TimerOxygen_Tick);

            gameOverLabel.Visible = false;
            playAgainButton.Visible = false;


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
            //ursula.X = rand.Next(spikeSize, theOcean.Width - ursulaSize - spikeSize);
            //ursula.Y = rand.Next(0, theOcean.Height - ursulaSize - spikeSize);
           
            ursula.Location = new Point(theOcean.Height, theOcean.Height);
			theOcean.Controls.Add(ursula);
		}

		private void TimerMove_Tick(object sender, EventArgs e)
        {
            if (move)
            {
                
                if (obstackles>0)
                {
                    if (obstackles < 11 && obstackles > 5)
                        Spikes_hide();
                    else if (obstackles < 6)
                        Spikes_show();
                      
                    if (obstackles == 6)
                    {
                        NoRepeatingSpikesPosition();
                        Spikes_spreading();
                    }
                    obstackles--;
                }
                
/* Bouncing off the wall and init spikes move */

                if ((theOcean.Width <= (marmaid.Right) || (marmaid.Left) <= 0))
                {
                    marmaid.Vx *= -1;
                    marmaid.rotate180();
                    points_display.Text = Convert.ToString(++point);
                    obstackles = 13;
                  //  ursulaTmpY = 0;
                    
                }
                marmaid.Location = new Point(marmaid.Left + Convert.ToInt32(marmaid.Vx), marmaid.Top + Convert.ToInt32(marmaid.Vy));

/* Collision with Ursula */
                bool ursulaFromLeft = (marmaid.Right >= ursula.Left) && (marmaid.Right <= ursula.Right);
                bool ursulaFromRight = (marmaid.Left >= ursula.Left) && (marmaid.Left <= ursula.Right);
                bool ursulaFromTop = (marmaid.Bottom >= ursula.Bottom) && (marmaid.Bottom <= ursula.Top);
                bool ursulaFromBottom = (marmaid.Top >= ursula.Bottom) && (marmaid.Top <= ursula.Top);
                if (ursulaFromLeft || ursulaFromRight || ursulaFromBottom || ursulaFromTop)
                {
                    marmaid.BackColor = Color.Red;
                    ursula.BackColor = Color.AliceBlue;
                }
                if (impulsTime != 0)
                {
                    impulsTime--;
                    marmaid.Vy++;
                }
/*Random - if Ursula appear in the ocean*/
                if (ursulaRand == 0 && rand.Next(0,2)<0.0001 )
                {
                    ursulaTmpY = 0;
                    ursula.X = rand.Next(spikeSize, theOcean.Width - ursulaSize - spikeSize);
                    ursulaRand = 200;
                    //ursula.BackColor = Color.FromArgb(90, rand.Next(0,200), rand.Next(0, 200), rand.Next(0, 200));
                }

                if(ursulaRand>0 )
                {
                    Ursula_down(ursulaTmpY);
                    ursulaTmpY += (theOcean.Height / 199);
                    ursulaRand--;
                }
                   
            }
        }
/* Init spikes and Ursula */
		private void UnderTheSea_Load(object sender, EventArgs e)
		{
			timerSpikeMove.Enabled = true;
			NoRepeatingSpikesPosition();
			StartListOfSpikes();
			leftSide = false;
		}
/* Determine hight of the ocean */
		private void theOcean_Paint(object sender, PaintEventArgs e)
		{
			theOcean.Height = spikeSize * placeForSpikes;
		}
/* Oxygen is running out */
		private void TimerOxygen_Tick(object sender, EventArgs e)
        {
            oxygen_progers.Value--;
            if (oxygen_progers.Value==0)
            {
                move = false;
                timerOxygen.Enabled = false;
                timerOxygen.Stop();
                gameOverLabel.Visible = true;
                playAgainButton.Visible = true;
                newGame = false;
            }
        }
/* Watching mouse click - bouncing the character */
        private void panel1_MoveClick(object sender, MouseEventArgs e)
        {
            if (newGame)
            {
                move = true;
                marmaid.Vy = -7;
                impulsTime = 8;
                timerOxygen.Enabled = true;
                timerOxygen.Start();
                
            }
        }

		


        private void Spikes_show()
        {
                if (leftSide == true)
                {
                    foreach (SpikeLeft s in listSpikesLeft)
                    {
                        s.X += 6;
                        s.Location = new Point(s.X, s.Y);
                    }
                }
                else if (leftSide == false)
                {
                    foreach (SpikeRight s in listSpikesRight)
                    {
                        s.X -= 6;
                        s.Location = new Point(s.X, s.Y);
                    }
                }
                theOcean.Refresh();
            
        }

       
        private void Ursula_down(int tmpY)
        {
            theOcean.Refresh();
            ursula.Location = new Point(ursula.X, tmpY);
        }

        private void Spikes_hide()
        {
            
                if (leftSide == true)
                {
                    foreach (SpikeLeft s in listSpikesLeft)
                    {
                        s.X -= 6;
                        s.Location = new Point(s.X, s.Y);
                    }
                }
                else if (leftSide == false)
                {
                    foreach (SpikeRight s in listSpikesRight)
                    {
                        s.X += 6;
                        s.Location = new Point(s.X, s.Y);
                    }
                }
                theOcean.Refresh();
            
        }
/* New places for spikes */
        public void Spikes_spreading()
        {

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
           
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            point = 0;
            oxygen_progers.Value = 100;
            oxygen_label.Text = Convert.ToString(point);
            playAgainButton.Visible = false;
            gameOverLabel.Visible = false;
            newGame = true;

        }
    }

    
}
