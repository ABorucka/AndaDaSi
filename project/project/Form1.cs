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
using System.Media;

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
        //System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
        SoundPlayer mainSong = new SoundPlayer(Properties.Resources.under);
       // SoundPlayer player = new SoundPlayer(s);
        
        Random rand = new Random();
		Ursula ursula = new Ursula();
        Buble bubble = new Buble();
        Buble bubble2 = new Buble();
        Shark shark = new Shark();
        Spikes spikes = new Spikes();
		
		public const int ursulaSize = 100;
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
            theOcean.Controls.Add(bubble2);
            theOcean.Controls.Add(shark);
            theOcean.Controls.Add(ursula);
            ursula.Visible = false;
            bubble.Visible = false;
            bubble2.Visible = false;
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
            //sea.SendToBack();
            //weed.SendToBack();


        }

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
                        //marmaid.BackColor = Color.Red;
                        //ursula.BackColor = Color.AliceBlue;
                    oxygen_progers.Value -= oxygen_progers.Value > 10 ? 10 : oxygen_progers.Value;
                    ursula.Visible = false;   
                }
                if(Collision(bubble))
                {
                    oxygen_progers.Value += 100-oxygen_progers.Value > 20 ? 20 : 100-oxygen_progers.Value;
                    bubble.Visible = false;
                }

                if (Collision(bubble2))
                {
                    oxygen_progers.Value += 100 - oxygen_progers.Value > 20 ? 20 : 100 - oxygen_progers.Value;
                    bubble2.Visible = false;
                }

                if (marmaid.Bottom >= (sea.Top)+sea.Height/5)
                {
                    double velocity = -9;
                    marmaid.Vy = velocity;
                    impulsTime = Convert.ToInt16(Math.Abs(velocity)) + 4;
                }

                if(Collision(shark)) 
                {
                    move = false;
                    timerOxygen.Enabled = false;
                    timerOxygen.Stop();
                    gameOverLabel.Visible = true;
                    playAgainButton.Visible = true;
                    newGame = false;

					//marmaid.BackColor = Color.Green;
					//shark.BackColor = Color.AliceBlue;
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
                    if (shark.X + shark.Width < ursula.X || shark.X > ursula.X + ursula.Width)
                    {
                        sharkTmpY = 0;
                        sharkRand = 300;
                        shark.Visible = true;
                    }
                }

                if (ursulaRand == 0 && rand.Next(0, 100) < point * 0.0001)
                {
                    int tmpX = rand.Next(spikes.SpikeSize, theOcean.Width - ursulaSize - spikes.SpikeSize);
                    int tmpY = rand.Next(0, theOcean.Height - ursulaSize - weed.Height);
                    if (marmaid.Left - marmaid.Width > tmpX || marmaid.Right + marmaid.Width < tmpX)
                    {
                        ursula.X = tmpX;
                        ursula.Y = tmpY;
                        ursula.Location = new Point(ursula.X, ursula.Y);
                        ursulaRand = 100;
                        ursula.Visible = true;
                    }
                }

                if (bubble.Visible==false)
                {
                    bubble.X = rand.Next(spikes.SpikeSize, theOcean.Width - bubble.Width - spikes.SpikeSize);
                    bubble.Y = rand.Next(0, theOcean.Height - bubble.Width - weed.Height);
                    bubble.Visible = true;
                    bubble.Location = new Point(bubble.X, bubble.Y);
                }
                if (bubble2.Visible == false)
                {
                    bubble2.X = rand.Next(spikes.SpikeSize, theOcean.Width - bubble.Width - spikes.SpikeSize);
                    bubble2.Y = rand.Next(0, theOcean.Height - bubble.Width - 2 * weed.Height);
                    bubble2.Visible = true;
                    bubble2.Location = new Point(bubble2.X, bubble2.Y);
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
			spikes.StartListOfSpikes(theOcean);
		}
/* Determine hight of the ocean */
		private void theOcean_Paint(object sender, PaintEventArgs e)
		{
			theOcean.Height = spikes.SpikeSize * spikes.PlaceForSpikes+weed.Height;
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
               // mainSong.Stop();
            }
            else { oxygen_progers.Value--; }
        }
/* Watching mouse click - bouncing the character */
		private void jumpButton_Click(object sender, EventArgs e)
		{
			if (newGame)
			{

				double velocity = -9;
				marmaid.Vy = velocity;
				impulsTime = Convert.ToInt16(Math.Abs(velocity)) + 4;
				if (!move)
				{
					move = true;
					timerOxygen.Enabled = true;
					timerOxygen.Start();
					mainSong.Play();
				}

			}
		}
       
        private void Shark_down(int tmpY)
        {
            shark.Location = new Point(shark.X, tmpY);
        }

       private bool Collision(PictureBox pictureBox)
       {
			bool isThereaCollision = false;
			bool isThereaSpike = false;

			if (pictureBox == bubble || pictureBox == bubble2)
			{
				isThereaCollision = DistanceFromObstacle(pictureBox, 0);
			}
			else
			{
				isThereaCollision = DistanceFromObstacle(pictureBox, 7);
			}

			isThereaSpike = spikes.CollisionWithSpikes(marmaid);

			return (isThereaCollision && pictureBox.Visible == true || isThereaSpike == true);
		}

		private bool DistanceFromObstacle(PictureBox obstackle, int difficulty)
		{
			int marmaidCenterX = marmaid.Location.X + marmaid.Width/2;
			int marmaidCenterY = marmaid.Location.Y + marmaid.Height/2;
			int obstackleCenterX = obstackle.Location.X + obstackle.Width/2;
			int obstackleCenterY = obstackle.Location.Y + obstackle.Height/2;
			
			double R1 = marmaid.Width / 2 - difficulty;
			double R2 = obstackle.Width / 2 - difficulty;

			double distanceX = Math.Abs(marmaidCenterX - obstackleCenterX);
			double distanceY = Math.Abs(marmaidCenterY - obstackleCenterY);
			double distance = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));

			return (distance <= R1 + R2);
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
