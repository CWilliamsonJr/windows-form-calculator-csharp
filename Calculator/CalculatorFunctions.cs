using System;



namespace Calculator
{
    public partial class FormCalculator
    {
        private string _lastNumberEntered = String.Empty;
        private string _calculation;
        private const char Negative = '-';
        private char _mathOperator;
        private bool _numIsNegative = false;

       private void DisplayText(string number)
        {
            if (String.IsNullOrEmpty(lblDisplay.Text))
            {
                lblDisplay.Text = number;

            }
            else
            {
                var strTemp = lblDisplay.Text;
                double numTemp;
               
                strTemp += number;
                numTemp = Convert.ToDouble(strTemp);
                // TODO: add format string for commas and decmail
                lblDisplay.Text = numTemp.ToString();
            }
        }

        private void AddToCalculation(string mathOperator)
        {
            if (String.IsNullOrEmpty(_calculation))
            {
                _calculation = lblDisplay.Text + " " + mathOperator + " ";
            }
            else
            {
                _calculation += lblDisplay.Text + " " + mathOperator + " ";
            }
            lblDisplay.Text = "";
        }
    }
}
