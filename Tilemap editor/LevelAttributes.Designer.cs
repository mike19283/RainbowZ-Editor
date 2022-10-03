namespace Tilemap_editor
{
    partial class LevelAttributes
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
            this.button_apply = new System.Windows.Forms.Button();
            this.label_attr = new System.Windows.Forms.Label();
            this.listBox_level = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_address = new System.Windows.Forms.Label();
            this.button_applyToAll = new System.Windows.Forms.Button();
            this.button_applyAllGlobal = new System.Windows.Forms.Button();
            this.button_allXOR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_levelCode = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button_load = new System.Windows.Forms.Button();
            this.button_applySanity = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_levelCode)).BeginInit();
            this.SuspendLayout();
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(158, 183);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 0;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // label_attr
            // 
            this.label_attr.AutoSize = true;
            this.label_attr.Location = new System.Drawing.Point(13, 180);
            this.label_attr.Name = "label_attr";
            this.label_attr.Size = new System.Drawing.Size(0, 13);
            this.label_attr.TabIndex = 1;
            // 
            // listBox_level
            // 
            this.listBox_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_level.FormattingEnabled = true;
            this.listBox_level.ItemHeight = 16;
            this.listBox_level.Location = new System.Drawing.Point(322, 7);
            this.listBox_level.Name = "listBox_level";
            this.listBox_level.Size = new System.Drawing.Size(369, 196);
            this.listBox_level.TabIndex = 2;
            this.listBox_level.SelectedIndexChanged += new System.EventHandler(this.listBox_level_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(322, 215);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(51, 13);
            this.label_address.TabIndex = 6;
            this.label_address.Text = "Address: ";
            // 
            // button_applyToAll
            // 
            this.button_applyToAll.Location = new System.Drawing.Point(200, 234);
            this.button_applyToAll.Name = "button_applyToAll";
            this.button_applyToAll.Size = new System.Drawing.Size(47, 23);
            this.button_applyToAll.TabIndex = 7;
            this.button_applyToAll.Text = "All |=";
            this.button_applyToAll.UseVisualStyleBackColor = true;
            this.button_applyToAll.Click += new System.EventHandler(this.button_applyToAll_Click);
            // 
            // button_applyAllGlobal
            // 
            this.button_applyAllGlobal.Location = new System.Drawing.Point(137, 234);
            this.button_applyAllGlobal.Name = "button_applyAllGlobal";
            this.button_applyAllGlobal.Size = new System.Drawing.Size(47, 23);
            this.button_applyAllGlobal.TabIndex = 8;
            this.button_applyAllGlobal.Text = "All &&=";
            this.button_applyAllGlobal.UseVisualStyleBackColor = true;
            this.button_applyAllGlobal.Click += new System.EventHandler(this.button_applyAllGlobal_Click);
            // 
            // button_allXOR
            // 
            this.button_allXOR.Location = new System.Drawing.Point(269, 234);
            this.button_allXOR.Name = "button_allXOR";
            this.button_allXOR.Size = new System.Drawing.Size(45, 23);
            this.button_allXOR.TabIndex = 9;
            this.button_allXOR.Text = "All ^=";
            this.button_allXOR.UseVisualStyleBackColor = true;
            this.button_allXOR.Click += new System.EventHandler(this.button_allXOR_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Applies to every level \r\ncode in the game";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "_________________";
            // 
            // numericUpDown_levelCode
            // 
            this.numericUpDown_levelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_levelCode.Hexadecimal = true;
            this.numericUpDown_levelCode.Location = new System.Drawing.Point(100, 196);
            this.numericUpDown_levelCode.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_levelCode.Name = "numericUpDown_levelCode";
            this.numericUpDown_levelCode.Size = new System.Drawing.Size(44, 29);
            this.numericUpDown_levelCode.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Level Code";
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(16, 175);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 14;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_applySanity
            // 
            this.button_applySanity.Location = new System.Drawing.Point(239, 183);
            this.button_applySanity.Name = "button_applySanity";
            this.button_applySanity.Size = new System.Drawing.Size(75, 23);
            this.button_applySanity.TabIndex = 15;
            this.button_applySanity.Text = "Apply Sanity";
            this.button_applySanity.UseVisualStyleBackColor = true;
            this.button_applySanity.Click += new System.EventHandler(this.button_applySanity_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(594, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 26);
            this.label4.TabIndex = 16;
            this.label4.Text = "See the manual\r\nfor more info";
            // 
            // LevelAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_applySanity);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_levelCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_allXOR);
            this.Controls.Add(this.button_applyAllGlobal);
            this.Controls.Add(this.button_applyToAll);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox_level);
            this.Controls.Add(this.label_attr);
            this.Controls.Add(this.button_apply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LevelAttributes";
            this.Text = "LevelAttributes";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_levelCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Label label_attr;
        private System.Windows.Forms.ListBox listBox_level;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Button button_applyToAll;
        private System.Windows.Forms.Button button_applyAllGlobal;
        private System.Windows.Forms.Button button_allXOR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_levelCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_applySanity;
        private System.Windows.Forms.Label label4;
    }
}