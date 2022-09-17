namespace Tilemap_editor
{
    partial class PopupImage
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
            this.pictureBox_copyPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_copyPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_copyPreview
            // 
            this.pictureBox_copyPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_copyPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_copyPreview.Name = "pictureBox_copyPreview";
            this.pictureBox_copyPreview.Size = new System.Drawing.Size(183, 80);
            this.pictureBox_copyPreview.TabIndex = 0;
            this.pictureBox_copyPreview.TabStop = false;
            // 
            // PopupImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 80);
            this.Controls.Add(this.pictureBox_copyPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopupImage";
            this.Text = "PopupImage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_copyPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_copyPreview;
    }
}