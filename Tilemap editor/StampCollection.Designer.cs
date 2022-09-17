namespace Tilemap_editor
{
    partial class StampCollection
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
            this.listBox_stampList = new System.Windows.Forms.ListBox();
            this.pictureBox_stampPreview = new System.Windows.Forms.PictureBox();
            this.button_select = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stampPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_stampList
            // 
            this.listBox_stampList.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_stampList.FormattingEnabled = true;
            this.listBox_stampList.Location = new System.Drawing.Point(0, 0);
            this.listBox_stampList.Name = "listBox_stampList";
            this.listBox_stampList.Size = new System.Drawing.Size(285, 261);
            this.listBox_stampList.TabIndex = 0;
            this.listBox_stampList.SelectedIndexChanged += new System.EventHandler(this.listBox_stampList_SelectedIndexChanged);
            this.listBox_stampList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_stampList_MouseDown);
            // 
            // pictureBox_stampPreview
            // 
            this.pictureBox_stampPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_stampPreview.Location = new System.Drawing.Point(291, 12);
            this.pictureBox_stampPreview.Name = "pictureBox_stampPreview";
            this.pictureBox_stampPreview.Size = new System.Drawing.Size(160, 160);
            this.pictureBox_stampPreview.TabIndex = 1;
            this.pictureBox_stampPreview.TabStop = false;
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(338, 178);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(75, 23);
            this.button_select.TabIndex = 2;
            this.button_select.Text = "Select";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(338, 226);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(75, 23);
            this.button_remove.TabIndex = 3;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // StampCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 261);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.pictureBox_stampPreview);
            this.Controls.Add(this.listBox_stampList);
            this.Name = "StampCollection";
            this.Text = "StampCollection";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stampPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_stampList;
        private System.Windows.Forms.PictureBox pictureBox_stampPreview;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Button button_remove;
    }
}