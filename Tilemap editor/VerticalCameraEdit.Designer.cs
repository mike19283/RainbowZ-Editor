namespace Tilemap_editor
{
    partial class VerticalCameraEdit
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
            this.numericUpDown_x = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_xSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_ySize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox_type = new System.Windows.Forms.ListBox();
            this.button_apply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_R = new System.Windows.Forms.RadioButton();
            this.radioButton_D = new System.Windows.Forms.RadioButton();
            this.radioButtonU = new System.Windows.Forms.RadioButton();
            this.radioButton_L = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_multiple = new System.Windows.Forms.RadioButton();
            this.radioButton_hidden = new System.Windows.Forms.RadioButton();
            this.radioButton_single = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_connected = new System.Windows.Forms.NumericUpDown();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_addConnection = new System.Windows.Forms.Button();
            this.button_removeConnection = new System.Windows.Forms.Button();
            this.label_address = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_camUp = new System.Windows.Forms.Button();
            this.button_camDown = new System.Windows.Forms.Button();
            this.button_connectAll = new System.Windows.Forms.Button();
            this.checkBox_editThis = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_xSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ySize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_connected)).BeginInit();
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
            this.listBox_entities.Size = new System.Drawing.Size(410, 593);
            this.listBox_entities.TabIndex = 0;
            this.listBox_entities.SelectedIndexChanged += new System.EventHandler(this.listBox_entities_SelectedIndexChanged);
            // 
            // numericUpDown_x
            // 
            this.numericUpDown_x.Hexadecimal = true;
            this.numericUpDown_x.Location = new System.Drawing.Point(503, 23);
            this.numericUpDown_x.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_x.Name = "numericUpDown_x";
            this.numericUpDown_x.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_x.TabIndex = 1;
            // 
            // numericUpDown_y
            // 
            this.numericUpDown_y.Hexadecimal = true;
            this.numericUpDown_y.Location = new System.Drawing.Point(503, 109);
            this.numericUpDown_y.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_y.Name = "numericUpDown_y";
            this.numericUpDown_y.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_y.TabIndex = 3;
            // 
            // numericUpDown_xSize
            // 
            this.numericUpDown_xSize.Hexadecimal = true;
            this.numericUpDown_xSize.Location = new System.Drawing.Point(503, 66);
            this.numericUpDown_xSize.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_xSize.Name = "numericUpDown_xSize";
            this.numericUpDown_xSize.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_xSize.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(544, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(532, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "X End";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y End";
            // 
            // numericUpDown_ySize
            // 
            this.numericUpDown_ySize.Hexadecimal = true;
            this.numericUpDown_ySize.Location = new System.Drawing.Point(503, 155);
            this.numericUpDown_ySize.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_ySize.Name = "numericUpDown_ySize";
            this.numericUpDown_ySize.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_ySize.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Connections";
            // 
            // listBox_type
            // 
            this.listBox_type.FormattingEnabled = true;
            this.listBox_type.Location = new System.Drawing.Point(444, 252);
            this.listBox_type.Name = "listBox_type";
            this.listBox_type.Size = new System.Drawing.Size(120, 95);
            this.listBox_type.TabIndex = 13;
            this.listBox_type.SelectedIndexChanged += new System.EventHandler(this.listBox_type_SelectedIndexChanged);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(464, 557);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 15;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_R);
            this.groupBox1.Controls.Add(this.radioButton_D);
            this.groupBox1.Controls.Add(this.radioButtonU);
            this.groupBox1.Controls.Add(this.radioButton_L);
            this.groupBox1.Location = new System.Drawing.Point(416, 353);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 50);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            // 
            // radioButton_R
            // 
            this.radioButton_R.AutoSize = true;
            this.radioButton_R.Location = new System.Drawing.Point(51, 23);
            this.radioButton_R.Name = "radioButton_R";
            this.radioButton_R.Size = new System.Drawing.Size(33, 17);
            this.radioButton_R.TabIndex = 3;
            this.radioButton_R.TabStop = true;
            this.radioButton_R.Text = "R";
            this.radioButton_R.UseVisualStyleBackColor = true;
            // 
            // radioButton_D
            // 
            this.radioButton_D.AutoSize = true;
            this.radioButton_D.Location = new System.Drawing.Point(139, 23);
            this.radioButton_D.Name = "radioButton_D";
            this.radioButton_D.Size = new System.Drawing.Size(33, 17);
            this.radioButton_D.TabIndex = 2;
            this.radioButton_D.TabStop = true;
            this.radioButton_D.Text = "D";
            this.radioButton_D.UseVisualStyleBackColor = true;
            // 
            // radioButtonU
            // 
            this.radioButtonU.AutoSize = true;
            this.radioButtonU.Location = new System.Drawing.Point(95, 23);
            this.radioButtonU.Name = "radioButtonU";
            this.radioButtonU.Size = new System.Drawing.Size(33, 17);
            this.radioButtonU.TabIndex = 1;
            this.radioButtonU.TabStop = true;
            this.radioButtonU.Text = "U";
            this.radioButtonU.UseVisualStyleBackColor = true;
            // 
            // radioButton_L
            // 
            this.radioButton_L.AutoSize = true;
            this.radioButton_L.Location = new System.Drawing.Point(7, 23);
            this.radioButton_L.Name = "radioButton_L";
            this.radioButton_L.Size = new System.Drawing.Size(31, 17);
            this.radioButton_L.TabIndex = 0;
            this.radioButton_L.TabStop = true;
            this.radioButton_L.Text = "L";
            this.radioButton_L.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_multiple);
            this.groupBox2.Controls.Add(this.radioButton_hidden);
            this.groupBox2.Controls.Add(this.radioButton_single);
            this.groupBox2.Location = new System.Drawing.Point(416, 411);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 89);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            // 
            // radioButton_multiple
            // 
            this.radioButton_multiple.AutoSize = true;
            this.radioButton_multiple.Location = new System.Drawing.Point(58, 65);
            this.radioButton_multiple.Name = "radioButton_multiple";
            this.radioButton_multiple.Size = new System.Drawing.Size(61, 17);
            this.radioButton_multiple.TabIndex = 2;
            this.radioButton_multiple.TabStop = true;
            this.radioButton_multiple.Text = "Multiple";
            this.radioButton_multiple.UseVisualStyleBackColor = true;
            // 
            // radioButton_hidden
            // 
            this.radioButton_hidden.AutoSize = true;
            this.radioButton_hidden.Location = new System.Drawing.Point(59, 42);
            this.radioButton_hidden.Name = "radioButton_hidden";
            this.radioButton_hidden.Size = new System.Drawing.Size(59, 17);
            this.radioButton_hidden.TabIndex = 1;
            this.radioButton_hidden.TabStop = true;
            this.radioButton_hidden.Text = "Hidden";
            this.radioButton_hidden.UseVisualStyleBackColor = true;
            // 
            // radioButton_single
            // 
            this.radioButton_single.AutoSize = true;
            this.radioButton_single.Location = new System.Drawing.Point(58, 19);
            this.radioButton_single.Name = "radioButton_single";
            this.radioButton_single.Size = new System.Drawing.Size(54, 17);
            this.radioButton_single.TabIndex = 0;
            this.radioButton_single.TabStop = true;
            this.radioButton_single.Text = "Single";
            this.radioButton_single.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(478, 515);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Connected";
            // 
            // numericUpDown_connected
            // 
            this.numericUpDown_connected.Hexadecimal = true;
            this.numericUpDown_connected.Location = new System.Drawing.Point(464, 531);
            this.numericUpDown_connected.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_connected.Name = "numericUpDown_connected";
            this.numericUpDown_connected.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown_connected.TabIndex = 18;
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(424, 54);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(75, 23);
            this.button_remove.TabIndex = 20;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(422, 21);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 21;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_addConnection
            // 
            this.button_addConnection.Location = new System.Drawing.Point(573, 252);
            this.button_addConnection.Name = "button_addConnection";
            this.button_addConnection.Size = new System.Drawing.Size(23, 23);
            this.button_addConnection.TabIndex = 22;
            this.button_addConnection.Text = "A";
            this.button_addConnection.UseVisualStyleBackColor = true;
            this.button_addConnection.Click += new System.EventHandler(this.button_addConnection_Click);
            // 
            // button_removeConnection
            // 
            this.button_removeConnection.Location = new System.Drawing.Point(573, 281);
            this.button_removeConnection.Name = "button_removeConnection";
            this.button_removeConnection.Size = new System.Drawing.Size(23, 23);
            this.button_removeConnection.TabIndex = 23;
            this.button_removeConnection.Text = "R";
            this.button_removeConnection.UseVisualStyleBackColor = true;
            this.button_removeConnection.Click += new System.EventHandler(this.button_removeConnection_Click);
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(413, 4);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(0, 13);
            this.label_address.TabIndex = 24;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(424, 89);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 26;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_camUp
            // 
            this.button_camUp.Location = new System.Drawing.Point(425, 152);
            this.button_camUp.Name = "button_camUp";
            this.button_camUp.Size = new System.Drawing.Size(23, 23);
            this.button_camUp.TabIndex = 27;
            this.button_camUp.Text = "^";
            this.button_camUp.UseVisualStyleBackColor = true;
            this.button_camUp.Click += new System.EventHandler(this.button_camUp_Click);
            // 
            // button_camDown
            // 
            this.button_camDown.Location = new System.Drawing.Point(477, 152);
            this.button_camDown.Name = "button_camDown";
            this.button_camDown.Size = new System.Drawing.Size(23, 23);
            this.button_camDown.TabIndex = 28;
            this.button_camDown.Text = "V";
            this.button_camDown.UseVisualStyleBackColor = true;
            this.button_camDown.Click += new System.EventHandler(this.button_camDown_Click);
            // 
            // button_connectAll
            // 
            this.button_connectAll.Location = new System.Drawing.Point(422, 123);
            this.button_connectAll.Name = "button_connectAll";
            this.button_connectAll.Size = new System.Drawing.Size(75, 23);
            this.button_connectAll.TabIndex = 29;
            this.button_connectAll.Text = "Connect All";
            this.button_connectAll.UseVisualStyleBackColor = true;
            this.button_connectAll.Click += new System.EventHandler(this.button_connectAll_Click);
            // 
            // checkBox_editThis
            // 
            this.checkBox_editThis.AutoSize = true;
            this.checkBox_editThis.Location = new System.Drawing.Point(422, 201);
            this.checkBox_editThis.Name = "checkBox_editThis";
            this.checkBox_editThis.Size = new System.Drawing.Size(119, 17);
            this.checkBox_editThis.TabIndex = 30;
            this.checkBox_editThis.Text = "Edit this with mouse";
            this.checkBox_editThis.UseVisualStyleBackColor = true;
            this.checkBox_editThis.CheckedChanged += new System.EventHandler(this.checkBox_editThis_CheckedChanged);
            // 
            // VerticalCameraEdit
            // 
            this.AcceptButton = this.button_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 593);
            this.Controls.Add(this.checkBox_editThis);
            this.Controls.Add(this.button_connectAll);
            this.Controls.Add(this.button_camDown);
            this.Controls.Add(this.button_camUp);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.button_removeConnection);
            this.Controls.Add(this.button_addConnection);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown_connected);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.listBox_type);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_ySize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_xSize);
            this.Controls.Add(this.numericUpDown_y);
            this.Controls.Add(this.numericUpDown_x);
            this.Controls.Add(this.listBox_entities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(600, 50);
            this.Name = "VerticalCameraEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EntityEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VerticalCameraEdit_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_xSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ySize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_connected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_entities;
        private System.Windows.Forms.NumericUpDown numericUpDown_x;
        private System.Windows.Forms.NumericUpDown numericUpDown_y;
        private System.Windows.Forms.NumericUpDown numericUpDown_xSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_ySize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox_type;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_R;
        private System.Windows.Forms.RadioButton radioButton_D;
        private System.Windows.Forms.RadioButton radioButtonU;
        private System.Windows.Forms.RadioButton radioButton_L;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_multiple;
        private System.Windows.Forms.RadioButton radioButton_hidden;
        private System.Windows.Forms.RadioButton radioButton_single;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_connected;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_addConnection;
        private System.Windows.Forms.Button button_removeConnection;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_camUp;
        private System.Windows.Forms.Button button_camDown;
        private System.Windows.Forms.Button button_connectAll;
        private System.Windows.Forms.CheckBox checkBox_editThis;
    }
}