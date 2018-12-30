using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace project
{
    
    public partial class Form1 : Form
    {

        class_character marmaid;
        int impulsTime = 0;
        int point = 0;
        bool move = false;
       // public delegate void KeyPressEventHandler(object sender, KeyPressEventArgs e);
        
        public Form1(Image character_image)
        {
            InitializeComponent();
            marmaid = new class_character(character_image);
            marmaid.Location = new Point(panel1.Width/2-25, panel1.Height/2-35);
            panel1.Controls.Add(marmaid);

            timerMarmaidMove.Interval = 30;
            timerMarmaidMove.Enabled = true;
            timerMarmaidMove.Start();
            timerMarmaidMove.Tick += new EventHandler(TimerMove_Tick);
            timerOxygen.Interval = 10 * timerMarmaidMove.Interval;
            timerOxygen.Tick += new EventHandler(TimerOxygen_Tick);

        }

        
        private void TimerMove_Tick(object sender, EventArgs e)
        {
            if (move)
            {
                if ((panel1.Width <= (marmaid.Right) || (marmaid.Left) <= 0))
                {
                    marmaid.Vx *= -1;
                    marmaid.rotate180();
                    points_display.Text = Convert.ToString(++point);
                }
                marmaid.Location = new Point(marmaid.Left + Convert.ToInt32(marmaid.Vx), marmaid.Top + Convert.ToInt32(marmaid.Vy));

                if (impulsTime != 0)
                {
                    impulsTime--;
                    marmaid.Vy++;
                }
                   
            }
        }

        private void TimerOxygen_Tick(object sender, EventArgs e)
        {
            oxygen_progers.Value--;
            if (oxygen_progers.Value==0)
            {
                move = false;
                timerOxygen.Enabled = false;
                timerOxygen.Stop();
            }
        }


        private void panel1_MoveClick(object sender, MouseEventArgs e)
        {
            move = true;
            marmaid.Vy = -7;
            impulsTime = 8;
            timerOxygen.Enabled = true;
            timerOxygen.Start();
        }

      
    }
}
