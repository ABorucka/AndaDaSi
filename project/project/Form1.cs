using System;
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
		Ursula ursula = new Ursula();
        Buble bubble = new Buble();
        Shark shark = new Shark();
        Spikes spikes = new Spikes();

//		public const int spikeSize = 30;
		public const int ursulaSize = 100;
/*		public const int placeForSpikes = 15;
		public const int numberOfSpikes = 5;
		int[] placesForSpikes = new int[numberOfSpikes];
		bool leftSide;
		bool go;*/
        int sharkTmpY = 0;
        int sharkRand = 0;
        int ursulaRand = 0;

		public UnderTheSea(int character_image)
        {
            InitializeComponent();
            marmaid = new class_character(character_image);
            marmaid.Location = new Point(theOcean.Width/2-25, theOcean.Height/2-35);
            theOcean.Controls.Add(marmaid);
            theOcean.Controls.Add(bubble);
            theOcean.Controls.Add(shark);
            theOcean.Controls.Add(ursula);
            ursula.Visible = false;
            bubble.Visible = false;
            shark.Visible = false;
            //shark.

            timerMarmaidMove.Interval = 30;
            timerMarmaidMove.Enabled = true;
            timerMarmaidMove.Start();
            timerMarmaidMove.Tick += new EventHandler(TimerMove_Tick);

            timerOxygen.Interval = 10 * timerMarmaidMove.Interval;
            timerOxygen.Tick += new EventHandler(TimerOxygen_Tick);

            gameOverLabel.Visible = false;
            playAgainButton.Visible = false;
            sea.SendToBack();
            weed.SendToBack();


        }
