namespace WinformRender
{
    partial class FastBitmapTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastBitmapTest));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fastBitmap1 = new WinformRender.Views.FastBitmap();
            ((System.ComponentModel.ISupportInitialize)(this.fastBitmap1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fastBitmap1
            // 
            this.fastBitmap1.Image = ((System.Drawing.Image)(resources.GetObject("fastBitmap1.Image")));
            this.fastBitmap1.Location = new System.Drawing.Point(12, 12);
            this.fastBitmap1.Name = "fastBitmap1";
            this.fastBitmap1.Size = new System.Drawing.Size(690, 426);
            this.fastBitmap1.TabIndex = 0;
            this.fastBitmap1.TabStop = false;
            // 
            // FastBitmapTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 450);
            this.Controls.Add(this.fastBitmap1);
            this.Name = "FastBitmapTest";
            this.Text = "FastBitmapTest";
            ((System.ComponentModel.ISupportInitialize)(this.fastBitmap1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Views.FastBitmap fastBitmap1;
        private System.Windows.Forms.Timer timer1;
    }
}