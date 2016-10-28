using System;
using System.Globalization;
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
            DisplayText("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            DisplayText("2");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            DisplayText("3");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            DisplayText("4");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            DisplayText("5");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            DisplayText("6");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            DisplayText("7");
        }

        private void bnEight_Click(object sender, EventArgs e)
        {
            DisplayText("8");
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            DisplayText("9");
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

        

        private void btnClearEntry_Click(object sender, EventArgs e) // clears what's on screen
        {
            lblDisplay.Text = "";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            _mathOperator = '+';
            AddToCalculation(_mathOperator.ToString());
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            var temp = Convert.ToDouble(lblDisplay.Text);
            if (_numIsNegative || temp <= 0) // testing if negative is was already added or the number itself is negative
            {
                lblDisplay.Text = Convert.ToString(Math.Abs(temp), CultureInfo.CurrentCulture); // converts negative number back to positive
                _numIsNegative = false;
            }
            else
            {
                _numIsNegative = true;
                lblDisplay.Text = Negative + lblDisplay.Text; // makes number negative
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lblDisplay.Text)) return;
            _calculation += lblDisplay.Text;
            Expression result = new Expression(_calculation);
            lblDisplay.Text = result.Evaluate().ToString();
            _calculation = "";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            _mathOperator = '/';
            AddToCalculation(_mathOperator.ToString());
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            _mathOperator = '*';
            AddToCalculation(_mathOperator.ToString());
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            _mathOperator = '-';
            AddToCalculation(_mathOperator.ToString());
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!lblDisplay.Text.Contains("."))
            {
               // DisplayText(".");
                lblDisplay.Text += ".";
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            _calculation = "";
        }
    }
}
