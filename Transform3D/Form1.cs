using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transform3D
{
    public partial class Form1 : Form
    {
        Pen axisPen;
        Pen pen;
        int WIDTH = 640;
        int HEIGHT = 480;

        public Form1() 
        {
            InitializeComponent();

            pen = new Pen(Brushes.Red);
            pen.Width = 3;
            axisPen = new Pen(Brushes.Blue);
        }

        private Point project(Point3D p)
        {
            Point normal = normalize(new Point(p.X, p.Y));

            int X_TRANSLATE = -3;
            int Y_TRANSLATE = 4;

            int x = normal.X;
            int y = normal.Y;

            Console.WriteLine("Normal : " + x + ", " + y);

            if (p.Z == 0)
            {
                return new Point(x, y);
            }
            else
            {
                x = x + (p.Z * X_TRANSLATE);
                y = y + (p.Z * Y_TRANSLATE);

                Console.WriteLine("Project : " + x + ", " + y);
                return new Point(x, y);
            }
        }

        private Point normalizeRaw(Point p)
        {
            int x = p.X * 5;
            int y = ((p.Y * -1) * 5 + HEIGHT);

            return new Point(x, y);
        }

        private Point normalize(Point p)
        {
            int x = (p.X + 30) * 5;
            int y = (((p.Y + 40) * -1) * 5 + HEIGHT);

            return new Point(x, y);
        }

        private void drawAxis(PaintEventArgs e)
        {
            Point p0;
            Point p1;

            p0 = new Point(0, 0);
            p1 = new Point(30, 40);

            e.Graphics.DrawLine(axisPen, normalizeRaw(p0), normalizeRaw(p1));

            p0 = new Point(30, 40);
            p1 = new Point(1000, 40);

            e.Graphics.DrawLine(axisPen, normalizeRaw(p0), normalizeRaw(p1));

            p0 = new Point(30, 40);
            p1 = new Point(30, 1000);

            e.Graphics.DrawLine(axisPen, normalizeRaw(p0), normalizeRaw(p1));
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            drawAxis(e);

            Point3D p3d0 = new Point3D(0, 0, 0);
            Point3D p3d1 = new Point3D(0, 0, 30);
			Point3D p3d2 = new Point3D(30, 0, 30);
			Point3D p3d3 = new Point3D(30, 0, 0);
			Point3D p3d4 = new Point3D(0, 30, 0);
			Point3D p3d5 = new Point3D(0, 30, 30);
			Point3D p3d6 = new Point3D(30, 30, 30);
			Point3D p3d7 = new Point3D(30, 30, 0);
			
            e.Graphics.DrawLine(pen, project(p3d0), project(p3d1));
			e.Graphics.DrawLine(pen, project(p3d1), project(p3d2));
			e.Graphics.DrawLine(pen, project(p3d2), project(p3d3));
			e.Graphics.DrawLine(pen, project(p3d3), project(p3d0));
			e.Graphics.DrawLine(pen, project(p3d4), project(p3d5));
			e.Graphics.DrawLine(pen, project(p3d5), project(p3d6));
			e.Graphics.DrawLine(pen, project(p3d6), project(p3d7));
			e.Graphics.DrawLine(pen, project(p3d7), project(p3d4));
			
			e.Graphics.DrawLine(pen, project(p3d0), project(p3d4));
			e.Graphics.DrawLine(pen, project(p3d1), project(p3d5));
			e.Graphics.DrawLine(pen, project(p3d2), project(p3d6));
			e.Graphics.DrawLine(pen, project(p3d3), project(p3d7));
        }
    }
}
