namespace Tilemap_editor
{
    partial class CopyrightEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_preview = new System.Windows.Forms.PictureBox();
            this.textBox_nintendo = new System.Windows.Forms.TextBox();
            this.textBox_custom1 = new System.Windows.Forms.TextBox();
            this.button_apply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preview";
            // 
            // pictureBox_preview
            // 
            this.pictureBox_preview.Location = new System.Drawing.Point(213, 35);
            this.pictureBox_preview.Name = "pictureBox_preview";
            this.pictureBox_preview.Size = new System.Drawing.Size(256, 72);
            this.pictureBox_preview.TabIndex = 1;
            this.pictureBox_preview.TabStop = false;
            // 
            // textBox_nintendo
            // 
            this.textBox_nintendo.Location = new System.Drawing.Point(44, 29);
            this.textBox_nintendo.Name = "textBox_nintendo";
            this.textBox_nintendo.ReadOnly = true;
            this.textBox_nintendo.Size = new System.Drawing.Size(100, 20);
            this.textBox_nintendo.TabIndex = 5;
            this.textBox_nintendo.Text = "NINTENDO";
            // 
            // textBox_custom1
            // 
            this.textBox_custom1.Location = new System.Drawing.Point(44, 64);
            this.textBox_custom1.Multiline = true;
            this.textBox_custom1.Name = "textBox_custom1";
            this.textBox_custom1.Size = new System.Drawing.Size(100, 103);
            this.textBox_custom1.TabIndex = 1;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(213, 147);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 2;
            this.button_apply.Text = "Apply + write";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // CopyrightEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 179);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.textBox_custom1);
            this.Controls.Add(this.textBox_nintendo);
            this.Controls.Add(this.pictureBox_preview);
            this.Controls.Add(this.label1);
            this.Name = "CopyrightEdit";
            this.Text = "CopyrightEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CopyrightEdit_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_preview;
        private System.Windows.Forms.TextBox textBox_nintendo;
        private System.Windows.Forms.TextBox textBox_custom1;
        private System.Windows.Forms.Button button_apply;
    }
}