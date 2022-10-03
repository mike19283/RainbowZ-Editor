namespace Tilemap_editor
{
    partial class TextEditor
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
            this.tabControl_text = new System.Windows.Forms.TabControl();
            this.tabPage_kf = new System.Windows.Forms.TabPage();
            this.button_resetTest = new System.Windows.Forms.Button();
            this.button_testThis = new System.Windows.Forms.Button();
            this.button_import_kfText = new System.Windows.Forms.Button();
            this.button_export_kfText = new System.Windows.Forms.Button();
            this.button_kfTextApply = new System.Windows.Forms.Button();
            this.richTextBox_preview = new System.Windows.Forms.RichTextBox();
            this.listBox_textPointers = new System.Windows.Forms.ListBox();
            this.listBox_tablePointers = new System.Windows.Forms.ListBox();
            this.tabPage_stage = new System.Windows.Forms.TabPage();
            this.button_exportall = new System.Windows.Forms.Button();
            this.button_importall = new System.Windows.Forms.Button();
            this.button_master = new System.Windows.Forms.Button();
            this.button_apply = new System.Windows.Forms.Button();
            this.textBox_stage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_stageCurrent = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_stageBase = new System.Windows.Forms.ListBox();
            this.tabPage_credits = new System.Windows.Forms.TabPage();
            this.button_import_credits = new System.Windows.Forms.Button();
            this.button_export_credits = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_real = new System.Windows.Forms.RadioButton();
            this.radioButton_fake = new System.Windows.Forms.RadioButton();
            this.button_creditsApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox_credits = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl_text.SuspendLayout();
            this.tabPage_kf.SuspendLayout();
            this.tabPage_stage.SuspendLayout();
            this.tabPage_credits.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_text
            // 
            this.tabControl_text.Controls.Add(this.tabPage_kf);
            this.tabControl_text.Controls.Add(this.tabPage_stage);
            this.tabControl_text.Controls.Add(this.tabPage_credits);
            this.tabControl_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_text.Location = new System.Drawing.Point(0, 0);
            this.tabControl_text.Name = "tabControl_text";
            this.tabControl_text.SelectedIndex = 0;
            this.tabControl_text.Size = new System.Drawing.Size(800, 450);
            this.tabControl_text.TabIndex = 0;
            this.tabControl_text.SelectedIndexChanged += new System.EventHandler(this.tabControl_text_SelectedIndexChanged);
            // 
            // tabPage_kf
            // 
            this.tabPage_kf.Controls.Add(this.label4);
            this.tabPage_kf.Controls.Add(this.button_resetTest);
            this.tabPage_kf.Controls.Add(this.button_testThis);
            this.tabPage_kf.Controls.Add(this.button_import_kfText);
            this.tabPage_kf.Controls.Add(this.button_export_kfText);
            this.tabPage_kf.Controls.Add(this.button_kfTextApply);
            this.tabPage_kf.Controls.Add(this.richTextBox_preview);
            this.tabPage_kf.Controls.Add(this.listBox_textPointers);
            this.tabPage_kf.Controls.Add(this.listBox_tablePointers);
            this.tabPage_kf.Location = new System.Drawing.Point(4, 22);
            this.tabPage_kf.Name = "tabPage_kf";
            this.tabPage_kf.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_kf.Size = new System.Drawing.Size(792, 424);
            this.tabPage_kf.TabIndex = 0;
            this.tabPage_kf.Text = "Kong Family";
            this.tabPage_kf.UseVisualStyleBackColor = true;
            // 
            // button_resetTest
            // 
            this.button_resetTest.Location = new System.Drawing.Point(412, 336);
            this.button_resetTest.Name = "button_resetTest";
            this.button_resetTest.Size = new System.Drawing.Size(75, 23);
            this.button_resetTest.TabIndex = 8;
            this.button_resetTest.Text = "Reset Test";
            this.button_resetTest.UseVisualStyleBackColor = true;
            this.button_resetTest.Click += new System.EventHandler(this.button_resetTest_Click);
            // 
            // button_testThis
            // 
            this.button_testThis.BackColor = System.Drawing.Color.Transparent;
            this.button_testThis.Location = new System.Drawing.Point(409, 288);
            this.button_testThis.Name = "button_testThis";
            this.button_testThis.Size = new System.Drawing.Size(75, 23);
            this.button_testThis.TabIndex = 7;
            this.button_testThis.Text = "Test Text";
            this.button_testThis.UseVisualStyleBackColor = false;
            this.button_testThis.Click += new System.EventHandler(this.button_testThis_Click);
            // 
            // button_import_kfText
            // 
            this.button_import_kfText.Location = new System.Drawing.Point(560, 288);
            this.button_import_kfText.Name = "button_import_kfText";
            this.button_import_kfText.Size = new System.Drawing.Size(75, 23);
            this.button_import_kfText.TabIndex = 6;
            this.button_import_kfText.Text = "Import Text";
            this.button_import_kfText.UseVisualStyleBackColor = true;
            this.button_import_kfText.Click += new System.EventHandler(this.button_import_kfText_Click);
            // 
            // button_export_kfText
            // 
            this.button_export_kfText.Location = new System.Drawing.Point(560, 336);
            this.button_export_kfText.Name = "button_export_kfText";
            this.button_export_kfText.Size = new System.Drawing.Size(75, 23);
            this.button_export_kfText.TabIndex = 5;
            this.button_export_kfText.Text = "Export Text";
            this.button_export_kfText.UseVisualStyleBackColor = true;
            this.button_export_kfText.Click += new System.EventHandler(this.button_export_kfText_Click);
            // 
            // button_kfTextApply
            // 
            this.button_kfTextApply.Location = new System.Drawing.Point(560, 233);
            this.button_kfTextApply.Name = "button_kfTextApply";
            this.button_kfTextApply.Size = new System.Drawing.Size(75, 23);
            this.button_kfTextApply.TabIndex = 4;
            this.button_kfTextApply.Text = "Apply";
            this.button_kfTextApply.UseVisualStyleBackColor = true;
            this.button_kfTextApply.Click += new System.EventHandler(this.button_kfTextApply_Click);
            // 
            // richTextBox_preview
            // 
            this.richTextBox_preview.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_preview.Location = new System.Drawing.Point(398, 21);
            this.richTextBox_preview.Name = "richTextBox_preview";
            this.richTextBox_preview.Size = new System.Drawing.Size(386, 184);
            this.richTextBox_preview.TabIndex = 3;
            this.richTextBox_preview.Text = "";
            // 
            // listBox_textPointers
            // 
            this.listBox_textPointers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_textPointers.FormattingEnabled = true;
            this.listBox_textPointers.ItemHeight = 24;
            this.listBox_textPointers.Location = new System.Drawing.Point(211, 21);
            this.listBox_textPointers.Name = "listBox_textPointers";
            this.listBox_textPointers.Size = new System.Drawing.Size(181, 388);
            this.listBox_textPointers.TabIndex = 1;
            this.listBox_textPointers.SelectedIndexChanged += new System.EventHandler(this.listBox_textPointers_SelectedIndexChanged);
            // 
            // listBox_tablePointers
            // 
            this.listBox_tablePointers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_tablePointers.FormattingEnabled = true;
            this.listBox_tablePointers.ItemHeight = 24;
            this.listBox_tablePointers.Location = new System.Drawing.Point(8, 21);
            this.listBox_tablePointers.Name = "listBox_tablePointers";
            this.listBox_tablePointers.Size = new System.Drawing.Size(181, 388);
            this.listBox_tablePointers.TabIndex = 0;
            this.listBox_tablePointers.SelectedIndexChanged += new System.EventHandler(this.listBox_tablePointers_SelectedIndexChanged);
            // 
            // tabPage_stage
            // 
            this.tabPage_stage.Controls.Add(this.button_exportall);
            this.tabPage_stage.Controls.Add(this.button_importall);
            this.tabPage_stage.Controls.Add(this.button_master);
            this.tabPage_stage.Controls.Add(this.button_apply);
            this.tabPage_stage.Controls.Add(this.textBox_stage);
            this.tabPage_stage.Controls.Add(this.label2);
            this.tabPage_stage.Controls.Add(this.listBox_stageCurrent);
            this.tabPage_stage.Controls.Add(this.label1);
            this.tabPage_stage.Controls.Add(this.listBox_stageBase);
            this.tabPage_stage.Location = new System.Drawing.Point(4, 22);
            this.tabPage_stage.Name = "tabPage_stage";
            this.tabPage_stage.Size = new System.Drawing.Size(792, 424);
            this.tabPage_stage.TabIndex = 1;
            this.tabPage_stage.Text = "Stage Name";
            this.tabPage_stage.UseVisualStyleBackColor = true;
            // 
            // button_exportall
            // 
            this.button_exportall.Location = new System.Drawing.Point(359, 377);
            this.button_exportall.Name = "button_exportall";
            this.button_exportall.Size = new System.Drawing.Size(75, 23);
            this.button_exportall.TabIndex = 8;
            this.button_exportall.Text = "Export all";
            this.button_exportall.UseVisualStyleBackColor = true;
            this.button_exportall.Click += new System.EventHandler(this.button_exportall_Click);
            // 
            // button_importall
            // 
            this.button_importall.Location = new System.Drawing.Point(359, 333);
            this.button_importall.Name = "button_importall";
            this.button_importall.Size = new System.Drawing.Size(75, 23);
            this.button_importall.TabIndex = 7;
            this.button_importall.Text = "Import all";
            this.button_importall.UseVisualStyleBackColor = true;
            this.button_importall.Click += new System.EventHandler(this.button_importall_Click);
            // 
            // button_master
            // 
            this.button_master.Location = new System.Drawing.Point(375, 73);
            this.button_master.Name = "button_master";
            this.button_master.Size = new System.Drawing.Size(75, 23);
            this.button_master.TabIndex = 6;
            this.button_master.Text = "button1";
            this.button_master.UseVisualStyleBackColor = true;
            this.button_master.Visible = false;
            this.button_master.Click += new System.EventHandler(this.button_master_Click);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(359, 281);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 5;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // textBox_stage
            // 
            this.textBox_stage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_stage.Location = new System.Drawing.Point(314, 234);
            this.textBox_stage.MaxLength = 30;
            this.textBox_stage.Name = "textBox_stage";
            this.textBox_stage.Size = new System.Drawing.Size(161, 20);
            this.textBox_stage.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(598, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current";
            // 
            // listBox_stageCurrent
            // 
            this.listBox_stageCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_stageCurrent.FormattingEnabled = true;
            this.listBox_stageCurrent.ItemHeight = 24;
            this.listBox_stageCurrent.Location = new System.Drawing.Point(481, 55);
            this.listBox_stageCurrent.Name = "listBox_stageCurrent";
            this.listBox_stageCurrent.Size = new System.Drawing.Size(308, 364);
            this.listBox_stageCurrent.TabIndex = 2;
            this.listBox_stageCurrent.SelectedIndexChanged += new System.EventHandler(this.listBox_stageCurrent_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base";
            // 
            // listBox_stageBase
            // 
            this.listBox_stageBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_stageBase.FormattingEnabled = true;
            this.listBox_stageBase.ItemHeight = 24;
            this.listBox_stageBase.Items.AddRange(new object[] {
            "Jungle Hijinxs",
            "Ropey Rampage",
            "Reptile Rumble",
            "Coral Capers",
            "Barrel Cannon Canyon",
            "Gnawty 1",
            "",
            "Winky\'s Walkway",
            "Mine Cart Carnage",
            "Bouncy Bonanza",
            "Stop & Go Station",
            "Millstone Mayhem",
            "Necky 1",
            "",
            "Vulture Culture",
            "Tree Top Town",
            "Forest Frenzy",
            "Temple Tempest",
            "Orang-utan Gang",
            "Clam City",
            "Queen Bee",
            "",
            "Snow Barrel Blast",
            "Slipslide Ride",
            "Ice Age Alley",
            "Croctopus Chase",
            "Torchlight Trouble",
            "Rope Bridge Rumble",
            "Gnawty 2",
            "",
            "Oil Drum Alley",
            "Trick Track Trek",
            "Elevator Antics",
            "Poison Pond",
            "Mine Cart Madness",
            "Blackout Basement",
            "Boss Dumb Drum",
            "",
            "Tanked Up Trouble",
            "Manic Mincers",
            "Misty Mine",
            "Loopy Lights",
            "Platform Perils",
            "Necky 2",
            "",
            "Gangplank Galleon"});
            this.listBox_stageBase.Location = new System.Drawing.Point(0, 55);
            this.listBox_stageBase.Name = "listBox_stageBase";
            this.listBox_stageBase.Size = new System.Drawing.Size(308, 364);
            this.listBox_stageBase.TabIndex = 0;
            this.listBox_stageBase.SelectedIndexChanged += new System.EventHandler(this.listBox_stageBase_SelectedIndexChanged);
            // 
            // tabPage_credits
            // 
            this.tabPage_credits.Controls.Add(this.button_import_credits);
            this.tabPage_credits.Controls.Add(this.button_export_credits);
            this.tabPage_credits.Controls.Add(this.groupBox1);
            this.tabPage_credits.Controls.Add(this.button_creditsApply);
            this.tabPage_credits.Controls.Add(this.label3);
            this.tabPage_credits.Controls.Add(this.richTextBox_credits);
            this.tabPage_credits.Location = new System.Drawing.Point(4, 22);
            this.tabPage_credits.Name = "tabPage_credits";
            this.tabPage_credits.Size = new System.Drawing.Size(792, 424);
            this.tabPage_credits.TabIndex = 2;
            this.tabPage_credits.Text = "Credits";
            this.tabPage_credits.UseVisualStyleBackColor = true;
            // 
            // button_import_credits
            // 
            this.button_import_credits.Location = new System.Drawing.Point(537, 253);
            this.button_import_credits.Name = "button_import_credits";
            this.button_import_credits.Size = new System.Drawing.Size(75, 23);
            this.button_import_credits.TabIndex = 5;
            this.button_import_credits.Text = "Import All";
            this.button_import_credits.UseVisualStyleBackColor = true;
            this.button_import_credits.Visible = false;
            this.button_import_credits.Click += new System.EventHandler(this.button_import_credits_Click);
            // 
            // button_export_credits
            // 
            this.button_export_credits.Location = new System.Drawing.Point(537, 309);
            this.button_export_credits.Name = "button_export_credits";
            this.button_export_credits.Size = new System.Drawing.Size(75, 23);
            this.button_export_credits.TabIndex = 4;
            this.button_export_credits.Text = "Export All";
            this.button_export_credits.UseVisualStyleBackColor = true;
            this.button_export_credits.Visible = false;
            this.button_export_credits.Click += new System.EventHandler(this.button_export_credits_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_real);
            this.groupBox1.Controls.Add(this.radioButton_fake);
            this.groupBox1.Location = new System.Drawing.Point(487, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credits";
            // 
            // radioButton_real
            // 
            this.radioButton_real.AutoSize = true;
            this.radioButton_real.Checked = true;
            this.radioButton_real.Location = new System.Drawing.Point(128, 45);
            this.radioButton_real.Name = "radioButton_real";
            this.radioButton_real.Size = new System.Drawing.Size(47, 17);
            this.radioButton_real.TabIndex = 1;
            this.radioButton_real.TabStop = true;
            this.radioButton_real.Text = "Real";
            this.radioButton_real.UseVisualStyleBackColor = true;
            this.radioButton_real.CheckedChanged += new System.EventHandler(this.radioButton_real_CheckedChanged);
            // 
            // radioButton_fake
            // 
            this.radioButton_fake.AutoSize = true;
            this.radioButton_fake.Location = new System.Drawing.Point(23, 45);
            this.radioButton_fake.Name = "radioButton_fake";
            this.radioButton_fake.Size = new System.Drawing.Size(49, 17);
            this.radioButton_fake.TabIndex = 0;
            this.radioButton_fake.Text = "Fake";
            this.radioButton_fake.UseVisualStyleBackColor = true;
            this.radioButton_fake.CheckedChanged += new System.EventHandler(this.radioButton_fake_CheckedChanged);
            // 
            // button_creditsApply
            // 
            this.button_creditsApply.Location = new System.Drawing.Point(537, 37);
            this.button_creditsApply.Name = "button_creditsApply";
            this.button_creditsApply.Size = new System.Drawing.Size(75, 23);
            this.button_creditsApply.TabIndex = 2;
            this.button_creditsApply.Text = "Apply";
            this.button_creditsApply.UseVisualStyleBackColor = true;
            this.button_creditsApply.Click += new System.EventHandler(this.button_creditsApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Credits";
            // 
            // richTextBox_credits
            // 
            this.richTextBox_credits.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_credits.Location = new System.Drawing.Point(41, 37);
            this.richTextBox_credits.Name = "richTextBox_credits";
            this.richTextBox_credits.Size = new System.Drawing.Size(335, 295);
            this.richTextBox_credits.TabIndex = 0;
            this.richTextBox_credits.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 65);
            this.label4.TabIndex = 9;
            this.label4.Text = "Clicking test sets\r\nCranky in-game\r\nto always display\r\nthat text for testing\r\npur" +
    "poses";
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl_text);
            this.Name = "TextEditor";
            this.Text = "TextEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TextEditor_FormClosing);
            this.tabControl_text.ResumeLayout(false);
            this.tabPage_kf.ResumeLayout(false);
            this.tabPage_kf.PerformLayout();
            this.tabPage_stage.ResumeLayout(false);
            this.tabPage_stage.PerformLayout();
            this.tabPage_credits.ResumeLayout(false);
            this.tabPage_credits.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_text;
        private System.Windows.Forms.TabPage tabPage_kf;
        private System.Windows.Forms.ListBox listBox_textPointers;
        private System.Windows.Forms.ListBox listBox_tablePointers;
        private System.Windows.Forms.TabPage tabPage_stage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_stageBase;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.TextBox textBox_stage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_stageCurrent;
        private System.Windows.Forms.Button button_master;
        private System.Windows.Forms.Button button_exportall;
        private System.Windows.Forms.Button button_importall;
        private System.Windows.Forms.TabPage tabPage_credits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox_credits;
        private System.Windows.Forms.Button button_creditsApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_real;
        private System.Windows.Forms.RadioButton radioButton_fake;
        private System.Windows.Forms.RichTextBox richTextBox_preview;
        private System.Windows.Forms.Button button_kfTextApply;
        private System.Windows.Forms.Button button_export_kfText;
        private System.Windows.Forms.Button button_import_kfText;
        private System.Windows.Forms.Button button_import_credits;
        private System.Windows.Forms.Button button_export_credits;
        private System.Windows.Forms.Button button_resetTest;
        private System.Windows.Forms.Button button_testThis;
        private System.Windows.Forms.Label label4;
    }
}