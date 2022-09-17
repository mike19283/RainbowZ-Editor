namespace Tilemap_editor
{
    partial class StageSections
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
            this.listBox_left = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_left = new System.Windows.Forms.Panel();
            this.pictureBox_left = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_right = new System.Windows.Forms.ListBox();
            this.panel_right = new System.Windows.Forms.Panel();
            this.pictureBox_right = new System.Windows.Forms.PictureBox();
            this.button_bothUp = new System.Windows.Forms.Button();
            this.button_bothDown = new System.Windows.Forms.Button();
            this.panel_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).BeginInit();
            this.panel_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_left
            // 
            this.listBox_left.FormattingEnabled = true;
            this.listBox_left.Location = new System.Drawing.Point(49, 46);
            this.listBox_left.Name = "listBox_left";
            this.listBox_left.Size = new System.Drawing.Size(120, 95);
            this.listBox_left.TabIndex = 0;
            this.listBox_left.SelectedIndexChanged += new System.EventHandler(this.listBox_left_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Left";
            // 
            // panel_left
            // 
            this.panel_left.AutoSize = true;
            this.panel_left.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_left.Controls.Add(this.pictureBox_left);
            this.panel_left.Location = new System.Drawing.Point(12, 147);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(259, 291);
            this.panel_left.TabIndex = 2;
            // 
            // pictureBox_left
            // 
            this.pictureBox_left.Location = new System.Drawing.Point(0, 32);
            this.pictureBox_left.Name = "pictureBox_left";
            this.pictureBox_left.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_left.TabIndex = 0;
            this.pictureBox_left.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Right";
            // 
            // listBox_right
            // 
            this.listBox_right.FormattingEnabled = true;
            this.listBox_right.Location = new System.Drawing.Point(343, 46);
            this.listBox_right.Name = "listBox_right";
            this.listBox_right.Size = new System.Drawing.Size(120, 95);
            this.listBox_right.TabIndex = 3;
            this.listBox_right.SelectedIndexChanged += new System.EventHandler(this.listBox_right_SelectedIndexChanged);
            // 
            // panel_right
            // 
            this.panel_right.AutoSize = true;
            this.panel_right.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_right.Controls.Add(this.pictureBox_right);
            this.panel_right.Location = new System.Drawing.Point(266, 144);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(259, 294);
            this.panel_right.TabIndex = 3;
            // 
            // pictureBox_right
            // 
            this.pictureBox_right.Location = new System.Drawing.Point(0, 35);
            this.pictureBox_right.Name = "pictureBox_right";
            this.pictureBox_right.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_right.TabIndex = 1;
            this.pictureBox_right.TabStop = false;
            // 
            // button_bothUp
            // 
            this.button_bothUp.Location = new System.Drawing.Point(236, 46);
            this.button_bothUp.Name = "button_bothUp";
            this.button_bothUp.Size = new System.Drawing.Size(75, 23);
            this.button_bothUp.TabIndex = 5;
            this.button_bothUp.Text = "Up";
            this.button_bothUp.UseVisualStyleBackColor = true;
            this.button_bothUp.Click += new System.EventHandler(this.button_bothUp_Click);
            // 
            // button_bothDown
            // 
            this.button_bothDown.Location = new System.Drawing.Point(236, 115);
            this.button_bothDown.Name = "button_bothDown";
            this.button_bothDown.Size = new System.Drawing.Size(75, 23);
            this.button_bothDown.TabIndex = 6;
            this.button_bothDown.Text = "Down";
            this.button_bothDown.UseVisualStyleBackColor = true;
            this.button_bothDown.Click += new System.EventHandler(this.button_bothDown_Click);
            // 
            // StageSections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 450);
            this.Controls.Add(this.button_bothDown);
            this.Controls.Add(this.button_bothUp);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_right);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_left);
            this.Name = "StageSections";
            this.Text = "StageSections";
            this.panel_left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).EndInit();
            this.panel_right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_left;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.PictureBox pictureBox_left;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_right;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.PictureBox pictureBox_right;
        private System.Windows.Forms.Button button_bothUp;
        private System.Windows.Forms.Button button_bothDown;
    }
}