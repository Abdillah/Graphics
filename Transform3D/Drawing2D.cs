using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transform3D
{
    class Drawing2D
    {
		Control canvas;
		PaintEventArgs e;

		PaintEventArgs PaintEvent {
			set {
				this.e = value;
			}
			get {
				return this.e;
			}
		};

		/**
		 * @brief Projecting 3D coordinate into 2D which involve
		 *        recalculation of X and Y with the help of Z.
		 * @param p point to project.
		 * @return 2D Point which ready to be drawn or render.
		 */
        private Point Project(Point3D p)
        {
            Point normal = Normalize(new Point(p.X, p.Y));

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

		/**
		 * @brief Translate point into bottom-left (0,0) and
		 *        scale appropriately to enhance visibility.
		 *        Used mainly to draw axis lines.
		 * @param p raw point to normalize
		 */
        private Point NormalizeRaw(Point p)
        {
            int x = p.X * 5;
            int y = ((p.Y * -1) * 5 + HEIGHT);

            return new Point(x, y);
        }

		/**
		 * @brief Translate point into pivot on (30,40) position
		 *        relative to bottom-left and also scale appropriately
		 *        to enhance visibility
		 * @param p raw point to normalize
		 */
        private Point Normalize(Point p)
        {
            int x = (p.X + 30) * 5;
            int y = (((p.Y + 40) * -1) * 5 + HEIGHT);

            return new Point(x, y);
        }

		/**
		 * @brief Wrap System.Graphics.DrawLine function, automatically
		 *        project the points.
		 */
		public void DrawLine(Pen pen, Point3D p1, Point3D p2) {
            e.Graphics.DrawLine(pen, Project(p1), Project(p2));
		}

		/**
		 * @param canvas Any window component to draw on.
		 */
        public Drawing2D(Control canvas) {
			this.canvas = canvas;
        }

    }
}
