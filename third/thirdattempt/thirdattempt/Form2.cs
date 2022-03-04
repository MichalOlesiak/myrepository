using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thirdattempt
{
    

    public partial class Form2 : Form
    {
        public static Form2 instance;
        public Form2()
        {
            AssginWordsToSquares();
            InitializeComponent();
            instance = this;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        
        }
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "A","A","B","B","C","C","D","D",
        };

        Label firsClicked, secondClicked;

    

        private void labelClick(object sender, EventArgs e)
        {
            if (firsClicked != null && secondClicked != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;

            if (clickedLabel.ForeColor == Color.Blue)
                return;

            if (firsClicked == null)
            {
                firsClicked = clickedLabel;
                firsClicked.ForeColor = Color.Black;
                return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            CheckForWinner();

            if (firsClicked.Text == secondClicked.Text)
            {
                firsClicked = null;
                secondClicked = null;
            }
            else
                timer1.Start();
        }

        private void CheckForWinner()
        {
            Label? label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            MessageBox.Show("You Won! U have great memory!");
            Close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firsClicked.ForeColor = firsClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firsClicked = null;
            secondClicked = null;
        }

        private void AssginWordsToSquares()
        {
            Label label;
            int randomNumber;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;
                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);
            }
        }
    }
}
