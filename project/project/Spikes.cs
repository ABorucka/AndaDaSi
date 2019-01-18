using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    class Spikes
    {
        private List<SpikeRight> listSpikesRight = new List<SpikeRight>();
        private List<SpikeLeft> listSpikesLeft = new List<SpikeLeft>();
        private const int spikeSize= 30;
        private const int placeForSpikes = 15;
        private const int numberOfSpikes = 5;
        private int[] placesForSpikes = new int[numberOfSpikes];
        private bool leftSide;
        private bool go;
        private Random rand = new Random();

        public Spikes() {  }
    
        public int SpikeSize
        {
            get { return spikeSize; }
           // set { spikeSize = value; }
        }

        public int PlaceForSpikes
        {
            get { return placeForSpikes; }
            // set { spikeSize = value; }
        }

        public bool LeftSide
        {
            get { return leftSide; }
            //set {  = value; }
        }

        public void NoRepeatingSpikesPosition()
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

        public void StartListOfSpikes(Panel theOcean)
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
                leftSide = false;
            }
            
        }

        public void Spikes_show()
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
            

        }

        public void Spikes_hide()
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

        }
        /* New places for spikes */
        public void Spikes_spreading(Panel theOcean)
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

		public bool CollisionWithSpikes(PictureBox mermaid)
		{
			int mermaidCenterX = mermaid.Location.X + mermaid.Width / 2;
			int mermaidCenterY = mermaid.Location.Y + mermaid.Height / 2;

			foreach (SpikeRight s in listSpikesRight)
			{
				
			}
			//double R1 = spikeSize;
			//double R2 = obstackle.Width / 2 - difficulty;
			//double minDistance = R1 + R2;

			//double distanceX = Math.Abs(marmaidCenterX - obstackleCenterX);
			//double distanceY = Math.Abs(marmaidCenterY - obstackleCenterY);
			//double distance = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));

			return true; //(distance <= R1 + R2);
		}
	}
}
