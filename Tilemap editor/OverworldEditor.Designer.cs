namespace Tilemap_editor
{
    partial class OverworldEditor
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
            this.pictureBox_mapPreview = new System.Windows.Forms.PictureBox();
            this.listBox_levels = new System.Windows.Forms.ListBox();
            this.numericUpDown_level = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_x = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_z = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_y = new System.Windows.Forms.NumericUpDown();
            this.button_loadImage = new System.Windows.Forms.Button();
            this.comboBox_overworld = new System.Windows.Forms.ComboBox();
            this.button_apply = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_stage = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown_dUp = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown_dDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown_dLeft = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown_dRight = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dRight)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_mapPreview
            // 
            this.pictureBox_mapPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_mapPreview.Location = new System.Drawing.Point(12, 25);
            this.pictureBox_mapPreview.Name = "pictureBox_mapPreview";
            this.pictureBox_mapPreview.Size = new System.Drawing.Size(256, 224);
            this.pictureBox_mapPreview.TabIndex = 0;
            this.pictureBox_mapPreview.TabStop = false;
            // 
            // listBox_levels
            // 
            this.listBox_levels.FormattingEnabled = true;
            this.listBox_levels.Location = new System.Drawing.Point(295, 25);
            this.listBox_levels.Name = "listBox_levels";
            this.listBox_levels.Size = new System.Drawing.Size(199, 225);
            this.listBox_levels.TabIndex = 1;
            this.listBox_levels.SelectedIndexChanged += new System.EventHandler(this.listBox_heads_SelectedIndexChanged);
            // 
            // numericUpDown_level
            // 
            this.numericUpDown_level.Enabled = false;
            this.numericUpDown_level.Hexadecimal = true;
            this.numericUpDown_level.Location = new System.Drawing.Point(537, 56);
            this.numericUpDown_level.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown_level.Name = "numericUpDown_level";
            this.numericUpDown_level.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_level.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(644, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Level X";
            // 
            // numericUpDown_x
            // 
            this.numericUpDown_x.Hexadecimal = true;
            this.numericUpDown_x.Location = new System.Drawing.Point(537, 108);
            this.numericUpDown_x.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_x.Name = "numericUpDown_x";
            this.numericUpDown_x.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown_x.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Level Z";
            // 
            // numericUpDown_z
            // 
            this.numericUpDown_z.Enabled = false;
            this.numericUpDown_z.Hexadecimal = true;
            this.numericUpDown_z.Location = new System.Drawing.Point(537, 212);
            this.numericUpDown_z.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_z.Name = "numericUpDown_z";
            this.numericUpDown_z.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown_z.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Level Y";
            // 
            // numericUpDown_y
            // 
            this.numericUpDown_y.Hexadecimal = true;
            this.numericUpDown_y.Location = new System.Drawing.Point(537, 158);
            this.numericUpDown_y.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_y.Name = "numericUpDown_y";
            this.numericUpDown_y.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown_y.TabIndex = 6;
            // 
            // button_loadImage
            // 
            this.button_loadImage.Location = new System.Drawing.Point(419, 256);
            this.button_loadImage.Name = "button_loadImage";
            this.button_loadImage.Size = new System.Drawing.Size(75, 23);
            this.button_loadImage.TabIndex = 11;
            this.button_loadImage.Text = "Load Image";
            this.button_loadImage.UseVisualStyleBackColor = true;
            this.button_loadImage.Click += new System.EventHandler(this.button_loadImage_Click);
            // 
            // comboBox_overworld
            // 
            this.comboBox_overworld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_overworld.FormattingEnabled = true;
            this.comboBox_overworld.Items.AddRange(new object[] {
            "Main Overworld",
            "W1.1",
            "W1.2",
            "W2.1",
            "W2.2",
            "W4.1",
            "W4.2",
            "W5.1",
            "W5.2",
            "W6.1",
            "W6.2",
            "W3.1",
            "W3.2"});
            this.comboBox_overworld.Location = new System.Drawing.Point(12, 256);
            this.comboBox_overworld.Name = "comboBox_overworld";
            this.comboBox_overworld.Size = new System.Drawing.Size(284, 21);
            this.comboBox_overworld.TabIndex = 12;
            // 
            // button_apply
            // 
            this.button_apply.Enabled = false;
            this.button_apply.Location = new System.Drawing.Point(526, 251);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 13;
            this.button_apply.Text = "Apply";
            this.toolTip1.SetToolTip(this.button_apply, "Clicking changes your ROM, whether you made changes or not!");
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // label_stage
            // 
            this.label_stage.AutoSize = true;
            this.label_stage.Location = new System.Drawing.Point(534, 25);
            this.label_stage.Name = "label_stage";
            this.label_stage.Size = new System.Drawing.Size(0, 13);
            this.label_stage.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(621, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Direction";
            // 
            // numericUpDown_dUp
            // 
            this.numericUpDown_dUp.Hexadecimal = true;
            this.numericUpDown_dUp.Location = new System.Drawing.Point(617, 108);
            this.numericUpDown_dUp.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_dUp.Name = "numericUpDown_dUp";
            this.numericUpDown_dUp.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown_dUp.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(636, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Up";
            // 
            // numericUpDown_dDown
            // 
            this.numericUpDown_dDown.Hexadecimal = true;
            this.numericUpDown_dDown.Location = new System.Drawing.Point(617, 158);
            this.numericUpDown_dDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_dDown.Name = "numericUpDown_dDown";
            this.numericUpDown_dDown.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown_dDown.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(629, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Down";
            // 
            // numericUpDown_dLeft
            // 
            this.numericUpDown_dLeft.Hexadecimal = true;
            this.numericUpDown_dLeft.Location = new System.Drawing.Point(617, 212);
            this.numericUpDown_dLeft.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_dLeft.Name = "numericUpDown_dLeft";
            this.numericUpDown_dLeft.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown_dLeft.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(632, 196);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Left";
            // 
            // numericUpDown_dRight
            // 
            this.numericUpDown_dRight.Hexadecimal = true;
            this.numericUpDown_dRight.Location = new System.Drawing.Point(617, 254);
            this.numericUpDown_dRight.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_dRight.Name = "numericUpDown_dRight";
            this.numericUpDown_dRight.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown_dRight.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(625, 238);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Right";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(264, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Currently, only offers the ability to ochange coordinates";
            // 
            // OverworldEditor
            // 
            this.AcceptButton = this.button_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 286);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown_dRight);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.numericUpDown_dLeft);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numericUpDown_dDown);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDown_dUp);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label_stage);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.comboBox_overworld);
            this.Controls.Add(this.button_loadImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_z);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_y);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_x);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_level);
            this.Controls.Add(this.listBox_levels);
            this.Controls.Add(this.pictureBox_mapPreview);
            this.Name = "OverworldEditor";
            this.Text = "OverworldEditor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_mapPreview;
        private System.Windows.Forms.ListBox listBox_levels;
        private System.Windows.Forms.NumericUpDown numericUpDown_level;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_x;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_z;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_y;
        private System.Windows.Forms.Button button_loadImage;
        private System.Windows.Forms.ComboBox comboBox_overworld;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_stage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown_dUp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDown_dDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDown_dLeft;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDown_dRight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
    }
}