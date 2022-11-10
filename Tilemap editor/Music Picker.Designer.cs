namespace Tilemap_editor
{
    partial class Music_Picker
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
            this.numericUpDown_levelCode = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_musicPointer = new System.Windows.Forms.NumericUpDown();
            this.listBox_musicTracks = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_applySanity = new System.Windows.Forms.Button();
            this.radioButton_sanity = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_levelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_musicPointer)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_levelCode
            // 
            this.numericUpDown_levelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_levelCode.Hexadecimal = true;
            this.numericUpDown_levelCode.Location = new System.Drawing.Point(13, 28);
            this.numericUpDown_levelCode.Maximum = new decimal(new int[] {
            229,
            0,
            0,
            0});
            this.numericUpDown_levelCode.Name = "numericUpDown_levelCode";
            this.numericUpDown_levelCode.Size = new System.Drawing.Size(81, 29);
            this.numericUpDown_levelCode.TabIndex = 0;
            this.numericUpDown_levelCode.ValueChanged += new System.EventHandler(this.numericUpDown_levelCode_ValueChanged);
            // 
            // numericUpDown_musicPointer
            // 
            this.numericUpDown_musicPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_musicPointer.Hexadecimal = true;
            this.numericUpDown_musicPointer.Location = new System.Drawing.Point(12, 81);
            this.numericUpDown_musicPointer.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_musicPointer.Name = "numericUpDown_musicPointer";
            this.numericUpDown_musicPointer.Size = new System.Drawing.Size(81, 29);
            this.numericUpDown_musicPointer.TabIndex = 1;
            // 
            // listBox_musicTracks
            // 
            this.listBox_musicTracks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_musicTracks.FormattingEnabled = true;
            this.listBox_musicTracks.ItemHeight = 24;
            this.listBox_musicTracks.Location = new System.Drawing.Point(122, 12);
            this.listBox_musicTracks.Name = "listBox_musicTracks";
            this.listBox_musicTracks.Size = new System.Drawing.Size(277, 196);
            this.listBox_musicTracks.TabIndex = 2;
            this.listBox_musicTracks.SelectedIndexChanged += new System.EventHandler(this.listBox_musicTracks_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Apply";
            this.toolTip1.SetToolTip(this.button1, "Apply changes to the current code only");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Level Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pointer";
            // 
            // button_applySanity
            // 
            this.button_applySanity.Location = new System.Drawing.Point(13, 145);
            this.button_applySanity.Name = "button_applySanity";
            this.button_applySanity.Size = new System.Drawing.Size(75, 42);
            this.button_applySanity.TabIndex = 6;
            this.button_applySanity.Text = "Apply (Sanity)";
            this.toolTip1.SetToolTip(this.button_applySanity, "Apply from checkpoints and bonuses too\r\n(all related levels)");
            this.button_applySanity.UseVisualStyleBackColor = true;
            this.button_applySanity.Click += new System.EventHandler(this.button_applySanity_Click);
            // 
            // radioButton_sanity
            // 
            this.radioButton_sanity.AutoSize = true;
            this.radioButton_sanity.Location = new System.Drawing.Point(17, 193);
            this.radioButton_sanity.Name = "radioButton_sanity";
            this.radioButton_sanity.Size = new System.Drawing.Size(54, 17);
            this.radioButton_sanity.TabIndex = 7;
            this.radioButton_sanity.TabStop = true;
            this.radioButton_sanity.Text = "Sanity";
            this.radioButton_sanity.UseVisualStyleBackColor = true;
            // 
            // Music_Picker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 216);
            this.Controls.Add(this.radioButton_sanity);
            this.Controls.Add(this.button_applySanity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox_musicTracks);
            this.Controls.Add(this.numericUpDown_musicPointer);
            this.Controls.Add(this.numericUpDown_levelCode);
            this.Name = "Music_Picker";
            this.Text = "Music_Picker";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_levelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_musicPointer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_levelCode;
        private System.Windows.Forms.NumericUpDown numericUpDown_musicPointer;
        private System.Windows.Forms.ListBox listBox_musicTracks;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button_applySanity;
        private System.Windows.Forms.RadioButton radioButton_sanity;
    }
}