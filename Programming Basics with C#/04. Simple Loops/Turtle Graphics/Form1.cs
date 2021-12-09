using Nakov.TurtleGraphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turtle_Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Turtle.Delay = 200;
            Turtle.Rotate(30);
            Turtle.Forward(200);
            Turtle.Rotate(120);
            Turtle.Forward(200);
            Turtle.Rotate(120);
            Turtle.Forward(200);
            Turtle.Rotate(-30);
            Turtle.PenUp();
            Turtle.Backward();
            Turtle.PenDown();
            Turtle.Backward(100);
            Turtle.PenUp();
            Turtle.Forward(150);
            Turtle.PenDown();
            Turtle.Rotate(30);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Turtle.Reset();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Turtle.ShowTurtle)
            {
                Turtle.ShowTurtle = false;
                this.button2.Text = "Show Turtle";
            }
            else
            {
                Turtle.ShowTurtle = true;
                this.button2.Text = "Hide Turtle";
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Turtle.Delay = 200;
            Turtle.Rotate(60);
            Turtle.Forward(100);
            Turtle.Rotate(60);
            Turtle.Forward(100);
            Turtle.Rotate(60);
            Turtle.Forward(100);
            Turtle.Rotate(60);
            Turtle.Forward(100);
            Turtle.Rotate(60);
            Turtle.Forward(100);
            Turtle.Rotate(60);
            Turtle.Forward(100);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Turtle.Delay = 200;
            Turtle.PenColor = Color.Green;
            Turtle.Forward(200);
            Turtle.Rotate(144);
            Turtle.Forward(200);
            Turtle.Rotate(144);
            Turtle.Forward(200);
            Turtle.Rotate(144);
            Turtle.Forward(200);
            Turtle.Rotate(144);
            Turtle.Forward(200);
            Turtle.Rotate(144);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Turtle.Delay = 200;
            for (int i = 0; i < 20; i++)
            {
                Turtle.Forward(i * 20);
                Turtle.Rotate(60);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Turtle.Delay = 200;
            for (int i = 0; i < 36; i++)
            {
                Turtle.Forward(150);
                Turtle.Backward(150);
                Turtle.Rotate(10);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Turtle.Delay = 200;
            Turtle.PenColor = Color.Red;
            for (int i = 0; i < 30; i++)
            {
                Turtle.Forward(100);
                Turtle.Rotate(120);
            }
        }
    }
}
