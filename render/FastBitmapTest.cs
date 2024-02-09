using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformRender
{
    public partial class FastBitmapTest : Form
    {
        bool switched = false;
        public FastBitmapTest()
        {
            InitializeComponent();
            FloatColor ssss = new FloatColor(0xAAFFFFDD);
            MessageBox.Show(ssss.GetHexValue().ToString());
            MessageBox.Show(Convert.ToUInt32(ssss.a * 255).ToString());
            MessageBox.Show(Convert.ToUInt32(ssss.r * 255).ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int width = fastBitmap1.ClientSize.Width;
            int height = fastBitmap1.ClientSize.Height;


            Vector2 canvasSize = new Vector2(width, height);

            SolidBrush sb = new SolidBrush(Color.White);
            SolidBrush sbTest = new SolidBrush(Color.Black);
            UInt32 test1 = 0xFF000000;
            UInt32 test2 = 0xFFFFFFFF;
            FloatColor test3 = new FloatColor(0xFFFFFFFF);
            double time = (double)DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
            float aspect = 500f;
            Vector2 center = new Vector2(canvasSize.x / 2, canvasSize.y / 2);
            for (int posX = 0; posX < canvasSize.x; posX++)
            {
                for (int posY = 0; posY < canvasSize.y; posY++)
                {
                    double circle = (new Vector2(posX, posY) - center).Length() - 200 * (Math.Sin(time) + 1) / 2;
                    circle = Math.Abs(circle);
                    //fastBitmap1._pixels[posX + posY * width] = circle < 10 ? test2 : test1;
                    fastBitmap1._pixels[posX + posY * width] = (test3 * smoothstep(0, width, posX)).GetHexValue();
                }
            }
            fastBitmap1.Invalidate();
        }

        private double smoothstep(double from, double to, double value)
        {
            if (value < from) return 0;
            if (value > to) return 1;
            return lerp(0, 1, (value - from) / (to - from));
        }

        private double lerp(double a, double b, double t)
        {
            return a * (1 - t) + b * t;
        }
    }
    
    class FloatColor
    {
        public double a, r, g, b;
        
        public FloatColor(UInt32 hex)
        {
            a = Convert.ToDouble((hex & 0xFF000000) >> (6 * 4)) / 0xFF;
            r = Convert.ToDouble((hex & 0x00FF0000) >> (4 * 4)) / 0xFF;
            g = Convert.ToDouble((hex & 0x0000FF00) >> (2 * 4)) / 0xFF;
            b = Convert.ToDouble(hex & 0x000000FF) / 0xFF;
        }

        public FloatColor(double r, double g, double b, double a)
        {
            this.a = a;
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public static FloatColor operator *(FloatColor color, double x) {
            return new FloatColor(color.a, color.r * x, color.g * x, color.b * x);
        }

        public static FloatColor operator +(FloatColor color, double x)
        {
            return new FloatColor(color.a, color.r + x, color.g + x, color.b + x);
        }

        public static FloatColor operator +(FloatColor cola, FloatColor colb)
        {
            return new FloatColor(cola.a, cola.r + colb.r, cola.g + colb.g, cola.b + colb.b);
        }

        public static FloatColor operator -(FloatColor cola)
        {
            return new FloatColor(cola.a, -cola.r, -cola.g, -cola.b);
        }

        public FloatColor Clamp()
        {
            return new FloatColor(
                (a < 0 ? 0 : (a > 1 ? 1 : a)),
                (r < 0 ? 0 : (r > 1 ? 1 : r)),
                (g < 0 ? 0 : (g > 1 ? 1 : g)),
                (b < 0 ? 0 : (b > 1 ? 1 : b))
                );
        }

        public UInt32 GetHexValue()
        {
            FloatColor c = this.Clamp();
            UInt32 hex = 0;
            
            hex |= Convert.ToUInt32(c.a * 0xFF) << 24;
            hex |= Convert.ToUInt32(c.r * 0xFF) << 16;
            hex |= Convert.ToUInt32(c.g * 0xFF) << 8;
            hex |= Convert.ToUInt32(c.b * 0xFF) << 0;
            return hex;
        }

        public override string ToString()
        {
            return String.Format("r:{0} g:{1} b:{2} a:{3}", r, g, b, a);
        }
    }
}
