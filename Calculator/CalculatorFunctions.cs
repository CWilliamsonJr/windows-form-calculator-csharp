using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public partial class FormCalculator
    {
        private string firstNumber = "";
        private string secondNumber = "";
        private char mathOperator, negative = '-';
        private bool numIsNegative = false;
        private DataTable result = new DataTable();
        private string[] calculations;
        

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
    }
}
