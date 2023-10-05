using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinformRender
{
    public class Vector3
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
        public static Vector3 operator /(Vector3 a, float b) => new Vector3(a.x / b, a.y / b, a.z / b);


        public static Vector3 Zero()
        {
            return new Vector3(0f, 0f, 0f);
        }

        public static Vector3 One() {
            return new Vector3(1f, 1f, 1f);
        }

        public Vector4 PuffToVector4()
        {
            return new Vector4(x, y, z, 0);
        }

        public override string ToString()
        {
            return String.Format("X: {0},Y: {1},Z: {2}", x, y, z);
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public Vector3 Normalize() // Returns NaN if IsNil() == true
        {
            return this * (1 / (float)Length());
        }

        public virtual bool IsNil()
        {
            return x == 0 && y == 0 && z == 0;
        }

        public virtual Point ToPoint()
        {
            return new Point((int)x, (int)y);
        }

        public virtual Matrix ToMatrix1x4()
        {
            return new Matrix(new float[4, 1]{
                { x },
                { y },
                { z },
                { 1 }});
        }
    }
    public class Vector4 : Vector3
    {
        public float w;
        public Vector4(float x, float y, float z, float w) : base(x,y,z)
        {
            this.w = w;
        }

        public static Vector4 Zero()
        {
            return new Vector4(0f, 0f, 0f, 0f);
        }

        public static Vector4 One()
        {
            return new Vector4(1f, 1f, 1f, 1f);
        }

        public static Vector4 FromMatrix1x4(Matrix matrix)
        {
            return new Vector4(matrix.value[0, 0], matrix.value[1, 0], matrix.value[2, 0], matrix.value[3, 0]);
        }

        public override Point ToPoint()
        {
            return new Point((int)x, (int)y);
        }

        public override bool IsNil()
        {
            return x == 0 && y == 0 && z == 0 && w == 0;
        }
        public override Matrix ToMatrix1x4()
        {
            return new Matrix(new float[4, 1]{
                { x },
                { y },
                { z },
                { w }});
        }

        public Vector3 FlattenToVector3()
        {
            return new Vector3(x, y, z);
        }

        public Vector3 FlattenDivideByW()
        {
            return this.FlattenToVector3() / w;
        }

        public Vector4 DivideByW()
        {
            return new Vector4(x / w, y / w, z / w, 1);
        }
    }
}
