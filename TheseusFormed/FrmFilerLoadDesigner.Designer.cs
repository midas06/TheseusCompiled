namespace TheseusFormed
{
    partial class FrmFilerLoadDesigner
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
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.lblUserMaps = new System.Windows.Forms.Label();
            this.lbxUserCreated = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(306, 170);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(120, 41);
            this.btnLoadMap.TabIndex = 8;
            this.btnLoadMap.Text = "Load Map";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // lblUserMaps
            // 
            this.lblUserMaps.AutoSize = true;
            this.lblUserMaps.Location = new System.Drawing.Point(141, -33);
            this.lblUserMaps.Name = "lblUserMaps";
            this.lblUserMaps.Size = new System.Drawing.Size(98, 13);
            this.lblUserMaps.TabIndex = 7;
            this.lblUserMaps.Text = "User Created Maps";
            // 
            // lbxUserCreated
            // 
            this.lbxUserCreated.FormattingEnabled = true;
            this.lbxUserCreated.Location = new System.Drawing.Point(37, 90);
            this.lbxUserCreated.Name = "lbxUserCreated";
            this.lbxUserCreated.Size = new System.Drawing.Size(227, 199);
            this.lbxUserCreated.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "User Created Maps";
            // 
            // FrmFilerLoadDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 409);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadMap);
            this.Controls.Add(this.lblUserMaps);
            this.Controls.Add(this.lbxUserCreated);
            this.Name = "FrmFilerLoadDesigner";
            this.Text = "FrmFilerLoadDesigner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.Label lblUserMaps;
        private System.Windows.Forms.ListBox lbxUserCreated;
        private System.Windows.Forms.Label label1;
    }
}