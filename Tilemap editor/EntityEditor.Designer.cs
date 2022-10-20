
namespace Tilemap_editor
{
    partial class EntityEditor
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
            this.listBox_initCodes = new System.Windows.Forms.ListBox();
            this.numericUpDown_key = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_value1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_value2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_value3 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.button_apply = new System.Windows.Forms.Button();
            this.numericUpDown_pointer = new System.Windows.Forms.NumericUpDown();
            this.button_search = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox_history = new System.Windows.Forms.ListBox();
            this.label_address = new System.Windows.Forms.Label();
            this.toolTip_hover = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_key)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_pointer)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_initCodes
            // 
            this.listBox_initCodes.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_initCodes.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_initCodes.FormattingEnabled = true;
            this.listBox_initCodes.ItemHeight = 21;
            this.listBox_initCodes.Location = new System.Drawing.Point(0, 0);
            this.listBox_initCodes.Name = "listBox_initCodes";
            this.listBox_initCodes.Size = new System.Drawing.Size(492, 520);
            this.listBox_initCodes.TabIndex = 0;
            this.listBox_initCodes.SelectedIndexChanged += new System.EventHandler(this.listBox_initCodes_SelectedIndexChanged);
            this.listBox_initCodes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_initCodes_MouseDoubleClick);
            this.listBox_initCodes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_initCodes_MouseDown);
            // 
            // numericUpDown_key
            // 
            this.numericUpDown_key.Hexadecimal = true;
            this.numericUpDown_key.Location = new System.Drawing.Point(510, 291);
            this.numericUpDown_key.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_key.Name = "numericUpDown_key";
            this.numericUpDown_key.Size = new System.Drawing.Size(140, 21);
            this.numericUpDown_key.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(552, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Value";
            // 
            // numericUpDown_value1
            // 
            this.numericUpDown_value1.Hexadecimal = true;
            this.numericUpDown_value1.Location = new System.Drawing.Point(510, 342);
            this.numericUpDown_value1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_value1.Name = "numericUpDown_value1";
            this.numericUpDown_value1.Size = new System.Drawing.Size(140, 21);
            this.numericUpDown_value1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Value";
            // 
            // numericUpDown_value2
            // 
            this.numericUpDown_value2.Hexadecimal = true;
            this.numericUpDown_value2.Location = new System.Drawing.Point(510, 393);
            this.numericUpDown_value2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_value2.Name = "numericUpDown_value2";
            this.numericUpDown_value2.Size = new System.Drawing.Size(140, 21);
            this.numericUpDown_value2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Value";
            // 
            // numericUpDown_value3
            // 
            this.numericUpDown_value3.Hexadecimal = true;
            this.numericUpDown_value3.Location = new System.Drawing.Point(510, 441);
            this.numericUpDown_value3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_value3.Name = "numericUpDown_value3";
            this.numericUpDown_value3.Size = new System.Drawing.Size(140, 21);
            this.numericUpDown_value3.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pointer";
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(525, 479);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(87, 27);
            this.button_apply.TabIndex = 10;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // numericUpDown_pointer
            // 
            this.numericUpDown_pointer.Hexadecimal = true;
            this.numericUpDown_pointer.Location = new System.Drawing.Point(510, 46);
            this.numericUpDown_pointer.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_pointer.Name = "numericUpDown_pointer";
            this.numericUpDown_pointer.Size = new System.Drawing.Size(140, 21);
            this.numericUpDown_pointer.TabIndex = 11;
            this.numericUpDown_pointer.Value = new decimal(new int[] {
            46099,
            0,
            0,
            0});
            this.numericUpDown_pointer.ValueChanged += new System.EventHandler(this.numericUpDown_pointer_ValueChanged);
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(525, 76);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(87, 27);
            this.button_search.TabIndex = 12;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(548, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "History";
            // 
            // listBox_history
            // 
            this.listBox_history.FormattingEnabled = true;
            this.listBox_history.ItemHeight = 15;
            this.listBox_history.Location = new System.Drawing.Point(510, 125);
            this.listBox_history.Name = "listBox_history";
            this.listBox_history.Size = new System.Drawing.Size(139, 139);
            this.listBox_history.TabIndex = 14;
            this.listBox_history.SelectedIndexChanged += new System.EventHandler(this.listBox_history_SelectedIndexChanged);
            this.listBox_history.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_history_MouseDoubleClick);
            this.listBox_history.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_history_MouseDown);
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(521, 26);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(63, 15);
            this.label_address.TabIndex = 15;
            this.label_address.Text = "Address:";
            // 
            // EntityEditor
            // 
            this.AcceptButton = this.button_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 520);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.listBox_history);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.numericUpDown_pointer);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_value3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_value2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_value1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_key);
            this.Controls.Add(this.listBox_initCodes);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(686, 50);
            this.MaximizeBox = false;
            this.Name = "EntityEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EntityEditor";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_key)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_pointer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_initCodes;
        private System.Windows.Forms.NumericUpDown numericUpDown_key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_value1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_value2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_value3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.NumericUpDown numericUpDown_pointer;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox_history;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.ToolTip toolTip_hover;
    }
}