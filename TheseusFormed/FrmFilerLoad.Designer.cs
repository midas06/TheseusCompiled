namespace TheseusFormed
{
    partial class FrmFilerLoad
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
            this.lbxOriginalMaps = new System.Windows.Forms.ListBox();
            this.lbxUserCreated = new System.Windows.Forms.ListBox();
            this.lblOGMaps = new System.Windows.Forms.Label();
            this.lblUserMaps = new System.Windows.Forms.Label();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxOriginalMaps
            // 
            this.lbxOriginalMaps.FormattingEnabled = true;
            this.lbxOriginalMaps.Location = new System.Drawing.Point(65, 91);
            this.lbxOriginalMaps.Name = "lbxOriginalMaps";
            this.lbxOriginalMaps.Size = new System.Drawing.Size(120, 199);
            this.lbxOriginalMaps.TabIndex = 0;
            this.lbxOriginalMaps.Click += new System.EventHandler(this.lbxOriginalMaps_Click);
            // 
            // lbxUserCreated
            // 
            this.lbxUserCreated.FormattingEnabled = true;
            this.lbxUserCreated.Location = new System.Drawing.Point(266, 91);
            this.lbxUserCreated.Name = "lbxUserCreated";
            this.lbxUserCreated.Size = new System.Drawing.Size(120, 199);
            this.lbxUserCreated.TabIndex = 1;
            this.lbxUserCreated.Click += new System.EventHandler(this.lbxUserCreated_Click);
            // 
            // lblOGMaps
            // 
            this.lblOGMaps.AutoSize = true;
            this.lblOGMaps.Location = new System.Drawing.Point(84, 32);
            this.lblOGMaps.Name = "lblOGMaps";
            this.lblOGMaps.Size = new System.Drawing.Size(71, 13);
            this.lblOGMaps.TabIndex = 2;
            this.lblOGMaps.Text = "Original Maps";
            // 
            // lblUserMaps
            // 
            this.lblUserMaps.AutoSize = true;
            this.lblUserMaps.Location = new System.Drawing.Point(273, 32);
            this.lblUserMaps.Name = "lblUserMaps";
            this.lblUserMaps.Size = new System.Drawing.Size(98, 13);
            this.lblUserMaps.TabIndex = 3;
            this.lblUserMaps.Text = "User Created Maps";
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(162, 320);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(120, 41);
            this.btnLoadMap.TabIndex = 5;
            this.btnLoadMap.Text = "Load Map";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadUser_Click);
            // 
            // FrmFilerLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.btnLoadMap);
            this.Controls.Add(this.lblUserMaps);
            this.Controls.Add(this.lblOGMaps);
            this.Controls.Add(this.lbxUserCreated);
            this.Controls.Add(this.lbxOriginalMaps);
            this.Name = "FrmFilerLoad";
            this.Text = "FrmFilerLoad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxOriginalMaps;
        private System.Windows.Forms.ListBox lbxUserCreated;
        private System.Windows.Forms.Label lblOGMaps;
        private System.Windows.Forms.Label lblUserMaps;
        private System.Windows.Forms.Button btnLoadMap;
    }
}