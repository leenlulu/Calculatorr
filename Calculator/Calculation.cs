using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculation    
    {
        public static string Calculate(string input)
        {
            string answer = "";
            Queue<string> p = new Queue<string>();
            try
            {
               p = PostFix(input);
            }
            catch (Exception e)
            {
                answer = "ERROR.";
            }

            try
            {
                answer = Solve(p);
            }
               catch (Exception e)
            {
                answer = "ERROR.";
            }
            return answer;
        }

        //solves postfix equations
        private static string Solve(Queue<String> p)
        {
            Stack<double> val = new Stack<double>();
            int lngth = p.Count;
            string answer = "";
            foreach (var item in p)
            {
                if (double.TryParse(item, out double num))
                {
                    val.Push(num);

                }
                else
                {
                    if (IsOp(char.Parse(item)))
                    {
                        
                        char op = char.Parse(item);
                        double b = val.Pop();
                        double a = val.Pop();
                        answer = Eval(a, b, op);
                        val.Push(double.Parse(answer));
                    }
                }
            }
            return answer;
        }

        private static string Eval(double a, double b, char op)
        {
            double answer = 0;
            if (op == '+') { answer = a + b; }
            if (op == '-') { answer = a - b; }
            if (op == '*') { answer = a * b; }
            if (op == '/') { answer = a / b; }
            return answer.ToString();
        }

        //converts equation to postfix
        private static Queue<string> PostFix(string input)
        {
            Stack<char> opr = new Stack<char>();
            Queue<string> output = new Queue<string>();
            string num = "";
            int bracket = 0;
            int op = 0;



            for (int i = 0; i < input.Length; i++)
            {
                
                //for operators
                if (IsOp(input[i]))
                {
                    op++;
                    if(i == 0 && Precedence(input[i]) == 1)
                    {
                        num = num + input[i];
                        op--;
                    }
                    
                    else if(op > 1 && Precedence(input[i]) == 1 && input[i - 1] != ')')
                    {
                        num = num + input[i];
                    }
                    else
                    {

                        if (num != "")
                        {
                            output.Enqueue(num);
                            num = "";

                        }


                        if (input[i] == '(')
                        {
                            
                            bracket++;
                            opr.Push(input[i]);

                        }
                        else
                        {
                            if (opr.Count == 0) { opr.Push(input[i]); }
                            else if (input[i] == ')')
                            {

                                while (opr.Peek() != '(' && opr.Count > 0)
                                {
                                    output.Enqueue(opr.Pop().ToString());
                                }

                                opr.Pop();
                                bracket--;
                            }
                            else if (Precedence(input[i]) > Precedence(opr.Peek()))
                            {
                                opr.Push(input[i]);
                            }
                            else if (Precedence(input[i]) == Precedence(opr.Peek()))
                            {

                                output.Enqueue(opr.Pop().ToString());
                                opr.Push(input[i]);

                            }
                            else if (Precedence(input[i]) < Precedence(opr.Peek()))
                            {
                                if (opr.Peek() == '(')
                                {
                                    opr.Push(input[i]);
                                }
                                else
                                {
                                    if (bracket > 0 && opr.Peek() != '(')
                                    {
                                        while (opr.Count > 0 && opr.Peek() != '(')
                                        {
                                            output.Enqueue(opr.Pop().ToString());
                                        }
                                        opr.Push(input[i]);

                                    }
                                    else
                                    {

                                        while (opr.Count > 0)
                                        {
                                            output.Enqueue(opr.Pop().ToString());
                                        }
                                        opr.Push(input[i]);
                                    }

                                }

                            }
                            else
                            {
                                while (opr.Count > 0)
                                {
                                    output.Enqueue(opr.Pop().ToString());
                                    opr.Push(input[i]);
                                }
                            }
                        }
                    }
                }
                    

                // for digits
               else if (IsDigit(input[i]) || input[i] == '.')
                {
                    op = 0;
                    num = num + input[i];
                }
            }
            if(num != "")
            {
                output.Enqueue(num);
            }
            while (opr.Count > 0)
            {
                output.Enqueue(opr.Pop().ToString());
            }


            return output;
        }

        //checks precedence
        private static int Precedence(char v)
        {
            int order = 0;
            if (v == '(' || v == ')') { order = 3; }
            if (v == '*' || v == '/') { order = 2; }
            if (v == '+' || v == '-') { order = 1; }
            return order;
        }



        public static bool IsDigit(char c)
        {
            return (c >= '0' && c <= '9');
        }

        public static bool IsOp(char c)
        {
            return (c == '+' || c == '-' || c == '*' || c == '/' || c == '(' || c == ')');
        }

    }
}
  