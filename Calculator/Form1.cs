using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class formCalculator : Form
    {
       private List<string> Calculations = new List<string>();

        public formCalculator()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            DisplayNumbers("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            DisplayNumbers("2");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            DisplayNumbers("3");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            DisplayNumbers("4");
        }

        private void DisplayNumbers(string number)
        {


            if (true)
            {
                if (String.IsNullOrEmpty(lblDisplay.Text))
                {
                    lblDisplay.Text = number;
                    Calculations.Add(number);
                }
                else
                {
                    lblDisplay.Text += number;
                    Calculations.Add(number);
                }
            }
            
            
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            DisplayNumbers("5");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            DisplayNumbers("6");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            DisplayNumbers("7");
        }

        private void bnEight_Click(object sender, EventArgs e)
        {
            DisplayNumbers("8");
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            DisplayNumbers("9");
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
