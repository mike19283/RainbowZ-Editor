namespace Tilemap_editor
{
    partial class BananaEdit
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
            this.listBox_entities = new System.Windows.Forms.ListBox();
            this.numericUpDown_entityType = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_entityY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_entityX = new System.Windows.Forms.NumericUpDown();
            this.button_apply = new System.Windows.Forms.Button();
            this.pictureBox_banana = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_varieties = new System.Windows.Forms.PictureBox();
            this.comboBox_variety = new System.Windows.Forms.ComboBox();
            this.label_address = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_banana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_varieties)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_entities
            // 
            this.listBox_entities.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_entities.FormattingEnabled = true;
            this.listBox_entities.ItemHeight = 24;
            this.listBox_entities.Location = new System.Drawing.Point(0, 0);
            this.listBox_entities.Name = "listBox_entities";
            this.listBox_entities.Size = new System.Drawing.Size(330, 268);
            this.listBox_entities.TabIndex = 0;
            this.listBox_entities.SelectedIndexChanged += new System.EventHandler(this.listBox_entities_SelectedIndexChanged);
            // 
            // numericUpDown_entityType
            // 
            this.numericUpDown_entityType.Hexadecimal = true;
            this.numericUpDown_entityType.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_entityType.Location = new System.Drawing.Point(378, 47);
            this.numericUpDown_entityType.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.numericUpDown_entityType.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_entityType.Name = "numericUpDown_entityType";
            this.numericUpDown_entityType.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_entityType.TabIndex = 1;
            this.numericUpDown_entityType.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDown_entityY
            // 
            this.numericUpDown_entityY.Hexadecimal = true;
            this.numericUpDown_entityY.Location = new System.Drawing.Point(378, 131);
            this.numericUpDown_entityY.Maximum = new decimal(new int[] {
            65836,
            0,
            0,
            0});
            this.numericUpDown_entityY.Name = "numericUpDown_entityY";
            this.numericUpDown_entityY.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_entityY.TabIndex = 3;
            // 
            // numericUpDown_entityX
            // 
            this.numericUpDown_entityX.Hexadecimal = true;
            this.numericUpDown_entityX.Location = new System.Drawing.Point(378, 88);
            this.numericUpDown_entityX.Maximum = new decimal(new int[] {
            65836,
            0,
            0,
            0});
            this.numericUpDown_entityX.Name = "numericUpDown_entityX";
            this.numericUpDown_entityX.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_entityX.TabIndex = 4;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(396, 170);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 5;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // pictureBox_banana
            // 
            this.pictureBox_banana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_banana.Location = new System.Drawing.Point(347, 199);
            this.pictureBox_banana.Name = "pictureBox_banana";
            this.pictureBox_banana.Size = new System.Drawing.Size(135, 151);
            this.pictureBox_banana.TabIndex = 6;
            this.pictureBox_banana.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "X";
            // 
            // pictureBox_varieties
            // 
            this.pictureBox_varieties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_varieties.Location = new System.Drawing.Point(12, 287);
            this.pictureBox_varieties.Name = "pictureBox_varieties";
            this.pictureBox_varieties.Size = new System.Drawing.Size(318, 151);
            this.pictureBox_varieties.TabIndex = 18;
            this.pictureBox_varieties.TabStop = false;
            // 
            // comboBox_variety
            // 
            this.comboBox_variety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_variety.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_variety.FormattingEnabled = true;
            this.comboBox_variety.Location = new System.Drawing.Point(361, 388);
            this.comboBox_variety.Name = "comboBox_variety";
            this.comboBox_variety.Size = new System.Drawing.Size(121, 33);
            this.comboBox_variety.TabIndex = 19;
            this.comboBox_variety.SelectedIndexChanged += new System.EventHandler(this.comboBox_variety_SelectedIndexChanged);
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(347, 13);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(35, 13);
            this.label_address.TabIndex = 20;
            this.label_address.Text = "label3";
            // 
            // BananaEdit
            // 
            this.AcceptButton = this.button_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 450);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.comboBox_variety);
            this.Controls.Add(this.pictureBox_varieties);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_banana);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.numericUpDown_entityX);
            this.Controls.Add(this.numericUpDown_entityY);
            this.Controls.Add(this.numericUpDown_entityType);
            this.Controls.Add(this.listBox_entities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(781, 50);
            this.Name = "BananaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EntityEdit";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_banana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_varieties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_entities;
        private System.Windows.Forms.NumericUpDown numericUpDown_entityType;
        private System.Windows.Forms.NumericUpDown numericUpDown_entityY;
        private System.Windows.Forms.NumericUpDown numericUpDown_entityX;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.PictureBox pictureBox_banana;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_varieties;
        private System.Windows.Forms.ComboBox comboBox_variety;
        private System.Windows.Forms.Label label_address;
    }
}