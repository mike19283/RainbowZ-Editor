namespace Tilemap_editor
{
    partial class Custom_Percent
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
            this.listBox_levelNames = new System.Windows.Forms.ListBox();
            this.numericUpDown_value = new System.Windows.Forms.NumericUpDown();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_zeroAndApply = new System.Windows.Forms.Button();
            this.button_zeroAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_levelNames
            // 
            this.listBox_levelNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_levelNames.FormattingEnabled = true;
            this.listBox_levelNames.ItemHeight = 24;
            this.listBox_levelNames.Location = new System.Drawing.Point(-2, 22);
            this.listBox_levelNames.Name = "listBox_levelNames";
            this.listBox_levelNames.Size = new System.Drawing.Size(376, 196);
            this.listBox_levelNames.TabIndex = 0;
            this.listBox_levelNames.SelectedIndexChanged += new System.EventHandler(this.listBox_levelNames_SelectedIndexChanged);
            // 
            // numericUpDown_value
            // 
            this.numericUpDown_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_value.Hexadecimal = true;
            this.numericUpDown_value.Location = new System.Drawing.Point(391, 62);
            this.numericUpDown_value.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_value.Name = "numericUpDown_value";
            this.numericUpDown_value.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown_value.TabIndex = 1;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(404, 116);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 2;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_zeroAndApply
            // 
            this.button_zeroAndApply.Location = new System.Drawing.Point(391, 145);
            this.button_zeroAndApply.Name = "button_zeroAndApply";
            this.button_zeroAndApply.Size = new System.Drawing.Size(100, 23);
            this.button_zeroAndApply.TabIndex = 3;
            this.button_zeroAndApply.Text = "Zero And Apply";
            this.button_zeroAndApply.UseVisualStyleBackColor = true;
            this.button_zeroAndApply.Click += new System.EventHandler(this.button_zeroAndApply_Click);
            // 
            // button_zeroAll
            // 
            this.button_zeroAll.Location = new System.Drawing.Point(391, 184);
            this.button_zeroAll.Name = "button_zeroAll";
            this.button_zeroAll.Size = new System.Drawing.Size(100, 23);
            this.button_zeroAll.TabIndex = 4;
            this.button_zeroAll.Text = "Zero All";
            this.button_zeroAll.UseVisualStyleBackColor = true;
            this.button_zeroAll.Click += new System.EventHandler(this.button_zeroAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(401, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Secrets";
            // 
            // Custom_Percent
            // 
            this.AcceptButton = this.button_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 229);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_zeroAll);
            this.Controls.Add(this.button_zeroAndApply);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.numericUpDown_value);
            this.Controls.Add(this.listBox_levelNames);
            this.Name = "Custom_Percent";
            this.Text = "Custom_Percent";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_levelNames;
        private System.Windows.Forms.NumericUpDown numericUpDown_value;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_zeroAndApply;
        private System.Windows.Forms.Button button_zeroAll;
        private System.Windows.Forms.Label label1;
    }
}