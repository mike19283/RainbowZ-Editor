namespace Tilemap_editor
{
    partial class K_Rool_Throw_Options
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_3flinches = new System.Windows.Forms.RadioButton();
            this.radioButton_1flinch = new System.Windows.Forms.RadioButton();
            this.radioButton_normalHit = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_3flinches);
            this.groupBox1.Controls.Add(this.radioButton_1flinch);
            this.groupBox1.Controls.Add(this.radioButton_normalHit);
            this.groupBox1.Location = new System.Drawing.Point(35, -11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // radioButton_3flinches
            // 
            this.radioButton_3flinches.AutoSize = true;
            this.radioButton_3flinches.Location = new System.Drawing.Point(6, 65);
            this.radioButton_3flinches.Name = "radioButton_3flinches";
            this.radioButton_3flinches.Size = new System.Drawing.Size(100, 17);
            this.radioButton_3flinches.TabIndex = 2;
            this.radioButton_3flinches.Text = "3 Grunts+Death";
            this.radioButton_3flinches.UseVisualStyleBackColor = true;
            // 
            // radioButton_1flinch
            // 
            this.radioButton_1flinch.AutoSize = true;
            this.radioButton_1flinch.Location = new System.Drawing.Point(6, 42);
            this.radioButton_1flinch.Name = "radioButton_1flinch";
            this.radioButton_1flinch.Size = new System.Drawing.Size(95, 17);
            this.radioButton_1flinch.TabIndex = 1;
            this.radioButton_1flinch.Text = "1 Grunt+Death";
            this.radioButton_1flinch.UseVisualStyleBackColor = true;
            // 
            // radioButton_normalHit
            // 
            this.radioButton_normalHit.AutoSize = true;
            this.radioButton_normalHit.Checked = true;
            this.radioButton_normalHit.Location = new System.Drawing.Point(6, 19);
            this.radioButton_normalHit.Name = "radioButton_normalHit";
            this.radioButton_normalHit.Size = new System.Drawing.Size(74, 17);
            this.radioButton_normalHit.TabIndex = 0;
            this.radioButton_normalHit.TabStop = true;
            this.radioButton_normalHit.Text = "Normal Hit";
            this.radioButton_normalHit.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // K_Rool_Throw_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(164, 104);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "K_Rool_Throw_Options";
            this.Text = "Animation After Hit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_3flinches;
        private System.Windows.Forms.RadioButton radioButton_1flinch;
        private System.Windows.Forms.RadioButton radioButton_normalHit;
        private System.Windows.Forms.Button button1;
    }
}