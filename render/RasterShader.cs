using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformRender
{
    static internal class RasterShader
    {
        static public class Perspective
        {
            public static void Draw(Graphics g, Vector3 globalLightDirection, STL model, Matrix tranformMatrix, Matrix normalRotationMatrix, Matrix perspectiveMatrix, ref Vector4[] vectorBuffer, ref Point[] pointBuffer, Vector2 canvasSize)
            {
                Vector3 canvasCenter = new Vector3(g.ClipBounds.Width / 2, (int)g.ClipBounds.Height / 2, 0);
                Vector3 cameraNormal = new Vector3(0, 0, 1);

                globalLightDirection = globalLightDirection.Normalize();

                Vector3 rotatedNormal;
                float cameraDot;
                float lightDot;
            

                float stepX = 1 / g.ClipBounds.Width;
                float stepY = 1 / g.ClipBounds.Height;

                SolidBrush sb = new SolidBrush(Color.White);
                SolidBrush sbTest = new SolidBrush(Color.Black);
                Pen test1 = new Pen(sb);
                Pen test2 = new Pen(sbTest);
                float aspect = 500f;
                Vector2 center = new Vector2(canvasSize.x / 2, canvasSize.y / 2);
                for(int posX = 0; posX < canvasSize.x; posX++)
                {
                    for (int posY = 0; posY < canvasSize.y; posY++)
                    {
                        g.DrawRectangle((new Vector2(posX,posY) - center).Length() - 200 > 0 ? test1 : test2, posX, posY, 1, 1);
                    }
                }
                

                //foreach (Tris tris in model.tris)
                //{
                //    rotatedNormal = normalRotationMatrix * tris.normal;
                //    if (!rotatedNormal.IsNil())
                //    {
                //        rotatedNormal = rotatedNormal.Normalize();
                //        cameraDot = cameraNormal * rotatedNormal;
                //        if (cameraDot <= 0) continue;

                //        lightDot = globalLightDirection * rotatedNormal;

                //        Vector3 color = Vector3.One() * Math.Max(0, lightDot) * 255;
                //        sb.Color = Color.FromArgb(255, (int)color.x, (int)color.y, (int)color.z);
                //    }
                //    else
                //    {   //error
                //        sb.Color = Color.PeachPuff;
                //    }

                //    // Object space -> World space -> View space -> Projection space
                //    vectorBuffer[0] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[0]);
                //    vectorBuffer[1] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[1]);
                //    vectorBuffer[2] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[2]);


                //    pointBuffer[0] = (vectorBuffer[0].FlattenDivideByW() * aspect + canvasCenter).ToPoint();
                //    pointBuffer[1] = (vectorBuffer[1].FlattenDivideByW() * aspect + canvasCenter).ToPoint();
                //    pointBuffer[2] = (vectorBuffer[2].FlattenDivideByW() * aspect + canvasCenter).ToPoint();

                //    g.FillRectangle(sb, );
                //}
            }
        }
    }
}
