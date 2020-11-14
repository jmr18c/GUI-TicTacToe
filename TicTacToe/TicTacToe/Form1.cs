using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        // Variables to be used throughout the class
        string currentPlayer;
        bool win = false;
        int dHScore = 0;
        int dAScore = 0;
        double dHPer = 0;
        double dAPer = 0;
        int turnCount = 0, roundCount = 0;
        int[] buttons = {0,0,0,0,0,0,0,0,0}; // Array the stores the current state of each button

        // Method that sets everything to beginning state for a new game
        void newGame()
        {
            // All button images set to null
            button1.Image = null;
            button2.Image = null;
            button3.Image = null;
            button4.Image = null;
            button5.Image = null;
            button6.Image = null;
            button7.Image = null;
            button8.Image = null;
            button9.Image = null;
            // Every index in buttons array set to 0
            for (int i = 0; i < 9; i++)
            {
                buttons[i] = 0;
            }
            // Set first current player, turn count to 0, and win bool to false
            currentPlayer = "Dr. Homer";
            turnCount = 0;
            win = false;
            // Show current statistics if "Play Again", Show fresh start of statistics if "Reset"
            label1.Text = String.Format("Winning Percentages:\nDr. Homer: {0:F2}\nDr. Arisoa: {1:F2}", dHPer, dAPer);
            // Display beginning texts
            textBox1.Text = currentPlayer + "'s Turn!";
            textBox2.Text = "Click a square to take your turn!";
        }
        // Method the switches which player's turn it is
        void switchPlayer()
        {
            // Increment turn count
            turnCount++;
            
            // If the 9th and final turn has not been taken
            if (turnCount <= 8)
            {
                // Simply switch current player
                if (currentPlayer == "Dr. Homer")
                {
                    currentPlayer = "Dr. Arisoa";
                }
                else
                {
                    currentPlayer = "Dr. Homer";
                }
            }
            else if (!win) // If the final turn has been taken and not win
            {
                // Display tie message and set win to true
                textBox2.Text = "It's a tie!";
                win = true;
            }

            // If win/If round is over
            if (win)
            {
                // Display round over message and increment round count
                textBox1.Text = "Round Over!";
                roundCount++;

                // Update each player's winning percentage
                dHPer = (double)dHScore / roundCount;
                dAPer = (double)dAScore / roundCount;
            }
            else // If not win
            {
                // Display whose turn it is
                textBox1.Text = currentPlayer + "'s Turn!";
            }

            // Show curren winning percentages
            label1.Text = String.Format("Winning Percentages:\nDr. Homer: {0:F2}\nDr. Arisoa: {1:F2}", dHPer, dAPer);
        }
        // Method to check for a win
        void checkForWin()
        {
            // If not a win yet (win is false)
            if (!win && buttons[0] != 0 && buttons[0] == buttons[1] && buttons[1] == buttons[2]) // Match across top row
            {
                // Display who won
                textBox2.Text = currentPlayer + " Wins!";

                // Update winning players score
                if (currentPlayer == "Dr. Homer")
                {
                    dHScore++;
                }
                else
                {
                    dAScore++;
                }

                // Set win to true
                win = true;
            }
            else if (!win && buttons[3] != 0 && buttons[3] == buttons[4] && buttons[4] == buttons[5]) // Match across middle row
            {
                // All same as first condition block
                textBox2.Text = currentPlayer + " Wins!";

                if (currentPlayer == "Dr. Homer")
                {
                    dHScore++;
                }
                else
                {
                    dAScore++;
                }

                win = true;
            }
            else if (!win && buttons[6] != 0 && buttons[6] == buttons[7] && buttons[7] == buttons[8]) // Match across bottom row
            {
                // All same as first condition block
                textBox2.Text = currentPlayer + " Wins!";

                if (currentPlayer == "Dr. Homer")
                {
                    dHScore++;
                }
                else
                {
                    dAScore++;
                }

                win = true;
            }
            else if (!win && buttons[0] != 0 && buttons[0] == buttons[3] && buttons[3] == buttons[6]) // Match down first column
            {
                // All same as first condition block
                textBox2.Text = currentPlayer + " Wins!";

                if (currentPlayer == "Dr. Homer")
                {
                    dHScore++;
                }
                else
                {
                    dAScore++;
                }

                win = true;
            }
            else if (!win && buttons[1] != 0 && buttons[1] == buttons[4] && buttons[4] == buttons[7]) // Match down middle column
            {
                // All same as first condition block
                textBox2.Text = currentPlayer + " Wins!";

                if (currentPlayer == "Dr. Homer")
                {
                    dHScore++;
                }
                else
                {
                    dAScore++;
                }

                win = true;
            }
            else if (!win && buttons[2] != 0 && buttons[2] == buttons[5] && buttons[5] == buttons[8]) // Match down last column
            {
                // All same as first condition block
                textBox2.Text = currentPlayer + " Wins!";

                if (currentPlayer == "Dr. Homer")
                {
                    dHScore++;
                }
                else
                {
                    dAScore++;
                }

                win = true;
            }
            else if (!win && buttons[0] != 0 && buttons[0] == buttons[4] && buttons[4] == buttons[8]) // Match down right to left diagonal
            {
                // All same as first condition block
                textBox2.Text = currentPlayer + " Wins!";

                if (currentPlayer == "Dr. Homer")
                {
                    dHScore++;
                }
                else
                {
                    dAScore++;
                }

                win = true;
            }
            else if (!win && buttons[2] != 0 && buttons[2] == buttons[4] && buttons[4] == buttons[6]) // Match down left to right diagonal
            {
                // All same as first condition block
                textBox2.Text = currentPlayer + " Wins!";

                if (currentPlayer == "Dr. Homer")
                {
                    dHScore++;
                }
                else
                {
                    dAScore++;
                }

                win = true;
            }
        }
        public Form1()
        {
            // Initialize the form and call new game method
            InitializeComponent();
            newGame();
        }

        // Button 1 clicked (Top Left Spot)
        private void button1_Click(object sender, EventArgs e)
        {
            // If index of button equals 0 and no win yet
            if (buttons[0] == 0 && !win)
            {
                // Update button's image based of whose turn it is
                if (currentPlayer == "Dr. Homer")
                {
                    
                    button1.Image = new Bitmap(Properties.Resources.drHomer, button1.Width, button1.Height);
                    buttons[0] = 1;
                }
                else
                {
                    button1.Image = new Bitmap(Properties.Resources.drArisoa, button1.Width, button1.Height);
                    buttons[0] = 2;
                }
                button1.Update();

                // Call check for win then switch player methods
                checkForWin();
                switchPlayer();
            }
        }

        // Button 2 clicked (Top Middle Spot)
        private void button2_Click(object sender, EventArgs e)
        {
            // All same as button 1 but for 2
            if (buttons[1] == 0 && !win)
            {
                if (currentPlayer == "Dr. Homer")
                {
                    button2.Image = new Bitmap(Properties.Resources.drHomer, button2.Width, button2.Height);
                    buttons[1] = 1;
                }
                else
                {
                    button2.Image = new Bitmap(Properties.Resources.drArisoa, button2.Width, button2.Height);
                    buttons[1] = 2;
                }
                button2.Update();

                checkForWin();
                switchPlayer();
            }
        }
        
        // Button 3 clicked (Top Right Spot)
        private void button3_Click(object sender, EventArgs e)
        {
            // All same as button 1 but for 3
            if (buttons[2] == 0 && !win)
            {
                if (currentPlayer == "Dr. Homer")
                {
                    button3.Image = new Bitmap(Properties.Resources.drHomer, button3.Width, button3.Height);
                    buttons[2] = 1;
                }
                else
                {
                    button3.Image = new Bitmap(Properties.Resources.drArisoa, button3.Width, button3.Height);
                    buttons[2] = 2;
                }
                button3.Update();

                checkForWin();
                switchPlayer();
            }
        }

        // Button 4 clicked (Middle Left Spot)
        private void button4_Click(object sender, EventArgs e)
        {
            // All same as button 1 but for 4
            if (buttons[3] == 0 && !win)
            {
                if (currentPlayer == "Dr. Homer")
                {
                    button4.Image = new Bitmap(Properties.Resources.drHomer, button4.Width, button4.Height);
                    buttons[3] = 1;
                }
                else
                {
                    button4.Image = new Bitmap(Properties.Resources.drArisoa, button4.Width, button4.Height);
                    buttons[3] = 2;
                }
                button4.Update();

                checkForWin();
                switchPlayer();
            }
        }

        // Button 5 clicked (Middle Middle Spot)
        private void button5_Click(object sender, EventArgs e)
        {
            // All same as button 1 but for 5
            if (buttons[4] == 0 && !win)
            {
                if (currentPlayer == "Dr. Homer")
                {
                    button5.Image = new Bitmap(Properties.Resources.drHomer, button5.Width, button5.Height);
                    buttons[4] = 1;
                }
                else
                {
                    button5.Image = new Bitmap(Properties.Resources.drArisoa, button5.Width, button5.Height);
                    buttons[4] = 2;
                }
                button5.Update();
                
                checkForWin();
                switchPlayer();
            }
        }

        // Button 6 clicked (Middle Right Spot)
        private void button6_Click(object sender, EventArgs e)
        {
            // All same as button 1 but for 6
            if (buttons[5] == 0 && !win)
            {
                if (currentPlayer == "Dr. Homer")
                {
                    button6.Image = new Bitmap(Properties.Resources.drHomer, button6.Width, button6.Height);
                    buttons[5] = 1;
                }
                else
                {
                    button6.Image = new Bitmap(Properties.Resources.drArisoa, button6.Width, button6.Height);
                    buttons[5] = 2;
                }
                button6.Update();
                
                checkForWin();
                switchPlayer();
            }
        }

        // Button 7 clicked (Bottom Left Spot)
        private void button7_Click(object sender, EventArgs e)
        {
            // All same as button 1 but for 7
            if (buttons[6] == 0 && !win)
            {
                if (currentPlayer == "Dr. Homer")
                {
                    button7.Image = new Bitmap(Properties.Resources.drHomer, button7.Width, button7.Height);
                    buttons[6] = 1;
                }
                else
                {
                    button7.Image = new Bitmap(Properties.Resources.drArisoa, button7.Width, button7.Height);
                    buttons[6] = 2;
                }
                button7.Update();
                
                checkForWin();
                switchPlayer();
            }
        }

        // Button 8 clicked (Bottom Middle Spot)
        private void button8_Click(object sender, EventArgs e)
        {
            // All same as button 1 but for 8
            if (buttons[7] == 0 && !win)
            {
                if (currentPlayer == "Dr. Homer")
                {
                    button8.Image = new Bitmap(Properties.Resources.drHomer, button8.Width, button8.Height);
                    buttons[7] = 1;
                }
                else
                {
                    button8.Image = new Bitmap(Properties.Resources.drArisoa, button8.Width, button8.Height);
                    buttons[7] = 2;
                }
                button8.Update();
                
                checkForWin();
                switchPlayer();
            }
        }

        // Button 9 clicked (Bottom Right Spot)
        private void button9_Click(object sender, EventArgs e)
        {
            // All same as button 1 but for 9
            if (buttons[8] == 0 && !win)
            {
                if (currentPlayer == "Dr. Homer")
                {
                    button9.Image = new Bitmap(Properties.Resources.drHomer, button9.Width, button9.Height);
                    buttons[8] = 1;

                }
                else
                {
                    button9.Image = new Bitmap(Properties.Resources.drArisoa, button9.Width, button9.Height);
                    buttons[8] = 2;
                }
                button9.Update();
                
                checkForWin();
                switchPlayer();
            }
        }

        // Play Again button clicked
        private void button10_Click(object sender, EventArgs e)
        {
            // Call new game method
            newGame();
        }

        // Reset button clicked
        private void button11_Click(object sender, EventArgs e)
        {
            // Before calling new game method
            // Set scores, percentages, and round count to 0
            dHScore = 0;
            dAScore = 0;
            dHPer = 0;
            dAPer = 0;
            roundCount = 0;

            // Call new game method
            newGame();
        }
    }
}
