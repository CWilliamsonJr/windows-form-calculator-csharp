using System;
using System.Diagnostics;
using System.Globalization;
using NCalc;


namespace Calculator
{
    public partial class FormCalculator
    {
        private string _lastNumberCalculated, _lastNumberEntered = String.Empty;
        private string _calculation; // holds string of the current math operations
        private const char Negative = '-';
        private char? _mathOperator; // stores the math operator

        private bool _canSkip,
            // Determines whether or not operand needs to be added to current operation.
            _canAddNewNum, // allows for the overwriting of the number display
            _numIsNegative; // determines whether or not the negative key as been hi

        private void DisplayText(string number)
        {
            if (_canAddNewNum) // adds the text to the screen
            {
                lblDisplay.Text = number;
                _canAddNewNum = false;
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
            if (_canSkip == false)
            {
                currentOperation.Text += lblDisplay.Text + @" " + mathOperator + @" ";
            }
            else
            {
                currentOperation.Text += @" " + mathOperator + @" ";
                _canSkip = false;
            }
            _canAddNewNum = true;
            //lblDisplay.Text = string.Empty; // makes the display blank.
        }

        private void DoCalculation()
        {
            if (!_mathOperator.HasValue) return; // returns if there is nothing to calculate, stops program from crashing.
            if (String.IsNullOrEmpty(_calculation))
            {

                _calculation = _lastNumberCalculated + _mathOperator + _lastNumberEntered; // makes new math expression to be calculated based on the last operation.
                var result = new Expression(_calculation);
                _lastNumberCalculated = lblDisplay.Text = result.Evaluate().ToString();
                lblHistory.Text += string.Format("{0} = \n {1} \n\n", _calculation, _lastNumberEntered);
                _calculation = String.Empty;
            }
            else
            {
                
                _lastNumberEntered = lblDisplay.Text; // stores the last number entered 
                _calculation += lblDisplay.Text; // adds the last entered value to the calculation string
                var result = new Expression(_calculation); // builds new object to be evaluated
                _lastNumberCalculated = lblDisplay.Text = result.Evaluate().ToString(); // posts answer to the screen.
                lblHistory.Text += string.Format("{0}{1} = \n {2} \n\n", currentOperation.Text, _lastNumberEntered,
                    _lastNumberCalculated);
                _calculation = String.Empty;
            }
            _canAddNewNum = true;
            currentOperation.Text = string.Empty;
        }
    }
}
