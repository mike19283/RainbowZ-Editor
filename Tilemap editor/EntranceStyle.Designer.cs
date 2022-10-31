namespace Tilemap_editor
{
    partial class EntranceStyle
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
            this.listBox_entranceStyle = new System.Windows.Forms.ListBox();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_applySanity = new System.Windows.Forms.Button();
            this.button_loadCode = new System.Windows.Forms.Button();
            this.numericUpDown_code = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_code)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_entranceStyle
            // 
            this.listBox_entranceStyle.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox_entranceStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_entranceStyle.FormattingEnabled = true;
            this.listBox_entranceStyle.ItemHeight = 24;
            this.listBox_entranceStyle.Items.AddRange(new object[] {
            "nothing",
            "run to the left",
            "run to the right as Rambi",
            "run to the left as Winky",
            "run to the right as Expresso",
            "start as Enguarde",
            "run to the right",
            "barrel roulette style",
            "walk to the right",
            "start at entrance",
            "swimming"});
            this.listBox_entranceStyle.Location = new System.Drawing.Point(145, 0);
            this.listBox_entranceStyle.Name = "listBox_entranceStyle";
            this.listBox_entranceStyle.Size = new System.Drawing.Size(277, 252);
            this.listBox_entranceStyle.TabIndex = 0;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(36, 133);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 1;
            this.button_apply.Text = "Apply";
            this.toolTip1.SetToolTip(this.button_apply, "Applies to just the code in the number box");
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_applySanity
            // 
            this.button_applySanity.Location = new System.Drawing.Point(36, 178);
            this.button_applySanity.Name = "button_applySanity";
            this.button_applySanity.Size = new System.Drawing.Size(75, 23);
            this.button_applySanity.TabIndex = 2;
            this.button_applySanity.Text = "Apply Sanity";
            this.toolTip1.SetToolTip(this.button_applySanity, "Applies to all related levels");
            this.button_applySanity.UseVisualStyleBackColor = true;
            this.button_applySanity.Click += new System.EventHandler(this.button_applySanity_Click);
            // 
            // button_loadCode
            // 
            this.button_loadCode.Location = new System.Drawing.Point(36, 70);
            this.button_loadCode.Name = "button_loadCode";
            this.button_loadCode.Size = new System.Drawing.Size(75, 23);
            this.button_loadCode.TabIndex = 3;
            this.button_loadCode.Text = "Load";
            this.toolTip1.SetToolTip(this.button_loadCode, "Load the entrance style for the specified code");
            this.button_loadCode.UseVisualStyleBackColor = true;
            this.button_loadCode.Click += new System.EventHandler(this.button_loadCode_Click);
            // 
            // numericUpDown_code
            // 
            this.numericUpDown_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_code.Hexadecimal = true;
            this.numericUpDown_code.Location = new System.Drawing.Point(36, 33);
            this.numericUpDown_code.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_code.Name = "numericUpDown_code";
            this.numericUpDown_code.Size = new System.Drawing.Size(75, 29);
            this.numericUpDown_code.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Level code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 39);
            this.label2.TabIndex = 6;
            this.label2.Text = "WARNING! Starting as\r\nanimals has weird \r\nside effects!";
            // 
            // EntranceStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 252);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_code);
            this.Controls.Add(this.button_loadCode);
            this.Controls.Add(this.button_applySanity);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.listBox_entranceStyle);
            this.Name = "EntranceStyle";
            this.Text = "EntranceStyle";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_code)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_entranceStyle;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_applySanity;
        private System.Windows.Forms.Button button_loadCode;
        private System.Windows.Forms.NumericUpDown numericUpDown_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
    }
}