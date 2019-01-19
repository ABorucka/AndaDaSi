﻿using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class Instr_window : Form
    {
        //Instruction in polish and english
        public Instr_window()
        {
            InitializeComponent();
            Text = "Instruction";
            instruction.MaximumSize = new Size(250, 0);
            instruction.AutoSize = true;
            instruction.Text = "Move your character by clicking a Jump button. " +
                "Avoid obstackles and collect bubles with oxygen. Remember: your oxygen is runing out and Urslua steals it from you. " +
                "What is more, shark and spikes can kill you. Be careful and have fun!";

            instrukcja.MaximumSize = new Size(250, 0);
            instrukcja.AutoSize = true;
            instrukcja.Text = "Pływaj swoją syreną naciskając przycisk Jump. Unkiaj przeszkód i zbieraj bąbelki z powietrzem. "+
                "Pamiętaj: twój tlen się kończy, a Urszula dodatkowo Ci go kradnie. Co więcej rekin i kolce mogą Cię zabić. "+
                "Bądź ostrożny i baw się dobrze!";
            
        }

       


    }
}
