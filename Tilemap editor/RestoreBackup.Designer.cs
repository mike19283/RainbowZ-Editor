namespace Tilemap_editor
{
    partial class RestoreBackup
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
            this.listBox_backups = new System.Windows.Forms.ListBox();
            this.button_restore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox_backups
            // 
            this.listBox_backups.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_backups.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_backups.FormattingEnabled = true;
            this.listBox_backups.ItemHeight = 25;
            this.listBox_backups.Location = new System.Drawing.Point(0, 0);
            this.listBox_backups.Name = "listBox_backups";
            this.listBox_backups.Size = new System.Drawing.Size(296, 293);
            this.listBox_backups.TabIndex = 0;
            this.listBox_backups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_backups_MouseDoubleClick);
            this.listBox_backups.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_backups_MouseDown);
            // 
            // button_restore
            // 
            this.button_restore.Location = new System.Drawing.Point(302, 9);
            this.button_restore.Name = "button_restore";
            this.button_restore.Size = new System.Drawing.Size(75, 23);
            this.button_restore.TabIndex = 1;
            this.button_restore.Text = "Restore";
            this.button_restore.UseVisualStyleBackColor = true;
            this.button_restore.Click += new System.EventHandler(this.button_restore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "Click restore or\r\nright-click to\r\nrestore the \r\nselected backup ";
            // 
            // RestoreBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 293);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_restore);
            this.Controls.Add(this.listBox_backups);
            this.Name = "RestoreBackup";
            this.Text = "RestoreBackup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_backups;
        private System.Windows.Forms.Button button_restore;
        private System.Windows.Forms.Label label1;
    }
}