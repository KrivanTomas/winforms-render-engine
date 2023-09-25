using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace render
{
    class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return String.Format("X: {0},Y: {1},Z: {2}", x, y, z);
        }

        public Point ToPoint()
        {
            return new Point(x, y);
        }
    }
}
