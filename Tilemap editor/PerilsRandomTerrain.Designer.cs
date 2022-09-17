namespace Tilemap_editor
{
    partial class PerilsRandomTerrain
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
            this.listBox_perilsRandomTerrain = new System.Windows.Forms.ListBox();
            this.textBox_perilsRandomTerrain = new System.Windows.Forms.TextBox();
            this.button_perilsRandomTerrain = new System.Windows.Forms.Button();
            this.label_index = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox_perilsRandomTerrain
            // 
            this.listBox_perilsRandomTerrain.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_perilsRandomTerrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_perilsRandomTerrain.FormattingEnabled = true;
            this.listBox_perilsRandomTerrain.ItemHeight = 25;
            this.listBox_perilsRandomTerrain.Location = new System.Drawing.Point(0, 0);
            this.listBox_perilsRandomTerrain.Name = "listBox_perilsRandomTerrain";
            this.listBox_perilsRandomTerrain.Size = new System.Drawing.Size(253, 212);
            this.listBox_perilsRandomTerrain.TabIndex = 0;
            this.listBox_perilsRandomTerrain.SelectedIndexChanged += new System.EventHandler(this.listBox_perilsRandomTerrain_SelectedIndexChanged);
            // 
            // textBox_perilsRandomTerrain
            // 
            this.textBox_perilsRandomTerrain.Location = new System.Drawing.Point(274, 64);
            this.textBox_perilsRandomTerrain.Name = "textBox_perilsRandomTerrain";
            this.textBox_perilsRandomTerrain.Size = new System.Drawing.Size(100, 20);
            this.textBox_perilsRandomTerrain.TabIndex = 1;
            // 
            // button_perilsRandomTerrain
            // 
            this.button_perilsRandomTerrain.Location = new System.Drawing.Point(287, 103);
            this.button_perilsRandomTerrain.Name = "button_perilsRandomTerrain";
            this.button_perilsRandomTerrain.Size = new System.Drawing.Size(75, 23);
            this.button_perilsRandomTerrain.TabIndex = 2;
            this.button_perilsRandomTerrain.Text = "Links";
            this.button_perilsRandomTerrain.UseVisualStyleBackColor = true;
            this.button_perilsRandomTerrain.Click += new System.EventHandler(this.button_perilsRandomTerrain_Click);
            // 
            // label_index
            // 
            this.label_index.AutoSize = true;
            this.label_index.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_index.Location = new System.Drawing.Point(287, 28);
            this.label_index.Name = "label_index";
            this.label_index.Size = new System.Drawing.Size(70, 26);
            this.label_index.TabIndex = 3;
            this.label_index.Text = "label1";
            // 
            // PerilsRandomTerrain
            // 
            this.AcceptButton = this.button_perilsRandomTerrain;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 212);
            this.Controls.Add(this.label_index);
            this.Controls.Add(this.button_perilsRandomTerrain);
            this.Controls.Add(this.textBox_perilsRandomTerrain);
            this.Controls.Add(this.listBox_perilsRandomTerrain);
            this.Name = "PerilsRandomTerrain";
            this.Text = "PerilsRandomTerrain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_perilsRandomTerrain;
        private System.Windows.Forms.TextBox textBox_perilsRandomTerrain;
        private System.Windows.Forms.Button button_perilsRandomTerrain;
        private System.Windows.Forms.Label label_index;
    }
}