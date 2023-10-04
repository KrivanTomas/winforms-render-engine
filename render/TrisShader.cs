using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinformRender
{
    static internal class TrisShader
    {
        static public class Orthographic
        {
            public static void DrawWireframe(Graphics g, Pen pen, STL model, Matrix tranformMatrix, Matrix orthographicMatrix, ref Point[] pointBuffer)
            {
                Vector3 canvasCenter = new Vector3(g.ClipBounds.Width / 2, (int)g.ClipBounds.Height / 2, 0);

                foreach (Tris tris in model.tris)
                {
                    // Object space -> World space -> View space -> Projection space
                    pointBuffer[0] = (orthographicMatrix * (tranformMatrix * tris.vertex[0]) + canvasCenter).ToPoint();
                    pointBuffer[1] = (orthographicMatrix * (tranformMatrix * tris.vertex[1]) + canvasCenter).ToPoint();
                    pointBuffer[2] = (orthographicMatrix * (tranformMatrix * tris.vertex[2]) + canvasCenter).ToPoint();


                    g.DrawPolygon(pen, pointBuffer);
                }
            }
        }
        static public class Perspective
        {
            public static void DrawWireframe(Graphics g, Pen pen, STL model, Matrix tranformMatrix, Matrix perspectiveMatrix, ref Vector4[] vectorBuffer, ref Point[] pointBuffer)
            {
                Vector3 canvasCenter = new Vector3(g.ClipBounds.Width / 2, (int)g.ClipBounds.Height / 2, 0);
                float aspect = 500f;
                foreach (Tris tris in model.tris)
                {
                    // Object space -> World space -> View space -> Projection space
                    vectorBuffer[0] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[0]);
                    vectorBuffer[1] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[1]);
                    vectorBuffer[2] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[2]);


                    pointBuffer[0] = (vectorBuffer[0].FlattenDivideByW() * aspect + canvasCenter).ToPoint();
                    pointBuffer[1] = (vectorBuffer[1].FlattenDivideByW() * aspect + canvasCenter).ToPoint();
                    pointBuffer[2] = (vectorBuffer[2].FlattenDivideByW() * aspect + canvasCenter).ToPoint();

                    g.DrawPolygon(pen, pointBuffer);
                }
            }
        }
    }
}
