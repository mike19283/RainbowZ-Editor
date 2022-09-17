namespace Tilemap_editor
{
    partial class Palette_HSLEdit
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
            this.trackBar_hue = new System.Windows.Forms.TrackBar();
            this.trackBar_luminance = new System.Windows.Forms.TrackBar();
            this.trackBar_saturation = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.button_confirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label_sa = new System.Windows.Forms.Label();
            this.label_hue = new System.Windows.Forms.Label();
            this.textBox_hue = new System.Windows.Forms.TextBox();
            this.textBox_saturation = new System.Windows.Forms.TextBox();
            this.textBox_luminance = new System.Windows.Forms.TextBox();
            this.label_luminance = new System.Windows.Forms.Label();
            this.label_saturation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_hue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_luminance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_saturation)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar_hue
            // 
            this.trackBar_hue.Location = new System.Drawing.Point(17, 44);
            this.trackBar_hue.Maximum = 360;
            this.trackBar_hue.Minimum = 1;
            this.trackBar_hue.Name = "trackBar_hue";
            this.trackBar_hue.Size = new System.Drawing.Size(646, 45);
            this.trackBar_hue.TabIndex = 2;
            this.trackBar_hue.TabStop = false;
            this.trackBar_hue.TickFrequency = 10;
            this.trackBar_hue.Value = 180;
            this.trackBar_hue.ValueChanged += new System.EventHandler(this.trackBarUpdateLabel);
            // 
            // trackBar_luminance
            // 
            this.trackBar_luminance.Location = new System.Drawing.Point(17, 190);
            this.trackBar_luminance.Maximum = 100;
            this.trackBar_luminance.Minimum = 1;
            this.trackBar_luminance.Name = "trackBar_luminance";
            this.trackBar_luminance.Size = new System.Drawing.Size(646, 45);
            this.trackBar_luminance.TabIndex = 1;
            this.trackBar_luminance.TabStop = false;
            this.trackBar_luminance.TickFrequency = 10;
            this.trackBar_luminance.Value = 50;
            this.trackBar_luminance.ValueChanged += new System.EventHandler(this.trackBarUpdateLabel);
            // 
            // trackBar_saturation
            // 
            this.trackBar_saturation.Location = new System.Drawing.Point(17, 123);
            this.trackBar_saturation.Maximum = 100;
            this.trackBar_saturation.Minimum = 1;
            this.trackBar_saturation.Name = "trackBar_saturation";
            this.trackBar_saturation.Size = new System.Drawing.Size(646, 45);
            this.trackBar_saturation.TabIndex = 2;
            this.trackBar_saturation.TabStop = false;
            this.trackBar_saturation.TickFrequency = 10;
            this.trackBar_saturation.Value = 50;
            this.trackBar_saturation.ValueChanged += new System.EventHandler(this.trackBarUpdateLabel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hue";
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(597, 226);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(75, 23);
            this.button_confirm.TabIndex = 4;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Luminance";
            // 
            // label_sa
            // 
            this.label_sa.AutoSize = true;
            this.label_sa.Location = new System.Drawing.Point(314, 102);
            this.label_sa.Name = "label_sa";
            this.label_sa.Size = new System.Drawing.Size(55, 13);
            this.label_sa.TabIndex = 6;
            this.label_sa.Text = "Saturation";
            // 
            // label_hue
            // 
            this.label_hue.AutoSize = true;
            this.label_hue.Location = new System.Drawing.Point(617, 29);
            this.label_hue.Name = "label_hue";
            this.label_hue.Size = new System.Drawing.Size(25, 13);
            this.label_hue.TabIndex = 7;
            this.label_hue.Text = "180";
            // 
            // textBox_hue
            // 
            this.textBox_hue.Location = new System.Drawing.Point(17, 22);
            this.textBox_hue.MaxLength = 3;
            this.textBox_hue.Name = "textBox_hue";
            this.textBox_hue.Size = new System.Drawing.Size(60, 20);
            this.textBox_hue.TabIndex = 1;
            this.textBox_hue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // textBox_saturation
            // 
            this.textBox_saturation.Location = new System.Drawing.Point(17, 95);
            this.textBox_saturation.MaxLength = 3;
            this.textBox_saturation.Name = "textBox_saturation";
            this.textBox_saturation.Size = new System.Drawing.Size(60, 20);
            this.textBox_saturation.TabIndex = 2;
            this.textBox_saturation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // textBox_luminance
            // 
            this.textBox_luminance.Location = new System.Drawing.Point(17, 164);
            this.textBox_luminance.MaxLength = 3;
            this.textBox_luminance.Name = "textBox_luminance";
            this.textBox_luminance.Size = new System.Drawing.Size(60, 20);
            this.textBox_luminance.TabIndex = 3;
            this.textBox_luminance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // label_luminance
            // 
            this.label_luminance.AutoSize = true;
            this.label_luminance.Location = new System.Drawing.Point(617, 164);
            this.label_luminance.Name = "label_luminance";
            this.label_luminance.Size = new System.Drawing.Size(19, 13);
            this.label_luminance.TabIndex = 10;
            this.label_luminance.Text = "50";
            // 
            // label_saturation
            // 
            this.label_saturation.AutoSize = true;
            this.label_saturation.Location = new System.Drawing.Point(617, 95);
            this.label_saturation.Name = "label_saturation";
            this.label_saturation.Size = new System.Drawing.Size(19, 13);
            this.label_saturation.TabIndex = 11;
            this.label_saturation.Text = "50";
            // 
            // Palette_HSLEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.label_saturation);
            this.Controls.Add(this.label_luminance);
            this.Controls.Add(this.textBox_luminance);
            this.Controls.Add(this.textBox_saturation);
            this.Controls.Add(this.textBox_hue);
            this.Controls.Add(this.label_hue);
            this.Controls.Add(this.label_sa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar_saturation);
            this.Controls.Add(this.trackBar_luminance);
            this.Controls.Add(this.trackBar_hue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Palette_HSLEdit";
            this.Text = "HSLEdit";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_hue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_luminance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_saturation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar_hue;
        private System.Windows.Forms.TrackBar trackBar_luminance;
        private System.Windows.Forms.TrackBar trackBar_saturation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_sa;
        private System.Windows.Forms.Label label_hue;
        private System.Windows.Forms.TextBox textBox_hue;
        private System.Windows.Forms.TextBox textBox_saturation;
        private System.Windows.Forms.TextBox textBox_luminance;
        private System.Windows.Forms.Label label_luminance;
        private System.Windows.Forms.Label label_saturation;
    }
}