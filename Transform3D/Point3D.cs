using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transform3D
{
    class Point3D
    {
        int[] positions;

        public int X {
            get {
                return positions[0];
            }
            set {
                positions[0] = value;
            }
        }

        public int Y
        {
            get {
                return positions[1];
            }
            set {
                positions[1] = value;
            }
        }
        public int Z
        {
            get {
                return positions[2];
            }
            set {
                positions[2] = value;
            }
        }

        public Point3D(int x, int y, int z) {
            positions = new int[3];

            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public void translate (int x, int y, int z, bool is_delta) {
            if (is_delta)
            {
                this.X += x;
                this.Y += y;
                this.Z += z;
            }
            else
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }
        }
    }
}
