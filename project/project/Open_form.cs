using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace project
{
    public partial class Open_form : Form
    {
        public int id = 1;                                                          // Default marmeid 
        List<choose_mermaid> mermaids = new List<choose_mermaid>();                 // List of mermaid
        SoundPlayer menuSong = new SoundPlayer(Properties.Resources.kiss_cut);      // Song
        
        public Open_form()
        {
            InitializeComponent();
            title.BackColor = Color.Transparent;
            choose_label.BackColor = Color.Transparent; 

            choose_mermaid m1 = new choose_mermaid(Properties.Resources.blond_men, 1);
            m1.Location = new Point(Width / 3 - 50, Height / 2 - 62);
            m1.BackColor = Color.FromArgb(90, 0, 0, 0); 
            choose_mermaid m2 = new choose_mermaid(Properties.Resources.girl_brown, 2);
            m2.Location = new Point(Width*2 / 3 - 50, Height / 2 - 62);
            m2.BackColor = Color.Transparent;
            mermaids.Add(m1);
            mermaids.Add(m2);
            foreach (var m in mermaids)
            {
                Controls.Add(m);
                m.MouseClick += new MouseEventHandler(CharacterClick);
            }

            menuSong.PlayLooping();
        }

       
        // Choosing character 
        private void CharacterClick(object sender, EventArgs e)
        {
            choose_mermaid m = sender as choose_mermaid;
            id = m.Id;
            foreach(var mer in mermaids)
            {
                if (sender as choose_mermaid != mer)
                    mer.BackColor = Color.Transparent;
            }
            m.BackColor = Color.FromArgb(90, 0, 0, 0);
            
        }
        // Start new game 
        private void Start_Click(object sender, EventArgs e)
        {
            UnderTheSea game = new UnderTheSea(id);
            game.FormClosed += Close_game;
            menuSong.Stop();
            game.ShowDialog();
            
        }

        //React when game window is closed
        private void Close_game (object sender, EventArgs e)
        {
            menuSong.PlayLooping();
        }

        //Open instruction
        private void Instruction_Click(object sender, EventArgs e)
        {
            Instr_window inst = new Instr_window();
            inst.ShowDialog();   
        }



      
    }
}
