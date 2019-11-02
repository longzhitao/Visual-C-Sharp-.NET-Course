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
            try
            {
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
                            int i_temp = i;
                            bool flag = true;
                            if (i != expression.Length - 1)         //判断是否为最后一个字符，如果不是则追加判断
                            {
                                if (expression[i + 1] == '-')       //如果下一个还是为负数，处理多符号情况如 ---3 = -3   --3 = 3 或 +3
                                {
                                    int count = 1;
                                    flag = false;
                                    i++;
                                    while (true)
                                    {
                                        if (expression[i] == '-')
                                        {
                                            count++;
                                            i++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    i--;
                                    if (count % 2 == 0)             //偶数个负号为正
                                    {
                                        if (i_temp == 0)            //解决用户输入中起始多个符号判断越界的问题 --2不加判断则会越界
                                        {
                                            i = this.AppendNumber(builder, expression, i + 1);
                                            this.infixExpression.Add(builder);
                                        }
                                        else
                                        {
                                            if (this.InfixExpression[this.InfixExpression.Count - 1][0] >= '0'      //越界地方
                                                && this.InfixExpression[this.InfixExpression.Count - 1][0] <= '9')  //如果出现sin--2 不加此判断会变成
                                            {                                                                       //sin+2 只需判断上一个中缀表达式数组中
                                                builder.Append('+');                                                //是否为数字如1--2 是则变成 1+2
                                                this.infixExpression.Add(builder);                                  //不是数字如sin--2 则移除-- 变成sin2
                                            }
                                        }

                                    }
                                    else                           //奇数个符号为负
                                    {
                                        if (i_temp == 0)            //解决用户输入中起始多个符号判断越界的问题 --2不加判断则会越界
                                        {
                                            builder.Append('-');
                                            i = this.AppendNumber(builder, expression, i + 1);
                                            this.infixExpression.Add(builder);
                                        }
                                        else
                                        {
                                            if (this.InfixExpression[this.InfixExpression.Count - 1][0] >= '0'      
                                                && this.InfixExpression[this.InfixExpression.Count - 1][0] <= '9')  
                                            {                                                                       
                                                builder.Append('-');                                                
                                                this.infixExpression.Add(builder);
                                            }
                                            else
                                            {
                                                if(this.InfixExpression[this.InfixExpression.Count - 1][0] == '^')
                                                {
                                                    builder.Append('-');
                                                    i = this.AppendNumber(builder, expression, i + 1);
                                                    this.infixExpression.Add(builder);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (flag)
                            {
                                if (i == 0)                                                                 //特判负号开头的问题
                                {
                                    if (expression[i + 1] >= '0' && expression[i + 1] <= '9')               //如果下一个字符为数字
                                    {                                                                       //则扫描下一个数字并加入数组中
                                        builder.Append('-');                                                //如-222 则直接加-222
                                        i = this.AppendNumber(builder, expression, i + 1);
                                        this.infixExpression.Add(builder);
                                    }
                                    else
                                    {
                                        builder.Append(expression[i]);                                      
                                        this.infixExpression.Add(builder);
                                    }
                                }
                                else if (expression[i - 1] == '(')                                         //解决（-200+100）问题
                                {                                                                          //直接如果是这样则加入 -200 + 100
                                    builder.Append('-');                                                   //而不是- 200 + 100
                                    i = this.AppendNumber(builder, expression, i + 1);
                                    this.infixExpression.Add(builder);
                                }
                                else
                                {                                                                          //特判sin-2 cos-2等问题
                                    if (this.infixExpression[this.infixExpression.Count - 1][0] == 's' ||
                                        this.infixExpression[this.infixExpression.Count - 1][0] == 'c' ||
                                        this.infixExpression[this.infixExpression.Count - 1][0] == 'S' ||
                                        this.infixExpression[this.infixExpression.Count - 1][0] == 'l' ||
                                        this.infixExpression[this.infixExpression.Count - 1][0] == '^')
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
                            if (expression[i + 1] == 'i' && expression[i + 2] == 'n')
                            {
                                builder = new StringBuilder("sin");
                                this.infixExpression.Add(builder);
                                i += 2;
                            }
                            else
                            {
                                builder.Append(expression[i]);
                                this.infixExpression.Add(builder);
                            }
                            break;
                        case 'c':
                            if(expression[i+1] == 'o' && expression[i+2] == 's')
                            {
                                builder = new StringBuilder("cos");
                                this.infixExpression.Add(builder);
                                i += 2;
                            }
                            else
                            {
                                builder.Append(expression[i]);
                                this.infixExpression.Add(builder);
                            }
                            break;
                        case 't':
                            if (expression[i + 1] == 'a' && expression[i + 2] == 'n')
                            {
                                builder = new StringBuilder("tan");
                                this.infixExpression.Add(builder);
                                i += 2;
                            }
                            else
                            {
                                builder.Append(expression[i]);
                                this.infixExpression.Add(builder);
                            }
                            break;
                        case 'l':
                            if (expression[i + 1] == 'n')
                            {
                                builder = new StringBuilder("ln");
                                this.infixExpression.Add(builder);
                                i++;
                            }
                            else
                            {
                                builder.Append(expression[i]);
                                this.infixExpression.Add(builder);
                            }
                            break;
                        case 'S':
                            if (expression[i + 1] == 'q' && expression[i + 2] == 'r' && expression[i + 3] == 't')
                            {
                                builder = new StringBuilder("Sqrt");
                                this.infixExpression.Add(builder);
                                i += 3;
                            }
                            else
                            {
                                builder.Append(expression[i]);
                                this.infixExpression.Add(builder);
                            }
                            break;
                        case ' ':
                            break;
                        case '\n':
                            break;
                        default:
                            if (expression[i] >= '0' && expression[i] <= '9')
                            {
                                i = this.AppendNumber(builder, expression, i);
                                this.infixExpression.Add(builder);
                            }
                            else
                            {
                                builder.Append(expression[i]);
                                this.infixExpression.Add(builder);
                            }

                            break;
                    }
                    index++;
                }
            }
            catch (Exception)//在保证表达式正确情况下出现越界则抛出异常，用户输入表达式有问题
            {
                this.infixExpression.Add(new StringBuilder("Error"));
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
                                if (parm.ToString() == "sin")
                                    stack.Push(Math.Sin(stack.Pop()));
                                else
                                {
                                    throw new Exception();
                                }
                                break;
                            case 'c':
                                if (parm.ToString() == "cos")
                                    stack.Push(Math.Cos(stack.Pop()));
                                else
                                {
                                    throw new Exception();
                                };
                                break;
                            case 't':
                                if (parm.ToString() == "tan")
                                    stack.Push(Math.Tan(stack.Pop()));
                                else
                                {
                                    throw new Exception();
                                };
                                break;
                            case 'S':
                                if (parm.ToString() == "Sqrt")
                                    stack.Push(Math.Sqrt(stack.Pop()));
                                else
                                {
                                    throw new Exception();
                                };
                                break;
                            case 'l':
                                if (parm.ToString() == "ln")
                                    stack.Push(Math.Log10(stack.Pop()));
                                else
                                {
                                    throw new Exception();
                                };
                                break;
                            default:
                                throw new Exception();
                        }
                    }
                }
                this.res = stack.Pop();
                return true;
            }
            catch (Exception)
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
                    if (stringBuilder.Length > 1)
                    {
                        if(stringBuilder[1] >= '0' && stringBuilder[1] <= '9')
                        {
                            this.postfixExpression.Add(stringBuilder);
                            continue;
                        }
                    }
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
