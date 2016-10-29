using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
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

        #region Calculator Button Clicks
        
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

        private void btnZero_Click(object sender, EventArgs e)
        {
            DisplayText("0");
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length >= 1) // removes a character from the display
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e) // clears screen and current calculation
        {
            lblDisplay.Text = string.Empty;
            _calculation = string.Empty;
            currentOperation.Text = string.Empty;
        }


        private void btnClearEntry_Click(object sender, EventArgs e) // clears what's on screen
        {
            lblDisplay.Text = string.Empty;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            _mathOperator = '+';
            AddToCalculation(_mathOperator.ToString());
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
        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            var temp = Convert.ToDouble(lblDisplay.Text); // changes string to a number to be tested if negative.
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
            DoCalculation();
        }
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!lblDisplay.Text.Contains(".")) // checks to see if decmail exist
            {
                lblDisplay.Text += ".";
            }
        }

        #endregion



        private void btnClear_MouseHover(object sender, EventArgs e)
        {
        }

        private void FormCalculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            Color color = new Color();
            int delay = 0;
            
            switch (e.KeyChar) // value of the key presses from the keyboard
            {
                case (char) Keys.Return:
                    DoCalculation();
                    e.Handled = true;
                    break;
                case (char) 42:
                    _mathOperator = '*';
                    AddToCalculation(_mathOperator.ToString());
                    e.Handled = true;
                    break;
                case (char) 43:
                    _mathOperator = '+';
                    AddToCalculation(_mathOperator.ToString());
                    e.Handled = true;
                    break;
                case (char) 45:
                    _mathOperator = '-';
                    AddToCalculation(_mathOperator.ToString());
                    e.Handled = true;
                    break;
                case (char) 47:
                    _mathOperator = '/';
                    AddToCalculation(_mathOperator.ToString());
                    e.Handled = true;
                    break;
                case (char) 48:
                    DisplayText("0");
                    /*
                    color = btnZero.BackColor;
                    btnZero.BackColor = Color.Gray;
                    Thread.Sleep(delay);
                    btnZero.BackColor = color;
                    //*/
                    e.Handled = true;
                    break;
                case (char) 49:
                    DisplayText("1");
                    e.Handled = true;
                    break;
                case (char) 50:
                    DisplayText("2");
                    e.Handled = true;
                    break;
                case (char) 51:
                    DisplayText("3");
                    e.Handled = true;
                    break;
                case (char) 52:
                    DisplayText("4");
                    e.Handled = true;
                    break;
                case (char) 53:
                    DisplayText("5");
                    e.Handled = true;
                    break;
                case (char) 54:
                    DisplayText("6");
                    e.Handled = true;
                    break;
                case (char) 55:
                    DisplayText("7");
                    e.Handled = true;
                    break;
                case (char) 56:
                    DisplayText("8");
                    e.Handled = true;
                    break;
                case (char) 57:
                    DisplayText("9");
                    e.Handled = true;
                    break;
                default:
                    
                    e.Handled = true;
                    break;
            }
        }
    }
}
