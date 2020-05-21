using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cayley
{
    public partial class Form1 : Form
    {
        int deepth = 10;
        double length = 100;
        double rightper1 = 0.6;
        double leftper2 = 0.7;
        double rightth1 = 30 * Math.PI / 180;
        double leftth2 = 20 * Math.PI / 180;
        Pen pen = Pens.Blue;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
                graphics = this.CreateGraphics();
            graphics.Clear(BackColor);
            drawCayleyTree(deepth, 200, 310, length, -Math.PI / 2);
        }
        private Graphics graphics;

        void drawCayleyTree(int n,double x0,double y0,double leng, double th)
        {
            if (n == 0)
                return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, rightper1 * leng, th + rightth1);
            drawCayleyTree(n - 1, x1, y1, leftper2 * leng, th - leftth2);
        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            deepth = int.Parse(this.numericUpDown1.Value.ToString());
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            length = double.Parse(this.numericUpDown2.Value.ToString());
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            rightper1 = double.Parse(this.numericUpDown3.Value.ToString()) / 100;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            leftper2 = double.Parse(this.numericUpDown4.Value.ToString()) / 100;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            rightth1 = double.Parse(this.numericUpDown5.Value.ToString()) * Math.PI / 180;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            leftth2 = double.Parse(this.numericUpDown6.Value.ToString()) * Math.PI / 180;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = comboBox1.SelectedItem.ToString();
            switch (text)
            {
                case "红色":
                    pen = Pens.Red;
                    break;
                case "蓝色":
                    pen = Pens.Blue;
                    break;
                case "绿色":
                    pen = Pens.Green;
                    break;
                case "黄色":
                    pen = Pens.Yellow;
                    break;
            }



        }
    }
}
