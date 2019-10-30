using System;
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
    public delegate void ChangeTextBoxText(string s, int len);
    public partial class formCalculator : Form
    {
        public ChangeTextBoxText Change_TextBox_Text;
        public Evaluator evaluator;
        public formCalculator()
        {
            InitializeComponent();
        }
        private void Change_InputTextBox_Text(string s, int len)
        {
            int selectionIndex = textBoxInput.SelectionStart;
            textBoxInput.Text = textBoxInput.Text.Insert(selectionIndex, s);
            textBoxInput.SelectionStart = selectionIndex + len;
            textBoxInput.Focus();
        }

        private void Change_LabelInputRes_Text(string s)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            if (labelInputRes.Text == "")
                labelInputRes.Text += s;
            else
            {
                if (s[0] >= '0' && s[0] <= '9' || s[0] == '.')
                {
                    if (labelInputRes.Text[0] >= '0' && labelInputRes.Text[0] <= '9')
                        labelInputRes.Text += s;
                    else if (labelInputRes.Text[0] == '-')
                    {
                        if (labelInputRes.Text.Length == 1)
                        {
                            Change_InputTextBox_Text(labelInputRes.Text, labelInputRes.Text.Length);
                            labelInputRes.Text = s;
                        }
                        else
                        {
                            labelInputRes.Text += s;
                        }
                    }
                    else
                    {
                        Change_InputTextBox_Text(labelInputRes.Text, labelInputRes.Text.Length);
                        labelInputRes.Text = s;
                    }
                }
                else
                {
                   if (labelInputRes.Text[0] == '-' && labelInputRes.Text.Length > 1)
                    {
                        labelInputRes.Text = "(" + labelInputRes.Text + ")";
                    }
                   Change_InputTextBox_Text(labelInputRes.Text, labelInputRes.Text.Length);
                   labelInputRes.Text = s;
                }

            }

        }

        private void Button_7_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("7");


        }

        private void Button_8_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("8");
        }

        private void Button_9_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("9");
        }

        private void Button_6_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("6");
        }

        private void Button_5_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("5");
        }

        private void Button_4_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("4");
        }

        private void Button_3_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("3");
        }

        private void Button_2_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("2");
        }

        private void Button_1_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("1");
        }

        private void Button_0_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("0");
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text(".");
        }

        private void ButtonDivision_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("/");
        }

        private void ButtonLeftBracket_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("(");
        }

        private void ButtonSin_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("sin");
        }

        private void ButtonTimes_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("*");
        }

        private void ButtonRightBracket_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text(")");
        }

        private void ButtonCos_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("cos");
        }

        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("-");
        }

        private void ButtonSqrt_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("Sqrt");
        }

        private void ButtonTan_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("tan");
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("+");
        }

        private void ButtonPow_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("^");
        }

        private void ButtonLn_Click(object sender, EventArgs e)
        {
            Change_LabelInputRes_Text("ln");
        }

        private void ButtonBackspace_Click(object sender, EventArgs e)
        {
            try
            {
                int selectionIndex = textBoxInput.SelectionStart;
                textBoxInput.Text = textBoxInput.Text.Remove(selectionIndex - 1, 1);
                textBoxInput.SelectionStart = selectionIndex - 1;
                textBoxInput.Focus();

                labelInputRes.Text = labelInputRes.Text.Remove(labelInputRes.Text.Length - 1, 1);
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }

            
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            if (this.labelInputRes.Text != "")
            {
                if (this.labelInputRes.Text.Length > 1 && this.labelInputRes.Text[0] == '-')
                {
                    labelInputRes.Text = "(" + labelInputRes.Text + ")";
                }
                Change_InputTextBox_Text(labelInputRes.Text, labelInputRes.Text.Length);
                this.labelInputRes.Text = "";

            }
            evaluator = new Evaluator(this.textBoxInput.Text);
            if (evaluator.Compute())
            {
                this.textBoxRes.Text = evaluator.Res.ToString();
            }
            else
            {
                this.textBoxRes.Text = "无效输入";
            }
        }

        private void ButtonSignTransfer_Click(object sender, EventArgs e)
        {
            if (this.labelInputRes.Text == "")
                return;
            else if (this.labelInputRes.Text[0] >= '0' && this.labelInputRes.Text[0] <= '9' || this.labelInputRes.Text[0] == '-')
            {
                if (this.labelInputRes.Text[0] == '-')
                {
                    this.labelInputRes.Text = this.labelInputRes.Text.Substring(1);
                }
                else
                {
                    this.labelInputRes.Text = "-" + this.labelInputRes.Text;
                }
            }
        }
    }
}
