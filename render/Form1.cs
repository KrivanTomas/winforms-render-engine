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

namespace render
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Render(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen whitePen = new Pen(Brushes.White, 2);
            // todo g.DrawPolygon(whitePen, );
        }

        private void LoadSTL(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "(*.stl)|*.stl|";
            //openFileDialog1.Filter = "(*.stl)|*.stl|";
            openFileDialog1.InitialDirectory = "~/Desktop";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            STL model = new STL(File.Open(openFileDialog1.FileName, FileMode.Open));
            for(int i = 0; i < model.trisCount; i++)
            {
                MessageBox.Show("Tris #" + i + ":\r\n" + model.tris[i].ToString());
            }
        }
    }
}
