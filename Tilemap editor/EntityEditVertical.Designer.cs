namespace Tilemap_editor
{
    partial class EntityEditVertical
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
            this.components = new System.ComponentModel.Container();
            this.listBox_entities = new System.Windows.Forms.ListBox();
            this.numericUpDown_entityType = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_entityPointer = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_entityY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_entityX = new System.Windows.Forms.NumericUpDown();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_selectEntity = new System.Windows.Forms.Button();
            this.button_editor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_getAddress = new System.Windows.Forms.Button();
            this.button_openPalette = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityPointer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityX)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_entities
            // 
            this.listBox_entities.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_entities.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_entities.FormattingEnabled = true;
            this.listBox_entities.ItemHeight = 24;
            this.listBox_entities.Location = new System.Drawing.Point(0, 0);
            this.listBox_entities.Name = "listBox_entities";
            this.listBox_entities.Size = new System.Drawing.Size(330, 450);
            this.listBox_entities.TabIndex = 0;
            this.listBox_entities.SelectedIndexChanged += new System.EventHandler(this.listBox_entities_SelectedIndexChanged);
            this.listBox_entities.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_entities_MouseDoubleClick);
            this.listBox_entities.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_entities_MouseDown);
            // 
            // numericUpDown_entityType
            // 
            this.numericUpDown_entityType.Hexadecimal = true;
            this.numericUpDown_entityType.Location = new System.Drawing.Point(378, 37);
            this.numericUpDown_entityType.Maximum = new decimal(new int[] {
            65836,
            0,
            0,
            0});
            this.numericUpDown_entityType.Name = "numericUpDown_entityType";
            this.numericUpDown_entityType.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_entityType.TabIndex = 1;
            // 
            // numericUpDown_entityPointer
            // 
            this.numericUpDown_entityPointer.Hexadecimal = true;
            this.numericUpDown_entityPointer.Location = new System.Drawing.Point(378, 190);
            this.numericUpDown_entityPointer.Maximum = new decimal(new int[] {
            65836,
            0,
            0,
            0});
            this.numericUpDown_entityPointer.Name = "numericUpDown_entityPointer";
            this.numericUpDown_entityPointer.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_entityPointer.TabIndex = 2;
            // 
            // numericUpDown_entityY
            // 
            this.numericUpDown_entityY.Hexadecimal = true;
            this.numericUpDown_entityY.Location = new System.Drawing.Point(378, 141);
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
            this.numericUpDown_entityX.Location = new System.Drawing.Point(378, 87);
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
            this.button_apply.Location = new System.Drawing.Point(396, 232);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 5;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_selectEntity
            // 
            this.button_selectEntity.Location = new System.Drawing.Point(343, 187);
            this.button_selectEntity.Name = "button_selectEntity";
            this.button_selectEntity.Size = new System.Drawing.Size(23, 23);
            this.button_selectEntity.TabIndex = 6;
            this.button_selectEntity.UseVisualStyleBackColor = true;
            this.button_selectEntity.Click += new System.EventHandler(this.button_selectEntity_Click);
            // 
            // button_editor
            // 
            this.button_editor.Location = new System.Drawing.Point(343, 277);
            this.button_editor.Name = "button_editor";
            this.button_editor.Size = new System.Drawing.Size(128, 48);
            this.button_editor.TabIndex = 7;
            this.button_editor.Text = "Open in entity editor";
            this.button_editor.UseVisualStyleBackColor = true;
            this.button_editor.Click += new System.EventHandler(this.button_editor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Pointer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Type";
            // 
            // button_getAddress
            // 
            this.button_getAddress.Location = new System.Drawing.Point(339, 34);
            this.button_getAddress.Name = "button_getAddress";
            this.button_getAddress.Size = new System.Drawing.Size(33, 23);
            this.button_getAddress.TabIndex = 12;
            this.button_getAddress.Text = "Get This Address";
            this.toolTip1.SetToolTip(this.button_getAddress, "Get hex offset of entity");
            this.button_getAddress.UseVisualStyleBackColor = true;
            this.button_getAddress.Click += new System.EventHandler(this.button_getAddress_Click);
            // 
            // button_openPalette
            // 
            this.button_openPalette.Location = new System.Drawing.Point(345, 138);
            this.button_openPalette.Name = "button_openPalette";
            this.button_openPalette.Size = new System.Drawing.Size(21, 23);
            this.button_openPalette.TabIndex = 25;
            this.button_openPalette.Text = "P";
            this.toolTip1.SetToolTip(this.button_openPalette, "Open (P)alette");
            this.button_openPalette.UseVisualStyleBackColor = true;
            this.button_openPalette.Click += new System.EventHandler(this.button_openPalette_Click);
            // 
            // EntityEditVertical
            // 
            this.AcceptButton = this.button_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 450);
            this.Controls.Add(this.button_openPalette);
            this.Controls.Add(this.button_getAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_editor);
            this.Controls.Add(this.button_selectEntity);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.numericUpDown_entityX);
            this.Controls.Add(this.numericUpDown_entityY);
            this.Controls.Add(this.numericUpDown_entityPointer);
            this.Controls.Add(this.numericUpDown_entityType);
            this.Controls.Add(this.listBox_entities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(781, 50);
            this.Name = "EntityEditVertical";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EntityEdit";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityPointer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entityX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_entities;
        private System.Windows.Forms.NumericUpDown numericUpDown_entityType;
        private System.Windows.Forms.NumericUpDown numericUpDown_entityPointer;
        private System.Windows.Forms.NumericUpDown numericUpDown_entityY;
        private System.Windows.Forms.NumericUpDown numericUpDown_entityX;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_selectEntity;
        private System.Windows.Forms.Button button_editor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_getAddress;
        private System.Windows.Forms.Button button_openPalette;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}