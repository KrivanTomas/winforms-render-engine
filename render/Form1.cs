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

namespace render
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            transform = Matrix.Identity4x4;
        }

        STL model;
        Matrix transform;

        private void Render(object sender, PaintEventArgs e)
        {
            if (model == null) return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Graphics g = e.Graphics;
            Vector3 centerOffset = new Vector3(g.ClipBounds.Width, g.ClipBounds.Height, 0) * 0.5f;

            Point[] pointBuffer = new Point[3];

            if (wireframeCheckBox.Checked)
            {
                Pen whitePen = new Pen(Brushes.White, Convert.ToSingle(penWidthNumericUpDown.Value));
                foreach (Tris tris in model.tris)
                {

                    pointBuffer[0] = (transform * tris.vertex[0] * 100f + centerOffset).ToPoint();
                    pointBuffer[1] = (transform * tris.vertex[1] * 100f + centerOffset).ToPoint();
                    pointBuffer[2] = (transform * tris.vertex[2] * 100f + centerOffset).ToPoint();

                    g.DrawPolygon(whitePen, pointBuffer);
                }
                whitePen.Dispose();
            }
            else
            {
                Vector3 cameraNormal = new Vector3(0, 0, 1);
                SolidBrush sb = new SolidBrush(Color.White);
                foreach (Tris tris in model.tris)
                {
                    float diff = cameraNormal * (transform * tris.normal).Normalize();
                    if (diff < 0) continue;
                    Vector3 color = Vector3.One * diff * 255;
                    sb.Color = Color.FromArgb(255, (int)color.x, (int)color.y, (int)color.z);
                    
                    pointBuffer[0] = (transform * tris.vertex[0] * 100f + centerOffset).ToPoint();
                    pointBuffer[1] = (transform * tris.vertex[1] * 100f + centerOffset).ToPoint();
                    pointBuffer[2] = (transform * tris.vertex[2] * 100f + centerOffset).ToPoint();

                    g.FillPolygon(sb, pointBuffer);
                }
                sb.Dispose();
            }
            stopwatch.Stop();
            renderTimeLabel.Text = stopwatch.ElapsedMilliseconds.ToString() + "ms";
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
            Matrix translation = Matrix.Identity4x4;
            translation.value[0, 3] = float.Parse(pX.Text);
            translation.value[1, 3] = float.Parse(pY.Text);
            translation.value[2, 3] = float.Parse(pZ.Text);

            Matrix scale = Matrix.Identity4x4;
            scale.value[0, 0] = float.Parse(sX.Text);
            scale.value[1, 1] = float.Parse(sY.Text);
            scale.value[2, 2] = float.Parse(sZ.Text);

            Matrix rotationX = Matrix.Identity4x4;
            float xRot = float.Parse(rX.Text);
            rotationX.value[1, 1] = (float)Math.Cos(xRot);
            rotationX.value[1, 2] = (float)-Math.Sin(xRot);
            rotationX.value[2, 1] = (float)Math.Sin(xRot);
            rotationX.value[2, 2] = (float)Math.Cos(xRot);

            Matrix rotationY = Matrix.Identity4x4;
            float yRot = float.Parse(rY.Text);
            rotationY.value[0, 0] = (float)Math.Cos(yRot);
            rotationY.value[0, 2] = (float)Math.Sin(yRot);
            rotationY.value[2, 0] = (float)-Math.Sin(yRot);
            rotationY.value[2, 2] = (float)Math.Cos(yRot);

            Matrix rotationZ = Matrix.Identity4x4;
            float zRot = float.Parse(rZ.Text);
            rotationZ.value[0, 0] = (float)Math.Cos(zRot);
            rotationZ.value[0, 1] = (float)-Math.Sin(zRot);
            rotationZ.value[1, 0] = (float)Math.Sin(zRot);
            rotationZ.value[1, 1] = (float)Math.Cos(zRot);

            this.transform = translation * scale * rotationX * rotationY * rotationZ;
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

        private void TimerTick(object sender, EventArgs e)
        {
            Matrix rotationY = Matrix.Identity4x4;
            float yRot = 0.01f;
            rotationY.value[0, 0] = (float)Math.Cos(yRot);
            rotationY.value[0, 2] = (float)Math.Sin(yRot);
            rotationY.value[2, 0] = (float)-Math.Sin(yRot);
            rotationY.value[2, 2] = (float)Math.Cos(yRot);

            transform *= rotationY;
            pictureBox1.Invalidate();
        }

        private void continuousRenderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = continuousRenderCheckBox.Checked;
        }

        private void wireframeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            wireframeWidthLabel.Enabled = wireframeCheckBox.Checked;
            penWidthNumericUpDown.Enabled = wireframeCheckBox.Checked;
            if (autoRenderCheckBox.Checked && !continuousRenderCheckBox.Checked) pictureBox1.Invalidate();
        }

        private void penWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (autoRenderCheckBox.Checked && !continuousRenderCheckBox.Checked) pictureBox1.Invalidate();
        }

        private void onTransformInput(object sender, EventArgs e)
        {
            UpdateMatriciesFromInput();
        }
    }
}
