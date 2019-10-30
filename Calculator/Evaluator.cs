using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public delegate Double Caculate(Double x, Double y);
    public class Evaluator
    {
        private List<StringBuilder> infixExpression = new List<StringBuilder>();
        private List<StringBuilder> postfixExpression = new List<StringBuilder>();
        private Double res;

        private int AppendNumber(StringBuilder builder, String expression, int i)
        {
            while ((expression[i] >= '0' && expression[i] <= '9') || expression[i] == '.')
            {
                builder.Append(expression[i]);
                i++;
                if (i >= expression.Length)
                    break;
            }
            i--;
            return i;
        }
        public Evaluator(string expression)
        {
            int index = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                StringBuilder builder = new StringBuilder();
                switch (expression[i])
                {
                    case '+':
                        builder.Append(expression[i]);
                        this.infixExpression.Add(builder);
                        break;
                    case '-':                                                           //文法
                        if (i == 0)
                        {
                            if (expression[i + 1] >= '0' && expression[i + 1] <= '9')
                            {
                                builder.Append('-');
                                i = this.AppendNumber(builder, expression, i + 1);
                                this.infixExpression.Add(builder);
                            }
                            else
                            {
                                builder.Append(expression[i]);
                                this.infixExpression.Add(builder);
                            }
                        }
                        else if (expression[i - 1] == '(')
                        {
                            builder.Append('-');
                            i = this.AppendNumber(builder, expression, i + 1);
                            this.infixExpression.Add(builder);
                        }
                        else
                        {
                            builder.Append(expression[i]);
                            this.infixExpression.Add(builder);
                        }
                        break;
                    case '*':
                        builder.Append(expression[i]);
                        this.infixExpression.Add(builder);
                        break;
                    case '/':
                        builder.Append(expression[i]);
                        this.infixExpression.Add(builder);
                        break;
                    case '(':
                        builder.Append(expression[i]);
                        this.infixExpression.Add(builder);
                        break;
                    case ')':
                        builder.Append(expression[i]);
                        this.infixExpression.Add(builder);
                        break;
                    case '^':
                        builder.Append(expression[i]);
                        this.infixExpression.Add(builder);
                        break;
                    case 's':
                        builder = new StringBuilder("sin");
                        this.infixExpression.Add(builder);
                        i += 2;
                        break;
                    case 'c':
                        builder = new StringBuilder("sin");
                        this.infixExpression.Add(builder);
                        i += 2;
                        break;
                    case 't':
                        builder = new StringBuilder("tan");
                        this.infixExpression.Add(builder);
                        i += 2;
                        break;
                    case 'l':
                        builder = new StringBuilder("ln");
                        this.infixExpression.Add(builder);
                        i++;
                        break;
                    case 'S':
                        builder = new StringBuilder("Sqrt");
                        this.infixExpression.Add(builder);
                        i += 3;
                        break;
                    case ' ':
                        break;
                    default:
                        i = this.AppendNumber(builder, expression, i);
                        this.infixExpression.Add(builder);
                        break;
                }
                index++;
            }
            this.ConvertToPostfix();

        }
        public bool Compute()
        {
            try
            {
                Stack<Double> stack = new Stack<Double>();
                foreach (StringBuilder parm in this.postfixExpression)
                {
                    if (parm[0] >= '0' && parm[0] <= '9')
                    {
                        stack.Push(Convert.ToDouble(parm.ToString()));
                    }
                    else
                    {
                        Double temp;
                        switch (parm[0])
                        {
                            case '+':
                                temp = stack.Pop();
                                stack.Push(stack.Pop() + temp);
                                break;
                            case '-':
                                if (parm.Length == 1)
                                {
                                    if (stack.Count != 1)
                                    {
                                        temp = stack.Pop();
                                        stack.Push(stack.Pop() - temp);
                                    }
                                    else
                                    {
                                        stack.Push(Convert.ToDouble(-stack.Pop()));
                                    }
                                }
                                else
                                {
                                    stack.Push(Convert.ToDouble(parm.ToString()));
                                }
                                break;
                            case '*':
                                temp = stack.Pop();
                                stack.Push(stack.Pop() * temp);
                                break;
                            case '/':
                                temp = stack.Pop();
                                stack.Push(stack.Pop() / temp);
                                break;
                            case '^':
                                temp = stack.Pop();
                                stack.Push(Math.Pow(stack.Pop(), temp));
                                break;
                            case 's':
                                stack.Push(Math.Sin(stack.Pop()));
                                break;
                            case 'c':
                                stack.Push(Math.Cos(stack.Pop()));
                                break;
                            case 't':
                                stack.Push(Math.Tan(stack.Pop()));
                                break;
                            case 'S':
                                stack.Push(Math.Sqrt(stack.Pop()));
                                break;
                            case 'l':
                                stack.Push(Math.Log10(stack.Pop()));
                                break;
                        }
                    }
                }
                this.res = stack.Pop();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<StringBuilder> InfixExpression { get => infixExpression; set => infixExpression = value; }
        public List<StringBuilder> PostfixExpression { get => postfixExpression; set => postfixExpression = value; }
        public double Res { get => res; set => res = value; }

        private int Priority(StringBuilder operator_)
        {
            int level;
            if (operator_[0] == '(')
                level = 0;
            else if (operator_[0] == '+' || operator_[0] == '-')
                level = 1;
            else if (operator_[0] == '*' || operator_[0] == '/')
                level = 2;
            else
                level = 3;

            return level;
        }

        private void ConvertToPostfix()
        {
            Stack<StringBuilder> stack = new Stack<StringBuilder>();

            foreach (StringBuilder stringBuilder in this.infixExpression)
            {
                if (stringBuilder[0] >= '0' && stringBuilder[0] <= '9')
                {
                    this.postfixExpression.Add(stringBuilder);
                }
                else if (stringBuilder[0] == '(')
                {
                    stack.Push(stringBuilder);
                }
                else if (stringBuilder[0] == ')')
                {
                    StringBuilder temp;
                    while (stack.Count != 0)
                    {
                        temp = stack.Pop();
                        if (temp[0] == '(')
                            break;
                        else
                            this.postfixExpression.Add(temp);
                    }
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(stringBuilder);
                        continue;
                    }
                    if (this.Priority(stringBuilder) > this.Priority(stack.Peek()))
                    {
                        stack.Push(stringBuilder);
                    }
                    else
                    {
                        while (stack.Count != 0 && this.Priority(stringBuilder) <= this.Priority(stack.Peek()))
                        {
                            this.postfixExpression.Add(stack.Pop());
                        }
                        stack.Push(stringBuilder);
                    }

                }
            }

            while (stack.Count != 0)
                this.postfixExpression.Add(stack.Pop());
        }
    }
}
