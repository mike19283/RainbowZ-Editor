namespace Tilemap_editor
{
    partial class WorldTerminator
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
            this.listBox_world = new System.Windows.Forms.ListBox();
            this.listBox_levelNames = new System.Windows.Forms.ListBox();
            this.numericUpDown_levelCode = new System.Windows.Forms.NumericUpDown();
            this.button_apply = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_levelCode)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_world
            // 
            this.listBox_world.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_world.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_world.FormattingEnabled = true;
            this.listBox_world.ItemHeight = 24;
            this.listBox_world.Items.AddRange(new object[] {
            "World 1",
            "World 2",
            "World 3",
            "World 4",
            "World 5",
            "World 6"});
            this.listBox_world.Location = new System.Drawing.Point(-2, 2);
            this.listBox_world.Name = "listBox_world";
            this.listBox_world.Size = new System.Drawing.Size(120, 146);
            this.listBox_world.TabIndex = 0;
            this.listBox_world.SelectedIndexChanged += new System.EventHandler(this.listBox_world_SelectedIndexChanged);
            // 
            // listBox_levelNames
            // 
            this.listBox_levelNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_levelNames.FormattingEnabled = true;
            this.listBox_levelNames.ItemHeight = 20;
            this.listBox_levelNames.Location = new System.Drawing.Point(267, 2);
            this.listBox_levelNames.Name = "listBox_levelNames";
            this.listBox_levelNames.Size = new System.Drawing.Size(278, 144);
            this.listBox_levelNames.TabIndex = 1;
            this.toolTip1.SetToolTip(this.listBox_levelNames, "Only regular levels and bosses work");
            this.listBox_levelNames.SelectedIndexChanged += new System.EventHandler(this.listBox_levelNames_SelectedIndexChanged);
            // 
            // numericUpDown_levelCode
            // 
            this.numericUpDown_levelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_levelCode.Hexadecimal = true;
            this.numericUpDown_levelCode.Location = new System.Drawing.Point(162, 37);
            this.numericUpDown_levelCode.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_levelCode.Name = "numericUpDown_levelCode";
            this.numericUpDown_levelCode.Size = new System.Drawing.Size(69, 29);
            this.numericUpDown_levelCode.TabIndex = 2;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(156, 97);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 3;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // WorldTerminator
            // 
            this.AcceptButton = this.button_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 150);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.numericUpDown_levelCode);
            this.Controls.Add(this.listBox_levelNames);
            this.Controls.Add(this.listBox_world);
            this.Name = "WorldTerminator";
            this.Text = "WorldTerminator";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_levelCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_world;
        private System.Windows.Forms.ListBox listBox_levelNames;
        private System.Windows.Forms.NumericUpDown numericUpDown_levelCode;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}