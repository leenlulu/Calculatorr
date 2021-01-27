using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {

            InitializeComponent();

        }

        int plusMinusCount = 0;
        int multiplyDivideCount = 0;
        int decimalCount = 0;
        private void calculateButton_Click(object sender, EventArgs e)
        {
            string input = textBox.Text;
            if (Brackets.BracketsBalanced(input))
            {
                if (Brackets.OperationNextToBracket(input))
                {
                    if (Brackets.BracketsEmpty(input))
                    {
                        MessageBox.Show("The brackets are empty!");
                    }
                    else
                    {
                        string answer = Calculation.Calculate(input);
                        textBox.Text = answer;
                    }

                }
                else
                {
                    MessageBox.Show("Please add an operation between the number and bracket.");
                }
            }
            else
            {
                MessageBox.Show("A bracket is missing.");
            }
        }




        public static bool IsDigit(char c)
        {
            return (c >= '0' && c <= '9');
        }

        private void InputButton(Button Btn)
        {
            textBox.Text = textBox.Text + Btn.Text;
            //Btn.Tag for operations
        }

        private void button1_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;

            InputButton(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;

            InputButton(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;

            InputButton(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;

            InputButton(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;

            InputButton(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;

            InputButton(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;

            InputButton(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;

            InputButton(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;

            InputButton(button9);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;

            InputButton(button0);
        }

        private void dotButton_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;
            decimalCount++;
            if (decimalCount < 2)
            {
                InputButton(dotButton);
            }

        }

        private void leftParanthesisButton_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;
            decimalCount = 0;

            InputButton(leftParanthesisButton);
        }

        private void rightParanthesisButton_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;
            decimalCount = 0;


            InputButton(rightParanthesisButton);
        }


        private void plusButton_Click(object sender, EventArgs e)
        {

            plusMinusCount++;
            multiplyDivideCount = 0;
            decimalCount = 0;

            if (plusMinusCount < 2)
            {
                InputButton(plusButton);
            }

        }

        private void minusButton_Click(object sender, EventArgs e)
        {

            plusMinusCount++;
            multiplyDivideCount = 0;
            decimalCount = 0;

            if (plusMinusCount < 2)
            {

                InputButton(minusButton);
            }
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            plusMinusCount = 0;
            decimalCount = 0;
            multiplyDivideCount++;

            if (multiplyDivideCount < 2 && textBox.Text != "" && !textBox.Text.EndsWith("+") && !textBox.Text.EndsWith("-") && !textBox.Text.EndsWith("."))

            {
                InputButton(multiplyButton);
            }
        }

        private void divideButton_Click(object sender, EventArgs e)
        {

            plusMinusCount = 0;
            decimalCount = 0;
            multiplyDivideCount++;

            if (multiplyDivideCount < 2 && textBox.Text != "")

            {
                InputButton(divideButton);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)

        {
            if (textBox.Text.EndsWith("."))
            {
                decimalCount = 0;
            }

            if (textBox.Text.EndsWith("+") || textBox.Text.EndsWith("-"))
            {
                plusMinusCount = 0;
            }

            if (textBox.Text.EndsWith("*") || textBox.Text.EndsWith("/"))
            {
                multiplyDivideCount = 0;
            }

            if(textBox.Text != "")
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }
           

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            multiplyDivideCount = 0;
            plusMinusCount = 0;
            decimalCount = 0;

            textBox.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
