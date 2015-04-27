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
		Drawing2D engine;
		CubeDrawingEngine cubeEngine;

        int WIDTH = 640;
        int HEIGHT = 480;

        public Form1()
        {
            InitializeComponent();

            pen = new Pen(Brushes.Red);
            pen.Width = 3;

            axisPen = new Pen(Brushes.Blue);

			engine = new Drawing2D(this.canvas);
			cubeEngine = new CubeDrawingEngine(this.canvas);
        }

		/**
		 * @brief Draw axis to suggest a 3D model to human brain.
		 * @param e Windows paint event information.
		 */
        private void DrawAxis(PaintEventArgs e)
        {
            Point p0;
            Point p1;

            p0 = new Point(0, 0);
            p1 = new Point(30, 40);

            e.Graphics.DrawLine(axisPen, NormalizeRaw(p0), NormalizeRaw(p1));

            p0 = new Point(30, 40);
            p1 = new Point(1000, 40);

            e.Graphics.DrawLine(axisPen, NormalizeRaw(p0), NormalizeRaw(p1));

            p0 = new Point(30, 40);
            p1 = new Point(30, 1000);

            e.Graphics.DrawLine(axisPen, NormalizeRaw(p0), NormalizeRaw(p1));
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
			engine.PaintEvent = e;
			cubeEngine.PaintEvent = e;
			
            DrawAxis(e);

			Point3D[] cubePoints = new Point3D[8];
            cubePoints[0] = new Point3D(0, 0, 0);
			cubePoints[1] = new Point3D(30, 0, 0);
			cubePoints[2] = new Point3D(30, 0, 30);
            cubePoints[3] = new Point3D(0, 0, 30);
			cubePoints[4] = new Point3D(0, 30, 0);
			cubePoints[5] = new Point3D(30, 30, 0);
			cubePoints[6] = new Point3D(30, 30, 30);
			cubePoints[7] = new Point3D(0, 30, 30);

			Cube cube = new Cube(cubePoints);
            cubeEngine.DrawCube(cube);
        }
    }
}
