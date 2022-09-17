namespace Tilemap_editor
{
    partial class HexEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HexEditor));
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.vScrollBar_hexedit = new System.Windows.Forms.VScrollBar();
            this.textBox_bytes = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_address
            // 
            this.textBox_address.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox_address.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_address.Location = new System.Drawing.Point(0, 24);
            this.textBox_address.Multiline = true;
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.ReadOnly = true;
            this.textBox_address.Size = new System.Drawing.Size(143, 426);
            this.textBox_address.TabIndex = 0;
            this.textBox_address.Text = "wwwwww";
            // 
            // vScrollBar_hexedit
            // 
            this.vScrollBar_hexedit.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar_hexedit.Location = new System.Drawing.Point(783, 24);
            this.vScrollBar_hexedit.Name = "vScrollBar_hexedit";
            this.vScrollBar_hexedit.Size = new System.Drawing.Size(17, 426);
            this.vScrollBar_hexedit.TabIndex = 1;
            this.vScrollBar_hexedit.Value = 1;
            this.vScrollBar_hexedit.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_hexedit_Scroll);
            this.vScrollBar_hexedit.ValueChanged += new System.EventHandler(this.vScrollBar_hexedit_ValueChanged);
            // 
            // textBox_bytes
            // 
            this.textBox_bytes.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox_bytes.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_bytes.Location = new System.Drawing.Point(143, 24);
            this.textBox_bytes.Multiline = true;
            this.textBox_bytes.Name = "textBox_bytes";
            this.textBox_bytes.Size = new System.Drawing.Size(504, 426);
            this.textBox_bytes.TabIndex = 2;
            this.textBox_bytes.Text = resources.GetString("textBox_bytes.Text");
            this.textBox_bytes.WordWrap = false;
            this.textBox_bytes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_bytes_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // gotoToolStripMenuItem
            // 
            this.gotoToolStripMenuItem.Name = "gotoToolStripMenuItem";
            this.gotoToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.gotoToolStripMenuItem.Text = "Goto";
            this.gotoToolStripMenuItem.Click += new System.EventHandler(this.gotoToolStripMenuItem_Click);
            // 
            // HexEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_bytes);
            this.Controls.Add(this.vScrollBar_hexedit);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HexEditor";
            this.Text = "HexEditor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.VScrollBar vScrollBar_hexedit;
        private System.Windows.Forms.TextBox textBox_bytes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoToolStripMenuItem;
    }
}