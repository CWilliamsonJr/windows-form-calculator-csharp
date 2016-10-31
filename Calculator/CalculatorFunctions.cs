using System;
using System.Globalization;
using NCalc;


namespace Calculator
{
    public partial class FormCalculator
    {
        private string _lastNumberCalculated, _lastNumberEntered = String.Empty;
        private string _calculation; // holds string of the current math operations
        private const char Negative = '-';
        private char _mathOperator; // stores the math operator
        private bool _skip, _numIsNegative; // determines whether or not the negative key as been hi

        private void DisplayText(string number)
        {
            if (string.IsNullOrEmpty(lblDisplay.Text)) // adds the text to the screen
            {
                lblDisplay.Text = number;

            }
            else
            {
                var strTemp = lblDisplay.Text;
                strTemp += number;
                var numTemp = Convert.ToDouble(strTemp);
                // TODO: add format string for commas and decmail
                lblDisplay.Text = numTemp.ToString(CultureInfo.CurrentCulture);
            }
        }

        private void AddToCalculation(string mathOperator)
        {
            //TODO: Add flag for if Sqrt is used so that current operation shows sqrt(num)

            if (string.IsNullOrEmpty(lblDisplay.Text)) return; // prevents blank operations from being added.

            _calculation += lblDisplay.Text + @" " + mathOperator + @" ";
            if (_skip == false)
            {
                currentOperation.Text += lblDisplay.Text + @" " + mathOperator + @" ";
            }
            else
            {
                currentOperation.Text += @" " + mathOperator + @" ";
                _skip = false;
            }

            lblDisplay.Text = string.Empty; // makes the display blank.
        }

        private void DoCalculation()
        {
            if (string.IsNullOrEmpty(_mathOperator.ToString())) return; // stops math from happening if enter is hit when nothing has been entered.

            if (String.IsNullOrEmpty(_calculation))
            {
                if (_mathOperator.ToString() == string.Empty) return; // stops math from happening if enter is hit when nothing has been entered.
                _calculation = _lastNumberCalculated + _mathOperator + _lastNumberEntered; // makes new math expression to be calculated based on the last operation.
                var result = new Expression(_calculation);
                _lastNumberCalculated = lblDisplay.Text = result.Evaluate().ToString();
                _calculation = String.Empty;
            }
            else
            {
                _lastNumberEntered = lblDisplay.Text; // stores the last number entered 
                _calculation += lblDisplay.Text; // adds the last entered value to the calculation string
                var result = new Expression(_calculation); // builds new object to be evaluated
                _lastNumberCalculated = lblDisplay.Text = result.Evaluate().ToString(); // posts answer to the screen.

                _calculation = String.Empty;
            }
            currentOperation.Text = string.Empty;
        }
    }
}
