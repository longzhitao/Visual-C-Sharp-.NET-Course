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

        private void Button_7_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("7", 1);
        }

        private void Button_8_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("8", 1);
        }

        private void Button_9_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("9", 1);
        }

        private void Button_6_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("6", 1);
        }

        private void Button_5_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("5", 1);
        }

        private void Button_4_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("4", 1);
        }

        private void Button_3_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("3", 1);
        }

        private void Button_2_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("2", 1);
        }

        private void Button_1_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("1", 1);
        }

        private void Button_0_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("0", 1);
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text(".", 1);
        }

        private void ButtonDivision_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("/", 1);
        }

        private void ButtonLeftBracket_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("(", 1);
        }

        private void ButtonSin_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("sin", 3);
        }

        private void ButtonTimes_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("*", 1);
        }

        private void ButtonRightBracket_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text(")", 1);
        }

        private void ButtonCos_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("cos", 3);
        }

        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("-", 1);
        }

        private void ButtonSqrt_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("Sqrt", 4);
        }

        private void ButtonTan_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("tan", 3);
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("+", 1);
        }

        private void ButtonPow_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("^", 1);
        }

        private void ButtonLn_Click(object sender, EventArgs e)
        {
            Change_TextBox_Text = new ChangeTextBoxText(Change_InputTextBox_Text);
            Change_TextBox_Text("ln", 2);
        }

        private void ButtonBackspace_Click(object sender, EventArgs e)
        {
            try
            {
                int selectionIndex = textBoxInput.SelectionStart;
                textBoxInput.Text = textBoxInput.Text.Remove(selectionIndex - 1, 1);
                textBoxInput.SelectionStart = selectionIndex - 1;
                textBoxInput.Focus();
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }

            
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            evaluator = new Evaluator(this.textBoxInput.Text);
            foreach (StringBuilder sb in evaluator.PostfixExpression)
            {
                this.textBoxRes.Text = this.textBoxRes.Text + sb + " " ;
            }
        }

        private void ButtonSignTransfer_Click(object sender, EventArgs e)
        {

        }
    }
}
