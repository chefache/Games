using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = X turn, false = Y;
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Stefan Koev", "Tic Tac Toe");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            turn = !turn;
            b.Enabled = false;
            turnCount++;

            CheckForWinner();
        }

        private void CheckForWinner()
        {            
            bool thereIsAWinner = false;

            // horizontal check
            if (A1.Text == A2.Text && A2.Text == A3.Text && !A1.Enabled)
            {
                thereIsAWinner = true;
            }
            if (B1.Text == B2.Text && B2.Text == B3.Text && !B1.Enabled)
            {
                thereIsAWinner = true;
            }
            if (C1.Text == C2.Text && C2.Text == C3.Text && !C1.Enabled)
            {
                thereIsAWinner = true;
            }

            // vertical check
            if (A1.Text == B1.Text && B1.Text == C1.Text && !A1.Enabled)
            {
                thereIsAWinner = true;
            }
            if (A2.Text == B2.Text && B2.Text == C2.Text && !A2.Enabled)
            {
                thereIsAWinner = true;
            }
            if (A3.Text == B3.Text && B3.Text == C3.Text && !A3.Enabled)
            {
                thereIsAWinner = true;
            }

            // diagonal check
            if (A1.Text == B2.Text && B2.Text == C3.Text && !A1.Enabled)
            {
                thereIsAWinner = true;
            }
            if (A3.Text == B2.Text && B2.Text == C1.Text && !A3.Enabled)
            {
                thereIsAWinner = true;
            }

            if (thereIsAWinner)
            {
                DisableButtons();
                string winner = "";
                if (turn)
                {
                    winner = "O";
                    oWinCount.Text = (Int32.Parse(oWinCount.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    xWinCount.Text = (Int32.Parse(xWinCount.Text) + 1).ToString();
                }
                MessageBox.Show(winner + " Wins!", "Super!");
            }
            else
            {
                if (turnCount == 9)
                {
                    drawCaunt.Text = (Int32.Parse(drawCaunt.Text) + 1).ToString();
                    MessageBox.Show("Draw!", "Bummer");
                }
            }
        } // End of winner check

        private void DisableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }          
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;
           
            foreach (Control c in Controls)
            {
                try
                {

                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
           
        }
         

        private void buttonEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                {
                    b.Text = "X";
                }
                else
                {
                    b.Text = "O";
                }
            }
        }

        private void buttonLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resetScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oWinCount.Text = "0";
            xWinCount.Text = "0";
            drawCaunt.Text = "0";
        }
    }
}
