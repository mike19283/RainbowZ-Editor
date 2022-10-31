
namespace Tilemap_editor
{
    partial class Entrances
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
            this.listBox_entities = new System.Windows.Forms.ListBox();
            this.numericUpDown_entranceX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_entranceY = new System.Windows.Forms.NumericUpDown();
            this.button_apply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_address = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindCheckpointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bind11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entranceX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entranceY)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_entities
            // 
            this.listBox_entities.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_entities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_entities.FormattingEnabled = true;
            this.listBox_entities.ItemHeight = 20;
            this.listBox_entities.Location = new System.Drawing.Point(0, 24);
            this.listBox_entities.Name = "listBox_entities";
            this.listBox_entities.Size = new System.Drawing.Size(352, 426);
            this.listBox_entities.TabIndex = 0;
            this.listBox_entities.SelectedIndexChanged += new System.EventHandler(this.listBox_entities_SelectedIndexChanged);
            // 
            // numericUpDown_entranceX
            // 
            this.numericUpDown_entranceX.Hexadecimal = true;
            this.numericUpDown_entranceX.Location = new System.Drawing.Point(369, 77);
            this.numericUpDown_entranceX.Maximum = new decimal(new int[] {
            65836,
            0,
            0,
            0});
            this.numericUpDown_entranceX.Name = "numericUpDown_entranceX";
            this.numericUpDown_entranceX.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_entranceX.TabIndex = 1;
            // 
            // numericUpDown_entranceY
            // 
            this.numericUpDown_entranceY.Hexadecimal = true;
            this.numericUpDown_entranceY.Location = new System.Drawing.Point(369, 127);
            this.numericUpDown_entranceY.Maximum = new decimal(new int[] {
            65836,
            0,
            0,
            0});
            this.numericUpDown_entranceY.Name = "numericUpDown_entranceY";
            this.numericUpDown_entranceY.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_entranceY.TabIndex = 4;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(387, 176);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 5;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y";
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(389, 30);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(35, 13);
            this.label_address.TabIndex = 8;
            this.label_address.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Uses intuitive values\r\ne.g. (0,0) is bottom left";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(483, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindCheckpointsToolStripMenuItem,
            this.bind11ToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // bindCheckpointsToolStripMenuItem
            // 
            this.bindCheckpointsToolStripMenuItem.Name = "bindCheckpointsToolStripMenuItem";
            this.bindCheckpointsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bindCheckpointsToolStripMenuItem.Text = "Bind checkpoints";
            this.bindCheckpointsToolStripMenuItem.Click += new System.EventHandler(this.bindCheckpointsToolStripMenuItem_Click);
            // 
            // bind11ToolStripMenuItem
            // 
            this.bind11ToolStripMenuItem.Name = "bind11ToolStripMenuItem";
            this.bind11ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bind11ToolStripMenuItem.Text = "Bind 1-1";
            this.bind11ToolStripMenuItem.Click += new System.EventHandler(this.bind11ToolStripMenuItem_Click);
            // 
            // Entrances
            // 
            this.AcceptButton = this.button_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.numericUpDown_entranceY);
            this.Controls.Add(this.numericUpDown_entranceX);
            this.Controls.Add(this.listBox_entities);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(781, 50);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Entrances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EntranceEdit";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entranceX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entranceY)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_entities;
        private System.Windows.Forms.NumericUpDown numericUpDown_entranceX;
        private System.Windows.Forms.NumericUpDown numericUpDown_entranceY;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bindCheckpointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bind11ToolStripMenuItem;
    }
}