namespace Tilemap_editor
{
    partial class Palette_Editor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importbmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportbmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_workZone = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button_AddToBookmarks = new System.Windows.Forms.Button();
            this.button_modifyAll = new System.Windows.Forms.Button();
            this.label_write = new System.Windows.Forms.Label();
            this.button_write = new System.Windows.Forms.Button();
            this.pictureBox_palette = new System.Windows.Forms.PictureBox();
            this.textBox_offset = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_palette = new System.Windows.Forms.Button();
            this.comboBox_palStyle = new System.Windows.Forms.ComboBox();
            this.textBox_columns = new System.Windows.Forms.TextBox();
            this.textBox_rows = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_written = new System.Windows.Forms.Timer(this.components);
            this.timer_saveAs = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer_hsl = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel_workZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_palette)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.bookmarksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importbmpToolStripMenuItem,
            this.exportbmpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importbmpToolStripMenuItem
            // 
            this.importbmpToolStripMenuItem.Enabled = false;
            this.importbmpToolStripMenuItem.Name = "importbmpToolStripMenuItem";
            this.importbmpToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.importbmpToolStripMenuItem.Text = "Import (.bmp)";
            this.importbmpToolStripMenuItem.Click += new System.EventHandler(this.importbmpToolStripMenuItem_Click);
            // 
            // exportbmpToolStripMenuItem
            // 
            this.exportbmpToolStripMenuItem.Enabled = false;
            this.exportbmpToolStripMenuItem.Name = "exportbmpToolStripMenuItem";
            this.exportbmpToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exportbmpToolStripMenuItem.Text = "Export (.bmp)";
            this.exportbmpToolStripMenuItem.Click += new System.EventHandler(this.exportbmpToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // bookmarksToolStripMenuItem
            // 
            this.bookmarksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bFToolStripMenuItem,
            this.objectsToolStripMenuItem,
            this.customToolStripMenuItem});
            this.bookmarksToolStripMenuItem.Name = "bookmarksToolStripMenuItem";
            this.bookmarksToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.bookmarksToolStripMenuItem.Text = "Bookmarks";
            // 
            // bFToolStripMenuItem
            // 
            this.bFToolStripMenuItem.Name = "bFToolStripMenuItem";
            this.bFToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.bFToolStripMenuItem.Text = "BG";
            this.bFToolStripMenuItem.Click += new System.EventHandler(this.bFToolStripMenuItem_Click);
            // 
            // objectsToolStripMenuItem
            // 
            this.objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
            this.objectsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.objectsToolStripMenuItem.Text = "Objects";
            this.objectsToolStripMenuItem.Click += new System.EventHandler(this.objectsToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.customToolStripMenuItem.Text = "Custom";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // panel_workZone
            // 
            this.panel_workZone.Controls.Add(this.label4);
            this.panel_workZone.Controls.Add(this.button_AddToBookmarks);
            this.panel_workZone.Controls.Add(this.button_modifyAll);
            this.panel_workZone.Controls.Add(this.label_write);
            this.panel_workZone.Controls.Add(this.button_write);
            this.panel_workZone.Controls.Add(this.pictureBox_palette);
            this.panel_workZone.Controls.Add(this.textBox_offset);
            this.panel_workZone.Controls.Add(this.label3);
            this.panel_workZone.Controls.Add(this.button_palette);
            this.panel_workZone.Controls.Add(this.comboBox_palStyle);
            this.panel_workZone.Controls.Add(this.textBox_columns);
            this.panel_workZone.Controls.Add(this.textBox_rows);
            this.panel_workZone.Controls.Add(this.label2);
            this.panel_workZone.Controls.Add(this.label1);
            this.panel_workZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_workZone.Location = new System.Drawing.Point(0, 24);
            this.panel_workZone.Name = "panel_workZone";
            this.panel_workZone.Size = new System.Drawing.Size(800, 353);
            this.panel_workZone.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Palette Size/Shape";
            this.toolTip1.SetToolTip(this.label4, "Select from dropdown if unsure");
            // 
            // button_AddToBookmarks
            // 
            this.button_AddToBookmarks.Enabled = false;
            this.button_AddToBookmarks.Location = new System.Drawing.Point(65, 311);
            this.button_AddToBookmarks.Name = "button_AddToBookmarks";
            this.button_AddToBookmarks.Size = new System.Drawing.Size(198, 23);
            this.button_AddToBookmarks.TabIndex = 11;
            this.button_AddToBookmarks.TabStop = false;
            this.button_AddToBookmarks.Text = "Add to bookmarks";
            this.toolTip1.SetToolTip(this.button_AddToBookmarks, "Save the offset for future use");
            this.button_AddToBookmarks.UseVisualStyleBackColor = true;
            this.button_AddToBookmarks.Click += new System.EventHandler(this.button_AddToBookmarks_Click);
            // 
            // button_modifyAll
            // 
            this.button_modifyAll.Enabled = false;
            this.button_modifyAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modifyAll.Location = new System.Drawing.Point(667, 14);
            this.button_modifyAll.Name = "button_modifyAll";
            this.button_modifyAll.Size = new System.Drawing.Size(121, 79);
            this.button_modifyAll.TabIndex = 10;
            this.button_modifyAll.TabStop = false;
            this.button_modifyAll.Text = "Modify\r\nAll";
            this.toolTip1.SetToolTip(this.button_modifyAll, "Change the whole palette at once");
            this.button_modifyAll.UseVisualStyleBackColor = true;
            this.button_modifyAll.Click += new System.EventHandler(this.button_modifyAll_Click);
            // 
            // label_write
            // 
            this.label_write.AutoSize = true;
            this.label_write.Location = new System.Drawing.Point(704, 283);
            this.label_write.Name = "label_write";
            this.label_write.Size = new System.Drawing.Size(44, 13);
            this.label_write.TabIndex = 9;
            this.label_write.Text = "Written!";
            this.label_write.Visible = false;
            // 
            // button_write
            // 
            this.button_write.Enabled = false;
            this.button_write.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_write.Location = new System.Drawing.Point(667, 299);
            this.button_write.Name = "button_write";
            this.button_write.Size = new System.Drawing.Size(121, 35);
            this.button_write.TabIndex = 8;
            this.button_write.TabStop = false;
            this.button_write.Text = "Write";
            this.toolTip1.SetToolTip(this.button_write, "Apply all changes to ROM");
            this.button_write.UseVisualStyleBackColor = true;
            this.button_write.Click += new System.EventHandler(this.button_write_Click);
            // 
            // pictureBox_palette
            // 
            this.pictureBox_palette.Location = new System.Drawing.Point(320, 14);
            this.pictureBox_palette.Name = "pictureBox_palette";
            this.pictureBox_palette.Size = new System.Drawing.Size(320, 320);
            this.pictureBox_palette.TabIndex = 7;
            this.pictureBox_palette.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox_palette, "Click on a color to modify");
            this.pictureBox_palette.Click += new System.EventHandler(this.PictureBoxClickAction);
            // 
            // textBox_offset
            // 
            this.textBox_offset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_offset.Location = new System.Drawing.Point(65, 214);
            this.textBox_offset.MaxLength = 6;
            this.textBox_offset.Name = "textBox_offset";
            this.textBox_offset.Size = new System.Drawing.Size(198, 29);
            this.textBox_offset.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBox_offset, "0 - 0x3ffffe");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Palette Address (Offset)";
            // 
            // button_palette
            // 
            this.button_palette.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_palette.Location = new System.Drawing.Point(65, 247);
            this.button_palette.Name = "button_palette";
            this.button_palette.Size = new System.Drawing.Size(198, 33);
            this.button_palette.TabIndex = 5;
            this.button_palette.Text = "Get Palette";
            this.toolTip1.SetToolTip(this.button_palette, "Load palette of size row * columns at the given address");
            this.button_palette.UseVisualStyleBackColor = true;
            this.button_palette.Click += new System.EventHandler(this.button_palette_Click);
            // 
            // comboBox_palStyle
            // 
            this.comboBox_palStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_palStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_palStyle.FormattingEnabled = true;
            this.comboBox_palStyle.Items.AddRange(new object[] {
            "Object",
            "BG",
            "Custom"});
            this.comboBox_palStyle.Location = new System.Drawing.Point(65, 73);
            this.comboBox_palStyle.Name = "comboBox_palStyle";
            this.comboBox_palStyle.Size = new System.Drawing.Size(198, 32);
            this.comboBox_palStyle.TabIndex = 5;
            this.comboBox_palStyle.TabStop = false;
            this.toolTip1.SetToolTip(this.comboBox_palStyle, "Select if you are unsure");
            this.comboBox_palStyle.SelectedIndexChanged += new System.EventHandler(this.comboBox_palStyle_SelectedIndexChanged);
            // 
            // textBox_columns
            // 
            this.textBox_columns.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_columns.Location = new System.Drawing.Point(182, 144);
            this.textBox_columns.MaxLength = 3;
            this.textBox_columns.Name = "textBox_columns";
            this.textBox_columns.Size = new System.Drawing.Size(81, 29);
            this.textBox_columns.TabIndex = 3;
            this.textBox_columns.Text = "15";
            this.toolTip1.SetToolTip(this.textBox_columns, "1 - 16");
            this.textBox_columns.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox_columns.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // textBox_rows
            // 
            this.textBox_rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_rows.Location = new System.Drawing.Point(65, 144);
            this.textBox_rows.MaxLength = 2;
            this.textBox_rows.Name = "textBox_rows";
            this.textBox_rows.Size = new System.Drawing.Size(53, 29);
            this.textBox_rows.TabIndex = 2;
            this.textBox_rows.Text = "1";
            this.toolTip1.SetToolTip(this.textBox_rows, "1 - 16");
            this.textBox_rows.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox_rows.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rows";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Columns";
            // 
            // timer_written
            // 
            this.timer_written.Enabled = true;
            this.timer_written.Tick += new System.EventHandler(this.timer_written_Tick);
            // 
            // timer_saveAs
            // 
            this.timer_saveAs.Tick += new System.EventHandler(this.timer_saveAs_Tick);
            // 
            // timer_hsl
            // 
            this.timer_hsl.Tick += new System.EventHandler(this.timer_hsl_Tick);
            // 
            // Palette_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 377);
            this.Controls.Add(this.panel_workZone);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Palette_Editor";
            this.Text = "Palette_Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Palette_Editor_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_workZone.ResumeLayout(false);
            this.panel_workZone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_palette)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel_workZone;
        private System.Windows.Forms.ComboBox comboBox_palStyle;
        private System.Windows.Forms.TextBox textBox_columns;
        private System.Windows.Forms.TextBox textBox_rows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem bookmarksToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_offset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_palette;
        private System.Windows.Forms.PictureBox pictureBox_palette;
        private System.Windows.Forms.Button button_write;
        private System.Windows.Forms.Label label_write;
        private System.Windows.Forms.Timer timer_written;
        private System.Windows.Forms.ToolStripMenuItem importbmpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportbmpToolStripMenuItem;
        private System.Windows.Forms.Button button_modifyAll;
        private System.Windows.Forms.Timer timer_saveAs;
        private System.Windows.Forms.Button button_AddToBookmarks;
        private System.Windows.Forms.ToolStripMenuItem bFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer_hsl;
    }
}

