using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

using WinformRender;

namespace UnitTests
{
    [TestClass]
    public class MatriciesTests
    {
        private bool IsEqualMatrix(Matrix a, Matrix b)
        {
            return a.value.Rank == b.value.Rank &&
            Enumerable.Range(0, a.value.Rank).All(dimension => a.value.GetLength(dimension) == b.value.GetLength(dimension)) &&
            a.value.Cast<float>().SequenceEqual(b.value.Cast<float>());
        }

        private bool IsEqualVector(Vector3 a, Vector3 b)
        {
            return a.x == b.x &&
                   a.y == b.y &&
                   a.z == b.z;
        }


        [TestMethod]
        public void Identity4x4Value()
        {
            Matrix actual = Matrix.Identity4x4();
            Matrix expected = new Matrix(new float[,]{
                { 1f, 0f, 0f, 0f},
                { 0f, 1f, 0f, 0f},
                { 0f, 0f, 1f, 0f},
                { 0f, 0f, 0f, 1f}
            });

            Assert.IsTrue(IsEqualMatrix(expected, actual));
        }

        [TestMethod]
        public void Identity4x4Reference()
        {
            Matrix actual = Matrix.Identity4x4();
            Matrix notExpected = Matrix.Identity4x4();
            Assert.AreNotSame(notExpected, actual);
        }

        [TestMethod]
        public void Mult_MxM_01()
        {
            Matrix actual = Matrix.Identity4x4() * Matrix.Identity4x4();
            Matrix expected = Matrix.Identity4x4();
            Assert.IsTrue(IsEqualMatrix(expected, actual));
        }

        [TestMethod]
        public void Mult_MxM_02()
        {
            Matrix actual = 
                 new Matrix(new float[,]{
                { 1f, 2f, 1f, 1f},
                { 0f, 1f, 0f, 1f},
                { 2f, 3f, 4f, 1f},
                { 1f, 1f, 1f, 1f}
            }) * new Matrix(new float[,]{
                { 2f, 5f, 1f, 1f},
                { 6f, 7f, 1f, 1f},
                { 1f, 8f, 1f, 1f},
                { 1f, 1f, 1f, 1f}
            });
            Matrix expected = new Matrix(new float[,]{
                { 16f, 28f,  5f,  5f},
                {  7f,  8f,  2f,  2f},
                { 27f, 64f, 10f, 10f},
                { 10f, 21f,  4f,  4f}
            });
            Assert.IsTrue(IsEqualMatrix(expected, actual));
        }

        [TestMethod]
        public void Mult_MxM_03()
        {
            Matrix actual =
                new Matrix(new float[,]{
                {  5f,  1f, 31f,  0f},
                {  3f, 12f,  1f, 12f},
                { 21f, 33f, 43f, 12f},
                { 31f, 13f,  0f,  0f}
            }) * new Matrix(new float[,]{
                { 2f, 5f, 1f, 1f},
                { 6f, 7f, 1f, 1f},
                { 1f, 8f, 1f, 1f},
                { 1f, 1f, 1f, 1f}
            });
            Matrix expected = new Matrix(new float[,]{
                {  47f, 280f,  37f,  37f},
                {  91f, 119f,  28f,  28f},
                { 295f, 692f, 109f, 109f},
                { 140f, 246f,  44f,  44f}
            });
            Assert.IsTrue(IsEqualMatrix(expected, actual));
        }

        [TestMethod]
        public void Mult_MxV_01()
        {
            Vector3 actual =
                new Matrix(new float[,]{
                {  5f,  1f, 31f,  0f},
                {  3f, 12f,  1f, 12f},
                { 21f, 33f, 43f, 12f},
                { 31f, 13f,  0f,  0f}
            }) * new Vector3(1, 2, 3);
            Vector3 expected =
                 new Vector3(100, 42, 228);
            Assert.IsTrue(IsEqualVector(expected, actual));
        }

        [TestMethod]
        public void Mult_MxV_02()
        {
            Vector3 actual =
                new Matrix(new float[,]{
                {  5f,  1f, 31f,  0f},
                {  3f, 12f,  1f, 12f},
                { 21f, 33f, 43f, 12f},
                { 31f, 13f,  0f,  0f}
            }) * new Vector3(64, 69, 34);
            Vector3 expected =
                 new Vector3(1443, 1066, 5095);
            Assert.IsTrue(IsEqualVector(expected, actual));
        }

        [TestMethod]
        public void Mult_MxV_03()
        {
            Vector3 actual =
                new Matrix(new float[,]{
                { 2f, 5f, 1f, 1f},
                { 6f, 7f, 1f, 1f},
                { 1f, 8f, 1f, 1f},
                { 1f, 1f, 1f, 1f}
            }) * new Vector3(64, 69, 34);
            Vector3 expected =
                 new Vector3(508, 902, 651);
            Assert.IsTrue(IsEqualVector(expected, actual));
        }

        [TestMethod]
        public void Transform_01()
        {
            Matrix actual =
                new Matrix(new float[,]{
                { 1f, 0f, 0f, 1.5f},
                { 0f, 1f, 0f, 1.0f},
                { 0f, 0f, 1f, 1.5f},
                { 0f, 0f, 0f, 1.0f}
            }) * new Matrix(new float[,]{
                { 1f,  0f,  0f, 0f},
                { 0f, -1f,  0f, 0f},
                { 0f,  0f, -1f, 0f},
                { 0f,  0f,  0f, 1f}
            }) * new Matrix(new float[,]{
                {  0f, 0f, 1f, 0f},
                {  0f, 1f, 0f, 0f},
                { -1f, 0f, 0f, 0f},
                {  0f, 0f, 0f, 1f}
            });
            
            Matrix expected =
                new Matrix(new float[,]{
                { 0f,  0f, 1f, 1.5f},
                { 0f, -1f, 0f, 1.0f},
                { 1f,  0f, 0f, 1.5f},
                { 0f,  0f, 0f, 1.0f}
            });
            
            Console.WriteLine(actual.ToString());
            Assert.IsTrue(IsEqualMatrix(expected, actual));
        }
    }
}