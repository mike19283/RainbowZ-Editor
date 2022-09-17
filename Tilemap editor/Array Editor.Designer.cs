namespace Tilemap_editor
{
    partial class Array_Editor
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
            this.listBox_addresses = new System.Windows.Forms.ListBox();
            this.button_change = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_array = new System.Windows.Forms.ListBox();
            this.numericUpDown_offset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_arraySize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_indexSize = new System.Windows.Forms.NumericUpDown();
            this.button_goto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox_array = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_indexedBy = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_arraySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_indexSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_indexedBy)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_addresses
            // 
            this.listBox_addresses.FormattingEnabled = true;
            this.listBox_addresses.Location = new System.Drawing.Point(653, 12);
            this.listBox_addresses.Name = "listBox_addresses";
            this.listBox_addresses.Size = new System.Drawing.Size(120, 173);
            this.listBox_addresses.TabIndex = 1;
            this.listBox_addresses.SelectedIndexChanged += new System.EventHandler(this.listBox_addresses_SelectedIndexChanged);
            // 
            // button_change
            // 
            this.button_change.Location = new System.Drawing.Point(579, 393);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(75, 23);
            this.button_change.TabIndex = 2;
            this.button_change.Text = "Change";
            this.button_change.UseVisualStyleBackColor = true;
            this.button_change.Click += new System.EventHandler(this.button_change_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(534, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Each index separated \r\nby a new line!";
            // 
            // listBox_array
            // 
            this.listBox_array.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_array.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_array.FormattingEnabled = true;
            this.listBox_array.ItemHeight = 24;
            this.listBox_array.Location = new System.Drawing.Point(-4, 3);
            this.listBox_array.Name = "listBox_array";
            this.listBox_array.Size = new System.Drawing.Size(651, 220);
            this.listBox_array.TabIndex = 4;
            this.listBox_array.SelectedIndexChanged += new System.EventHandler(this.listBox_array_SelectedIndexChanged);
            // 
            // numericUpDown_offset
            // 
            this.numericUpDown_offset.Hexadecimal = true;
            this.numericUpDown_offset.Location = new System.Drawing.Point(653, 215);
            this.numericUpDown_offset.Maximum = new decimal(new int[] {
            16777215,
            0,
            0,
            0});
            this.numericUpDown_offset.Name = "numericUpDown_offset";
            this.numericUpDown_offset.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_offset.TabIndex = 5;
            // 
            // numericUpDown_arraySize
            // 
            this.numericUpDown_arraySize.Hexadecimal = true;
            this.numericUpDown_arraySize.Location = new System.Drawing.Point(653, 256);
            this.numericUpDown_arraySize.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_arraySize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_arraySize.Name = "numericUpDown_arraySize";
            this.numericUpDown_arraySize.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_arraySize.TabIndex = 6;
            this.numericUpDown_arraySize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_indexSize
            // 
            this.numericUpDown_indexSize.Hexadecimal = true;
            this.numericUpDown_indexSize.Location = new System.Drawing.Point(653, 306);
            this.numericUpDown_indexSize.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_indexSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_indexSize.Name = "numericUpDown_indexSize";
            this.numericUpDown_indexSize.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_indexSize.TabIndex = 7;
            this.numericUpDown_indexSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_goto
            // 
            this.button_goto.Location = new System.Drawing.Point(688, 393);
            this.button_goto.Name = "button_goto";
            this.button_goto.Size = new System.Drawing.Size(75, 23);
            this.button_goto.TabIndex = 8;
            this.button_goto.Text = "Goto";
            this.button_goto.UseVisualStyleBackColor = true;
            this.button_goto.Click += new System.EventHandler(this.button_goto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(694, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Offset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(685, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Array Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(685, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Index size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "<- Low to High  ->";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(380, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "The game stores in small-endian format.\r\n";
            // 
            // richTextBox_array
            // 
            this.richTextBox_array.Location = new System.Drawing.Point(12, 257);
            this.richTextBox_array.Name = "richTextBox_array";
            this.richTextBox_array.Size = new System.Drawing.Size(561, 168);
            this.richTextBox_array.TabIndex = 17;
            this.richTextBox_array.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(667, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Indexed by (DKC1)";
            // 
            // numericUpDown_indexedBy
            // 
            this.numericUpDown_indexedBy.Hexadecimal = true;
            this.numericUpDown_indexedBy.Location = new System.Drawing.Point(653, 353);
            this.numericUpDown_indexedBy.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown_indexedBy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_indexedBy.Name = "numericUpDown_indexedBy";
            this.numericUpDown_indexedBy.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_indexedBy.TabIndex = 18;
            this.numericUpDown_indexedBy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Array_Editor
            // 
            this.AcceptButton = this.button_change;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown_indexedBy);
            this.Controls.Add(this.richTextBox_array);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_goto);
            this.Controls.Add(this.numericUpDown_indexSize);
            this.Controls.Add(this.numericUpDown_arraySize);
            this.Controls.Add(this.numericUpDown_offset);
            this.Controls.Add(this.listBox_array);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_change);
            this.Controls.Add(this.listBox_addresses);
            this.Name = "Array_Editor";
            this.Text = "Array_Editor";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_arraySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_indexSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_indexedBy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox_addresses;
        private System.Windows.Forms.Button button_change;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_array;
        private System.Windows.Forms.NumericUpDown numericUpDown_offset;
        private System.Windows.Forms.NumericUpDown numericUpDown_arraySize;
        private System.Windows.Forms.NumericUpDown numericUpDown_indexSize;
        private System.Windows.Forms.Button button_goto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox_array;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_indexedBy;
    }
}