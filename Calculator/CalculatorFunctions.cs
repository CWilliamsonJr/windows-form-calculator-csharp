using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;


namespace Calculator
{
    public partial class FormCalculator
    {
        private string firstNumber;
        private string secondNumber;
        private string calculation;
        private const char _negative = '-';
        private char _mathOperator;
        private bool _numIsNegative = false;

        private void DisplayNumbers(string number)
        {
            if (String.IsNullOrEmpty(lblDisplay.Text))
            {
                lblDisplay.Text = number;

            }
            else
            {
                lblDisplay.Text += number;

            }
        }

        private void Temp(char mathOperator)
        {
            if (String.IsNullOrEmpty(calculation))
            {
                calculation = lblDisplay.Text + " " + mathOperator + " ";
            }
            else
            {
                calculation += lblDisplay.Text + " " + mathOperator + " ";
            }
        }
    }
}
