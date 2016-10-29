using System;
using NCalc;


namespace Calculator
{
    public partial class FormCalculator
    {
        private string _lastNumberCalculated, _lastNumberEntered = String.Empty;
        private string _calculation; // holds string of the current math operations
        private const char Negative = '-';
        private char _mathOperator; // stores the math operator
        private bool _numIsNegative = false; // determines whether or not the negative key as been hi

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
                double numTemp = Convert.ToDouble(strTemp);
                // TODO: add format string for commas and decmail
                lblDisplay.Text = numTemp.ToString();
            }
        }

        private void AddToCalculation(string mathOperator)
        {
            if (String.IsNullOrEmpty(_calculation)) // populates the calculation string
            {
                _calculation = lblDisplay.Text + " " + mathOperator + " ";
                currentOperation.Text = _calculation;
            }
            else
            {
                _calculation += lblDisplay.Text + " " + mathOperator + " ";
                currentOperation.Text = _calculation;
            }
            
            lblDisplay.Text = string.Empty; // makes the display blank.
        }

        private void DoCalculation()
        {
            if (String.IsNullOrEmpty(lblDisplay.Text)) return; // returns if there is nothing to calculate, stops program from crashing.
            if (String.IsNullOrEmpty(_calculation))
            {
                _calculation = _lastNumberCalculated + _mathOperator + _lastNumberEntered; // makes new math expression to be calculated based on the last operation.
                Expression result = new Expression(_calculation);
                _lastNumberCalculated = lblDisplay.Text = result.Evaluate().ToString();

                _calculation = String.Empty;
            }
            else
            {
                _lastNumberEntered = lblDisplay.Text; // stores the last number entered 
                _calculation += lblDisplay.Text; // adds the last entered value to the calculation string
                Expression result = new Expression(_calculation); // builds new object to be evaluated
                _lastNumberCalculated = lblDisplay.Text = result.Evaluate().ToString(); // posts answer to the screen.

                _calculation = String.Empty;
            }
            currentOperation.Text = string.Empty;
        }
    }
}
