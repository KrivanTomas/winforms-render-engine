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
        }

        STL model;

        private void Render(object sender, PaintEventArgs e)
        {
            if (model == null) return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Graphics g = e.Graphics;
            Vector3 centerOffset = new Vector3(g.ClipBounds.Width, g.ClipBounds.Height, 0) * 0.5f;

            if (wireframeCheckBox.Checked)
            {
                Pen whitePen = new Pen(Brushes.White, Convert.ToSingle(penWidthNumericUpDown.Value));
                foreach (Tris tris in model.tris)
                {

                    g.DrawPolygon(whitePen, tris.vertex.Select(x => (x * 100f + centerOffset).ToPoint()).ToArray<Point>());


                }
                whitePen.Dispose();
            }
            else
            {
                Vector3 cameraNormal = new Vector3(0, 0, 1);
                foreach (Tris tris in model.tris)
                {
                    float diff = cameraNormal * tris.normal.Normalize();
                    if (diff < 0) continue;
                    Vector3 color = Vector3.One * Math.Abs(diff) * 255;

                    g.FillPolygon(new SolidBrush(Color.FromArgb(diff < 0 ? 0 : 255, Convert.ToInt32(color.x), Convert.ToInt32(color.y), Convert.ToInt32(color.z))), tris.vertex.Select(x => (x * 100f + centerOffset).ToPoint()).ToArray<Point>());
                }
            }
            stopwatch.Stop();
            renderTimeLabel.Text = stopwatch.ElapsedMilliseconds.ToString() + "ms";
        }

        private void LoadSTL(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.stl)|*.stl";
            //openFileDialog1.InitialDirectory = "~/Desktop";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            model = new STL(File.Open(openFileDialog1.FileName, FileMode.Open));

            trisCountLabel.Text = "Tris count: " + model.trisCount.ToString();
            fileNameLabel.Text = "File name: " + openFileDialog1.FileName.Split('\\').Last();

            if (autoRenderCheckBox.Checked && !continuousRenderCheckBox.Checked) pictureBox1.Refresh();
            if (!listDatacheckBox.Checked) return;
            for(int i = 0; i < model.trisCount; i++)
            {
                MessageBox.Show("Tris #" + i + ":\r\n" + model.tris[i].ToString());
            }
        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            if (model == null)
            {
                MessageBox.Show("No model loaded in memory", "Cannot render", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pictureBox1.Refresh();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void continuousRenderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = continuousRenderCheckBox.Checked;
        }

        private void wireframeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            wireframeWidthLabel.Enabled = wireframeCheckBox.Checked;
            penWidthNumericUpDown.Enabled = wireframeCheckBox.Checked;
            if (autoRenderCheckBox.Checked && !continuousRenderCheckBox.Checked) pictureBox1.Refresh();
        }

        private void penWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (autoRenderCheckBox.Checked && !continuousRenderCheckBox.Checked) pictureBox1.Refresh();
        }
    }
}