/*
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
		}*/

		private void TimerMove_Tick(object sender, EventArgs e)
        {
            if (move)
            {
                
                if (obstackles>0)
                {
                    if (obstackles < 11 && obstackles > 5)
                    {
                        spikes.Spikes_hide();
                       // theOcean.Refresh();
                    }
                    else if (obstackles < 6)
                    {
                        spikes.Spikes_show();
                       // theOcean.Refresh();
                    }
                      
                    if (obstackles == 6)
                    {
                        spikes.NoRepeatingSpikesPosition();
                        spikes.Spikes_spreading(theOcean);
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
                //theOcean.Refresh();
/* Collision with Ursula, bubble and shark */
                if (Collision(ursula))
                {
                      //  marmaid.BackColor = Color.Red;
                       // ursula.BackColor = Color.AliceBlue;
                    oxygen_progers.Value -= oxygen_progers.Value > 10 ? 10 : oxygen_progers.Value;
                    ursula.Visible = false;   
                }
                if(Collision(bubble))
                {
                    oxygen_progers.Value += 100-oxygen_progers.Value > 10 ? 10 : 100-oxygen_progers.Value;
                    bubble.Visible = false;
                }



                if(Collision(shark) || marmaid.Bottom>(sea.Top+sea.Height/2)/*Collision(shark)*/)
                {
                    move = false;
                    timerOxygen.Enabled = false;
                    timerOxygen.Stop();
                    gameOverLabel.Visible = true;
                    playAgainButton.Visible = true;
                    newGame = false;
                    //shark.BackColor = Color.Aquamarine;
                    //marmaid.BackColor = Color.PaleGreen;
                }

                if (impulsTime != 0)
                {
                    impulsTime--;
                    marmaid.Vy++;
                }
                


                /*Random - if Ursula, shark or bubble appear in the ocean*/
                if (sharkRand == 0 && rand.Next(0,100) < point*0.0001 )
                {
                    shark.X = rand.Next(2*spikes.SpikeSize, theOcean.Width - shark.Width - 2*spikes.SpikeSize);
                    sharkTmpY = 0;
                    sharkRand = 300;
                    shark.Visible = true;
                    marmaid.BackColor = Color.Transparent;
                }

                if (ursulaRand == 0 && rand.Next(0, 100) < point * 0.0001)
                {
                    int tmpX = rand.Next(spikes.SpikeSize, theOcean.Width - ursulaSize - spikes.SpikeSize);
                    int tmpY = rand.Next(sea.Height, theOcean.Height - ursulaSize - spikes.SpikeSize);
                    if (marmaid.Left - marmaid.Width > tmpX || marmaid.Right + marmaid.Width < tmpX)
                    {
                        ursula.X = tmpX;
                        ursula.Y = tmpY;
                        ursula.Location = new Point(ursula.X, ursula.Y);
                        ursulaRand = 100;
                        ursula.Visible = true;
                    }
                }

                if (rand.Next(0, 2) < 0.001 && bubble.Visible==false)
                {
                    bubble.X = rand.Next(spikes.SpikeSize, theOcean.Width - bubble.Width - spikes.SpikeSize);
                    bubble.Y = rand.Next(sea.Height, theOcean.Height - bubble.Width - spikes.SpikeSize);
                    bubble.Visible = true;
                    bubble.Location = new Point(bubble.X, bubble.Y);
                }

                if (sharkRand>0 )
                {
                    Shark_down(sharkTmpY);
                    sharkTmpY += (theOcean.Height / 200);
                    sharkRand--;
                }
                if (ursulaRand > 0)
                    ursulaRand--;
                else
                    ursula.Visible = false;

                
                   
            }
        }
/* Init spikes and Ursula */
		private void UnderTheSea_Load(object sender, EventArgs e)
		{
			//timerSpikeMove.Enabled = true;
            spikes.NoRepeatingSpikesPosition();
			//NoRepeatingSpikesPosition();
			spikes.StartListOfSpikes(theOcean);
           // StartListOfSpikes();
			//leftSide = false;
		}
/* Determine hight of the ocean */
		private void theOcean_Paint(object sender, PaintEventArgs e)
		{
			theOcean.Height = spikes.SpikeSize * spikes.PlaceForSpikes+weed.Height;
           // theOcean.BackgroundImage = Properties.Resources.tlo;
		}
/* Oxygen is running out */
		private void TimerOxygen_Tick(object sender, EventArgs e)
        {
            
            if (oxygen_progers.Value==0)
            {
                move = false;
                timerOxygen.Enabled = false;
                timerOxygen.Stop();
                gameOverLabel.Visible = true;
                playAgainButton.Visible = true;
                newGame = false;
            }
            else { oxygen_progers.Value--; }
        }
/* Watching mouse click - bouncing the character */
        private void panel1_MoveClick(object sender, MouseEventArgs e)
        {
            if (newGame)
            {
                move = true;
                double velocity = -9;
                marmaid.Vy = velocity;
                impulsTime = Convert.ToInt16(Math.Abs(velocity))+4;
                timerOxygen.Enabled = true;
                timerOxygen.Start();
                
            }
        }

		/*


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
            
        }*/

       
        private void Shark_down(int tmpY)
        {
           // theOcean.Refresh();
            shark.Location = new Point(shark.X, tmpY);
        }
/*
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
            
        }*/
/* New places for spikes */
  /*      public void Spikes_spreading()
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
        */
       private bool Collision(PictureBox pictureBox)
       {
            bool objectFromLeft = (marmaid.Right >= pictureBox.Left) && (marmaid.Right <= pictureBox.Right);
            bool objectFromRight = (marmaid.Left >= pictureBox.Left) && (marmaid.Left <= pictureBox.Right);
            bool objectFromTop = (marmaid.Bottom >= pictureBox.Top) && (marmaid.Bottom <= pictureBox.Bottom);
            bool objectFromBottom = (marmaid.Top >= pictureBox.Top) && (marmaid.Top <= pictureBox.Bottom);
            //  if (marmaid.Bottom >= bubble.Top && b.Bottom <= pad.Bottom + pad.Height / 2 && b.Left + 15 >= pad.Left && b.Left + 15 <= pad.Right && b.Control == 0)
             return (((objectFromLeft || objectFromRight) && (objectFromBottom || objectFromTop)) && pictureBox.Visible == true);
            
			//return DistanceFromCircle(pictureBox);
		}

		private bool DistanceFromCircle(PictureBox circle)
		{
			int elipseCenterX = marmaid.Location.X + marmaid.Width/2;
			int elipseCenterY = marmaid.Location.Y + marmaid.Height/2;
			int circleCenterX = circle.Location.X + circle.Width/2;
			int circleCenterY = circle.Location.Y + circle.Height/2;

			double radius = circle.Height / 2;
			double majorAxis = marmaid.Width / 2;
			double minorAxis = marmaid.Height / 2;
			double focalDistance = Math.Sqrt(Math.Pow(majorAxis,2) - Math.Pow(minorAxis, 2));
			double distanceToCenter = Math.Sqrt(Math.Pow((elipseCenterX - (int)focalDistance),2) 
				+ Math.Pow((elipseCenterY - circleCenterY),2));
			double distanceToFoci = Math.Sqrt(Math.Pow((elipseCenterX - circleCenterX),2)
				+ Math.Pow((elipseCenterY - circleCenterY),2));
			double distanceFromBord = distanceToCenter - radius;

			double cos = (Math.Pow(distanceToCenter,2) + Math.Pow(focalDistance,2) - Math.Pow(distanceToFoci,2))
				/ (2 * distanceToCenter * focalDistance);

			double R1 = Math.Sqrt(Math.Pow(focalDistance,2) + Math.Pow(distanceFromBord, 2)
				- (2 * distanceFromBord * focalDistance * cos));
			double R2 = Math.Sqrt(Math.Pow(focalDistance, 2) + Math.Pow(distanceFromBord, 2)
				+ (2 * distanceFromBord * focalDistance * cos));

			return (R1 + R2 <= marmaid.Width);
		}

        private void button1_Click(object sender, EventArgs e)
        {
            point = 0;
            oxygen_progers.Value = 100;
            points_display.Text = Convert.ToString(point);
            playAgainButton.Visible = false;
            gameOverLabel.Visible = false;
            newGame = true;
            marmaid.Location = new Point(theOcean.Width / 2 - 25, theOcean.Height / 2 - 35);
            ursula.Visible = false;
            shark.Visible = false;


        }
    }

    
}
