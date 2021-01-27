using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Brackets
    {
        public static bool BracketsEmpty(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ')' && input[i - 1] == '(') { return true; }
            }
            return false;
        }

        public static bool OperationNextToBracket(string input)
        {
            bool ontb = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (i != 0 && i != input.Length)
                {
                    if (input[i] == '(' && char.IsDigit(input[i - 1])) { ontb = false; }
                    if (char.IsDigit(input[i]) && input[i - 1] == ')') { ontb = false; }
                }

            }
            return ontb;
        }

        public static bool BracketsBalanced(string input)
        {
            int count = 0;
            foreach (var item in input)
            {
                if (item == '(') { count++; }
                if (item == ')') { count--; }
            }
            if (count == 0) { return true; }

            return false;
        }
    }


}
