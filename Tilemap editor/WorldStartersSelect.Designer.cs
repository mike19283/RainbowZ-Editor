namespace Tilemap_editor
{
    partial class WorldStartersSelect
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
            this.listBox_levelList = new System.Windows.Forms.ListBox();
            this.listBox_world = new System.Windows.Forms.ListBox();
            this.button_apply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_levelList
            // 
            this.listBox_levelList.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox_levelList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_levelList.FormattingEnabled = true;
            this.listBox_levelList.ItemHeight = 24;
            this.listBox_levelList.Location = new System.Drawing.Point(253, 0);
            this.listBox_levelList.Name = "listBox_levelList";
            this.listBox_levelList.Size = new System.Drawing.Size(401, 289);
            this.listBox_levelList.TabIndex = 0;
            // 
            // listBox_world
            // 
            this.listBox_world.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_world.FormattingEnabled = true;
            this.listBox_world.ItemHeight = 24;
            this.listBox_world.Items.AddRange(new object[] {
            "World 1"});
            this.listBox_world.Location = new System.Drawing.Point(1, 0);
            this.listBox_world.Name = "listBox_world";
            this.listBox_world.Size = new System.Drawing.Size(120, 292);
            this.listBox_world.TabIndex = 1;
            this.listBox_world.SelectedIndexChanged += new System.EventHandler(this.listBox_world_SelectedIndexChanged);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(148, 109);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 3;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // WorldStartersSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 289);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.listBox_world);
            this.Controls.Add(this.listBox_levelList);
            this.Name = "WorldStartersSelect";
            this.Text = "WorldStartersSelect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_levelList;
        private System.Windows.Forms.ListBox listBox_world;
        private System.Windows.Forms.Button button_apply;
    }
}