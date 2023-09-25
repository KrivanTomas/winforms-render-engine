namespace render
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loadStlButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listDatacheckBox = new System.Windows.Forms.CheckBox();
            this.renderButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wireframeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.autoRenderCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.trisCountLabel = new System.Windows.Forms.Label();
            this.wireframeWidthLabel = new System.Windows.Forms.Label();
            this.penWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.renderTimeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.continuousRenderCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penWidthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Indigo;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(641, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.Render);
            // 
            // loadStlButton
            // 
            this.loadStlButton.Location = new System.Drawing.Point(645, 12);
            this.loadStlButton.Name = "loadStlButton";
            this.loadStlButton.Size = new System.Drawing.Size(122, 23);
            this.loadStlButton.TabIndex = 1;
            this.loadStlButton.Text = "Load STL";
            this.loadStlButton.UseVisualStyleBackColor = true;
            this.loadStlButton.Click += new System.EventHandler(this.LoadSTL);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listDatacheckBox
            // 
            this.listDatacheckBox.AutoSize = true;
            this.listDatacheckBox.Location = new System.Drawing.Point(779, 16);
            this.listDatacheckBox.Name = "listDatacheckBox";
            this.listDatacheckBox.Size = new System.Drawing.Size(66, 17);
            this.listDatacheckBox.TabIndex = 2;
            this.listDatacheckBox.Text = "List data";
            this.listDatacheckBox.UseVisualStyleBackColor = true;
            // 
            // renderButton
            // 
            this.renderButton.Location = new System.Drawing.Point(645, 408);
            this.renderButton.Name = "renderButton";
            this.renderButton.Size = new System.Drawing.Size(200, 30);
            this.renderButton.TabIndex = 3;
            this.renderButton.Text = "Render";
            this.renderButton.UseVisualStyleBackColor = true;
            this.renderButton.Click += new System.EventHandler(this.renderButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(645, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 139);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transformations";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(154, 110);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(42, 20);
            this.textBox7.TabIndex = 20;
            this.textBox7.Text = "1.0";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "z:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(90, 110);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(42, 20);
            this.textBox8.TabIndex = 18;
            this.textBox8.Text = "1.0";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "y:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(24, 110);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(42, 20);
            this.textBox9.TabIndex = 16;
            this.textBox9.Text = "1.0";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "x:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Scale";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(154, 71);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(42, 20);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "0.0";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "z:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(90, 71);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(42, 20);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "0.0";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "y:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(24, 71);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(42, 20);
            this.textBox6.TabIndex = 9;
            this.textBox6.Text = "0.0";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "x:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Rotation";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(154, 32);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(42, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "0.0";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "z:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(90, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(42, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "0.0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "y:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "0.0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "x:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position";
            // 
            // wireframeCheckBox
            // 
            this.wireframeCheckBox.AutoSize = true;
            this.wireframeCheckBox.Checked = true;
            this.wireframeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wireframeCheckBox.Location = new System.Drawing.Point(9, 19);
            this.wireframeCheckBox.Name = "wireframeCheckBox";
            this.wireframeCheckBox.Size = new System.Drawing.Size(96, 17);
            this.wireframeCheckBox.TabIndex = 7;
            this.wireframeCheckBox.Text = "Wireframe only";
            this.wireframeCheckBox.UseVisualStyleBackColor = true;
            this.wireframeCheckBox.CheckedChanged += new System.EventHandler(this.wireframeCheckBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.continuousRenderCheckBox);
            this.groupBox2.Controls.Add(this.penWidthNumericUpDown);
            this.groupBox2.Controls.Add(this.wireframeWidthLabel);
            this.groupBox2.Controls.Add(this.autoRenderCheckBox);
            this.groupBox2.Controls.Add(this.wireframeCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(645, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 148);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rendering options";
            // 
            // autoRenderCheckBox
            // 
            this.autoRenderCheckBox.AutoSize = true;
            this.autoRenderCheckBox.Checked = true;
            this.autoRenderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoRenderCheckBox.Location = new System.Drawing.Point(9, 63);
            this.autoRenderCheckBox.Name = "autoRenderCheckBox";
            this.autoRenderCheckBox.Size = new System.Drawing.Size(107, 17);
            this.autoRenderCheckBox.TabIndex = 8;
            this.autoRenderCheckBox.Text = "Re-render frames";
            this.autoRenderCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.renderTimeLabel);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.fileNameLabel);
            this.groupBox3.Controls.Add(this.trisCountLabel);
            this.groupBox3.Location = new System.Drawing.Point(645, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 62);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model statistics";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(8, 16);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(70, 13);
            this.fileNameLabel.TabIndex = 1;
            this.fileNameLabel.Text = "File name: ----";
            // 
            // trisCountLabel
            // 
            this.trisCountLabel.AutoSize = true;
            this.trisCountLabel.Location = new System.Drawing.Point(8, 38);
            this.trisCountLabel.Name = "trisCountLabel";
            this.trisCountLabel.Size = new System.Drawing.Size(72, 13);
            this.trisCountLabel.TabIndex = 0;
            this.trisCountLabel.Text = "Tris count: ----";
            // 
            // wireframeWidthLabel
            // 
            this.wireframeWidthLabel.AutoSize = true;
            this.wireframeWidthLabel.Location = new System.Drawing.Point(8, 42);
            this.wireframeWidthLabel.Name = "wireframeWidthLabel";
            this.wireframeWidthLabel.Size = new System.Drawing.Size(83, 13);
            this.wireframeWidthLabel.TabIndex = 9;
            this.wireframeWidthLabel.Text = "Wireframe width";
            // 
            // penWidthNumericUpDown
            // 
            this.penWidthNumericUpDown.DecimalPlaces = 1;
            this.penWidthNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.penWidthNumericUpDown.Location = new System.Drawing.Point(97, 40);
            this.penWidthNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.penWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.penWidthNumericUpDown.Name = "penWidthNumericUpDown";
            this.penWidthNumericUpDown.Size = new System.Drawing.Size(82, 20);
            this.penWidthNumericUpDown.TabIndex = 10;
            this.penWidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.penWidthNumericUpDown.ValueChanged += new System.EventHandler(this.penWidthNumericUpDown_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(127, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Render time:";
            // 
            // renderTimeLabel
            // 
            this.renderTimeLabel.AutoSize = true;
            this.renderTimeLabel.Location = new System.Drawing.Point(144, 38);
            this.renderTimeLabel.Name = "renderTimeLabel";
            this.renderTimeLabel.Size = new System.Drawing.Size(33, 13);
            this.renderTimeLabel.TabIndex = 3;
            this.renderTimeLabel.Text = "N / A";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.TimerTick);
            // 
            // continuousRenderCheckBox
            // 
            this.continuousRenderCheckBox.AutoSize = true;
            this.continuousRenderCheckBox.Location = new System.Drawing.Point(9, 86);
            this.continuousRenderCheckBox.Name = "continuousRenderCheckBox";
            this.continuousRenderCheckBox.Size = new System.Drawing.Size(123, 17);
            this.continuousRenderCheckBox.TabIndex = 11;
            this.continuousRenderCheckBox.Text = "Render continuously";
            this.continuousRenderCheckBox.UseVisualStyleBackColor = true;
            this.continuousRenderCheckBox.CheckedChanged += new System.EventHandler(this.continuousRenderCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.renderButton);
            this.Controls.Add(this.listDatacheckBox);
            this.Controls.Add(this.loadStlButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Winforms renderer // Made by: @cyanroke";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penWidthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button loadStlButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox listDatacheckBox;
        private System.Windows.Forms.Button renderButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox wireframeCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox autoRenderCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label trisCountLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.NumericUpDown penWidthNumericUpDown;
        private System.Windows.Forms.Label wireframeWidthLabel;
        private System.Windows.Forms.Label renderTimeLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox continuousRenderCheckBox;
    }
}

