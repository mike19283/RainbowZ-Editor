namespace Tilemap_editor
{
    partial class PathEdit
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
            this.listBox_entities = new System.Windows.Forms.ListBox();
            this.numericUpDown_X = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_speed = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Y = new System.Windows.Forms.NumericUpDown();
            this.button_apply = new System.Windows.Forms.Button();
            this.label_x = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_multiple = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_speed = new System.Windows.Forms.RadioButton();
            this.radioButton_y = new System.Windows.Forms.RadioButton();
            this.radioButton_x = new System.Windows.Forms.RadioButton();
            this.label_address = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_command = new System.Windows.Forms.NumericUpDown();
            this.button_add = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_moveUp = new System.Windows.Forms.Button();
            this.button_moveDown = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_command)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_entities
            // 
            this.listBox_entities.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_entities.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_entities.FormattingEnabled = true;
            this.listBox_entities.ItemHeight = 24;
            this.listBox_entities.Location = new System.Drawing.Point(0, 0);
            this.listBox_entities.Name = "listBox_entities";
            this.listBox_entities.Size = new System.Drawing.Size(330, 450);
            this.listBox_entities.TabIndex = 0;
            this.listBox_entities.SelectedIndexChanged += new System.EventHandler(this.listBox_entities_SelectedIndexChanged);
            // 
            // numericUpDown_X
            // 
            this.numericUpDown_X.Hexadecimal = true;
            this.numericUpDown_X.Location = new System.Drawing.Point(378, 71);
            this.numericUpDown_X.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_X.Name = "numericUpDown_X";
            this.numericUpDown_X.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_X.TabIndex = 1;
            // 
            // numericUpDown_speed
            // 
            this.numericUpDown_speed.Hexadecimal = true;
            this.numericUpDown_speed.Location = new System.Drawing.Point(378, 175);
            this.numericUpDown_speed.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_speed.Name = "numericUpDown_speed";
            this.numericUpDown_speed.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_speed.TabIndex = 3;
            // 
            // numericUpDown_Y
            // 
            this.numericUpDown_Y.Hexadecimal = true;
            this.numericUpDown_Y.Location = new System.Drawing.Point(378, 121);
            this.numericUpDown_Y.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_Y.Name = "numericUpDown_Y";
            this.numericUpDown_Y.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_Y.TabIndex = 4;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(396, 206);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 5;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Location = new System.Drawing.Point(413, 55);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(14, 13);
            this.label_x.TabIndex = 6;
            this.label_x.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Speed";
            // 
            // button_multiple
            // 
            this.button_multiple.Location = new System.Drawing.Point(378, 359);
            this.button_multiple.Name = "button_multiple";
            this.button_multiple.Size = new System.Drawing.Size(93, 23);
            this.button_multiple.TabIndex = 9;
            this.button_multiple.Text = "Set [Start, end)";
            this.toolTip1.SetToolTip(this.button_multiple, "Set the attribute chosen above\r\nover multiple indices");
            this.button_multiple.UseVisualStyleBackColor = true;
            this.button_multiple.Click += new System.EventHandler(this.button_multiple_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_speed);
            this.groupBox1.Controls.Add(this.radioButton_y);
            this.groupBox1.Controls.Add(this.radioButton_x);
            this.groupBox1.Location = new System.Drawing.Point(336, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 126);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Multiple";
            // 
            // radioButton_speed
            // 
            this.radioButton_speed.AutoSize = true;
            this.radioButton_speed.Location = new System.Drawing.Point(42, 103);
            this.radioButton_speed.Name = "radioButton_speed";
            this.radioButton_speed.Size = new System.Drawing.Size(56, 17);
            this.radioButton_speed.TabIndex = 2;
            this.radioButton_speed.TabStop = true;
            this.radioButton_speed.Text = "Speed";
            this.radioButton_speed.UseVisualStyleBackColor = true;
            // 
            // radioButton_y
            // 
            this.radioButton_y.AutoSize = true;
            this.radioButton_y.Location = new System.Drawing.Point(42, 60);
            this.radioButton_y.Name = "radioButton_y";
            this.radioButton_y.Size = new System.Drawing.Size(32, 17);
            this.radioButton_y.TabIndex = 1;
            this.radioButton_y.TabStop = true;
            this.radioButton_y.Text = "Y";
            this.radioButton_y.UseVisualStyleBackColor = true;
            // 
            // radioButton_x
            // 
            this.radioButton_x.AutoSize = true;
            this.radioButton_x.Checked = true;
            this.radioButton_x.Location = new System.Drawing.Point(42, 19);
            this.radioButton_x.Name = "radioButton_x";
            this.radioButton_x.Size = new System.Drawing.Size(32, 17);
            this.radioButton_x.TabIndex = 0;
            this.radioButton_x.TabStop = true;
            this.radioButton_x.Text = "X";
            this.radioButton_x.UseVisualStyleBackColor = true;
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(348, 0);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(35, 13);
            this.label_address.TabIndex = 11;
            this.label_address.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Command";
            // 
            // numericUpDown_command
            // 
            this.numericUpDown_command.Hexadecimal = true;
            this.numericUpDown_command.Location = new System.Drawing.Point(378, 32);
            this.numericUpDown_command.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_command.Name = "numericUpDown_command";
            this.numericUpDown_command.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_command.TabIndex = 12;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(378, 404);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(23, 23);
            this.button_add.TabIndex = 14;
            this.button_add.Text = "A";
            this.toolTip1.SetToolTip(this.button_add, "Add track index");
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(436, 404);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(23, 23);
            this.button_delete.TabIndex = 15;
            this.button_delete.Text = "D";
            this.toolTip1.SetToolTip(this.button_delete, "Delete track index");
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_moveUp
            // 
            this.button_moveUp.Location = new System.Drawing.Point(336, 359);
            this.button_moveUp.Name = "button_moveUp";
            this.button_moveUp.Size = new System.Drawing.Size(23, 23);
            this.button_moveUp.TabIndex = 16;
            this.button_moveUp.Text = "^";
            this.toolTip1.SetToolTip(this.button_moveUp, "Move index up 1");
            this.button_moveUp.UseVisualStyleBackColor = true;
            this.button_moveUp.Click += new System.EventHandler(this.button_moveUp_Click);
            // 
            // button_moveDown
            // 
            this.button_moveDown.Location = new System.Drawing.Point(336, 404);
            this.button_moveDown.Name = "button_moveDown";
            this.button_moveDown.Size = new System.Drawing.Size(23, 23);
            this.button_moveDown.TabIndex = 17;
            this.button_moveDown.Text = "V";
            this.toolTip1.SetToolTip(this.button_moveDown, "Move index down 1");
            this.button_moveDown.UseVisualStyleBackColor = true;
            this.button_moveDown.Click += new System.EventHandler(this.button_moveDown_Click);
            // 
            // PathEdit
            // 
            this.AcceptButton = this.button_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 450);
            this.Controls.Add(this.button_moveDown);
            this.Controls.Add(this.button_moveUp);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_command);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_multiple);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_x);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.numericUpDown_Y);
            this.Controls.Add(this.numericUpDown_speed);
            this.Controls.Add(this.numericUpDown_X);
            this.Controls.Add(this.listBox_entities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(781, 50);
            this.Name = "PathEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EntityEdit";
            this.Load += new System.EventHandler(this.PathEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_command)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_entities;
        private System.Windows.Forms.NumericUpDown numericUpDown_X;
        private System.Windows.Forms.NumericUpDown numericUpDown_speed;
        private System.Windows.Forms.NumericUpDown numericUpDown_Y;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_multiple;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_speed;
        private System.Windows.Forms.RadioButton radioButton_y;
        private System.Windows.Forms.RadioButton radioButton_x;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_command;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_moveUp;
        private System.Windows.Forms.Button button_moveDown;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}