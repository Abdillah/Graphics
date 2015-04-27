using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transform3D
{
    class CubeDrawingEngine : Drawing2D
    {
		/**
		 * @param canvas Any window component to draw on.
		 */
        public CubeDrawingEngine(Control canvas)
		{
			this.canvas = canvas;
        }

		private void DrawFace(Point3D[] face)
		{
			Point[] projection;

			int i = 0;
			foreach (Point3D p in face)
			{
				projection[i] = Project(p);
				i++;
			}

			DrawLine(projection[0], projection[1]);
			DrawLine(projection[1], projection[2]);
			DrawLine(projection[2], projection[3]);
			DrawLine(projection[3], projection[1]);
		}

		public void DrawCube(Point3D[] cube)
		{
			Point[] projection;

			int i = 0;
			foreach (Point3D p in cube)
			{
				projection[i] = Project(p);
				i++;
			}

			// Draw line 1-2, 2-3, 3-4, 4-1
			DrawFace(cube.GetFace(1));
			// Draw line 5-6, 6-7, 7-8, 8-5
			DrawFace(cube.GetFace(6));
			// Draw line 1-5, 2-6, 3-7, 4-8
			DrawLine(projection[1], projection[5]);
			DrawLine(projection[2], projection[6]);
			DrawLine(projection[3], projection[7]);
			DrawLine(projection[4], projection[8]);
		}

    }
}
