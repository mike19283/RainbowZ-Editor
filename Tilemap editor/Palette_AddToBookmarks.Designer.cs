namespace Tilemap_editor
{
    partial class Palette_AddToBookmarks
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_bookmarkAdd = new System.Windows.Forms.TextBox();
            this.button_bookmarkAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter name:";
            // 
            // textBox_bookmarkAdd
            // 
            this.textBox_bookmarkAdd.Location = new System.Drawing.Point(11, 61);
            this.textBox_bookmarkAdd.MaxLength = 22;
            this.textBox_bookmarkAdd.Name = "textBox_bookmarkAdd";
            this.textBox_bookmarkAdd.Size = new System.Drawing.Size(145, 20);
            this.textBox_bookmarkAdd.TabIndex = 1;
            this.textBox_bookmarkAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_bookmarkAdd_KeyDown);
            // 
            // button_bookmarkAdd
            // 
            this.button_bookmarkAdd.Location = new System.Drawing.Point(43, 114);
            this.button_bookmarkAdd.Name = "button_bookmarkAdd";
            this.button_bookmarkAdd.Size = new System.Drawing.Size(75, 23);
            this.button_bookmarkAdd.TabIndex = 2;
            this.button_bookmarkAdd.Text = "Add";
            this.button_bookmarkAdd.UseVisualStyleBackColor = true;
            this.button_bookmarkAdd.Click += new System.EventHandler(this.button_bookmarkAdd_Click);
            // 
            // AddToBookmarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 156);
            this.Controls.Add(this.button_bookmarkAdd);
            this.Controls.Add(this.textBox_bookmarkAdd);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddToBookmarks";
            this.Text = "Add To Bookmarks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_bookmarkAdd;
        private System.Windows.Forms.Button button_bookmarkAdd;
    }
}