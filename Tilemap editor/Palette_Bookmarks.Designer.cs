namespace Tilemap_editor
{
    partial class Palette_Bookmarks
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
            this.listBox_bookmarks = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_bookmarks
            // 
            this.listBox_bookmarks.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_bookmarks.FormattingEnabled = true;
            this.listBox_bookmarks.Location = new System.Drawing.Point(0, 0);
            this.listBox_bookmarks.Name = "listBox_bookmarks";
            this.listBox_bookmarks.Size = new System.Drawing.Size(491, 450);
            this.listBox_bookmarks.TabIndex = 0;
            this.listBox_bookmarks.DoubleClick += new System.EventHandler(this.button1_Click);
            this.listBox_bookmarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_bookmarks_KeyDown);
            this.listBox_bookmarks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_bookmarks_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bookmarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox_bookmarks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Bookmarks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bookmarks";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_bookmarks;
        private System.Windows.Forms.Button button1;
    }
}