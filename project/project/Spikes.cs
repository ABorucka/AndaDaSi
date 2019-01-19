using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    class Spikes
    {
        private List<SpikeRight> listSpikesRight = new List<SpikeRight>();
        private List<SpikeLeft> listSpikesLeft = new List<SpikeLeft>();
        private const int spikeSize= 30; //size of a spike
        private const int placeForSpikes = 15; //how many places for spikes are provided
        private const int numberOfSpikes = 4; //how many spikes will be visible on the screen
        private int[] placesForSpikes = new int[numberOfSpikes]; //a list of all posibilities to place a spake
        private bool leftSide; //if spikes appear in the left side of the screen it is true, if in the right -- false
        private bool go; //auxiliary variable

		private Random rand = new Random();

        public Spikes() {  }
    
        public int SpikeSize => spikeSize;

        public int PlaceForSpikes => placeForSpikes;

        public bool LeftSide => leftSide;

		//drawing the place for spikes without repetition
		public void NoRepeatingSpikesPosition()
        {
            for (var i = 0; i < numberOfSpikes; i++)
            {
                go = true;
                while (go)
                {
                    placesForSpikes[i] = rand.Next(0, placeForSpikes );
                    go = false;
                    for (var ii = 0; ii < i; ii++)
                        if (placesForSpikes[i] == placesForSpikes[ii])
                        {
                            go = true;
                            break;
                        }
                }
            }
        }

		/*initialization of the spike lists and 
		assigning places from NoRepeatingSpikesPosition()*/
		public void StartListOfSpikes(Panel theOcean)
        {
            for (var i = 0; i < numberOfSpikes; i++)
            {
                var newSpike = new SpikeRight();
                newSpike.X = theOcean.Width - spikeSize;
                newSpike.Y = placesForSpikes[i] * spikeSize;
                newSpike.Location = new Point(newSpike.X, newSpike.Y);
                listSpikesRight.Add(newSpike);
                theOcean.Controls.Add(newSpike);

                var newSpikeL = new SpikeLeft();
                newSpikeL.X = 0 - spikeSize;
                newSpikeL.Y = placesForSpikes[i] * spikeSize;
                newSpikeL.Location = new Point(newSpikeL.X, newSpikeL.Y);
                listSpikesLeft.Add(newSpikeL);
                theOcean.Controls.Add(newSpikeL);
                leftSide = false;
            }
            
        }

		//Mooving spikes -- show and hide
        public void Spikes_show()
        {
            if (leftSide)
                foreach (var s in listSpikesLeft)
                {
                    s.X += 6;
                    s.Location = new Point(s.X, s.Y);
                }
            else
                foreach (var s in listSpikesRight)
                {
                    s.X -= 6;
                    s.Location = new Point(s.X, s.Y);
                }
        }

        public void Spikes_hide()
        {

            if (leftSide)
                foreach (var s in listSpikesLeft)
                {
                    s.X -= 6;
                    s.Location = new Point(s.X, s.Y);
                }
            else
                foreach (var s in listSpikesRight)
                {
                    s.X += 6;
                    s.Location = new Point(s.X, s.Y);
                }
        }

		/* New places for spikes and induction of 
		 * NoRepeatingSpikesPosition() method*/
		public void Spikes_spreading(Panel theOcean)
        {

            if (leftSide == false)
                leftSide = true;
            else if (leftSide) leftSide = false;

            var n = 0;
            if (leftSide)
                foreach (var s in listSpikesLeft)
                {
                    s.X = 0 - spikeSize;
                    s.Y = placesForSpikes[n] * spikeSize;
                    s.Location = new Point(s.X, s.Y);
                    theOcean.Controls.Add(s);
                    n++;
                }
            else if (leftSide == false)
                foreach (var s in listSpikesRight)
                {
                    s.X = theOcean.Width;
                    s.Y = placesForSpikes[n] * spikeSize;
                    s.Location = new Point(s.X, s.Y);
                    theOcean.Controls.Add(s);
                    n++;
                }
        }

		//collision with spikes
		public bool CollisionWithSpikes(PictureBox mermaid)
		{
			var collision = false;

			int mermaidCenterX;
			if (leftSide == false)
                mermaidCenterX = mermaid.Location.X + mermaid.Width - mermaid.Height / 5;
            else
                mermaidCenterX = mermaid.Location.X + mermaid.Height / 5;
            var mermaidCenterY = mermaid.Location.Y + mermaid.Height / 2;

			double spikeR = 5;
			double mermaidR = 8;

			if (leftSide == false)
                foreach (var s in listSpikesRight)
                {
                    var spikeCenterX = s.X;
                    var spikeCenterY = s.Y + spikeSize / 2;

                    var distance = calculateDistance
                        (mermaidCenterX, spikeCenterX, mermaidCenterY, spikeCenterY);

                    if (distance <= spikeR + mermaidR)
                    {
                        collision = true;
                        break;
                    }
                }
            else if (leftSide)
                foreach (var s in listSpikesLeft)
                {
                    var spikeCenterX = s.X + spikeSize;
                    var spikeCenterY = s.Y + spikeSize / 2;

                    var distance = calculateDistance
                        (mermaidCenterX, spikeCenterX, mermaidCenterY, spikeCenterY);

                    if (distance <= spikeR + mermaidR)
                    {
                        collision = true;
                        break;
                    }
                }

            return collision;
		}

		/*function which calculate the distance between spike and mermaid,
		 needed in the collision function*/
		private double calculateDistance(int mermX, int spikX, int mermY, int spikY)
		{
			double distanceX = Math.Abs(mermX - spikX);
			double distanceY = Math.Abs(mermY - spikY);
			return Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));
		}
	}
}
