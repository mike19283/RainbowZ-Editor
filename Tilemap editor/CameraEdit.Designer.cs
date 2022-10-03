
namespace Tilemap_editor
{
    partial class CameraEdit
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
            this.numericUpDown_leftCam = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_lowerCamY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_upperCamY = new System.Windows.Forms.NumericUpDown();
            this.button_apply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_setMultiple = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_yB = new System.Windows.Forms.RadioButton();
            this.radioButton_yT = new System.Windows.Forms.RadioButton();
            this.radioButton_xStart = new System.Windows.Forms.RadioButton();
            this.label_address = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_leftCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_lowerCamY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_upperCamY)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // 
            // numericUpDown_leftCam
            // 
            this.numericUpDown_leftCam.Hexadecimal = true;
            this.numericUpDown_leftCam.Location = new System.Drawing.Point(378, 53);
            this.numericUpDown_leftCam.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_leftCam.Name = "numericUpDown_leftCam";
            this.numericUpDown_leftCam.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_leftCam.TabIndex = 1;
            // 
            // numericUpDown_lowerCamY
            // 
            this.numericUpDown_lowerCamY.Hexadecimal = true;
            this.numericUpDown_lowerCamY.Location = new System.Drawing.Point(378, 157);
            this.numericUpDown_lowerCamY.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_lowerCamY.Name = "numericUpDown_lowerCamY";
            this.numericUpDown_lowerCamY.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_lowerCamY.TabIndex = 3;
            // 
            // numericUpDown_upperCamY
            // 
            this.numericUpDown_upperCamY.Hexadecimal = true;
            this.numericUpDown_upperCamY.Location = new System.Drawing.Point(378, 103);
            this.numericUpDown_upperCamY.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_upperCamY.Name = "numericUpDown_upperCamY";
            this.numericUpDown_upperCamY.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_upperCamY.TabIndex = 4;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(396, 195);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 5;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Y - Top";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "X - Left";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Y - Bottom";
            // 
            // button_setMultiple
            // 
            this.button_setMultiple.Location = new System.Drawing.Point(360, 425);
            this.button_setMultiple.Name = "button_setMultiple";
            this.button_setMultiple.Size = new System.Drawing.Size(111, 23);
            this.button_setMultiple.TabIndex = 20;
            this.button_setMultiple.Text = "Set [Start, end)";
            this.toolTip1.SetToolTip(this.button_setMultiple, "Set the attribute chosen above\r\nover multiple indices");
            this.button_setMultiple.UseVisualStyleBackColor = true;
            this.button_setMultiple.Click += new System.EventHandler(this.button_setMultiple_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_yB);
            this.groupBox1.Controls.Add(this.radioButton_yT);
            this.groupBox1.Controls.Add(this.radioButton_xStart);
            this.groupBox1.Location = new System.Drawing.Point(360, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 159);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Multiple";
            // 
            // radioButton_yB
            // 
            this.radioButton_yB.AutoSize = true;
            this.radioButton_yB.Location = new System.Drawing.Point(18, 125);
            this.radioButton_yB.Name = "radioButton_yB";
            this.radioButton_yB.Size = new System.Drawing.Size(68, 17);
            this.radioButton_yB.TabIndex = 2;
            this.radioButton_yB.Text = "Y Bottom";
            this.radioButton_yB.UseVisualStyleBackColor = true;
            // 
            // radioButton_yT
            // 
            this.radioButton_yT.AutoSize = true;
            this.radioButton_yT.Location = new System.Drawing.Point(18, 81);
            this.radioButton_yT.Name = "radioButton_yT";
            this.radioButton_yT.Size = new System.Drawing.Size(54, 17);
            this.radioButton_yT.TabIndex = 1;
            this.radioButton_yT.Text = "Y Top";
            this.radioButton_yT.UseVisualStyleBackColor = true;
            // 
            // radioButton_xStart
            // 
            this.radioButton_xStart.AutoSize = true;
            this.radioButton_xStart.Checked = true;
            this.radioButton_xStart.Location = new System.Drawing.Point(18, 31);
            this.radioButton_xStart.Name = "radioButton_xStart";
            this.radioButton_xStart.Size = new System.Drawing.Size(53, 17);
            this.radioButton_xStart.TabIndex = 0;
            this.radioButton_xStart.TabStop = true;
            this.radioButton_xStart.Text = "X Left";
            this.radioButton_xStart.UseVisualStyleBackColor = true;
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(337, 13);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(35, 13);
            this.label_address.TabIndex = 22;
            this.label_address.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 26);
            this.label4.TabIndex = 23;
            this.label4.Text = "Uses computer values\r\ne.g. (0,0) is top left";
            // 
            // CameraEdit
            // 
            this.AcceptButton = this.button_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_setMultiple);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.numericUpDown_upperCamY);
            this.Controls.Add(this.numericUpDown_lowerCamY);
            this.Controls.Add(this.numericUpDown_leftCam);
            this.Controls.Add(this.listBox_entities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(781, 50);
            this.Name = "CameraEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EntityEdit";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_leftCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_lowerCamY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_upperCamY)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_entities;
        private System.Windows.Forms.NumericUpDown numericUpDown_leftCam;
        private System.Windows.Forms.NumericUpDown numericUpDown_lowerCamY;
        private System.Windows.Forms.NumericUpDown numericUpDown_upperCamY;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_setMultiple;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_yB;
        private System.Windows.Forms.RadioButton radioButton_yT;
        private System.Windows.Forms.RadioButton radioButton_xStart;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}