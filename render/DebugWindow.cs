using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WinformRender
{
    public partial class DebugWindow : Form
    {
        // TODO:
        // Ambient light
        // Mouse rotation

        // Gamma correction
        // Z Depth rendering / clipping
        // Clip space / Camera perspective cliping
        // Actual per pixel rendering / Vert and Frag shaders
        // Sprite rendering
        // FBX support - UVs, Textures, ...
        // Camera transform
        // Shadow mapping
        // Ray casting / Ray tracing

        public DebugWindow()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(Enum.GetNames(typeof(RenderingMode)));
            comboBox1.SelectedIndex = 0;

            fixedDelta = timer1.Interval * 0.001f;
            renderMode = RenderingMode.OrthographicWireframe;


            // transforms
            transformMX = Matrix.Identity4x4();
            orthographicMX = Matrix.Identity4x4();
            UpdateMatriciesFromInput();

            float width = .008f;
            float height = .006f;
            float Z_far = 10f;
            float Z_near = 0.01f;

            // orthographic projection
            orthographicMX.value[0, 0] = 1 / width;
            orthographicMX.value[1, 1] = 1 / height;
            orthographicMX.value[2, 2] = -(2 / (Z_far - Z_near));
            orthographicMX.value[2, 3] = -((Z_far + Z_near) / (Z_far - Z_near));

            float FOVx = 80f;
            float FOVy = 60f;
            //float Z_far = 10f;
            //float Z_near = 0.01f;
            perspectiveMX = Matrix.Identity4x4();

            perspectiveMX.value[0, 0] = (float)Math.Atan(FOVx / 2);
            perspectiveMX.value[1, 1] = (float)Math.Atan(FOVy / 2);
            perspectiveMX.value[2, 2] = -(Z_far + Z_near) / (Z_far - Z_near);
            perspectiveMX.value[2, 3] = -2 * Z_near * Z_far / (Z_far - Z_near);
            perspectiveMX.value[3, 2] = -1;



        }

        STL model;
        Matrix transformMX;
        Matrix orthographicMX;
        Matrix perspectiveMX;

        RenderingMode renderMode;

        Matrix translation;
        Matrix scale;
        Matrix rotation;
        Matrix rotationX;
        Matrix rotationY;
        Matrix rotationZ;


        float delta = 0;

        private void Render(object sender, PaintEventArgs e)
        {
            if (model == null) return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Graphics g = e.Graphics;

            Point[] pointBuffer = new Point[3];
            Vector4[] vectorBuffer = new Vector4[3];

            transformMX = translation * scale * rotation;

            switch (renderMode)
            {
                case RenderingMode.OrthographicWireframe:
                {
                    Pen whitePen = new Pen(Brushes.White, Convert.ToSingle(penWidthNumericUpDown.Value));
                    TrisShader.Orthographic.DrawWireframe(g, whitePen, model, transformMX, orthographicMX, ref pointBuffer);
                    whitePen.Dispose();
                    break;
                }
                case RenderingMode.PerspectiveWireframe:
                {
                    Pen whitePen = new Pen(Brushes.White, Convert.ToSingle(penWidthNumericUpDown.Value));
                    TrisShader.Perspective.DrawWireframe(g, whitePen, model, transformMX, perspectiveMX, ref vectorBuffer, ref pointBuffer);
                    whitePen.Dispose();
                    break;
                }
                case RenderingMode.OrthographicTrisshade:
                {
                    Vector3 lightDirection = new Vector3(-1, 0, 1);
                    TrisShader.Orthographic.DrawTrisshade(g, lightDirection, model, transformMX, rotation, orthographicMX, ref pointBuffer);
                    break;
                }
                case RenderingMode.PerspectiveTrisshade:
                {
                    Vector3 lightDirection = new Vector3(-1, 0, 1);
                    TrisShader.Perspective.DrawTrisshade(g, lightDirection, model, transformMX, rotation, perspectiveMX, ref vectorBuffer, ref pointBuffer);
                    break;
                }
                case RenderingMode.OrthographicZDepth:
                {
                    Vector3 lightDirection = new Vector3(-1, 0, 1);
                    TrisShader.Orthographic.DrawZDepth(g, model, transformMX, rotation, orthographicMX, ref vectorBuffer, ref pointBuffer);
                    break;
                }
                case RenderingMode.PerspectiveZDepth:
                {
                    Vector3 lightDirection = new Vector3(-1, 0, 1);
                    TrisShader.Perspective.DrawZDepth(g, model, transformMX, rotation, perspectiveMX, ref vectorBuffer, ref pointBuffer);
                    break;
                }
                case RenderingMode.RandomTrisshade:
                {
                    Vector3 lightDirection = new Vector3(-1, 0, 1);
                    TrisShader.Funky.RandomTrisshade(g, lightDirection, model, transformMX, rotation, perspectiveMX, ref vectorBuffer, ref pointBuffer);
                    break;
                }
                case RenderingMode.OffsetTrisshade:
                {
                    Vector3 lightDirection = new Vector3(-1, 0, 1);
                    TrisShader.Funky.OffsetTrisshade(g, lightDirection, model, transformMX, rotation, perspectiveMX, ref vectorBuffer, ref pointBuffer);
                    break;
                }
                case RenderingMode.OutlineTrisshade:
                {
                    Vector3 lightDirection = new Vector3(-1, 0, 1);
                    TrisShader.Funky.OutlineTrisshade(g, lightDirection, model, transformMX, rotation, perspectiveMX, ref vectorBuffer, ref pointBuffer);
                    break;
                }
            }
            stopwatch.Stop();
            delta = (float)stopwatch.ElapsedTicks / Stopwatch.Frequency;
            renderTimeLabel.Text = (delta * 1000) + "ms";
            //g.DrawString((double)1 / (stopwatch.ElapsedMilliseconds) * 1000 + " fps", new Font("Arial", 10), Brushes.White, PointF.Empty);
        }

        private void LoadSTL(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.stl)|*.stl";
            //openFileDialog1.InitialDirectory = "~/Desktop";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            model = new STL(File.Open(openFileDialog1.FileName, FileMode.Open));

            trisCountLabel.Text = "Tris count: " + model.trisCount.ToString();
            fileNameLabel.Text = "File name: " + openFileDialog1.FileName.Split('\\').Last();

            if (autoRenderCheckBox.Checked && !continuousRenderCheckBox.Checked) pictureBox1.Invalidate();
            if (!listDatacheckBox.Checked) return;
            for(int i = 0; i < model.trisCount; i++)
            {
                MessageBox.Show("Tris #" + i + ":\r\n" + model.tris[i].ToString());
            }
        }

        public void UpdateMatriciesFromInput()
        {
            translation = Matrix.Identity4x4();
            translation.value[0, 3] = float.Parse(pX.Text);
            translation.value[1, 3] = float.Parse(pY.Text);
            translation.value[2, 3] = float.Parse(pZ.Text);

            scale = Matrix.Identity4x4();
            translation.value[0, 0] = float.Parse(sX.Text);
            translation.value[1, 1] = float.Parse(sY.Text);
            translation.value[2, 2] = float.Parse(sZ.Text);

            rotationX = Matrix.Identity4x4();
            float xRot = float.Parse(rX.Text);
            rotationX.value[1, 1] = (float)Math.Cos(xRot);
            rotationX.value[1, 2] = (float)-Math.Sin(xRot);
            rotationX.value[2, 1] = (float)Math.Sin(xRot);
            rotationX.value[2, 2] = (float)Math.Cos(xRot);

            rotationY = Matrix.Identity4x4();
            float yRot = float.Parse(rY.Text);
            rotationY.value[0, 0] = (float)Math.Cos(yRot);
            rotationY.value[0, 2] = (float)Math.Sin(yRot);
            rotationY.value[2, 0] = (float)-Math.Sin(yRot);
            rotationY.value[2, 2] = (float)Math.Cos(yRot);

            rotationZ = Matrix.Identity4x4();
            float zRot = float.Parse(rZ.Text);
            rotationZ.value[0, 0] = (float)Math.Cos(zRot);
            rotationZ.value[0, 1] = (float)-Math.Sin(zRot);
            rotationZ.value[1, 0] = (float)Math.Sin(zRot);
            rotationZ.value[1, 1] = (float)Math.Cos(zRot);

            rotation = rotationX * rotationY * rotationZ;
            this.transformMX = translation * scale * rotation;
            if (autoRenderCheckBox.Checked && !continuousRenderCheckBox.Checked) pictureBox1.Invalidate();
        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            if (model == null)
            {
                MessageBox.Show("No model loaded in memory", "Cannot render", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pictureBox1.Invalidate();
        }

        float fixedDelta;
        private void TimerTick(object sender, EventArgs e)
        {
            Matrix rotationY = Matrix.Identity4x4();
            float yRot = (float)Math.PI * fixedDelta;
            rotationY.value[0, 0] = (float)Math.Cos(yRot);
            rotationY.value[0, 2] = (float)Math.Sin(yRot);
            rotationY.value[2, 0] = (float)-Math.Sin(yRot);
            rotationY.value[2, 2] = (float)Math.Cos(yRot);

            Matrix rotationX = Matrix.Identity4x4();
            float xRot = (float)Math.PI * fixedDelta;
            rotationX.value[1, 1] = (float)Math.Cos(xRot);
            rotationX.value[1, 2] = (float)-Math.Sin(xRot);
            rotationX.value[2, 1] = (float)Math.Sin(xRot);
            rotationX.value[2, 2] = (float)Math.Cos(xRot);

            // slide back
            Matrix translation = Matrix.Identity4x4();
            translation.value[0, 3] = 0;
            translation.value[1, 3] = 0;
            translation.value[2, 3] = 10f * fixedDelta;

            rotation *= rotationY;

            pictureBox1.Invalidate();
        }

        private enum RenderingMode
        {
            OrthographicWireframe,
            OrthographicTrisshade,
            OrthographicZDepth,
            PerspectiveWireframe,
            PerspectiveTrisshade,
            PerspectiveZDepth,
            RandomTrisshade,
            OffsetTrisshade,
            OutlineTrisshade
        }

        private void continuousRenderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = continuousRenderCheckBox.Checked;
        }

        //private void wireframeCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    wireframeWidthLabel.Enabled = wireframeCheckBox.Checked;
        //    penWidthNumericUpDown.Enabled = wireframeCheckBox.Checked;
        //    if (autoRenderCheckBox.Checked && !continuousRenderCheckBox.Checked) pictureBox1.Invalidate();
        //}

        private void penWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (autoRenderCheckBox.Checked && !continuousRenderCheckBox.Checked) pictureBox1.Invalidate();
        }

        private void onTransformInput(object sender, EventArgs e)
        {
            UpdateMatriciesFromInput();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderMode = (RenderingMode)comboBox1.SelectedIndex;
            if (autoRenderCheckBox.Checked && !continuousRenderCheckBox.Checked) pictureBox1.Invalidate();
        }
    }
}
