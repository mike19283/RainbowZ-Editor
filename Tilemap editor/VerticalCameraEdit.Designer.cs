namespace Tilemap_editor
{
    partial class VerticalCameraEdit
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
            this.listBox_entities = new System.Windows.Forms.ListBox();
            this.numericUpDown_x = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_xSize = new System.Windows.Forms.NumericUpDown();
            this.button_write = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_ySize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox_type = new System.Windows.Forms.ListBox();
            this.numericUpDown_type = new System.Windows.Forms.NumericUpDown();
            this.button_apply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_xSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_type)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_entities
            // 
            this.listBox_entities.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_entities.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_entities.FormattingEnabled = true;
            this.listBox_entities.ItemHeight = 16;
            this.listBox_entities.Location = new System.Drawing.Point(0, 0);
            this.listBox_entities.Name = "listBox_entities";
            this.listBox_entities.Size = new System.Drawing.Size(471, 450);
            this.listBox_entities.TabIndex = 0;
            this.listBox_entities.SelectedIndexChanged += new System.EventHandler(this.listBox_entities_SelectedIndexChanged);
            // 
            // numericUpDown_x
            // 
            this.numericUpDown_x.Hexadecimal = true;
            this.numericUpDown_x.Location = new System.Drawing.Point(495, 37);
            this.numericUpDown_x.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_x.Name = "numericUpDown_x";
            this.numericUpDown_x.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_x.TabIndex = 1;
            // 
            // numericUpDown_y
            // 
            this.numericUpDown_y.Hexadecimal = true;
            this.numericUpDown_y.Location = new System.Drawing.Point(495, 141);
            this.numericUpDown_y.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_y.Name = "numericUpDown_y";
            this.numericUpDown_y.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_y.TabIndex = 3;
            // 
            // numericUpDown_xSize
            // 
            this.numericUpDown_xSize.Hexadecimal = true;
            this.numericUpDown_xSize.Location = new System.Drawing.Point(495, 87);
            this.numericUpDown_xSize.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_xSize.Name = "numericUpDown_xSize";
            this.numericUpDown_xSize.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_xSize.TabIndex = 4;
            // 
            // button_write
            // 
            this.button_write.Location = new System.Drawing.Point(517, 415);
            this.button_write.Name = "button_write";
            this.button_write.Size = new System.Drawing.Size(75, 23);
            this.button_write.TabIndex = 5;
            this.button_write.Text = "Write";
            this.button_write.UseVisualStyleBackColor = true;
            this.button_write.Click += new System.EventHandler(this.button_write_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "X End";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(536, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(524, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y End";
            // 
            // numericUpDown_ySize
            // 
            this.numericUpDown_ySize.Hexadecimal = true;
            this.numericUpDown_ySize.Location = new System.Drawing.Point(495, 186);
            this.numericUpDown_ySize.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_ySize.Name = "numericUpDown_ySize";
            this.numericUpDown_ySize.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_ySize.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Type";
            // 
            // listBox_type
            // 
            this.listBox_type.FormattingEnabled = true;
            this.listBox_type.Location = new System.Drawing.Point(477, 240);
            this.listBox_type.Name = "listBox_type";
            this.listBox_type.Size = new System.Drawing.Size(120, 95);
            this.listBox_type.TabIndex = 13;
            this.listBox_type.SelectedIndexChanged += new System.EventHandler(this.listBox_type_SelectedIndexChanged);
            // 
            // numericUpDown_type
            // 
            this.numericUpDown_type.Hexadecimal = true;
            this.numericUpDown_type.Location = new System.Drawing.Point(495, 341);
            this.numericUpDown_type.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_type.Name = "numericUpDown_type";
            this.numericUpDown_type.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_type.TabIndex = 14;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(513, 377);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 15;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // VerticalCameraEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 450);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.numericUpDown_type);
            this.Controls.Add(this.listBox_type);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_ySize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_write);
            this.Controls.Add(this.numericUpDown_xSize);
            this.Controls.Add(this.numericUpDown_y);
            this.Controls.Add(this.numericUpDown_x);
            this.Controls.Add(this.listBox_entities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(600, 50);
            this.Name = "VerticalCameraEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EntityEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VerticalCameraEdit_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_xSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_type)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_entities;
        private System.Windows.Forms.NumericUpDown numericUpDown_x;
        private System.Windows.Forms.NumericUpDown numericUpDown_y;
        private System.Windows.Forms.NumericUpDown numericUpDown_xSize;
        private System.Windows.Forms.Button button_write;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_ySize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox_type;
        private System.Windows.Forms.NumericUpDown numericUpDown_type;
        private System.Windows.Forms.Button button_apply;
    }
}