using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 第一个数_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1, num2;
            int num3, num4;
            bool a=int.TryParse(textBox1.Text, out num3);
            bool b=int.TryParse(textBox1.Text, out num4);
            if (a && b == true)
            {
                num1 = Convert.ToDouble(textBox1.Text);
                num2 = Convert.ToDouble(textBox2.Text);
                switch (listBox1.Text)
                {
                    case "+":
                        textBox3.Text = Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        textBox3.Text = Convert.ToString(num1 - num2);
                        break;
                    case "*":
                        textBox3.Text = Convert.ToString(num1 * num2);
                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            textBox3.Text = "除数不能为0。";
                            break;
                        }
                        else textBox3.Text = Convert.ToString(num1 / num2);
                        break;
                    default:
                        textBox3.Text = "运算符未选择。";
                        break;
                }
            }
            else textBox3.Text = "请输入数字。";
        }
    }
}
