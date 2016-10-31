using System;
using System.Drawing;
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
            lblDisplay.Text = '0'.ToString();
            _calculation = string.Empty;
            currentOperation.Text = string.Empty;
        }

        private void btnNegative_Click(object sender, EventArgs e)
        {
            //*
            //ERROR: Enter Key is trigering this click event.

            if (_numIsNegative || (lblDisplay.Text.Contains("-")))
            {
                var temp = Convert.ToDouble(lblDisplay.Text); // changes string to a number.
                lblDisplay.Text = Convert.ToString(Math.Abs(temp), CultureInfo.CurrentCulture); // converts negative number back to positive
                _numIsNegative = false;
            }
            else
            {
                _numIsNegative = true;
                lblDisplay.Text = Negative + lblDisplay.Text; // makes number negative
            }

            //*/
        }

        private void btnClearEntry_Click(object sender, EventArgs e) // clears what's on screen
        {
            lblDisplay.Text = '0'.ToString();
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
        

        private void btnEqual_Click(object sender, EventArgs e)
        {
            DoCalculation();
        }
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!lblDisplay.Text.Contains(".")) // checks to see if decmail exist
            {
                lblDisplay.Text += @".";
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(_calculation)) return;

            var strTemp = _calculation;
            strTemp = strTemp.Trim(); // removes leading space
            strTemp = strTemp.Remove(strTemp.Length - 1); // removes operator sign
            var percent = 0.01 * Convert.ToDouble(lblDisplay.Text); // makes percentange into a decimal

            var result = new Expression($"({strTemp}) * {percent}"); // evaluates the expression

            currentOperation.Text += result.Evaluate().ToString(); // add to current operation text
            lblDisplay.Text = result.Evaluate().ToString();
            _skip = true;
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            var result = new Expression($"Sqrt({lblDisplay.Text})");
            currentOperation.Text += $@"sqrt({lblDisplay.Text})"; // adds square root to the current operation display
            lblDisplay.Text = result.Evaluate().ToString(); // posts result to the screen
            _skip = true;
        }

        private void btnSquared_Click(object sender, EventArgs e)
        {
            var sqr = lblDisplay.Text; // converts to double so a
            sqr += "*" + sqr;
            var result = new Expression(sqr);
            currentOperation.Text += $@"sqr({lblDisplay.Text})";
            lblDisplay.Text = result.Evaluate().ToString();
            _skip = true;
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            var inverse = "1/" + lblDisplay.Text;
            var result = new Expression(inverse);
            currentOperation.Text += $@"1/({lblDisplay.Text})";
            lblDisplay.Text = result.Evaluate().ToString();
            _skip = true;
        }

        #endregion



        private void FormCalculator_KeyUp(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode) // value of the key presses from the keyboard
            {
                //TODO: Fix Enter Key Issue
                
                case Keys.Return:
                    btnEqual.PerformClick();
                    btnEqual.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.Multiply:
                    btnMultiply.PerformClick();
                    btnMultiply.ResetBackColor();
                    break;
                case Keys.Add:
                    btnPlus.PerformClick();
                    btnPlus.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.Subtract:
                    btnMinus.PerformClick();
                    btnMinus.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.Divide:
                    btnDivide.PerformClick();
                    btnDivide.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.D0:
                case Keys.NumPad0:
                    btnZero.PerformClick();
                    btnZero.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    btnOne.PerformClick();
                    btnOne.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    btnTwo.PerformClick();
                    btnTwo.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    btnThree.PerformClick();
                    btnThree.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    btnFour.PerformClick();
                    btnFour.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    btnFive.PerformClick();
                    btnFive.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    btnSix.PerformClick();
                    btnSix.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    btnSeven.PerformClick();
                    btnSeven.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    bntEight.PerformClick();
                    bntEight.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    btnNine.PerformClick();
                    btnNine.ResetBackColor();
                    e.Handled = true;
                    break;
                case Keys.Back:
                    btnBackspace.PerformClick();
                    btnBackspace.ResetBackColor();
                    break;
                case Keys.Delete:
                    btnClearEntry.PerformClick();
                    btnClearEntry.ResetBackColor();
                    break;
                case Keys.Decimal:
                    btnDecimal.PerformClick();
                    btnDecimal.ResetBackColor();
                    break;
            }
        }

        private void FormCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) // value of the key presses from the keyboard
            {
                //TODO: Fix Enter Key Issue
                
                case Keys.Return:
                    btnEqual.BackColor = Color.CornflowerBlue;
                    e.Handled = true;
                    break;
                case Keys.Multiply:
                    btnMultiply.BackColor = Color.LightGray;
                    break;
                case Keys.Add:
                    btnPlus.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.Subtract:
                    btnMinus.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.Divide:
                    btnDivide.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.D0:
                case Keys.NumPad0:
                    btnZero.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    btnOne.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    btnTwo.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    btnThree.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    btnFour.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    btnFive.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    btnSix.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    btnSeven.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    bntEight.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    btnNine.BackColor = Color.LightGray;
                    e.Handled = true;
                    break;
                case Keys.Back:
                    btnBackspace.BackColor = Color.LightGray;
                    break;
                case Keys.Delete:
                    btnClearEntry.BackColor = Color.LightGray;
                    break;
                case Keys.Decimal:
                    btnDecimal.BackColor = Color.LightGray;
                    break;
            }
        }
    }
}
