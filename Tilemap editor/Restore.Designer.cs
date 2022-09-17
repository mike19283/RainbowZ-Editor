
namespace Tilemap_editor
{
    partial class Restore
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
            this.listBox_keep = new System.Windows.Forms.ListBox();
            this.button_select = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_keep
            // 
            this.listBox_keep.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_keep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_keep.FormattingEnabled = true;
            this.listBox_keep.ItemHeight = 24;
            this.listBox_keep.Location = new System.Drawing.Point(0, 0);
            this.listBox_keep.Name = "listBox_keep";
            this.listBox_keep.Size = new System.Drawing.Size(196, 304);
            this.listBox_keep.TabIndex = 0;
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(209, 12);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(75, 23);
            this.button_select.TabIndex = 1;
            this.button_select.Text = "Select";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(209, 59);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 304);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.listBox_keep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(954, 50);
            this.Name = "Restore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Restore";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_keep;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Button button_cancel;
    }
}