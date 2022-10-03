namespace Tilemap_editor
{
    partial class KongAttributes
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
            this.listBox_attribute = new System.Windows.Forms.ListBox();
            this.numericUpDown_attrValue = new System.Windows.Forms.NumericUpDown();
            this.button_apply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_attrValue)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_attribute
            // 
            this.listBox_attribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_attribute.FormattingEnabled = true;
            this.listBox_attribute.ItemHeight = 24;
            this.listBox_attribute.Items.AddRange(new object[] {
            "Kong base walk speed",
            "Kong base run speed",
            "Kong base stationary roll",
            "Kong base running roll",
            "Kong base swimming x right",
            "Kong base swimming x left",
            "Donkey takeoff speed",
            "Diddy takeoff speed",
            "Roll speed increase",
            "Max roll speed",
            "Rambi walk speed",
            "Rambi run speed",
            "Rambi takeoff speed",
            "Enguarde swimming x right",
            "Enguarde swimming x left",
            "Enguarde lunge speed",
            "Enguarde up speed",
            "Enguarde down speed",
            "Winky walk speed",
            "Winky run speed",
            "Winky takeoff speed",
            "Expresso walk speed",
            "Expresso run speed",
            "Expresso takeoff speed"});
            this.listBox_attribute.Location = new System.Drawing.Point(23, 12);
            this.listBox_attribute.Name = "listBox_attribute";
            this.listBox_attribute.Size = new System.Drawing.Size(404, 244);
            this.listBox_attribute.TabIndex = 0;
            this.listBox_attribute.SelectedIndexChanged += new System.EventHandler(this.listBox_attribute_SelectedIndexChanged);
            // 
            // numericUpDown_attrValue
            // 
            this.numericUpDown_attrValue.Hexadecimal = true;
            this.numericUpDown_attrValue.Location = new System.Drawing.Point(468, 81);
            this.numericUpDown_attrValue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_attrValue.Name = "numericUpDown_attrValue";
            this.numericUpDown_attrValue.Size = new System.Drawing.Size(77, 20);
            this.numericUpDown_attrValue.TabIndex = 1;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(468, 125);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 2;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "Changes various attributes.\r\nWARNING\r\nSetting too high could\r\nbreak the game! Ple" +
    "ase\r\nuse responsiibly!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Attribute Value";
            // 
            // KongAttributes
            // 
            this.AcceptButton = this.button_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 283);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.numericUpDown_attrValue);
            this.Controls.Add(this.listBox_attribute);
            this.Name = "KongAttributes";
            this.Text = "KongAttributes";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_attrValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_attribute;
        private System.Windows.Forms.NumericUpDown numericUpDown_attrValue;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}