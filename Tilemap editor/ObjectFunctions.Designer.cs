namespace Tilemap_editor
{
    partial class ObjectFunctions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectFunctions));
            this.panel_main = new System.Windows.Forms.Panel();
            this.button_copy = new System.Windows.Forms.Button();
            this.listBox_functions = new System.Windows.Forms.ListBox();
            this.button_getAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_get = new System.Windows.Forms.Button();
            this.numericUpDown_d45 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_d45)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.label2);
            this.panel_main.Controls.Add(this.button_copy);
            this.panel_main.Controls.Add(this.listBox_functions);
            this.panel_main.Controls.Add(this.button_getAll);
            this.panel_main.Controls.Add(this.label1);
            this.panel_main.Controls.Add(this.button_get);
            this.panel_main.Controls.Add(this.numericUpDown_d45);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(488, 425);
            this.panel_main.TabIndex = 1;
            this.panel_main.Visible = false;
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(41, 305);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(75, 23);
            this.button_copy.TabIndex = 6;
            this.button_copy.Text = "Copy";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // listBox_functions
            // 
            this.listBox_functions.FormattingEnabled = true;
            this.listBox_functions.Location = new System.Drawing.Point(179, 0);
            this.listBox_functions.Name = "listBox_functions";
            this.listBox_functions.Size = new System.Drawing.Size(308, 407);
            this.listBox_functions.TabIndex = 5;
            this.listBox_functions.Click += new System.EventHandler(this.listBox_functions_MouseClick);
            this.listBox_functions.SelectedIndexChanged += new System.EventHandler(this.listBox_functions_SelectedIndexChanged);
            // 
            // button_getAll
            // 
            this.button_getAll.Location = new System.Drawing.Point(41, 106);
            this.button_getAll.Name = "button_getAll";
            this.button_getAll.Size = new System.Drawing.Size(75, 23);
            this.button_getAll.TabIndex = 4;
            this.button_getAll.Text = "Get all";
            this.button_getAll.UseVisualStyleBackColor = true;
            this.button_getAll.Click += new System.EventHandler(this.button_getAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "D45";
            // 
            // button_get
            // 
            this.button_get.Location = new System.Drawing.Point(41, 65);
            this.button_get.Name = "button_get";
            this.button_get.Size = new System.Drawing.Size(75, 23);
            this.button_get.TabIndex = 1;
            this.button_get.Text = "Get";
            this.button_get.UseVisualStyleBackColor = true;
            this.button_get.Click += new System.EventHandler(this.button_get_Click);
            // 
            // numericUpDown_d45
            // 
            this.numericUpDown_d45.Hexadecimal = true;
            this.numericUpDown_d45.Location = new System.Drawing.Point(41, 39);
            this.numericUpDown_d45.Name = "numericUpDown_d45";
            this.numericUpDown_d45.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown_d45.TabIndex = 0;
            this.numericUpDown_d45.ValueChanged += new System.EventHandler(this.numericUpDown_d45_ValueChanged);
            this.numericUpDown_d45.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_d45_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 78);
            this.label2.TabIndex = 7;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // ObjectFunctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 425);
            this.Controls.Add(this.panel_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ObjectFunctions";
            this.Text = "Object Function Starts";
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_d45)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Button button_get;
        private System.Windows.Forms.NumericUpDown numericUpDown_d45;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_getAll;
        private System.Windows.Forms.ListBox listBox_functions;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Label label2;
    }
}