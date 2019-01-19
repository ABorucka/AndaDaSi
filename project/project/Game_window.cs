using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace project
{

    public partial class UnderTheSea : Form
    {

        int impulsTime = 0;     // jump impuls
        int point = 0;          // amount of points
        int obstackles = 0;     // time for operate the spikes
        bool newGame = true;    // new game?
        int wait = 0;           // to chceck if the velocity should be increased
        bool sound_on = true;

        SoundPlayer mainSong = new SoundPlayer(Properties.Resources.under_cut);             // Main song - Under the sea
        SoundPlayer dieSong = new SoundPlayer(Properties.Resources.Gabsssss_andadasi_2);    // Sound to inform that game is over - selfmade 


        //Characters and obstackles
        class_character marmaid;
        Random rand = new Random();
		Ursula ursula = new Ursula();
        Buble bubble = new Buble();
        Buble bubble2 = new Buble();
        Shark shark = new Shark();
        Spikes spikes = new Spikes();
		
        //Tmp variables for obstackles
        int sharkTmpY = 0;   
        int sharkRand = 0;
        int ursulaRand = 0;

		public UnderTheSea(int character_image, bool soundOn)
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
            gameOverLabel.Visible = false;
            playAgainButton.Visible = false;
            
            
            //Move timer - for mermaid move and other pictureboxes apperance
            timerMarmaidMove.Interval = 30;
            timerMarmaidMove.Enabled = false;
            timerMarmaidMove.Tick += new EventHandler(TimerMove_Tick);

            //Oxygen timer - for running out the oxygen
            timerOxygen.Interval = 8 * timerMarmaidMove.Interval;
            timerOxygen.Tick += new EventHandler(TimerOxygen_Tick);

            //Reaction for closing the window
            this.Closing += Window_Closing;
            sound_on = soundOn;
            if (!sound_on) sound.BackgroundImage = Properties.Resources.Volume_Off_512;

        }

		private void TimerMove_Tick(object sender, EventArgs e)
        {
            //Spike moving
            if (obstackles>0)
            {
                if (obstackles < 11 && obstackles > 5)
                {
                    spikes.Spikes_hide();
                }
                else if (obstackles < 6)
                {
                    spikes.Spikes_show();
                }
                      
                if (obstackles == 6)
                {
                    spikes.NoRepeatingSpikesPosition();
                    spikes.Spikes_spreading(theOcean);
                }
                obstackles--;
            }
                
            //Reflecting of the wall and normal move

            if ((theOcean.Width <= (marmaid.Right) || (marmaid.Left) <= 0))
            { 
                marmaid.Vx *= -1;
                marmaid.rotate180();
                points_display.Text = Convert.ToString(++point);
                if (point % 5 == 0 && marmaid.Vx<7) wait = 5;
                obstackles = 13;
                    
            }
			if (marmaid.Top <= 0 - marmaid.Height)
			{
				marmaid.Vy += impulsTime;
				impulsTime = 0;
			}

			marmaid.Location = new Point(marmaid.Left + Convert.ToInt32(marmaid.Vx), 
				marmaid.Top + Convert.ToInt32(marmaid.Vy));
               
            // Collision with Ursula, bubbles, shark and ground
            if (Collision(ursula))
            {
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

            if(Collision(shark))    Die();

            if (marmaid.Bottom >= (sea.Top) + sea.Height / 5)
            {
                double velocity = -9;
                marmaid.Vy = velocity;
                impulsTime = Convert.ToInt16(Math.Abs(velocity)) + 4;
            }


			//Jump
			if (impulsTime != 0)
                {
                    impulsTime--;
                    marmaid.Vy++;
                }
                


            //Random - decide if Ursula, shark or bubbles appear in the ocean*/
            if (sharkRand == 0 && rand.Next(0,100) < point*0.0001 )
            {
                shark.X = rand.Next(2*spikes.SpikeSize, theOcean.Width - shark.Width - 2*spikes.SpikeSize);
                if ((shark.X + shark.Width < ursula.X || shark.X > ursula.X + ursula.Width))
                {
                    sharkTmpY = -shark.Height;
                    sharkRand = 400;
                    shark.Visible = true;
                    shark.Vy = rand.Next(200-point*5, 200);
                }
            }

                if (ursulaRand == 0 && rand.Next(0, 100) < point * 0.0001)
                {
                    int tmpX = rand.Next(spikes.SpikeSize, theOcean.Width - ursula.Width - spikes.SpikeSize);
                    int tmpY = rand.Next(0, theOcean.Height - ursula.Height - 2* weed.Height);
                    if ((marmaid.Left - marmaid.Width > tmpX || marmaid.Right + marmaid.Width < tmpX)
						&& ((tmpX + ursula.Width < shark.X || tmpX > shark.X + shark.Width)))
                    {
                        ursula.X = tmpX;
                        ursula.Y = tmpY;
                        ursula.Location = new Point(ursula.X, ursula.Y);
                        ursulaRand = rand.Next(80,200);
                        ursula.Visible = true;
                    }
                }

            if (bubble.Visible==false)
            {
                bubble.X = rand.Next(spikes.SpikeSize, theOcean.Width - bubble.Width - spikes.SpikeSize);
                bubble.Y = rand.Next(0, theOcean.Height - bubble.Height - 2 * weed.Height);
                bubble.Visible = true;
                bubble.Location = new Point(bubble.X, bubble.Y);
            }
            if (bubble2.Visible == false)
            {
                bubble2.X = rand.Next(spikes.SpikeSize, theOcean.Width - bubble.Width - spikes.SpikeSize);
                bubble2.Y = rand.Next(0, theOcean.Height - bubble.Height - 2 * weed.Height);
                bubble2.Visible = true;
                bubble2.Location = new Point(bubble2.X, bubble2.Y);
            }


            //Aperance of shark and urslua
            if (sharkRand>0 )
            {
                shark.Shark_down(sharkTmpY);
                sharkTmpY += (theOcean.Height / shark.Vy);
                sharkRand--;
            }
            if (ursulaRand > 0)
                ursulaRand--;
            else
                ursula.Visible = false;

            //Incerasing of velocity
            if(wait!=0)
            {
                double tmp = Math.Abs(marmaid.Vx) + 1;
                marmaid.Vx = marmaid.Vx>0 ? tmp : -tmp;
                wait = 0;
            }
                   

            
        }
        // Init spikes and Ursula 
		private void UnderTheSea_Load(object sender, EventArgs e)
		{
            spikes.NoRepeatingSpikesPosition();
			spikes.StartListOfSpikes(theOcean);
		}
        // Determine hight of the ocean */
		private void theOcean_Paint(object sender, PaintEventArgs e)
		{
			theOcean.Height = spikes.SpikeSize * spikes.PlaceForSpikes+weed.Height;
		}
        // Oxygen is running out - timer
		private void TimerOxygen_Tick(object sender, EventArgs e)
        {
            
            if (oxygen_progers.Value==0)
            {
                Die();
            }
            else { oxygen_progers.Value--; }
        }

        // Some game over stuff
        private void Die()
        {
            timerOxygen.Enabled = false;
            timerOxygen.Stop();
            timerMarmaidMove.Enabled = false;
            timerMarmaidMove.Stop();
            gameOverLabel.Visible = true;
            playAgainButton.Visible = true;
            newGame = false;
            if (sound_on)
            {
                mainSong.Dispose();
                dieSong.PlaySync();
            }
        }

        // Watching mouse click - bouncing the character 
		private void JumpButton_Click(object sender, EventArgs e)
		{
			if (newGame)
			{

				const double velocity = -9;
				marmaid.Vy = velocity;
				impulsTime = Convert.ToInt16(Math.Abs(velocity)) + 4;
				if (timerMarmaidMove.Enabled==false)
				{
					timerOxygen.Enabled = true;
					timerOxygen.Start();
                    timerMarmaidMove.Enabled = true;
                    timerMarmaidMove.Start();
                    if (sound_on)  mainSong.Play();
				}

			}
		}
       
        //Collision with obstackles based on distance between them
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
				isThereaCollision = DistanceFromObstacle(pictureBox, 9);
			}

			isThereaSpike = spikes.CollisionWithSpikes(marmaid);

			return (isThereaCollision && pictureBox.Visible == true || isThereaSpike == true);
		}

		private bool DistanceFromObstacle(PictureBox obstackle, int difficulty)
		{
			int marmaidCenterX = 0;
			if (spikes.LeftSide == false)
			{
				marmaidCenterX = marmaid.Location.X + (marmaid.Width / 2) + 15;
			}
			else if (spikes.LeftSide == true)
			{
				marmaidCenterX = marmaid.Location.X + (marmaid.Width / 2) - 15;
			}
			else if (obstackle == bubble || obstackle == bubble2)
			{
				marmaidCenterX = marmaid.Location.X + (marmaid.Width / 2);
			}
			int marmaidCenterY = marmaid.Location.Y + marmaid.Height/2;
			int obstackleCenterX = obstackle.Location.X + obstackle.Width/2;
			int obstackleCenterY = obstackle.Location.Y + obstackle.Height/2 + 5;

			double R1;
			if (obstackle == bubble || obstackle == bubble2)
				R1 = marmaid.Width / 2;
			else R1 = marmaid.Height / 2;
			double R2 = obstackle.Width / 2 - difficulty;

			double distanceX = Math.Abs(marmaidCenterX - obstackleCenterX);
			double distanceY = Math.Abs(marmaidCenterY - obstackleCenterY);
			double distance = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));

			return (distance <= R1 + R2);
		}


        //Play again button
        private void PlayAgain_Click(object sender, EventArgs e)
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
            marmaid.Vx = marmaid.Vx > 0 ? marmaid.Vx_start : -marmaid.Vx_start;


        }

        //Colsing window
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            mainSong.Stop();
            sound_on = false;
            Die();
        }

        private void sound_Click(object sender, EventArgs e)
        {
            if (sound_on)
            {
                mainSong.Stop();
                dieSong.Stop();
                sound.BackgroundImage = Properties.Resources.Volume_Off_512;
            }
            else
            {
                sound.BackgroundImage = Properties.Resources.volume_on;
                if(timerMarmaidMove.Enabled==true)
                    mainSong.PlayLooping();
            }
            sound_on = !sound_on;
            
        }
    }

    
}
