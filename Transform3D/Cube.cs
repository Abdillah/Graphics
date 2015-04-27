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
		protected const int[,] POINTS_IN_FACE = {{1, 2, 3, 4},
												 {1, 2, 6, 5},
												 {2, 3, 7, 6},
												 {3, 4, 8, 7},
												 {4, 1, 5, 8},
												 {5, 6, 7, 8}};
		Point3D[] points;

        public Cube(Point3D[] points)
        {
            if (points.GetLength(0) >= 8)
            {
                this.points = points;
            }
        }

        public void Translate(int x, int y, int z)
        {
            foreach (Point3D point in points) {
                point.X += x;
                point.Y += y;
                point.Z += z;
				// hi
            }
        }

		/**
		 * @brief Get points occured in nth face.
		 *        See the constant @code{POINTS_IN_FACE} above.
		 */
		protected Point3D[] GetFace(int nth)
		{
			nth -= 1;

			Point3D[] face;
			for (int i = 0; i < 4; i++)
			{
				int idx = POINTS_IN_FACE[nth, i];
				face[i] = points[idx];
			}

			return face;
		}

    }
}
