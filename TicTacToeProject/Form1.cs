using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeProject
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = X turn; false = Y turn
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Alex", "Tic Tac Toes About");
        }

        private void existToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                if (turn)
                {
                    b.Text = "X";
                    b.BackColor = Color.BlueViolet;
                }

                else
                {
                    b.Text = "O";
                    b.BackColor = Color.AntiqueWhite;
                }
                turn = !turn;
                b.Enabled = false;
                turn_count++;
                checkForWinner();
            }
            catch { }
            
        }

        private void checkForWinner()
        {
            bool there_is_a_winner = false;

            foreach (Control c in Controls)
            {
                // Horizontal Check
                if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                    there_is_a_winner = true;
                else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                    there_is_a_winner = true;
                else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                    there_is_a_winner = true;
                
                // Vertical Check
                else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                    there_is_a_winner = true;
                else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!B1.Enabled))
                    there_is_a_winner = true;
                else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!C1.Enabled))
                    there_is_a_winner = true;
                
                // Diagonal Check
                else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                    there_is_a_winner = true;
                else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                    there_is_a_winner = true;
                break;
            }


            if (there_is_a_winner)
            {
                disableButtons();

                String Winner = "";
                if (turn)               
                    Winner = "O";
                else Winner = "X";

                MessageBox.Show(Winner + " Wins", "Yay!");
                

            }//end if

            else
            {
                if (turn_count == 9)
                {
                    MessageBox.Show("Draw!", "Bummer!");
                }
            }

            

        }//end for checkFormWinner
        private void disableButtons()
        {
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
                catch
                {

                }

            }//end foreach



        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    
                }
                catch
                {

                }

            }
        }

    }
}