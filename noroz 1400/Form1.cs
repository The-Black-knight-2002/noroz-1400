using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noroz_1400
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int gcd(int a, int b)
        {
            if (a % b == 0)
                return b;
            return gcd(b, a % b);
        }

        static int lcm(int a, int b)
        {
            return a * b / gcd(a, b);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Draw(350, 210, 140, Pens.Green);
            Draw(150, 100, 80,Pens.Red);
        }

        void Draw(int R, int r, int d,Pen p)
        {
            Graphics g = this.CreateGraphics();

            double px_old = R - r + d;
            double py_old = 0;

            int offsetx = this.Width / 2;
            int offsety = this.Height / 2;

            for (double t = 0; t < lcm(R, r) / R * 2 * Math.PI; t += 0.1)
            {
                double cx = (R - r) * Math.Cos(t);
                double cy = (R - r) * Math.Sin(t);

                double u = -R * t / r;

                double px = cx + d * Math.Cos(u);
                double py = cy + d * Math.Sin(u);

                g.DrawLine(p, offsetx + (float)px_old, offsety + (float)py_old, offsetx + (float)px, offsety + (float)py);
                px_old = px;
                py_old = py;

                System.Threading.Thread.Sleep(10);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}
