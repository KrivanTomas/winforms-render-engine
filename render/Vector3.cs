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

        public static Vector3 operator +(Vector3 a) => a;
        public static Vector3 operator -(Vector3 a) => new Vector3(-a.x, -a.y, -a.z);
        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => a + (-b);
        public static Vector3 operator *(Vector3 a, float b) => new Vector3(a.x * b, a.y * b, a.z * b);

        public static float operator *(Vector3 a, Vector3 b) => a.x * b.x + a.y * b.y + a.z * b.z;

        public static Vector3 Zero = new Vector3(0, 0, 0);
        public static Vector3 One = new Vector3(1, 1, 1);

        public override string ToString()
        {
            return String.Format("X: {0},Y: {1},Z: {2}", x, y, z);
        }
        
        public double Length()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public Vector3 Normalize()
        {
            return this * (1 / (float)Length());
        }

        public Point ToPoint()
        {
            return new Point((int)x, (int)y);
        }
    }
}
