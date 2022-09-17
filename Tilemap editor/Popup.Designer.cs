namespace Tilemap_editor
{
    partial class Popup
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
            this.listBox_obj_list = new System.Windows.Forms.ListBox();
            this.comboBox_category = new System.Windows.Forms.ComboBox();
            this.pictureBox_spritePreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_spritePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_obj_list
            // 
            this.listBox_obj_list.FormattingEnabled = true;
            this.listBox_obj_list.ItemHeight = 24;
            this.listBox_obj_list.Location = new System.Drawing.Point(-1, 2);
            this.listBox_obj_list.Margin = new System.Windows.Forms.Padding(6);
            this.listBox_obj_list.Name = "listBox_obj_list";
            this.listBox_obj_list.Size = new System.Drawing.Size(652, 508);
            this.listBox_obj_list.TabIndex = 0;
            this.listBox_obj_list.SelectedIndexChanged += new System.EventHandler(this.listBox_obj_list_SelectedIndexChanged);
            this.listBox_obj_list.DoubleClick += new System.EventHandler(this.listBox_obj_list_DoubleClick);
            this.listBox_obj_list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_obj_list_KeyDown);
            this.listBox_obj_list.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_obj_list_MouseDown);
            // 
            // comboBox_category
            // 
            this.comboBox_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_category.FormattingEnabled = true;
            this.comboBox_category.Location = new System.Drawing.Point(419, 2);
            this.comboBox_category.Name = "comboBox_category";
            this.comboBox_category.Size = new System.Drawing.Size(210, 32);
            this.comboBox_category.TabIndex = 1;
            this.comboBox_category.SelectedIndexChanged += new System.EventHandler(this.comboBox_category_SelectedIndexChanged);
            // 
            // pictureBox_spritePreview
            // 
            this.pictureBox_spritePreview.Location = new System.Drawing.Point(373, 40);
            this.pictureBox_spritePreview.Name = "pictureBox_spritePreview";
            this.pictureBox_spritePreview.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_spritePreview.TabIndex = 2;
            this.pictureBox_spritePreview.TabStop = false;
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 516);
            this.Controls.Add(this.pictureBox_spritePreview);
            this.Controls.Add(this.comboBox_category);
            this.Controls.Add(this.listBox_obj_list);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(954, 50);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopupForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_spritePreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_obj_list;
        private System.Windows.Forms.ComboBox comboBox_category;
        private System.Windows.Forms.PictureBox pictureBox_spritePreview;
    }
}