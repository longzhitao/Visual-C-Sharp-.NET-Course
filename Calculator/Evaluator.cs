using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Evaluator
    {
        private List<StringBuilder> infixExpression = new List<StringBuilder>();
        private List<StringBuilder> postfixExpression = new List<StringBuilder>();

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
                    case '-':
                        builder.Append(expression[i]);
                        this.infixExpression.Add(builder);
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
                        while ((expression[i] >= '0' && expression[i] <= '9') || expression[i] == '.')
                        {
                            builder.Append(expression[i]);
                            i++;
                            if (i >= expression.Length)
                                break;
                        }
                        i--;
                        this.infixExpression.Add(builder);
                        break;
                }
                index++;
            }
            this.ConvertToPostfix();
        }

        public List<StringBuilder> InfixExpression { get => infixExpression; set => infixExpression = value; }
        public List<StringBuilder> PostfixExpression { get => postfixExpression; set => postfixExpression = value; }

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
