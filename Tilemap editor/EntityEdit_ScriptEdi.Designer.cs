namespace Tilemap_editor
{
    partial class EntityEdit_ScriptEdi
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_entityX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_entityY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_entityPointer = new System.Windows.Forms.NumericUpDown();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_selectEntity = new System.Windows.Forms.Button();
            this.label_address = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityPointer)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_entities
            // 
            this.listBox_entities.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_entities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_entities.FormattingEnabled = true;
            this.listBox_entities.ItemHeight = 20;
            this.listBox_entities.Location = new System.Drawing.Point(0, 0);
            this.listBox_entities.Name = "listBox_entities";
            this.listBox_entities.Size = new System.Drawing.Size(282, 326);
            this.listBox_entities.TabIndex = 0;
            this.listBox_entities.SelectedIndexChanged += new System.EventHandler(this.listBox_entities_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Pointer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "X";
            // 
            // numericUpDown_entityX
            // 
            this.numericUpDown_entityX.Hexadecimal = true;
            this.numericUpDown_entityX.Location = new System.Drawing.Point(317, 26);
            this.numericUpDown_entityX.Maximum = new decimal(new int[] {
            65836,
            0,
            0,
            0});
            this.numericUpDown_entityX.Name = "numericUpDown_entityX";
            this.numericUpDown_entityX.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_entityX.TabIndex = 18;
            // 
            // numericUpDown_entityY
            // 
            this.numericUpDown_entityY.Hexadecimal = true;
            this.numericUpDown_entityY.Location = new System.Drawing.Point(317, 73);
            this.numericUpDown_entityY.Maximum = new decimal(new int[] {
            65836,
            0,
            0,
            0});
            this.numericUpDown_entityY.Name = "numericUpDown_entityY";
            this.numericUpDown_entityY.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_entityY.TabIndex = 17;
            // 
            // numericUpDown_entityPointer
            // 
            this.numericUpDown_entityPointer.Hexadecimal = true;
            this.numericUpDown_entityPointer.Location = new System.Drawing.Point(317, 114);
            this.numericUpDown_entityPointer.Maximum = new decimal(new int[] {
            65836,
            0,
            0,
            0});
            this.numericUpDown_entityPointer.Name = "numericUpDown_entityPointer";
            this.numericUpDown_entityPointer.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_entityPointer.TabIndex = 16;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(326, 157);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 22;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_selectEntity
            // 
            this.button_selectEntity.Location = new System.Drawing.Point(288, 111);
            this.button_selectEntity.Name = "button_selectEntity";
            this.button_selectEntity.Size = new System.Drawing.Size(23, 23);
            this.button_selectEntity.TabIndex = 23;
            this.button_selectEntity.UseVisualStyleBackColor = true;
            this.button_selectEntity.Click += new System.EventHandler(this.button_selectEntity_Click);
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(285, 9);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(10, 13);
            this.label_address.TabIndex = 26;
            this.label_address.Text = " ";
            // 
            // EntityEdit_ScriptEdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 326);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.button_selectEntity);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_entityX);
            this.Controls.Add(this.numericUpDown_entityY);
            this.Controls.Add(this.numericUpDown_entityPointer);
            this.Controls.Add(this.listBox_entities);
            this.Name = "EntityEdit_ScriptEdi";
            this.Text = "EntityEdit_ScriptEdi";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityPointer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_entities;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_entityX;
        private System.Windows.Forms.NumericUpDown numericUpDown_entityY;
        private System.Windows.Forms.NumericUpDown numericUpDown_entityPointer;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_selectEntity;
        private System.Windows.Forms.Label label_address;
    }
}