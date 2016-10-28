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
using NCalc;

namespace Calculator
{
    public partial class FormCalculator : Form
    {

        public FormCalculator()
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

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length >= 1)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) // clears everything
        {
            lblDisplay.Text = "";
        }

        private void btnClearEntry_Click(object sender, EventArgs e) // clears what's on screen
        {
            lblDisplay.Text = "";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            _mathOperator = '+';
            Temp(_mathOperator);
            lblDisplay.Text = "";
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            var temp = Convert.ToDouble(lblDisplay.Text);
            if (_numIsNegative || temp <= 0) // testing if negative is was already added or the number itself is negative
            {
                lblDisplay.Text = Convert.ToString(Math.Abs(temp)); // converts negative number back to positive
                _numIsNegative = false;
            }
            else
            {
                _numIsNegative = true;
                lblDisplay.Text = _negative + lblDisplay.Text; // makes number negative
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            calculation += lblDisplay.Text;
            Expression result = new Expression(calculation);
            lblDisplay.Text = result.Evaluate().ToString();
        }
    }
}
