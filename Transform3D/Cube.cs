using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transform3D
{
    class Cube
    {
        Point3D[] points;
        public Cube(Point3D[] points)
        {
            if (points.GetLength(0) >= 8)
            {
                this.points = points;
            }
        }

        public void translate(int x, int y, int z) 
        {
            foreach (Point3D point in points) {
                point.X += x;
                point.Y += y;
                point.Z += z;
				// hi
            }
        }

        private void constructEdge(PaintEventArgs e)
        {
            // e.Graphics.DrawLine();
        }

        public void draw(PaintEventArgs e)
        {
            
        }
    }
}
