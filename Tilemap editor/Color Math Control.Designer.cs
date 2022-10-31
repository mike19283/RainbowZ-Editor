namespace Tilemap_editor
{
    partial class Color_Math_Control
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Color_Math_Control));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_2131 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_2132 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_levelCode = new System.Windows.Forms.NumericUpDown();
            this.label_ = new System.Windows.Forms.Label();
            this.button_load = new System.Windows.Forms.Button();
            this.numericUpDown_r = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_g = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_b = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_applySanity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_2131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_2132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_levelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_g)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_b)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(272, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(489, 282);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "2131";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Combined Intensity";
            // 
            // numericUpDown_2131
            // 
            this.numericUpDown_2131.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_2131.Hexadecimal = true;
            this.numericUpDown_2131.Location = new System.Drawing.Point(38, 77);
            this.numericUpDown_2131.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_2131.Name = "numericUpDown_2131";
            this.numericUpDown_2131.Size = new System.Drawing.Size(73, 29);
            this.numericUpDown_2131.TabIndex = 3;
            // 
            // numericUpDown_2132
            // 
            this.numericUpDown_2132.Enabled = false;
            this.numericUpDown_2132.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_2132.Hexadecimal = true;
            this.numericUpDown_2132.Location = new System.Drawing.Point(156, 77);
            this.numericUpDown_2132.Maximum = new decimal(new int[] {
            65635,
            0,
            0,
            0});
            this.numericUpDown_2132.Name = "numericUpDown_2132";
            this.numericUpDown_2132.Size = new System.Drawing.Size(73, 29);
            this.numericUpDown_2132.TabIndex = 4;
            // 
            // numericUpDown_levelCode
            // 
            this.numericUpDown_levelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_levelCode.Hexadecimal = true;
            this.numericUpDown_levelCode.Location = new System.Drawing.Point(38, 25);
            this.numericUpDown_levelCode.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_levelCode.Name = "numericUpDown_levelCode";
            this.numericUpDown_levelCode.Size = new System.Drawing.Size(73, 29);
            this.numericUpDown_levelCode.TabIndex = 6;
            // 
            // label_
            // 
            this.label_.AutoSize = true;
            this.label_.Location = new System.Drawing.Point(35, 3);
            this.label_.Name = "label_";
            this.label_.Size = new System.Drawing.Size(61, 13);
            this.label_.TabIndex = 5;
            this.label_.Text = "Level Code";
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(156, 25);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(73, 23);
            this.button_load.TabIndex = 7;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // numericUpDown_r
            // 
            this.numericUpDown_r.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_r.Hexadecimal = true;
            this.numericUpDown_r.Location = new System.Drawing.Point(156, 147);
            this.numericUpDown_r.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDown_r.Name = "numericUpDown_r";
            this.numericUpDown_r.Size = new System.Drawing.Size(73, 29);
            this.numericUpDown_r.TabIndex = 9;
            this.numericUpDown_r.ValueChanged += new System.EventHandler(this.numericUpDown_IntensityValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "R";
            // 
            // numericUpDown_g
            // 
            this.numericUpDown_g.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_g.Hexadecimal = true;
            this.numericUpDown_g.Location = new System.Drawing.Point(156, 193);
            this.numericUpDown_g.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDown_g.Name = "numericUpDown_g";
            this.numericUpDown_g.Size = new System.Drawing.Size(73, 29);
            this.numericUpDown_g.TabIndex = 11;
            this.numericUpDown_g.ValueChanged += new System.EventHandler(this.numericUpDown_IntensityValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "G";
            // 
            // numericUpDown_b
            // 
            this.numericUpDown_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_b.Hexadecimal = true;
            this.numericUpDown_b.Location = new System.Drawing.Point(156, 248);
            this.numericUpDown_b.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDown_b.Name = "numericUpDown_b";
            this.numericUpDown_b.Size = new System.Drawing.Size(73, 29);
            this.numericUpDown_b.TabIndex = 13;
            this.numericUpDown_b.ValueChanged += new System.EventHandler(this.numericUpDown_IntensityValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "B";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Intensity by Color";
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(36, 150);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 27);
            this.button_apply.TabIndex = 15;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_applySanity
            // 
            this.button_applySanity.Location = new System.Drawing.Point(36, 218);
            this.button_applySanity.Name = "button_applySanity";
            this.button_applySanity.Size = new System.Drawing.Size(75, 23);
            this.button_applySanity.TabIndex = 16;
            this.button_applySanity.Text = "Apply Sanity";
            this.button_applySanity.UseVisualStyleBackColor = true;
            this.button_applySanity.Click += new System.EventHandler(this.button_applySanity_Click);
            // 
            // Color_Math_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 282);
            this.Controls.Add(this.button_applySanity);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown_b);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown_g);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_r);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.numericUpDown_levelCode);
            this.Controls.Add(this.label_);
            this.Controls.Add(this.numericUpDown_2132);
            this.Controls.Add(this.numericUpDown_2131);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Color_Math_Control";
            this.Text = "Color_Math_Control";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_2131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_2132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_levelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_g)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_b)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_2131;
        private System.Windows.Forms.NumericUpDown numericUpDown_2132;
        private System.Windows.Forms.NumericUpDown numericUpDown_levelCode;
        private System.Windows.Forms.Label label_;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.NumericUpDown numericUpDown_r;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_g;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_b;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_applySanity;
    }
}