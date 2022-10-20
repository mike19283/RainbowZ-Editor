using System;

namespace Tilemap_editor
{
    partial class Kkr_Cannonball_Options
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_cannonballSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_cannonballSelect
            // 
            this.comboBox_cannonballSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cannonballSelect.DropDownWidth = 150;
            this.comboBox_cannonballSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_cannonballSelect.FormattingEnabled = true;
            this.comboBox_cannonballSelect.Items.AddRange(new object[] {
            "Winky",
            "Expresso",
            "Rambi",
            "Enguarde",
            "Random animal",
            "Random enemy"});
            this.comboBox_cannonballSelect.Location = new System.Drawing.Point(42, 21);
            this.comboBox_cannonballSelect.Name = "comboBox_cannonballSelect";
            this.comboBox_cannonballSelect.Size = new System.Drawing.Size(85, 32);
            this.comboBox_cannonballSelect.TabIndex = 2;
            // 
            // Kkr_Cannonball_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(164, 104);
            this.Controls.Add(this.comboBox_cannonballSelect);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Kkr_Cannonball_Options";
            this.Text = "Animation After Hit";
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_cannonballSelect;
    }
}