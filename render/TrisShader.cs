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
            public static void DrawTrisshade(Graphics g, Vector3 globalLightDirection, STL model, Matrix tranformMatrix, Matrix normalRotationMatrix, Matrix orthographicMatrix, ref Point[] pointBuffer)
            {
                Vector3 canvasCenter = new Vector3(g.ClipBounds.Width / 2, (int)g.ClipBounds.Height / 2, 0);
                Vector3 cameraNormal = new Vector3(0, 0, 1);

                globalLightDirection = globalLightDirection.Normalize();

                Vector3 rotatedNormal;
                float cameraDot;
                float lightDot;

                SolidBrush sb = new SolidBrush(Color.White);

                foreach (Tris tris in model.tris)
                {
                    rotatedNormal = normalRotationMatrix * tris.normal;
                    if (!rotatedNormal.IsNil())
                    {
                        rotatedNormal = rotatedNormal.Normalize();
                        cameraDot = cameraNormal * rotatedNormal;
                        if (cameraDot <= 0) continue;

                        lightDot = globalLightDirection * rotatedNormal;

                        Vector3 color = Vector3.One() * Math.Max(0, lightDot) * 255;
                        sb.Color = Color.FromArgb(255, (int)color.x, (int)color.y, (int)color.z);
                    }
                    else
                    {   //error
                        sb.Color = Color.PeachPuff;
                    }

                    // Object space -> World space -> View space -> Projection space
                    pointBuffer[0] = (orthographicMatrix * (tranformMatrix * tris.vertex[0]) + canvasCenter).ToPoint();
                    pointBuffer[1] = (orthographicMatrix * (tranformMatrix * tris.vertex[1]) + canvasCenter).ToPoint();
                    pointBuffer[2] = (orthographicMatrix * (tranformMatrix * tris.vertex[2]) + canvasCenter).ToPoint();


                    g.FillPolygon(sb, pointBuffer);
                }
            }
            public static void DrawZDepth(Graphics g, STL model, Matrix tranformMatrix, Matrix normalRotationMatrix, Matrix orthographicMatrix, ref Vector4[] vectorBuffer, ref Point[] pointBuffer)
            {
                Vector3 canvasCenter = new Vector3(g.ClipBounds.Width / 2, (int)g.ClipBounds.Height / 2, 0);
                SolidBrush sb = new SolidBrush(Color.White);
                Vector3 cameraNormal = new Vector3(0, 0, 1);

                Vector3 rotatedNormal;
                float cameraDot;

                foreach (Tris tris in model.tris)
                {
                    rotatedNormal = normalRotationMatrix * tris.normal;
                    if (!rotatedNormal.IsNil())
                    {
                        rotatedNormal = rotatedNormal.Normalize();
                        cameraDot = cameraNormal * rotatedNormal;
                        if (cameraDot <= 0) continue;
                    }
                    // Object space -> World space -> View space -> Projection space
                    vectorBuffer[0] = orthographicMatrix ^ (tranformMatrix * tris.vertex[0]);
                    vectorBuffer[1] = orthographicMatrix ^ (tranformMatrix * tris.vertex[1]);
                    vectorBuffer[2] = orthographicMatrix ^ (tranformMatrix * tris.vertex[2]);

                    float averageZ = ((vectorBuffer[0].z + vectorBuffer[1].z + vectorBuffer[2].z) / 3f + 1f) * 0.5f;
                    if (averageZ > 1 || averageZ < 0) continue;
                    Vector3 color = Vector3.One() * averageZ * 255;
                    sb.Color = Color.FromArgb(255, (int)color.x, (int)color.y, (int)color.z);

                    pointBuffer[0] = (vectorBuffer[0] + canvasCenter).ToPoint();
                    pointBuffer[1] = (vectorBuffer[1] + canvasCenter).ToPoint();
                    pointBuffer[2] = (vectorBuffer[2] + canvasCenter).ToPoint();

                    g.FillPolygon(sb, pointBuffer);
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

            public static void DrawTrisshade(Graphics g, Vector3 globalLightDirection, STL model, Matrix tranformMatrix, Matrix normalRotationMatrix, Matrix perspectiveMatrix, ref Vector4[] vectorBuffer, ref Point[] pointBuffer)
            {
                Vector3 canvasCenter = new Vector3(g.ClipBounds.Width / 2, (int)g.ClipBounds.Height / 2, 0);
                Vector3 cameraNormal = new Vector3(0, 0, 1);

                globalLightDirection = globalLightDirection.Normalize();

                Vector3 rotatedNormal;
                float cameraDot;
                float lightDot;

                SolidBrush sb = new SolidBrush(Color.White);
                float aspect = 500f;
                foreach (Tris tris in model.tris)
                {
                    rotatedNormal = normalRotationMatrix * tris.normal;
                    if (!rotatedNormal.IsNil())
                    {
                        rotatedNormal = rotatedNormal.Normalize();
                        cameraDot = cameraNormal * rotatedNormal;
                        if (cameraDot <= 0) continue;

                        lightDot = globalLightDirection * rotatedNormal;

                        Vector3 color = Vector3.One() * Math.Max(0, lightDot) * 255;
                        sb.Color = Color.FromArgb(255, (int)color.x, (int)color.y, (int)color.z);
                    }
                    else
                    {   //error
                        sb.Color = Color.PeachPuff;
                    }

                    // Object space -> World space -> View space -> Projection space
                    vectorBuffer[0] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[0]);
                    vectorBuffer[1] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[1]);
                    vectorBuffer[2] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[2]);


                    pointBuffer[0] = (vectorBuffer[0].FlattenDivideByW() * aspect + canvasCenter).ToPoint();
                    pointBuffer[1] = (vectorBuffer[1].FlattenDivideByW() * aspect + canvasCenter).ToPoint();
                    pointBuffer[2] = (vectorBuffer[2].FlattenDivideByW() * aspect + canvasCenter).ToPoint();

                    g.FillPolygon(sb, pointBuffer);
                }
            }
            public static void DrawZDepth(Graphics g, STL model, Matrix tranformMatrix, Matrix normalRotationMatrix, Matrix perspectiveMatrix, ref Vector4[] vectorBuffer, ref Point[] pointBuffer)
            {
                Vector3 canvasCenter = new Vector3(g.ClipBounds.Width / 2, (int)g.ClipBounds.Height / 2, 0);
                SolidBrush sb = new SolidBrush(Color.White);
                Vector3 cameraNormal = new Vector3(0, 0, 1);

                Vector3 rotatedNormal;
                float cameraDot;

                float aspect = 500f;
                foreach (Tris tris in model.tris)
                {
                    rotatedNormal = normalRotationMatrix * tris.normal;
                    if (!rotatedNormal.IsNil())
                    {
                        rotatedNormal = rotatedNormal.Normalize();
                        cameraDot = cameraNormal * rotatedNormal;
                        if (cameraDot <= 0) continue;
                    }
                    // Object space -> World space -> View space -> Projection space
                    vectorBuffer[0] = (perspectiveMatrix ^ (tranformMatrix * tris.vertex[0])).DivideByW();
                    vectorBuffer[1] = (perspectiveMatrix ^ (tranformMatrix * tris.vertex[1])).DivideByW();
                    vectorBuffer[2] = (perspectiveMatrix ^ (tranformMatrix * tris.vertex[2])).DivideByW();

                    float averageZ = ((vectorBuffer[0].z + vectorBuffer[1].z + vectorBuffer[2].z) / 3f + 1f) * 0.5f;
                    if (averageZ > 1 || averageZ < 0) continue;
                    Vector3 color = Vector3.One() * averageZ * 255;
                    sb.Color = Color.FromArgb(255, (int)color.x, (int)color.y, (int)color.z);

                    pointBuffer[0] = (vectorBuffer[0] * aspect + canvasCenter).ToPoint();
                    pointBuffer[1] = (vectorBuffer[1] * aspect + canvasCenter).ToPoint();
                    pointBuffer[2] = (vectorBuffer[2] * aspect + canvasCenter).ToPoint();

                    g.FillPolygon(sb, pointBuffer);
                }
            }
        }
        static public class Funky
        {
            public static void RandomTrisshade(Graphics g, Vector3 globalLightDirection, STL model, Matrix tranformMatrix, Matrix normalRotationMatrix, Matrix perspectiveMatrix, ref Vector4[] vectorBuffer, ref Point[] pointBuffer)
            {
                Vector3 canvasCenter = new Vector3(g.ClipBounds.Width / 2, (int)g.ClipBounds.Height / 2, 0);
                Vector3 cameraNormal = new Vector3(0, 0, 1);

                globalLightDirection = globalLightDirection.Normalize();

                Vector3 rotatedNormal;
                float cameraDot;
                float lightDot;

                Random rand = new Random();

                SolidBrush sb = new SolidBrush(Color.White);
                float aspect = 500f;
                foreach (Tris tris in model.tris)
                {
                    rotatedNormal = normalRotationMatrix * tris.normal;
                    if (!rotatedNormal.IsNil())
                    {
                        rotatedNormal = rotatedNormal.Normalize();
                        cameraDot = cameraNormal * rotatedNormal;
                        if (cameraDot <= 0 || rand.Next(0, 2) == 0) continue;

                        lightDot = globalLightDirection * rotatedNormal;

                        Vector3 color = Vector3.One() * Math.Max(0, lightDot) * 255;
                        sb.Color = Color.FromArgb(255, (int)color.x, (int)color.y, (int)color.z);
                    }
                    else
                    {   //error
                        sb.Color = Color.PeachPuff;
                    }

                    // Object space -> World space -> View space -> Projection space
                    vectorBuffer[0] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[0]);
                    vectorBuffer[1] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[1]);
                    vectorBuffer[2] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[2]);


                    pointBuffer[0] = (vectorBuffer[0].FlattenDivideByW() * aspect + canvasCenter).ToPoint();
                    pointBuffer[1] = (vectorBuffer[1].FlattenDivideByW() * aspect + canvasCenter).ToPoint();
                    pointBuffer[2] = (vectorBuffer[2].FlattenDivideByW() * aspect + canvasCenter).ToPoint();

                    g.FillPolygon(sb, pointBuffer);
                }
            }
            public static void OffsetTrisshade(Graphics g, Vector3 globalLightDirection, STL model, Matrix tranformMatrix, Matrix normalRotationMatrix, Matrix perspectiveMatrix, ref Vector4[] vectorBuffer, ref Point[] pointBuffer)
            {
                Vector3 canvasCenter = new Vector3(g.ClipBounds.Width / 2, (int)g.ClipBounds.Height / 2, 0);
                Vector3 cameraNormal = new Vector3(0, 0, 1);

                globalLightDirection = globalLightDirection.Normalize();

                Vector3 rotatedNormal;
                float cameraDot;
                float lightDot;

                Random rand = new Random();
                float maxOffset = 0.2f;

                SolidBrush sb = new SolidBrush(Color.White);
                float aspect = 500f;
                foreach (Tris tris in model.tris)
                {
                    rotatedNormal = normalRotationMatrix * tris.normal;
                    if (!rotatedNormal.IsNil())
                    {
                        rotatedNormal = rotatedNormal.Normalize();
                        cameraDot = cameraNormal * rotatedNormal;
                        if (cameraDot <= 0) continue;

                        lightDot = globalLightDirection * rotatedNormal;

                        Vector3 color = Vector3.One() * Math.Max(0, lightDot) * 255;
                        sb.Color = Color.FromArgb(255, (int)color.x, (int)color.y, (int)color.z);
                    }
                    else
                    {   //error
                        sb.Color = Color.PeachPuff;
                    }
                    Vector3 randomOffset;
                    

                    // Object space -> World space -> View space -> Projection space

                    
                    randomOffset = new Vector3((float)((rand.NextDouble() - 0.5f) * 2 * maxOffset), (float)((rand.NextDouble() - 0.5f) * 2 * maxOffset), (float)((rand.NextDouble() - 0.5f) * 2 * maxOffset));
                    vectorBuffer[0] = perspectiveMatrix ^ (tranformMatrix * (tris.vertex[0] + randomOffset));
                    randomOffset = new Vector3((float)((rand.NextDouble() - 0.5f) * 2 * maxOffset), (float)((rand.NextDouble() - 0.5f) * 2 * maxOffset), (float)((rand.NextDouble() - 0.5f) * 2 * maxOffset));
                    vectorBuffer[1] = perspectiveMatrix ^ (tranformMatrix * (tris.vertex[1] + randomOffset));
                    randomOffset = new Vector3((float)((rand.NextDouble() - 0.5f) * 2 * maxOffset), (float)((rand.NextDouble() - 0.5f) * 2 * maxOffset), (float)((rand.NextDouble() - 0.5f) * 2 * maxOffset));
                    vectorBuffer[2] = perspectiveMatrix ^ (tranformMatrix * (tris.vertex[2] + randomOffset));


                    pointBuffer[0] = ((vectorBuffer[0].FlattenDivideByW()) * aspect + canvasCenter).ToPoint();
                    pointBuffer[1] = ((vectorBuffer[1].FlattenDivideByW()) * aspect + canvasCenter).ToPoint();
                    pointBuffer[2] = ((vectorBuffer[2].FlattenDivideByW()) * aspect + canvasCenter).ToPoint();

                    g.FillPolygon(sb, pointBuffer);
                }
            }
            public static void OutlineTrisshade(Graphics g, Vector3 globalLightDirection, STL model, Matrix tranformMatrix, Matrix normalRotationMatrix, Matrix perspectiveMatrix, ref Vector4[] vectorBuffer, ref Point[] pointBuffer)
            {
                Vector3 canvasCenter = new Vector3(g.ClipBounds.Width / 2, (int)g.ClipBounds.Height / 2, 0);
                Vector3 cameraNormal = new Vector3(0, 0, 1);

                globalLightDirection = globalLightDirection.Normalize();

                Vector3 rotatedNormal;
                float cameraDot;
                float lightDot;

                SolidBrush sb = new SolidBrush(Color.White);
                float aspect = 500f;
                foreach (Tris tris in model.tris)
                {
                    rotatedNormal = normalRotationMatrix * tris.normal;
                    if (!rotatedNormal.IsNil())
                    {
                        rotatedNormal = rotatedNormal.Normalize();
                        cameraDot = cameraNormal * rotatedNormal;
                        if (cameraDot <= 0) continue;

                        if (cameraDot < 0.1)
                        {
                            sb.Color = Color.Gold;
                        }
                        else
                        {
                            lightDot = globalLightDirection * rotatedNormal;

                            Vector3 color = Vector3.One() * Math.Max(0, lightDot) * 255;
                            sb.Color = Color.FromArgb(255, (int)color.x, (int)color.y, (int)color.z);
                        }
                    }
                    else
                    {   //error
                        sb.Color = Color.PeachPuff;
                    }

                    // Object space -> World space -> View space -> Projection space
                    vectorBuffer[0] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[0]);
                    vectorBuffer[1] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[1]);
                    vectorBuffer[2] = perspectiveMatrix ^ (tranformMatrix * tris.vertex[2]);


                    pointBuffer[0] = (vectorBuffer[0].FlattenDivideByW() * aspect + canvasCenter).ToPoint();
                    pointBuffer[1] = (vectorBuffer[1].FlattenDivideByW() * aspect + canvasCenter).ToPoint();
                    pointBuffer[2] = (vectorBuffer[2].FlattenDivideByW() * aspect + canvasCenter).ToPoint();

                    g.FillPolygon(sb, pointBuffer);
                }
            }
        }
    }
}
