using System;
using System.Windows.Forms;

namespace Tilemap_editor
{
    partial class Tile_display
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
            this.tabControl_modes = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.button_exportMapchip = new System.Windows.Forms.Button();
            this.checkBox_yFlip = new System.Windows.Forms.CheckBox();
            this.checkBox_xFlip = new System.Windows.Forms.CheckBox();
            this.panel_tiles = new System.Windows.Forms.Panel();
            this.pictureBox_tiles = new System.Windows.Forms.PictureBox();
            this.tabPage_trail = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.button_r = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_l = new System.Windows.Forms.Button();
            this.button_m = new System.Windows.Forms.Button();
            this.checkBox_yFlip1 = new System.Windows.Forms.CheckBox();
            this.checkBox_xFlip1 = new System.Windows.Forms.CheckBox();
            this.pictureBox_trail = new System.Windows.Forms.PictureBox();
            this.panel_customDraw = new System.Windows.Forms.Panel();
            this.pictureBox_tiles1 = new System.Windows.Forms.PictureBox();
            this.tabPage_stamp = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.button_mirrorY = new System.Windows.Forms.Button();
            this.button_mirrorX = new System.Windows.Forms.Button();
            this.button_stampClipboard = new System.Windows.Forms.Button();
            this.button_saveStamp = new System.Windows.Forms.Button();
            this.button_loadStamp = new System.Windows.Forms.Button();
            this.button_clearStamp = new System.Windows.Forms.Button();
            this.checkBox_yFlip2 = new System.Windows.Forms.CheckBox();
            this.checkBox_xFlip2 = new System.Windows.Forms.CheckBox();
            this.pictureBox_stamp = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_tiles2 = new System.Windows.Forms.PictureBox();
            this.tabPage_highlight = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_copyHistory = new System.Windows.Forms.ListBox();
            this.checkBox_highlightY = new System.Windows.Forms.CheckBox();
            this.checkBox_highlightX = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_yFlipPaste = new System.Windows.Forms.Button();
            this.button_xFlipPaste = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_cut = new System.Windows.Forms.Button();
            this.button_copy = new System.Windows.Forms.Button();
            this.radioButton_paste = new System.Windows.Forms.RadioButton();
            this.radioButton_highlight = new System.Windows.Forms.RadioButton();
            this.tabPage_autofill = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_autoRight = new System.Windows.Forms.RadioButton();
            this.radioButton_autoLeft = new System.Windows.Forms.RadioButton();
            this.radioButton_autoDown = new System.Windows.Forms.RadioButton();
            this.radioButton_autoUp = new System.Windows.Forms.RadioButton();
            this.button_getLinks = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_water = new System.Windows.Forms.TabPage();
            this.label_height_width = new System.Windows.Forms.Label();
            this.button_waterSet = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown_size = new System.Windows.Forms.NumericUpDown();
            this.timer_previewTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl_modes.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel_tiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tiles)).BeginInit();
            this.tabPage_trail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trail)).BeginInit();
            this.panel_customDraw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tiles1)).BeginInit();
            this.tabPage_stamp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stamp)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tiles2)).BeginInit();
            this.tabPage_highlight.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_autofill.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage_water.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_modes
            // 
            this.tabControl_modes.Controls.Add(this.tabPage1);
            this.tabControl_modes.Controls.Add(this.tabPage_trail);
            this.tabControl_modes.Controls.Add(this.tabPage_stamp);
            this.tabControl_modes.Controls.Add(this.tabPage_highlight);
            this.tabControl_modes.Controls.Add(this.tabPage_autofill);
            this.tabControl_modes.Controls.Add(this.tabPage_water);
            this.tabControl_modes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_modes.Location = new System.Drawing.Point(0, 0);
            this.tabControl_modes.Name = "tabControl_modes";
            this.tabControl_modes.SelectedIndex = 0;
            this.tabControl_modes.Size = new System.Drawing.Size(315, 496);
            this.tabControl_modes.TabIndex = 0;
            this.tabControl_modes.Click += new System.EventHandler(this.tabControl_modes_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.button_exportMapchip);
            this.tabPage1.Controls.Add(this.checkBox_yFlip);
            this.tabPage1.Controls.Add(this.checkBox_xFlip);
            this.tabPage1.Controls.Add(this.panel_tiles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(307, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Regular";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "Press Ctrl+Z to undo\r\nany tilemap changes";
            // 
            // button_exportMapchip
            // 
            this.button_exportMapchip.Location = new System.Drawing.Point(185, 8);
            this.button_exportMapchip.Name = "button_exportMapchip";
            this.button_exportMapchip.Size = new System.Drawing.Size(98, 23);
            this.button_exportMapchip.TabIndex = 6;
            this.button_exportMapchip.Text = "Export Mapchip";
            this.toolTip1.SetToolTip(this.button_exportMapchip, "For use with Platinum");
            this.button_exportMapchip.UseVisualStyleBackColor = true;
            this.button_exportMapchip.Click += new System.EventHandler(this.button_exportMapchip_Click);
            // 
            // checkBox_yFlip
            // 
            this.checkBox_yFlip.AutoSize = true;
            this.checkBox_yFlip.Location = new System.Drawing.Point(13, 31);
            this.checkBox_yFlip.Name = "checkBox_yFlip";
            this.checkBox_yFlip.Size = new System.Drawing.Size(52, 17);
            this.checkBox_yFlip.TabIndex = 5;
            this.checkBox_yFlip.Text = "Y Flip";
            this.checkBox_yFlip.UseVisualStyleBackColor = true;
            this.checkBox_yFlip.Click += new System.EventHandler(this.checkBox_yFlipAll_Click);
            // 
            // checkBox_xFlip
            // 
            this.checkBox_xFlip.AutoSize = true;
            this.checkBox_xFlip.Location = new System.Drawing.Point(13, 8);
            this.checkBox_xFlip.Name = "checkBox_xFlip";
            this.checkBox_xFlip.Size = new System.Drawing.Size(52, 17);
            this.checkBox_xFlip.TabIndex = 4;
            this.checkBox_xFlip.Text = "X Flip";
            this.checkBox_xFlip.UseVisualStyleBackColor = true;
            this.checkBox_xFlip.Click += new System.EventHandler(this.checkBox_xFlipAll_Click);
            // 
            // panel_tiles
            // 
            this.panel_tiles.AutoScroll = true;
            this.panel_tiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_tiles.Controls.Add(this.pictureBox_tiles);
            this.panel_tiles.Location = new System.Drawing.Point(13, 54);
            this.panel_tiles.Name = "panel_tiles";
            this.panel_tiles.Size = new System.Drawing.Size(280, 384);
            this.panel_tiles.TabIndex = 3;
            // 
            // pictureBox_tiles
            // 
            this.pictureBox_tiles.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_tiles.Location = new System.Drawing.Point(3, 0);
            this.pictureBox_tiles.Name = "pictureBox_tiles";
            this.pictureBox_tiles.Size = new System.Drawing.Size(256, 300);
            this.pictureBox_tiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_tiles.TabIndex = 0;
            this.pictureBox_tiles.TabStop = false;
            this.pictureBox_tiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_tiles_MouseClick);
            // 
            // tabPage_trail
            // 
            this.tabPage_trail.Controls.Add(this.label4);
            this.tabPage_trail.Controls.Add(this.button_r);
            this.tabPage_trail.Controls.Add(this.button_clear);
            this.tabPage_trail.Controls.Add(this.button_l);
            this.tabPage_trail.Controls.Add(this.button_m);
            this.tabPage_trail.Controls.Add(this.checkBox_yFlip1);
            this.tabPage_trail.Controls.Add(this.checkBox_xFlip1);
            this.tabPage_trail.Controls.Add(this.pictureBox_trail);
            this.tabPage_trail.Controls.Add(this.panel_customDraw);
            this.tabPage_trail.Location = new System.Drawing.Point(4, 22);
            this.tabPage_trail.Name = "tabPage_trail";
            this.tabPage_trail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_trail.Size = new System.Drawing.Size(307, 470);
            this.tabPage_trail.TabIndex = 1;
            this.tabPage_trail.Text = "Trail";
            this.tabPage_trail.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 26);
            this.label4.TabIndex = 13;
            this.label4.Text = "Select a pattern you want to repeat. Then, drag\r\nin the main window to place";
            // 
            // button_r
            // 
            this.button_r.Location = new System.Drawing.Point(190, 57);
            this.button_r.Name = "button_r";
            this.button_r.Size = new System.Drawing.Size(75, 23);
            this.button_r.TabIndex = 12;
            this.button_r.Text = "Right";
            this.button_r.UseVisualStyleBackColor = true;
            this.button_r.Click += new System.EventHandler(this.button_r_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(189, 140);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 11;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_l
            // 
            this.button_l.Location = new System.Drawing.Point(10, 57);
            this.button_l.Name = "button_l";
            this.button_l.Size = new System.Drawing.Size(75, 23);
            this.button_l.TabIndex = 9;
            this.button_l.Text = "Left";
            this.button_l.UseVisualStyleBackColor = true;
            this.button_l.Click += new System.EventHandler(this.button_left_Click);
            // 
            // button_m
            // 
            this.button_m.Location = new System.Drawing.Point(102, 57);
            this.button_m.Name = "button_m";
            this.button_m.Size = new System.Drawing.Size(75, 23);
            this.button_m.TabIndex = 8;
            this.button_m.Text = "Mid";
            this.button_m.UseVisualStyleBackColor = true;
            this.button_m.Click += new System.EventHandler(this.button_m_Click);
            // 
            // checkBox_yFlip1
            // 
            this.checkBox_yFlip1.AutoSize = true;
            this.checkBox_yFlip1.Location = new System.Drawing.Point(68, 167);
            this.checkBox_yFlip1.Name = "checkBox_yFlip1";
            this.checkBox_yFlip1.Size = new System.Drawing.Size(52, 17);
            this.checkBox_yFlip1.TabIndex = 7;
            this.checkBox_yFlip1.Text = "Y Flip";
            this.checkBox_yFlip1.UseVisualStyleBackColor = true;
            this.checkBox_yFlip1.Click += new System.EventHandler(this.checkBox_yFlipAll_Click);
            // 
            // checkBox_xFlip1
            // 
            this.checkBox_xFlip1.AutoSize = true;
            this.checkBox_xFlip1.Location = new System.Drawing.Point(10, 167);
            this.checkBox_xFlip1.Name = "checkBox_xFlip1";
            this.checkBox_xFlip1.Size = new System.Drawing.Size(52, 17);
            this.checkBox_xFlip1.TabIndex = 6;
            this.checkBox_xFlip1.Text = "X Flip";
            this.checkBox_xFlip1.UseVisualStyleBackColor = true;
            this.checkBox_xFlip1.Click += new System.EventHandler(this.checkBox_xFlipAll_Click);
            // 
            // pictureBox_trail
            // 
            this.pictureBox_trail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_trail.Location = new System.Drawing.Point(8, 102);
            this.pictureBox_trail.Name = "pictureBox_trail";
            this.pictureBox_trail.Size = new System.Drawing.Size(256, 32);
            this.pictureBox_trail.TabIndex = 1;
            this.pictureBox_trail.TabStop = false;
            // 
            // panel_customDraw
            // 
            this.panel_customDraw.AutoScroll = true;
            this.panel_customDraw.Controls.Add(this.pictureBox_tiles1);
            this.panel_customDraw.Location = new System.Drawing.Point(6, 188);
            this.panel_customDraw.Name = "panel_customDraw";
            this.panel_customDraw.Size = new System.Drawing.Size(295, 274);
            this.panel_customDraw.TabIndex = 0;
            // 
            // pictureBox_tiles1
            // 
            this.pictureBox_tiles1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_tiles1.Name = "pictureBox_tiles1";
            this.pictureBox_tiles1.Size = new System.Drawing.Size(256, 269);
            this.pictureBox_tiles1.TabIndex = 0;
            this.pictureBox_tiles1.TabStop = false;
            this.pictureBox_tiles1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_tiles1_MouseClick);
            // 
            // tabPage_stamp
            // 
            this.tabPage_stamp.Controls.Add(this.label6);
            this.tabPage_stamp.Controls.Add(this.button_mirrorY);
            this.tabPage_stamp.Controls.Add(this.button_mirrorX);
            this.tabPage_stamp.Controls.Add(this.button_stampClipboard);
            this.tabPage_stamp.Controls.Add(this.button_saveStamp);
            this.tabPage_stamp.Controls.Add(this.button_loadStamp);
            this.tabPage_stamp.Controls.Add(this.button_clearStamp);
            this.tabPage_stamp.Controls.Add(this.checkBox_yFlip2);
            this.tabPage_stamp.Controls.Add(this.checkBox_xFlip2);
            this.tabPage_stamp.Controls.Add(this.pictureBox_stamp);
            this.tabPage_stamp.Controls.Add(this.panel1);
            this.tabPage_stamp.Location = new System.Drawing.Point(4, 22);
            this.tabPage_stamp.Name = "tabPage_stamp";
            this.tabPage_stamp.Size = new System.Drawing.Size(307, 470);
            this.tabPage_stamp.TabIndex = 2;
            this.tabPage_stamp.Text = "Stamp";
            this.tabPage_stamp.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(292, 39);
            this.label6.TabIndex = 25;
            this.label6.Text = "Click a stamp spot, then click a tile and assemble your stamp\r\nLeft-click = Previ" +
    "ew stamp in that location\r\nRight-click = Place stamp";
            // 
            // button_mirrorY
            // 
            this.button_mirrorY.Location = new System.Drawing.Point(48, 126);
            this.button_mirrorY.Name = "button_mirrorY";
            this.button_mirrorY.Size = new System.Drawing.Size(35, 23);
            this.button_mirrorY.TabIndex = 24;
            this.button_mirrorY.Text = "Y";
            this.button_mirrorY.UseVisualStyleBackColor = true;
            this.button_mirrorY.Click += new System.EventHandler(this.button_mirrorY_Click);
            // 
            // button_mirrorX
            // 
            this.button_mirrorX.Location = new System.Drawing.Point(10, 126);
            this.button_mirrorX.Name = "button_mirrorX";
            this.button_mirrorX.Size = new System.Drawing.Size(35, 23);
            this.button_mirrorX.TabIndex = 23;
            this.button_mirrorX.Text = "X";
            this.button_mirrorX.UseVisualStyleBackColor = true;
            this.button_mirrorX.Click += new System.EventHandler(this.button_mirrorX_Click);
            // 
            // button_stampClipboard
            // 
            this.button_stampClipboard.Location = new System.Drawing.Point(10, 97);
            this.button_stampClipboard.Name = "button_stampClipboard";
            this.button_stampClipboard.Size = new System.Drawing.Size(75, 23);
            this.button_stampClipboard.TabIndex = 22;
            this.button_stampClipboard.Text = "Clipboard";
            this.button_stampClipboard.UseVisualStyleBackColor = true;
            this.button_stampClipboard.Click += new System.EventHandler(this.button_stampClipboard_Click);
            // 
            // button_saveStamp
            // 
            this.button_saveStamp.Location = new System.Drawing.Point(8, 39);
            this.button_saveStamp.Name = "button_saveStamp";
            this.button_saveStamp.Size = new System.Drawing.Size(75, 23);
            this.button_saveStamp.TabIndex = 21;
            this.button_saveStamp.Text = "Save Stamp";
            this.toolTip1.SetToolTip(this.button_saveStamp, "All stamps are saved beyond\r\nthe life of this program");
            this.button_saveStamp.UseVisualStyleBackColor = true;
            this.button_saveStamp.Click += new System.EventHandler(this.button_saveStamp_Click);
            // 
            // button_loadStamp
            // 
            this.button_loadStamp.Location = new System.Drawing.Point(10, 68);
            this.button_loadStamp.Name = "button_loadStamp";
            this.button_loadStamp.Size = new System.Drawing.Size(75, 23);
            this.button_loadStamp.TabIndex = 20;
            this.button_loadStamp.Text = "Load Stamp";
            this.button_loadStamp.UseVisualStyleBackColor = true;
            this.button_loadStamp.Click += new System.EventHandler(this.button_loadStamp_Click);
            // 
            // button_clearStamp
            // 
            this.button_clearStamp.Location = new System.Drawing.Point(10, 10);
            this.button_clearStamp.Name = "button_clearStamp";
            this.button_clearStamp.Size = new System.Drawing.Size(75, 23);
            this.button_clearStamp.TabIndex = 19;
            this.button_clearStamp.Text = "Clear";
            this.button_clearStamp.UseVisualStyleBackColor = true;
            this.button_clearStamp.Click += new System.EventHandler(this.button_clearStamp_Click);
            // 
            // checkBox_yFlip2
            // 
            this.checkBox_yFlip2.AutoSize = true;
            this.checkBox_yFlip2.Location = new System.Drawing.Point(68, 155);
            this.checkBox_yFlip2.Name = "checkBox_yFlip2";
            this.checkBox_yFlip2.Size = new System.Drawing.Size(52, 17);
            this.checkBox_yFlip2.TabIndex = 16;
            this.checkBox_yFlip2.Text = "Y Flip";
            this.checkBox_yFlip2.UseVisualStyleBackColor = true;
            this.checkBox_yFlip2.Click += new System.EventHandler(this.checkBox_yFlipAll_Click);
            // 
            // checkBox_xFlip2
            // 
            this.checkBox_xFlip2.AutoSize = true;
            this.checkBox_xFlip2.Location = new System.Drawing.Point(10, 155);
            this.checkBox_xFlip2.Name = "checkBox_xFlip2";
            this.checkBox_xFlip2.Size = new System.Drawing.Size(52, 17);
            this.checkBox_xFlip2.TabIndex = 15;
            this.checkBox_xFlip2.Text = "X Flip";
            this.checkBox_xFlip2.UseVisualStyleBackColor = true;
            this.checkBox_xFlip2.Click += new System.EventHandler(this.checkBox_xFlipAll_Click);
            // 
            // pictureBox_stamp
            // 
            this.pictureBox_stamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_stamp.Location = new System.Drawing.Point(126, 10);
            this.pictureBox_stamp.Name = "pictureBox_stamp";
            this.pictureBox_stamp.Size = new System.Drawing.Size(160, 160);
            this.pictureBox_stamp.TabIndex = 14;
            this.pictureBox_stamp.TabStop = false;
            this.pictureBox_stamp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_stamp_MouseClick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox_tiles2);
            this.panel1.Location = new System.Drawing.Point(6, 217);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 233);
            this.panel1.TabIndex = 13;
            // 
            // pictureBox_tiles2
            // 
            this.pictureBox_tiles2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_tiles2.Name = "pictureBox_tiles2";
            this.pictureBox_tiles2.Size = new System.Drawing.Size(256, 269);
            this.pictureBox_tiles2.TabIndex = 0;
            this.pictureBox_tiles2.TabStop = false;
            this.pictureBox_tiles2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_tiles2_MouseClick);
            // 
            // tabPage_highlight
            // 
            this.tabPage_highlight.Controls.Add(this.label8);
            this.tabPage_highlight.Controls.Add(this.label7);
            this.tabPage_highlight.Controls.Add(this.label2);
            this.tabPage_highlight.Controls.Add(this.listBox_copyHistory);
            this.tabPage_highlight.Controls.Add(this.checkBox_highlightY);
            this.tabPage_highlight.Controls.Add(this.checkBox_highlightX);
            this.tabPage_highlight.Controls.Add(this.groupBox1);
            this.tabPage_highlight.Location = new System.Drawing.Point(4, 22);
            this.tabPage_highlight.Name = "tabPage_highlight";
            this.tabPage_highlight.Size = new System.Drawing.Size(307, 470);
            this.tabPage_highlight.TabIndex = 3;
            this.tabPage_highlight.Text = "Highlight";
            this.tabPage_highlight.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 26);
            this.label8.TabIndex = 6;
            this.label8.Text = "Left-click = Preview paste in that location\r\nRight-click = Place paste";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Holds your past copies by index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "History:";
            // 
            // listBox_copyHistory
            // 
            this.listBox_copyHistory.FormattingEnabled = true;
            this.listBox_copyHistory.Location = new System.Drawing.Point(48, 332);
            this.listBox_copyHistory.Name = "listBox_copyHistory";
            this.listBox_copyHistory.Size = new System.Drawing.Size(203, 134);
            this.listBox_copyHistory.TabIndex = 3;
            this.listBox_copyHistory.SelectedIndexChanged += new System.EventHandler(this.listBox_copyHistory_SelectedIndexChanged);
            // 
            // checkBox_highlightY
            // 
            this.checkBox_highlightY.AutoSize = true;
            this.checkBox_highlightY.Enabled = false;
            this.checkBox_highlightY.Location = new System.Drawing.Point(269, 145);
            this.checkBox_highlightY.Name = "checkBox_highlightY";
            this.checkBox_highlightY.Size = new System.Drawing.Size(15, 14);
            this.checkBox_highlightY.TabIndex = 2;
            this.checkBox_highlightY.UseVisualStyleBackColor = true;
            // 
            // checkBox_highlightX
            // 
            this.checkBox_highlightX.AutoSize = true;
            this.checkBox_highlightX.Enabled = false;
            this.checkBox_highlightX.Location = new System.Drawing.Point(269, 90);
            this.checkBox_highlightX.Name = "checkBox_highlightX";
            this.checkBox_highlightX.Size = new System.Drawing.Size(15, 14);
            this.checkBox_highlightX.TabIndex = 1;
            this.checkBox_highlightX.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_yFlipPaste);
            this.groupBox1.Controls.Add(this.button_xFlipPaste);
            this.groupBox1.Controls.Add(this.button_delete);
            this.groupBox1.Controls.Add(this.button_cut);
            this.groupBox1.Controls.Add(this.button_copy);
            this.groupBox1.Controls.Add(this.radioButton_paste);
            this.groupBox1.Controls.Add(this.radioButton_highlight);
            this.groupBox1.Location = new System.Drawing.Point(51, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 231);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button_yFlipPaste
            // 
            this.button_yFlipPaste.Location = new System.Drawing.Point(155, 72);
            this.button_yFlipPaste.Name = "button_yFlipPaste";
            this.button_yFlipPaste.Size = new System.Drawing.Size(45, 23);
            this.button_yFlipPaste.TabIndex = 6;
            this.button_yFlipPaste.Text = "Y";
            this.button_yFlipPaste.UseVisualStyleBackColor = true;
            this.button_yFlipPaste.Click += new System.EventHandler(this.button_yFlipPaste_Click);
            // 
            // button_xFlipPaste
            // 
            this.button_xFlipPaste.Location = new System.Drawing.Point(155, 21);
            this.button_xFlipPaste.Name = "button_xFlipPaste";
            this.button_xFlipPaste.Size = new System.Drawing.Size(45, 23);
            this.button_xFlipPaste.TabIndex = 5;
            this.button_xFlipPaste.Text = "X";
            this.button_xFlipPaste.UseVisualStyleBackColor = true;
            this.button_xFlipPaste.Click += new System.EventHandler(this.button_xFlipPaste_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(51, 160);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 4;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_cut
            // 
            this.button_cut.Location = new System.Drawing.Point(51, 62);
            this.button_cut.Name = "button_cut";
            this.button_cut.Size = new System.Drawing.Size(75, 23);
            this.button_cut.TabIndex = 3;
            this.button_cut.Text = "Cut";
            this.button_cut.UseVisualStyleBackColor = true;
            this.button_cut.Click += new System.EventHandler(this.button_cut_Click);
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(51, 110);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(75, 23);
            this.button_copy.TabIndex = 2;
            this.button_copy.Text = "Copy";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // radioButton_paste
            // 
            this.radioButton_paste.AutoSize = true;
            this.radioButton_paste.Location = new System.Drawing.Point(51, 195);
            this.radioButton_paste.Name = "radioButton_paste";
            this.radioButton_paste.Size = new System.Drawing.Size(52, 17);
            this.radioButton_paste.TabIndex = 1;
            this.radioButton_paste.Text = "Paste";
            this.radioButton_paste.UseVisualStyleBackColor = true;
            this.radioButton_paste.CheckedChanged += new System.EventHandler(this.radioButton_paste_CheckedChanged);
            // 
            // radioButton_highlight
            // 
            this.radioButton_highlight.AutoSize = true;
            this.radioButton_highlight.Checked = true;
            this.radioButton_highlight.Location = new System.Drawing.Point(51, 25);
            this.radioButton_highlight.Name = "radioButton_highlight";
            this.radioButton_highlight.Size = new System.Drawing.Size(66, 17);
            this.radioButton_highlight.TabIndex = 0;
            this.radioButton_highlight.TabStop = true;
            this.radioButton_highlight.Text = "Highlight";
            this.radioButton_highlight.UseVisualStyleBackColor = true;
            this.radioButton_highlight.CheckedChanged += new System.EventHandler(this.radioButton_highlight_CheckedChanged);
            // 
            // tabPage_autofill
            // 
            this.tabPage_autofill.Controls.Add(this.label3);
            this.tabPage_autofill.Controls.Add(this.groupBox2);
            this.tabPage_autofill.Controls.Add(this.button_getLinks);
            this.tabPage_autofill.Controls.Add(this.label1);
            this.tabPage_autofill.Location = new System.Drawing.Point(4, 22);
            this.tabPage_autofill.Name = "tabPage_autofill";
            this.tabPage_autofill.Size = new System.Drawing.Size(307, 470);
            this.tabPage_autofill.TabIndex = 4;
            this.tabPage_autofill.Text = "Autofill";
            this.tabPage_autofill.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 52);
            this.label3.TabIndex = 5;
            this.label3.Text = "This is a beta feature. Some\r\nconnections are not right.\r\nThere are currently no " +
    "plans\r\nto update this feature\r\n";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_autoRight);
            this.groupBox2.Controls.Add(this.radioButton_autoLeft);
            this.groupBox2.Controls.Add(this.radioButton_autoDown);
            this.groupBox2.Controls.Add(this.radioButton_autoUp);
            this.groupBox2.Location = new System.Drawing.Point(43, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 156);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // radioButton_autoRight
            // 
            this.radioButton_autoRight.AutoSize = true;
            this.radioButton_autoRight.Location = new System.Drawing.Point(72, 133);
            this.radioButton_autoRight.Name = "radioButton_autoRight";
            this.radioButton_autoRight.Size = new System.Drawing.Size(50, 17);
            this.radioButton_autoRight.TabIndex = 3;
            this.radioButton_autoRight.Text = "Right";
            this.radioButton_autoRight.UseVisualStyleBackColor = true;
            this.radioButton_autoRight.Click += new System.EventHandler(this.RadioButtonPress);
            // 
            // radioButton_autoLeft
            // 
            this.radioButton_autoLeft.AutoSize = true;
            this.radioButton_autoLeft.Location = new System.Drawing.Point(72, 99);
            this.radioButton_autoLeft.Name = "radioButton_autoLeft";
            this.radioButton_autoLeft.Size = new System.Drawing.Size(43, 17);
            this.radioButton_autoLeft.TabIndex = 2;
            this.radioButton_autoLeft.Text = "Left";
            this.radioButton_autoLeft.UseVisualStyleBackColor = true;
            this.radioButton_autoLeft.Click += new System.EventHandler(this.RadioButtonPress);
            // 
            // radioButton_autoDown
            // 
            this.radioButton_autoDown.AutoSize = true;
            this.radioButton_autoDown.Location = new System.Drawing.Point(72, 54);
            this.radioButton_autoDown.Name = "radioButton_autoDown";
            this.radioButton_autoDown.Size = new System.Drawing.Size(53, 17);
            this.radioButton_autoDown.TabIndex = 1;
            this.radioButton_autoDown.Text = "Down";
            this.radioButton_autoDown.UseVisualStyleBackColor = true;
            this.radioButton_autoDown.Click += new System.EventHandler(this.RadioButtonPress);
            // 
            // radioButton_autoUp
            // 
            this.radioButton_autoUp.AutoSize = true;
            this.radioButton_autoUp.Checked = true;
            this.radioButton_autoUp.Location = new System.Drawing.Point(72, 20);
            this.radioButton_autoUp.Name = "radioButton_autoUp";
            this.radioButton_autoUp.Size = new System.Drawing.Size(39, 17);
            this.radioButton_autoUp.TabIndex = 0;
            this.radioButton_autoUp.TabStop = true;
            this.radioButton_autoUp.Text = "Up";
            this.radioButton_autoUp.UseVisualStyleBackColor = true;
            this.radioButton_autoUp.Click += new System.EventHandler(this.RadioButtonPress);
            // 
            // button_getLinks
            // 
            this.button_getLinks.Location = new System.Drawing.Point(104, 78);
            this.button_getLinks.Name = "button_getLinks";
            this.button_getLinks.Size = new System.Drawing.Size(75, 23);
            this.button_getLinks.TabIndex = 3;
            this.button_getLinks.Text = "Get links";
            this.button_getLinks.UseVisualStyleBackColor = true;
            this.button_getLinks.Click += new System.EventHandler(this.button_getLinks_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "WARNING! All links  are based off of \r\nwhat is seen in ROM, so if you have \r\na ti" +
    "le placed poorly, the program thinks \r\nit is ok to place more tiles like that.";
            // 
            // tabPage_water
            // 
            this.tabPage_water.Controls.Add(this.label10);
            this.tabPage_water.Controls.Add(this.label_height_width);
            this.tabPage_water.Controls.Add(this.button_waterSet);
            this.tabPage_water.Controls.Add(this.label9);
            this.tabPage_water.Controls.Add(this.numericUpDown_size);
            this.tabPage_water.Location = new System.Drawing.Point(4, 22);
            this.tabPage_water.Name = "tabPage_water";
            this.tabPage_water.Size = new System.Drawing.Size(307, 470);
            this.tabPage_water.TabIndex = 5;
            this.tabPage_water.Text = "Water";
            this.tabPage_water.UseVisualStyleBackColor = true;
            // 
            // label_height_width
            // 
            this.label_height_width.AutoSize = true;
            this.label_height_width.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_height_width.Location = new System.Drawing.Point(225, 114);
            this.label_height_width.Name = "label_height_width";
            this.label_height_width.Size = new System.Drawing.Size(20, 24);
            this.label_height_width.TabIndex = 3;
            this.label_height_width.Text = "0";
            // 
            // button_waterSet
            // 
            this.button_waterSet.Location = new System.Drawing.Point(200, 141);
            this.button_waterSet.Name = "button_waterSet";
            this.button_waterSet.Size = new System.Drawing.Size(75, 23);
            this.button_waterSet.TabIndex = 2;
            this.button_waterSet.Text = "Set";
            this.button_waterSet.UseVisualStyleBackColor = true;
            this.button_waterSet.Click += new System.EventHandler(this.button_waterSet_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Height/Width";
            // 
            // numericUpDown_size
            // 
            this.numericUpDown_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_size.Hexadecimal = true;
            this.numericUpDown_size.Location = new System.Drawing.Point(31, 135);
            this.numericUpDown_size.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_size.Name = "numericUpDown_size";
            this.numericUpDown_size.Size = new System.Drawing.Size(71, 29);
            this.numericUpDown_size.TabIndex = 0;
            this.numericUpDown_size.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // timer_previewTimer
            // 
            this.timer_previewTimer.Interval = 1000;
            this.timer_previewTimer.Tick += new System.EventHandler(this.timer_previewTimer_Tick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(246, 52);
            this.label10.TabIndex = 4;
            this.label10.Text = "This will auto draw a coral passageway for you\r\nbased on where you click and drag" +
    " your mouse.\r\nSetting the height/width changes the size of the\r\npassageway. This" +
    " is only available in water stages.\r\n";
            // 
            // Tile_display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 496);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl_modes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(954, 50);
            this.Name = "Tile_display";
            this.Opacity = 0.95D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tile_display";
            this.tabControl_modes.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel_tiles.ResumeLayout(false);
            this.panel_tiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tiles)).EndInit();
            this.tabPage_trail.ResumeLayout(false);
            this.tabPage_trail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_trail)).EndInit();
            this.panel_customDraw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tiles1)).EndInit();
            this.tabPage_stamp.ResumeLayout(false);
            this.tabPage_stamp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stamp)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tiles2)).EndInit();
            this.tabPage_highlight.ResumeLayout(false);
            this.tabPage_highlight.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage_autofill.ResumeLayout(false);
            this.tabPage_autofill.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage_water.ResumeLayout(false);
            this.tabPage_water.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl_modes;
        private TabPage tabPage1;
        private CheckBox checkBox_yFlip;
        private CheckBox checkBox_xFlip;
        private Panel panel_tiles;
        private PictureBox pictureBox_tiles;
        private TabPage tabPage_trail;
        private Panel panel_customDraw;
        private PictureBox pictureBox_tiles1;
        private CheckBox checkBox_yFlip1;
        private CheckBox checkBox_xFlip1;
        private PictureBox pictureBox_trail;
        private Button button_m;
        private Button button_clear;
        private Button button_l;
        private Button button_r;
        private TabPage tabPage_stamp;
        private Button button_clearStamp;
        private CheckBox checkBox_yFlip2;
        private CheckBox checkBox_xFlip2;
        private PictureBox pictureBox_stamp;
        private Panel panel1;
        private PictureBox pictureBox_tiles2;
        private TabPage tabPage_highlight;
        private GroupBox groupBox1;
        private Button button_copy;
        private RadioButton radioButton_paste;
        private RadioButton radioButton_highlight;
        private Button button_delete;
        private Button button_cut;
        private Button button_yFlipPaste;
        private Button button_xFlipPaste;
        private CheckBox checkBox_highlightY;
        private CheckBox checkBox_highlightX;
        private TabPage tabPage_autofill;
        private Label label1;
        private GroupBox groupBox2;
        private Button button_getLinks;
        private RadioButton radioButton_autoRight;
        private RadioButton radioButton_autoLeft;
        private RadioButton radioButton_autoDown;
        private RadioButton radioButton_autoUp;
        private Button button_saveStamp;
        private Button button_loadStamp;
        private Button button_stampClipboard;
        private Button button_mirrorY;
        private Button button_mirrorX;
        private Label label2;
        private ListBox listBox_copyHistory;
        private Timer timer_previewTimer;
        private Button button_exportMapchip;
        private Label label3;
        private Label label5;
        private ToolTip toolTip1;
        private Label label4;
        private Label label6;
        private Label label8;
        private Label label7;
        private TabPage tabPage_water;
        private NumericUpDown numericUpDown_size;
        private Label label9;
        private Label label_height_width;
        private Button button_waterSet;
        private Label label10;
    }
}